using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    enum AccountType
    {
        Текущий,
        Сберегательный
    }
    class Bank
    {
        public Bank(string accountNumber, double balance, AccountType type)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.type = type;
        }
        private string accountNumber { get; set; }
        public double balance { get; set; }
        public AccountType type { get; set; }
        public override string ToString() => $"Номер счета - {accountNumber}, Баланс - {balance}, Тип банковского счета - {type}";

        public double PutOn(double balance)
        {
            Console.Write("Введите сумму для пополнения ");
            double temp = Convert.ToDouble(Console.ReadLine());
            return balance + temp;
        }
        public double WithdrawFrom(double balance)
        {
            Console.Write("Введите сумму, которую хотите снять: ");
            double temp = Convert.ToDouble(Console.ReadLine());
            if (balance >= temp)
            {
                return balance - temp;
            }
            else
            {
                Console.WriteLine("Недостаточно средств");
                return balance;
            }
        }

    }
    class Building
    {
        private int numbe;
        public int Numb { get=> numbe; set => numbe = value; }
        
        private ushort height;
        public ushort Height { get => height; set => height = value; }
        
        private byte numberOfFloors;
        public byte floors { get => numberOfFloors; set => numberOfFloors = value; }
        
        private ushort numberOfFlats;
        public ushort Flats
        {
            get => numberOfFlats;
            set => numberOfFlats = value;
        }
        private byte numberOfEntrance;
        public byte Entrance
        {
            get => numberOfEntrance;
            set => numberOfEntrance = value;
        }
        static Random rand = new Random();
        public static int number = rand.Next(1000);
        public Building(int n, ushort h, byte Floors, ushort Flats, byte entrances)
        {
            this.numbe = n;
            this.height = h;
            this.numberOfFloors = Floors;
            this.numberOfFlats = Flats;
            this.numberOfEntrance = entrances;
        }
        public int floorHeight(ushort h, byte f)
        {
            int temp = h / f;
            return temp;
        }
        public int FlatsInEntrance(ushort f, byte e)
        {
            int temp = f / e;
            return temp;
        }
        public int FlatsOnFloor(ushort flats, byte e, byte floors)
        {
            int temp = (flats / e) / (floors - 1);
            return temp;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 7.1");
            AccountType Type1 = AccountType.Текущий;
            Console.WriteLine(Type1);
            Bank bank = new Bank("3387448", 1000, AccountType.Сберегательный);
            Console.WriteLine(bank);

            Console.WriteLine("Задание 7.2");
            AccountType Type2 = AccountType.Сберегательный;
            Console.WriteLine(Type2);
            Random rnd = new Random();
            int accNum1 = rnd.Next(1000, 100000);
            string accnum11 = accNum1.ToString();
            Bank bank1 = new Bank(accnum11, 5608800, AccountType.Сберегательный);
            Console.WriteLine(bank1);

            Console.WriteLine("Задание 7.3");
            Random rnd1 = new Random();
            int accNum2 = rnd1.Next(1000, 100000);
            string accNum12 = accNum2.ToString();
            Bank bank2 = new Bank(accNum12, 108800, AccountType.Текущий);
            Console.WriteLine("Выберите операцию \n1. Снять\n2. Пополнить");

            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    bank2.balance = bank2.WithdrawFrom(bank2.balance);
                    Console.WriteLine(bank2);
                    break;
                case 2:
                    bank2.balance = bank2.PutOn(bank2.balance);
                    Console.WriteLine(bank2);
                    break;
                default:
                    Console.WriteLine("Запрос отклонен");
                    break;
            }


            Console.WriteLine("Домашнее задание");
            Building building = new Building(1, 45, 18, 120, 7);
            Console.WriteLine($"Высота одного этажа {building.floorHeight(building.Height, building.floors)} метра, количество квартир в подъезде: {building.FlatsInEntrance(building.Flats, building.Entrance)}, количество квартир на этаже: {building.FlatsOnFloor(building.Flats, building.Entrance, building.floors)}");
        }
    }
}
