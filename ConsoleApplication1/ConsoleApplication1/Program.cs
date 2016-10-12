using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /*public static void CN(int?)*/
        static void Main(string[] args)
        {
            dynamic obj = new {city=1};
            obj.city = "New York";
            Console.WriteLine(obj.city);
        }
    }

    public struct group<T>
    {
        private List<T> Members { get; set; }
    }
}
