using System;
using MongoDB.Bson;

namespace MongoDb
{
    [Serializable]
    public class Car
    {
        public ObjectId Id { get; set; } // requried by mongo
        public string VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
        }

        public override string ToString()
        {
            return string.Format("VIN={0} Make={1} Model={2} Year={3}", VehicleId, Make, Model, Year);
        }
    }
}
