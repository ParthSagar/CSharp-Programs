using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SerializingJson
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Product product =new Product();
            product.Name = "Apple";
            product.Price = (float) 3.99;
            product.ExpiryDate=new DateTime(2008,12,28);
            product.Sizes=new string[]{"Small", "Medium", "Large"};
            Console.WriteLine("********Object Project**************\n");
            Console.WriteLine(product);
            string output = JsonConvert.SerializeObject(product);
            Console.WriteLine("\n*********Serialized Converter Ouput********\n");
            Console.WriteLine(output);

            Console.WriteLine();
            Product p=new Product();
            
            p.ExpiryDate = new DateTime(2008, 12, 28);
           
            JsonSerializer serializer=new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling=NullValueHandling.Ignore;
            using (StreamWriter sw=new StreamWriter(@"D:\json.txt"))
            using (JsonWriter writer=new JsonTextWriter(sw))
            {
                serializer.Serialize(writer,p);
            }

            Console.WriteLine("\n***********Deserialized Convert Ouput********\n");
            Product deserializeProduct = JsonConvert.DeserializeObject<Product>(output);
            Console.WriteLine(deserializeProduct);

            Console.WriteLine("\n*********Deserialized Serializer Output*******");
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using(StreamReader sr=new StreamReader(@"D:\json.txt"))
            using (JsonReader reader=new JsonTextReader(sr))
            {
                Product pr = serializer.Deserialize<Product>(reader);
                Console.WriteLine(pr.ExpiryDate);
            }*/
            string a = "hello";
            string b = "h";
            b += "ello";
            Console.WriteLine(a==b);
            Console.WriteLine((object)a==(object)b);

        }
    }

    class Product
    {
        private string[] _roles;
        public string Name
        {
            get; set; }
        public DateTime ExpiryDate { get; set; }
        public float Price { get; set; }

        public string[] Sizes { get; set; }

        public override string ToString()
        {
            string s= "Name:"+Name+"\nExpiry Date:"+ExpiryDate+" \nPrice:"+Price+"\nSizes:";
            foreach (var st in Sizes)
            {
                s += st + ",";
            }
            return s;
        }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
