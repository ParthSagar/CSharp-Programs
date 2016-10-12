using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDB
{
    class Program2
    {
        private static IMongoClient Client;
        private static IMongoDatabase DB;
       
        public static void insertData()
        {
            try
            {
                List<ItemMaster> itemCollection = new List<ItemMaster>
                {
                    new ItemMaster {Id = 13, item = "Cricket", qty = 12, date=DateTime.Now},
                    new ItemMaster {Id = 14, item = "Football", qty = 16, date=DateTime.Now},
                    new ItemMaster {Id = 15,item = "Kabaddi", qty = 11, date=DateTime.Now},
                
                };

                DB.CreateCollection("ItemMaster");

                var collection = DB.GetCollection<ItemMaster>("ItemMaster");


                collection.InsertMany(itemCollection);
            }
            catch (Exception)
            {
                Console.WriteLine("Already Inserted");
                throw;
            }
        }

        public static void Findrecord()
        {
            try
            {
                var collection = DB.GetCollection<ItemMaster>("ItemMaster");
                var filter = Builders<ItemMaster>.Filter.Gte("date", new DateTime(2016,09,05,0,0,0,DateTimeKind.Utc));
                var sort = Builders<ItemMaster>.Sort.Descending("date");
            var select = collection.Find(filter).Sort(sort).ToList();
            foreach (var v in select)
            {
                Console.WriteLine(v);
            }
               
            }
            catch (Exception)
            {
                
               Console.WriteLine("Not Applicable");
            }


        }
        public static void c()
        {
          Client = new MongoClient("mongodb://parth:test1@ds025469.mlab.com:25469/tuplitest");
            DB = Client.GetDatabase("tuplitest");
            //insertData();
            Findrecord();

        }
    }

    class ItemMaster
    {
        public int Id { get; set; }

        public String item { get; set; }
        public int qty { get; set; }
        public DateTime date { get; set; }
        public override string ToString()
        {
            return string.Format("ID={0} item={1} qty={2} date={3}", Id, item, qty, date);

        }

    }
}
