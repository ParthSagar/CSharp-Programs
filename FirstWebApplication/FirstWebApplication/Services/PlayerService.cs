using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using FirstWebApplication.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace FirstWebApplication.Services
{
    public class PlayerService:EntityService<Player>
    {
        public void AddScore(string playerId, Score score)
        {
            var playerObjectId=new ObjectId(playerId);
            var updateResult =
                this.MongoConnectionHandler.MongoCollection.Update(Query<Player>.EQ(p => p.Id, playerObjectId), Update<Player>.Push(p=>p.Scores,score),new MongoUpdateOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });
            if(updateResult.DocumentsAffected==0)
            { throw new NullReferenceException("Somthing Went Wrong");}
        }

        public IEnumerable<Player> GetPlayersDetailes(int limit, int skip)
        {
            var PlayerCursor =
                this.MongoConnectionHandler.MongoCollection.FindAllAs<Player>()
                    .SetSortOrder(SortBy<Player>.Ascending(p => p.Name))
                    .SetLimit(limit)
                    .SetSkip(skip)
                    .SetFields(Fields<Player>.Include(p => p.Id, p => p.Name));
            return PlayerCursor;
        }
        public override void Update(Player entity)
        {
            var updateResult = this.MongoConnectionHandler.MongoCollection.Update(
                    Query<Player>.EQ(p=>p.Id,entity.Id),Update<Player>.Set(p=>p.Name,entity.Name).Set(p=>p.Gender,entity.Gender),new MongoUpdateOptions
                    {
                        WriteConcern = WriteConcern.Acknowledged
                        
                    });
            if (updateResult.DocumentsAffected == 0)
            { throw new NullReferenceException("Somthing Went Wrong"); }
        }
    }
}