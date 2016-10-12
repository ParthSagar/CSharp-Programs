    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB
{
    class Program
    {
        private static IMongoClient _myClient;
        private static IMongoDatabase _database;
        public static string DataBasePath
        {
            get { return "mongodb://parth:test1@ds025469.mlab.com:25469/tuplitest"; }
        }

        public static string DataBaseName
        {
            get { return "tuplitest"; }
        }


        public static void LoadSettings()
        {
            _myClient = new MongoClient(DataBasePath);
            _database = _myClient.GetDatabase("tuplitest"); //name of the database here
        }
        private static void InsertIntoDatabase(int id,string item,int qty)
        {
           

            try
            {
                /*List<Test> carCollection = new List<Test>
                {
                    new Test {Id = 13, item = "Cricket", qty = 12},
                    new Test {Id = 14, item = "Football", qty = 16},
                    new Test {Id = 15,item = "Kabaddi", qty = 11},
                
                };

                //_database.CreateCollection("test");

                var collection = _database.GetCollection<Test>("test");


                collection.InsertMany(carCollection);
                Console.WriteLine(carCollection.ToString());*/
                var collection = _database.GetCollection<Test>("test");
                Test t = new Test {Id = id, item = item, qty = qty};
                collection.InsertOne(t);
                Console.WriteLine(t);
            }
            catch (Exception)
            {
                Console.WriteLine("Already inserted");
                
            }
            // here is your logic for reading data from DB.

        }

        

        static void  ListData()
        {
            
            var collection = _database.GetCollection<Test>("test");
            var selectedCollection = collection.AsQueryable().ToList();
            foreach (var v in selectedCollection)
            {
                Console.WriteLine(v);
            }

        }

        static void ListDataNumber(int id)
        {
            var collection = _database.GetCollection<Test>("test");
            var filter = Builders<Test>.Filter.Eq("_id", id);
            var select = collection.Find(filter).ToList().Single();
            Console.WriteLine(select);
            
        }

        static  void  UpdateData(int id,string column,string val)
        {
            UpdateDefinition<Test> update;
            try
            {
                var collection = _database.GetCollection<Test>("test");
                var filter = Builders<Test>.Filter.Eq("_id", id);
                if(column=="item")
                {  update = Builders<Test>.Update.Set(column, val); }
                else 
                {  update = Builders<Test>.Update.Set(column, Convert.ToInt32(val)); }
                
                //var result = await collection.UpdateOneAsync(filter, update);
                collection.UpdateOne(filter, update);
                Console.WriteLine(update.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("can't do it");
                throw;
            }
        }

        static void DeleteData(int id)
        {
            var collection = _database.GetCollection<Test>("test");
            var filter = Builders<Test>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }
        static void Main(string[] args)
        {
            LoadSettings();
           /* string st;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Insert Data");
                Console.WriteLine("2. List Data");
                Console.WriteLine("3. List Data Specifically");
                Console.WriteLine("4. Update Data");
                Console.WriteLine("5. Delete Data");
                Console.Write("What do you want to do? ");
                try
                {
                    int s = Convert.ToInt32(Console.ReadLine());
                    switch (s)
                    {
                        case 1:
                             Console.Write("Please enter the Id number you want to Insert: ");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter the Item you want to Insert:");
                            string item = Console.ReadLine();
                            Console.Write("Please enter the qty you want to Insert:");
                       
                            int qty = Convert.ToInt32(Console.ReadLine());
                            InsertIntoDatabase(id1,item,qty);

                            break;
                        case 2:
                            ListData();
                            break;
                        case 3:
                            Console.Write("Please enter the Id number you want to See: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            ListDataNumber(id);
                            break;
                        case 4:
                            Console.Write("Please enter the Id number you want to change: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Which column you want to change? (item/qty)");
                            string column = Console.ReadLine();
                            Console.Write("Please Enter the new value");
                       
                            var val = Console.ReadLine();
                            UpdateData(id,column,val);
                            break;
                        case 5:
                            Console.Write("Please enter the Id number you want to delete: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            DeleteData(id);
                            break;
                        default:
                            Console.WriteLine("Please select Proper number");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please select Proper number");
                    
                }
                Console.Write("Do you want to continue?(Yes/No) ");
                st = Console.ReadLine();
            } while (st.ToLower()!="no");
*/
           Program2.c();
            

        }
    }
    public class Test
    {
        
        public int  Id { get; set; }

        public String item { get; set; }
        public int qty { get; set; }
        public override string ToString()
        {
            return string.Format("ID={0} item={1} qty={2} ", Id, item, qty);
        }

    }
}
