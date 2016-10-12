using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstWebApplication.Entities
{
    [BsonIgnoreExtraElements]
    public class Game:MongoEnitity
    {
        public Game()
        {
           Categories=new List<string>();
        }
        public string Name { get; set; }
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime RealeseDate { get; set; }
        public List<string> Categories { get; set; }
        public bool Played { get; set; }

    }
}