using System;
using System.Linq;
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

        public User GetUserByID(ObjectId id)
        {
            try
            {
                return userConn.FindOneByIdAs<User>(id);
            }
            catch
            {
                throw new Exception();
            }
        }

        public IQueryable<User> GetUserList()
        {
            return userConn.AsQueryable<User>();
        }

        public IQueryable<User> GetUserListByName(string username)
        {
            return this.GetUserList()
                .Where(o => o.UserName == username);
        }

        public IQueryable<User> GetUserListByNameAndPsd(string username,string password)
        {
            return this.GetUserListByName(username)
                .Where(o => o.Password == password);
        }


    }
}
