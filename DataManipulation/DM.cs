using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataManipulation
{
    public class MyMongoCollection : MongoCollection
    {
        public override SafeModeResult Insert<TNominalType>(TNominalType document) {
            try {
                return base.Insert<TNominalType>(document);
            }
            catch (MongoConnectionException) {
                throw new Exception();
            }
        }
    }
}
