using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace JSon_App
{
    public class MyDate
    {
        public int year;
        public int month;
        public int day;
    }

    public class Lad
    {
        public string firstName;
        public string lastName;
        public MyDate dateofBirth;
    }

    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj=new Lad()
            {
                firstName = "Parth",
                lastName = "Sagar",
                dateofBirth = new MyDate()
                {
                    year = 1992,
                    month = 8,
                    day=30
                }
            };
            var json = new JavaScriptSerializer().Serialize(obj);
            Console.WriteLine(json);
            List<User>  userList=new List<User>();
            User user=new User();
            user.Age = 20;
            user.Name = "Parth";
            user.City = "Surat";
            user.Address = "Ramji ni Pole";
            userList.Add(user);
            User user1=new User();
            user1.Age = 50;
            user1.Name = "Manoj";
            user1.City = "Surat";
            user1.Address = "Nanavat";
            userList.Add(user1);
            json = @"{
'@Id': 1,
'Email': 'john@google.com',
'Active': true,
'CreatedDate': '2013-11-12T00:00:00Z',
'Roles': [
'User',
'Admin'
],
'Team': {
'@Id': 2,
'Name': 'Software Developers',
'Description': 'Creators of fine software products and services.'
}
}";
            string jsonString = JsonConvert.SerializeObject(userList);
            Console.WriteLine(jsonString);
            XNode node = JsonConvert.DeserializeXNode(json, "Root");
            Console.WriteLine(node.ToString());
        }

    }
}
