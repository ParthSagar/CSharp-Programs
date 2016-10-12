using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApplication
{
    class Program6
    {
        public static void c()
        {
            System.Collections.Generic.List<Dog> dogs=new System.Collections.Generic.List<Dog>();
            dogs.Add(new Dog("Vicky"));
            dogs.Add(new Dog("Ricky"));
            dogs.Add(new Dog("Shrea"));
            dogs.Add(new Dog("Janzir"));
            
            dogs.Sort();
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Describe());
            }
            Console.ReadKey();
        }
    }

    interface IAnimal
    {
        string Describe();

        string Name
        {
            get;
            set;
        }
    }

    class Dog : IAnimal, IComparable
    {
        private string name;

        public Dog(string name)
        {
            this.Name = name;
        }

        public string Describe()
        {
            return "Hello, I'm a dog and my name is " + this.Name;
        }

        public int CompareTo(object obj)
        {
            if (obj is IAnimal)
                return this.Name.CompareTo((obj as IAnimal).Name);
            return 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

