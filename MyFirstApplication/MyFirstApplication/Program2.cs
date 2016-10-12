using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    class Program2
    {
        public static void c()
        {
            /*Console.WriteLine("*****Current Thread Information*******");
            Thread t = Thread.CurrentThread;
            t.Name = "Primary_Thread";
            Console.WriteLine("Thread Name: {0}",t.Name);
            Console.WriteLine("Thread Status: {0}", t.IsAlive);
            Console.WriteLine("Priority: {0}", t.Priority);
            Console.WriteLine("Context Id: {0}", Thread.CurrentContext.ContextID);
            Console.WriteLine("Current application domain: {0}", Thread.GetDomain().FriendlyName);
*/
            /*Thread t=new Thread(myFun);
            t.IsBackground = false;
            t.Start();
            Console.WriteLine("Main Thread Running");*/
            Test t=new Test();
            Thread[] tr=new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                tr[i]=new Thread(new ThreadStart(t.calculation));
                tr[i].Name = String.Format("Working Thread: {0}", i);
            }
            foreach (Thread x in tr)
            {
                x.Start();
            }
        }

        static void myFun()
        {
            Console.WriteLine("Thread {0} started",Thread.CurrentThread.Name);
            //Thread.Sleep(5000);
            Console.WriteLine("Thread State: {0}", Thread.CurrentThread.IsAlive);
            Console.WriteLine("Thread {0} Completed",Thread.CurrentThread.Name);
        }


    }

    public class Test
    {
        public object tlock=new object();
        public  void calculation()
        {
            Monitor.Enter(tlock);
            try
            {
                Console.WriteLine("{0} is Executing", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(1000));
                    Console.Write("{0},", i);
                }
                Console.WriteLine();
            }
            catch
            {
            }
            finally
            {
                Monitor.Exit(tlock);
            }
        }

    }
}
