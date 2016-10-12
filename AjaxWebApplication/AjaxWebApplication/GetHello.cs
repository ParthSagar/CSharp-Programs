using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AjaxWebApplication
{
    public class GetHello
    {
        public static string Hello()
        {
            Employee e = new Employee()
            {
                FirstName = "parth",
                LastName = "Sagar",
                Id = 1
            };
            string json = JsonConvert.SerializeObject(e);
            return json;
        }
    }
}