using System;
using System.Linq;
using Common.Exception;
using Common.Msg;
using Connection;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Service
{
    public class UserService
    {
        private readonly MongoCollection userConn = ConnectionFactory.GetUserConn();

        public void AddUser(User user)
        {
            //数据库UserName存小写，回传前要转换
            try
            {
                userConn.Insert(user);
            }
            catch
            {

            }
        }

        public IQueryable<User> GetUserList()
        {
            return userConn.AsQueryable<User>();
        }

        public IQueryable<User> GetUserByID(ObjectId id)
        {
            var user = this.GetUserList()
               .Where(o => o.ID == id);
            if (user.Count() == 0)
            {
                throw new DataNotFoundException("");
            }
            else
                return user;
        }

        public IQueryable<User> GetUserListByName(string username)
        {
            return this.GetUserList()
                .Where(o => o.UserName == username);
        }

        /// <summary>
        /// 根据Username与Psd来查找User
        /// </summary>
        /// <error>如果找到重复的Username，则丢错</error>
        /// <returns></returns>
        public IQueryable<User> GetUserListByNameAndPsd(string username, string password)
        {
            var user = this.GetUserListByName(username);
            if (user.Count() > 1)
            {
                throw new RepeatedUsernameException(String.Format(ErrorMsg.RepeatedUsername, username));
            }
            else
                return user.Where(o => o.Password == password);
        }
    }
}
