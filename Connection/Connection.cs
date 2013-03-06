using MongoDB.Driver;

namespace Connection
{
    public class Connection
    {
        public static MongoServer GetServer(string connString)
        {
            //string connectionString = "mongodb://localhost";
            string connectionString = connString;
            return MongoServer.Create(connectionString);
        }

        public static MongoCollection GetCollection(string connString, string collectionName)
        {
            MongoServer server = GetServer(connString);
            string DBname = collectionName;       //使用collectionName作为DBname
            MongoDatabase db = server.GetDatabase(DBname);
            return db.GetCollection(collectionName);
        }
    }
}
