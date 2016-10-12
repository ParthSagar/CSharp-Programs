using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    
    class Program
    {
        public static int i = 5, j = 6;
        static void Main(string[] args)
        {
// Generic List
           /*List<int> myints=new List<int>();
            
            myints.Add(Int32.Parse(Console.ReadLine()));
            myints.Add(25);
            myints.Add(65);
            Console.WriteLine("Your Array:");
            for (int i = 0; i < myints.Length;i++)
            {
                Console.WriteLine(myints.Get(i));
            }
// ArrayList
            ArrayList alist=new ArrayList();
            alist.Add(5);
            alist.Add("Parth");
            foreach (var VARIABLE in alist)
            {
                Console.WriteLine(VARIABLE);
            }*/
            
// Ref and out Parameter
            /*int number;
            AddFive(out number);
            Console.WriteLine(number);*/
// Variable Parameters 
            /* GreetPerson(0,"Parth", "Manoj", "Sagar");
            GreetPerson(5,"Manoj","Meeta","Mihir","Bhavika","Sweetu");*/
// Array Sorting
            /*int[] ar = {6, 2, 8, 7, 1, 3};
            Array.Sort(ar);
            foreach (var a in ar)
            {
                Console.WriteLine(a);
            }*/
           /* Car car;
            car=new Car("Blue");
            Console.WriteLine(car.describe());
            Console.WriteLine(car.Color);*/
           
            
            Program7.c();
        }

        static void AddFive(int number)
        {
            j++;
            number = 5;
        }

        static void GreetPerson(int sn,params string[] ar)
        {
            foreach (var x in ar)
            {
                Console.WriteLine(x);
            }
        }
    }

    class Car
    {
        private string color;
        
        public Car(string color)
        {
            this.color = color;
        }

        public string describe()
        {
            return "This car is " + color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
