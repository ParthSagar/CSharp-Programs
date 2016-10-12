using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstWebApplication.Entities
{
    [BsonIgnoreExtraElements]
    public class Player : MongoEnitity
    {
        public Player()
        { Scores=new List<Score>();}
        public string Name { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Gender Gender { get; set; }
        public List<Score> Scores { get; set; }
    }
}