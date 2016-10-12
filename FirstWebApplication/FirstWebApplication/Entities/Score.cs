using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace FirstWebApplication.Entities
{
    public class Score
    {
        public ObjectId GameId { get; set; }
        public string GameName { get; set; }
        public int ScoreValue{ get; set; }
        public DateTime ScoreDateTime { get; set; }
    }
}