using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    class Program3
    {
        static object obj1=new object();
        static object obj2=new object();

        public static void Deadlock1()
        {
            lock (obj1)
            {
                Console.WriteLine("Thread 1 get locked");
                Thread.Sleep(500);
                lock (obj2)
                {
                    Console.WriteLine("Thread 2 get Locked");
                }
            }
        }
        public static void Deadlock2()
        {
            lock (obj2)
            {
                Console.WriteLine("Thread 2 get locked");
                Thread.Sleep(500);
                lock (obj1)
                {
                    Console.WriteLine("Thread 1 get Locked");
                }
            }
        }
        public static void d()
        {
            Thread t1 = new Thread(new ThreadStart(Deadlock1));
            Thread t2=new Thread(new ThreadStart(Deadlock2));
            t1.Start();
            t2.Start();
        }
    }
}
