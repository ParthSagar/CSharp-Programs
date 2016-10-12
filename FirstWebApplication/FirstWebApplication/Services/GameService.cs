using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstWebApplication.Entities;
using MongoDB.Driver.Builders;

namespace FirstWebApplication.Services
{
    public class GameService:EntityService<Game>
    {
        public IEnumerable<Game> GetGamesDetails(int limit, int skip)
        {
            var gameCursor =
                this.MongoConnectionHandler.MongoCollection.FindAllAs<Game>()
                    .SetSortOrder(SortBy<Game>.Descending(g => g.RealeseDate))
                    .SetLimit(limit)
                    .SetSkip(skip)
                    .SetFields(Fields<Game>.Include(g => g.Id, g => g.Name, g => g.RealeseDate));
            return gameCursor;
        }
        public override void Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}