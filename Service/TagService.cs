using System.Linq;
using Common.Exception;
using Connection;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Common.Msg;

namespace Service
{
    public class TagService
    {
        private readonly MongoCollection tagConn = ConnectionFactory.GetTagConn();

        public void AddTag(Tag tag) {
            tagConn.Insert(tag);
        }

        public IQueryable<Tag> GetTagList() {
            return tagConn.AsQueryable<Tag>();
        }

        public IQueryable<Tag> GetTagByID(ObjectId id) {
            var tag = this.GetTagList()
                .Where(o => o.ID == id);
            if (tag.Count() == 0) {
                throw new DataNotFoundException(TagErrorMsg.CannotFindTagByID);
            }
            else {
                return tag;
            }
        }
    }
}
