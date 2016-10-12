using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstWebApplication.Entities
{
    public class MongoEnitity : IMongoEnitity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}