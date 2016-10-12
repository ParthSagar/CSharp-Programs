using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Data
{
    public static class MyObj
    {
        private static IMongoClient _client;
        private static IMongoDatabase _db;

        private static void Connection()
        {
            _client = new MongoClient("mongodb://parth:test1@ds025469.mlab.com:25469/tuplitest");
            _db = _client.GetDatabase("tuplitest");
        }

        public static ItemMasterList GetData()
        {
            Connection();
            var collection = _db.GetCollection<ItemMaster>("ItemMaster");
            var filter = Builders<ItemMaster>.Filter.Gte("date", new DateTime(2016, 09, 05, 0, 0, 0, DateTimeKind.Utc));
            //var sort = Builders<BsonDocument>.Sort.Descending("date");
            var select = collection.Find(filter).ToList();
            ItemMasterList il = new ItemMasterList();
            il.Add(select);
            //select.Clear();
            return il;
        }

        public static bool InsertData(string item, int qty, DateTime date, string phone)
        {
            try
            {
             
               
                var collection = _db.GetCollection<ItemMaster>("ItemMaster");
                var builder = Builders<ItemMaster>.Sort;
                var sort = builder.Descending("_id");
                var cursor = collection.Find<ItemMaster>(new BsonDocument()).Sort(sort);
                var max = cursor.FirstOrDefault();

                if (max != null)
                {
                    max.Id += 1;
                    ItemMaster t = new ItemMaster() { Id = max.Id, item = item, qty = qty, date=date,phone=phone };
            
                    collection.InsertOne(t);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool  DeleteData(int id)
        {
            try
            {
                var collection = _db.GetCollection<ItemMaster>("ItemMaster");
                var filter = Builders<ItemMaster>.Filter.Eq("_id", id);
                collection.DeleteOne(filter);
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
    }
}
