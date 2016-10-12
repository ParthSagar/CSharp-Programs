using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstWebApplication.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace FirstWebApplication.Services
{
    public abstract class EntityService<T>:IEntityService<T> where T:IMongoEnitity
    {
        protected MongoConnectionHandler<T> MongoConnectionHandler;
        public virtual void Create(T entity)
        {
            
            var result = this.MongoConnectionHandler.MongoCollection.Save(entity,
                new MongoInsertOptions {WriteConcern = WriteConcern.Acknowledged});
            
        }

        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionHandler.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id, 
                new ObjectId(id)), 
                RemoveFlags.None, 
                WriteConcern.Acknowledged); 

        }

        protected EntityService()
        {
            MongoConnectionHandler=new MongoConnectionHandler<T>();
        }
        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public abstract void Update(T entity);
    }
}