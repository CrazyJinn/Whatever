using System;
using System.Linq;
using Common.Exception;
using Common.Msg;
using Connection;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Service
{
    public class UserService
    {
        private readonly MongoCollection userConn = ConnectionFactory.GetUserConn();

        public void AddUser(User user) {
            //数据库UserName存小写，回传前要转换
            userConn.Insert(user);
        }

        public void SaveUser(User user) {
            userConn.Save(user);
        }

        public void UpdateUserPing(ObjectId id, string ping) {
            var query = Query.EQ("_id", id);
            var update = Update.Set("Ping", ping);
            userConn.Update(query, update);
        }

        public void UpdateUserTag(ObjectId id, ObjectId tagId) {
            var user = this.GetUserByID(id).First();
            var tag = new TagService().GetTagByID(tagId).First();
            int nowMoney = user.Money - tag.NeedMoney;
            if (nowMoney < 0) {
                //现金少于0的异常
            }
            var query = Query<User>.EQ(o => o.ID, id);
            var update = Update.Set("Money", nowMoney).Push("Tags", tag.ID.ToString());
            userConn.Update(query, update);
        }

        public void UpdateUserMoney(ObjectId id, int money) {
            var user = this.GetUserByID(id).First();
            int nowMoney = user.Money + money;
            if (nowMoney < 0) {
                //现金少于0的异常
            }
            var query = Query<User>.EQ(o => o.ID, id);
            var update = Update<User>.Set(o => o.Money, nowMoney);
            userConn.Update(query, update);
        }

        public IQueryable<User> GetUserList() {
            return userConn.AsQueryable<User>();
        }

        public IQueryable<User> GetUserByID(ObjectId id) {
            var user = this.GetUserList()
               .Where(o => o.ID == id);
            if (user.Count() == 0) {
                throw new DataNotFoundException(UserErrorMsg.CannotFindUserByID);
            }
            else {
                return user;
            }
        }

        public IQueryable<User> GetUserByPing(string ping) {
            var user = this.GetUserList()
               .Where(o => o.Ping == ping);
            if (user.Count() == 0) {
                throw new DataNotFoundException(UserErrorMsg.CannotFindUserByPing);
            }
            else {
                return user;
            }
        }

        public IQueryable<User> GetUserListByName(string username) {
            var user = this.GetUserList()
                .Where(o => o.UserName == username);
            if (user.Count() > 1) {
                throw new RepeatedUsernameException(String.Format(UserErrorMsg.RepeatedUsername, username));
            }
            else {
                return user;
            }
        }

        /// <summary>
        /// 根据Username与Psd来查找User
        /// </summary>
        /// <error>如果找到重复的Username，则丢错</error>
        /// <returns></returns>
        public IQueryable<User> GetUserListByNameAndPsd(string username, string password) {
            var user = this.GetUserListByName(username)
                .Where(o => o.Password == password);
            if (user.Count() == 0) {
                throw new DataNotFoundException(UserErrorMsg.CannotFindUserByNameAndPsd);
            }
            else {
                return user;
            }
        }
    }
}
