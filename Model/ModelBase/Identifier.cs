using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Model
{
    public class ModelBase
    {
        [BsonId]
        public ObjectId ID { get; set; }

        /// <summary>
        /// 此条记录的生成时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 这条记录的最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
    }
}
