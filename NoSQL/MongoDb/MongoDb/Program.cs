using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
           // List<Car> carCollection = new List<Car>
           // {
           //     new Car {Make = "TOYOTA", Model = "CAMRY", VehicleId = "VT1", Year = 2016},
           //     new Car {Make = "TOYOTA", Model = "COROLA", VehicleId = "VT2", Year = 2016},
           //     new Car {Make = "TOYOTA", Model = "AVELON", VehicleId = "VT3", Year = 2016},
           //     new Car {Make = "HONDA", Model = "ACCORD", VehicleId = "VH1", Year = 2016},
           //     new Car {Make = "HONDA", Model = "CIVIC", VehicleId = "VH2", Year = 2016},
           //     new Car {Make = "HONDA", Model = "CROSSTOUR", VehicleId = "VH3", Year = 2016}
           //};

           // SampleDb.MyDb.CreateCollection("Cars");

            var collection = SampleDb.MyDb.GetCollection<Car>("Cars");

            //collection.InsertMany(carCollection);

            var selectedCollection = collection.AsQueryable().ToList();
            foreach (var car in selectedCollection)
            {
                Console.WriteLine(car);
            }
        }
    }
}
