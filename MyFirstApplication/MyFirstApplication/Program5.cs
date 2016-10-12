using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    class Program5
    {
        private static Semaphore obj = new Semaphore(2, 2);

        public static void c()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(SempStart).Start(i);
            }
        }

        static void SempStart(object id)
        {
            Console.WriteLine(id + "-->> Wants to get Enter");
            try
            {
                obj.WaitOne();
                Console.WriteLine("Success: " + id + " is in");
                Thread.Sleep(2000);
                Console.WriteLine(id + "<<-- is Evacuating");
            }
            finally
            {
                obj.Release();
            }
        }
    }
}
