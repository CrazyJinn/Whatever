using MongoDB.Driver;

namespace Connection
{
    public class Connection
    {
        public static MongoCollection GetCollection(string connString, string collectionName) {
            MongoServer server = MongoServer.Create(connString);
            string DBname = "Whatever_" + collectionName;       //使用"Whatever_+ collectionName作为DBname
            MongoDatabase db = server.GetDatabase(DBname);
            return db.GetCollection(collectionName);
        }
    }
}
