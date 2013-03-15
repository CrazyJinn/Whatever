using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Service
{
    public class TagService
    {
        private readonly MongoCollection tagConn = ConnectionFactory.GetTagConn();

        public void AddTag(Tag tag) {
            try {
                tagConn.Insert(tag);
            }
            catch {

            }
        }

        public IQueryable<Tag> GetTagList() {
            return tagConn.AsQueryable<Tag>();
        }
    }
}
