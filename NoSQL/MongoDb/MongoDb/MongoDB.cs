using System;
using MongoDB.Driver;

namespace MongoDb
{
    public class SampleDb
    {
        public static readonly IMongoDatabase MyDb;
        private static string MongoDbName = "tuplitest";

        static SampleDb()
        {
            IMongoClient myCLient = new MongoClient(String.Format("mongodb://parth:test1@ds025469.mlab.com:25469/{0}", MongoDbName));
            MyDb = myCLient.GetDatabase(MongoDbName);
        }
    }
}