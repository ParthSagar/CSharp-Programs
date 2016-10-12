using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    class Program4
    {
        private static Mutex mutex=new Mutex();
        public static void c()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t=new Thread(new ThreadStart(MutexDemo));
                t.Name = string.Format("Thread {0}", i);
                t.Start();
            }
        }

        static void MutexDemo()
        {
            try
            {
                mutex.WaitOne();
                Console.WriteLine("{0} has entered in the Domain", Thread.CurrentThread.Name);
                Thread.Sleep(1000);
                Console.WriteLine("{0} is leaving the Domain\r\n", Thread.CurrentThread.Name);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
