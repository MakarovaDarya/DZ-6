using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    abstract class Employee
    {
        public string name { get; }
        public Employee(string name)
        {
            this.name = name;
        }
        public void Work() => Console.WriteLine($"{name} на работе");
    }
    
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Person (string name,string surname,int age)
        {
            this.name = name;   
            this.surname = surname; 
            this.age = age; 
        }
        public void Print()
        {
            Console.WriteLine($"Имя \t{name}\nФамилия \t{surname}\nВозраст \t{age}");
        }
    }
    public class JobTitle : Person
    {
        private int check { get; set; }
        private string inn { get;  }
        private string snils { get; }
        public string education { get; }
        public JobTitle(string name, string surname, int age, int check,string inn,string snils,string education)
            : base(name, surname, age)
        {
            this.check = check;
            this.inn = inn; 
            this.snils = snils;
            this.education= education;  
        }
    }
    public class Client : Person
    {
        private int budget { get; }
        public string car { get; }
        public Client(string name, string surname, int age,int budget, string car)
            : base(name, surname, age)
        {
            this.budget = budget;
            this.car = car;
        }   
    }
    public class mechanic : JobTitle
    {
        
        public mechanic(string name, string surname, int age, int check, string inn, string snils, string education)
            : base(name, surname, age,check,  inn,  snils,  education) { }
        
    }
    public class Chief: JobTitle
    {
        public Chief(string name, string surname, int age, int check, string inn, string snils, string education)
            : base(name, surname, age, check, inn, snils, education) { }
    }
    
    public class ServicesAndPrices
    {
        public void Services(List<string> services)
        {
            StreamReader list = new StreamReader("Services.txt");
            string line;
            while ((line = list.ReadLine()) != null)
            {
                services.Add(line);
            }
        }
        public void PrintServices()
        {
            List<string> services = new List<string>();
            Services(services);
            foreach(string it in services)
                Console.WriteLine(it);
        }
        public void Prices(ref List<string> prices)
        {
            string file = File.ReadAllText("Prices.txt");
            int[] nums = file
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            foreach (int i in nums)
                Console.WriteLine(i);
        }
        public void PrintPrices()
        {
            List<string> prices = new List<string>();
            Services(prices);
            foreach (string it in prices)
                Console.WriteLine(it);
        }
    }
   
    public class accountant:JobTitle
    {
        public accountant(string name, string surname, int age, int check, string inn, string snils, string education)
            : base(name, surname, age, check, inn, snils, education) { }


        public class CarService
        {
            public int arenda;
            public int electrSupply;
            public int equipment;
            public int purchase;
            public CarService(int arenda, int electrSupply, int equipment, int purchase)
            {
                this.arenda = arenda;
                this.electrSupply = electrSupply;
                this.equipment = equipment;
                this.purchase = purchase;
            }
            public void CarServiceCosts()
            {
                CarService salon = new CarService(250000, 74000, 67000, 3000);
                Console.WriteLine($" Месячные траты на автосерис составляют - {arenda + electrSupply + equipment + purchase}");
            }
        }
    }
    class visitor: Person
    {
        public visitor(string name,string surname,int age) : base(name,surname,age) { }
        public void GetInfo(StreamReader sr,ref List<string> people)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                people.Add(line);
            }
        }
        public void NewVisitor(ref List<string> people)
        {
            Console.WriteLine("Здравствуйте, я Валерий");
            string nameV = Console.ReadLine();
            Console.WriteLine("Сколько людей находится в автосалоне: ");
            foreach (string person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("Поговрите с новым клиентом?");
            string answ = Console.ReadLine();
            switch (answ)
            {
                case "да":
                    Console.WriteLine("Какая у вас проблема?");
                    int problem = int.Parse(Console.ReadLine());
                    /*
                 * 1. Замена тормозных колодок
                 * 2. Утечка охлаждающей жикости
                 * 3. Царапины
                 * 4. Вмятины
                 * 5. Замена шин
                 * 6. Проблемы с аккумулятором
                 * 7. Топливный насос
                 * 8. Кондиционер
                 * 9. Свчеи и катушки зажигания
                */
                    break;
                case "нет":
                    Console.WriteLine("Эти клиенты все еще ждут");
                    foreach (string person in people)
                    {
                        Console.WriteLine(person);
                    }
                    break;
            }
        }

    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сегодня отличный рабочий день");
            accountant Ivan = new accountant("Иван","Иванов", 23, 12342,"657484","5757674544","Механик");
            Console.WriteLine("Работа бухгалтера выполнена: ", Ivan);

            visitor newChelovek = new visitor("Евгений","Михайлов",32);
            Console.WriteLine("Зашел новый клиент: ",newChelovek);
        }
    }
}
