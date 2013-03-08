using Model;
using MongoDB.Driver;

namespace Connection
{
    public class ConnectionFactory
    {
        public static MongoCollection GetUserConn()
        {
            string connString = "mongodb://localhost";
            string collectionName = "User";
            return Connection.GetCollection(connString, collectionName);
        }

        public static MongoCollection GetTagConn()
        {
            string connString = "mongodb://localhost";
            string collectionName = "Tag";
            return Connection.GetCollection(connString, collectionName);
        }

        //public static MongoCollection GetImgConn()
        //{
        //    string connString = "mongodb://localhost";
        //    string collectionName = "TestImg";
        //    return Connection.GetCollection(connString, collectionName);
        //}
    }
}
