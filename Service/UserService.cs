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

        #region Update

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
            user.Money = user.Money - tag.NeedMoney;
            if (user.Money < 0) {
                //现金少于0的异常
            }
            user.Tags.Add(tag.ID.ToString());
            userConn.Save(user);
        }

        public void UpdateUserMoney(ObjectId id, int money) {
            var user = this.GetUserByID(id).First();
            user.Money = user.Money + money;
            userConn.Save(user);
        }

        #endregion

        public IQueryable<User> GetUserList(User user = null) {
            var result = userConn.AsQueryable<User>();
            if (user != null) {
                if (user.UserName != null) {
                    result.Where(o => o.UserName == user.UserName);
                }
                if (user.Password != null) {
                    result.Where(o => o.Password == user.Password);
                }
                if (user.Gender != Gender.Undefined) {
                    result.Where(o => o.Gender == user.Gender);
                }
                if (user.UserStatus != UserStatus.Active) {
                    result.Where(o => o.UserStatus == user.UserStatus);
                }
            }
            return result;
        }

        public IQueryable<User> GetUserByID(ObjectId id) {
            var user = userConn.AsQueryable<User>()
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
    }
}
