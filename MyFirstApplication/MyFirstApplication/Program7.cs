using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    public enum Days
    {
        Monday=1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };
    class Program7
    {
        public static void c()
        {
            Days day = (Days) 5;
            Console.WriteLine(day);
            string[] values = Enum.GetNames(typeof(Days));
            foreach (var v in values)
            {
                Console.WriteLine(v);
            }
        }
    }
}
