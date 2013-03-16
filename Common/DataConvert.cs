using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Exception;
using MongoDB.Bson;

namespace Common
{
    /// <summary>
    /// 数据格式化类
    /// </summary>
    public static class DataConvert
    {
        public static ObjectId ToObjectId(string value) {
            try {
                return new ObjectId(value);
            }
            catch {
                throw new InvalidIdException();
            }
        }
    }
}
