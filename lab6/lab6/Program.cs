﻿using System;
using System.Collections.Generic;
namespace lab6
{
    interface IClone
    {
        void Clone();
    }
    public abstract class Vehicle
    {
        public abstract void Clone();
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected string owner;
        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }
        protected int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        abstract public void IsTrain();
        public abstract void IsCar();
    }
    public class Train : Vehicle, IClone
    {
        public Train(string name, string owner, int price)
        {
            this.owner = owner;
            this.price = price;
            this.name = name;
        }
        public override void IsCar()
        {
            Console.WriteLine("Не является машиной");
        }
        public override void IsTrain()
        {
            Console.WriteLine("Это поезд");
        }
        public override void Clone()
        {
            Console.WriteLine("Метод абстрактного класса");
        }
        void IClone.Clone()
        {
            Console.WriteLine("Это метод интерфейса");
        }
        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine($"Имя: {Name}, владелец: {Owner}, стоимость: {Price}$");
            return " type " + base.ToString();
        }
    }
    public class Car : Vehicle
    {
        protected int expenditure;
        public int Expenditure { get { return expenditure; } set { expenditure = value; } }
        protected int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public Car(string name, string owner, int price, int speed, int expenditure)
        {
            this.name = name;
            this.owner = owner;
            this.price = price;
            this.speed = speed;
            this.expenditure = expenditure;
        }
        public override void IsCar()
        {
            Console.WriteLine("Это машина");
        }
        public override void IsTrain()
        {
            Console.WriteLine("Не является поездом");
        }
        public override void Clone()
        {
            Console.WriteLine("Метод абстрактного класса");
        }
        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine($"Имя: {Name}, владелец: {Owner}, стоимость: {Price}$, скорость: {Speed} км/ч, расход топлива на 100 км: {Expenditure} л");
            return " type " + base.GetType();
        }
    }
    public class Express : Train
    {
        protected int speed;
        public int Speed { get { return speed; } set { speed = value; } }
        public Express(string name, string owner, int price, int speed) : base(name, owner, price)
        {
            this.speed = speed;
        }
        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine($"Имя: {Name}, владелец: {Owner}, стоимость: {Price}$, скорость: {Speed} км/ч");
            return " type " + base.GetType();
        }
    }
    sealed public class Engine : Car
    {
        private int volume;
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }
        public Engine(string name, string owner,int price, int volume, int speed, int expenditure) : base(name, owner, price, speed, expenditure)
        {
            this.volume = volume;
        }
        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine($"Имя: {Name}, владелец: {Owner}, стоимость: {Price}$, объём: {volume} л, расход топлива на 100 км: {Expenditure} л");
            return " type " + base.GetType();
        }
    }
    class Van : Train
    {
        protected int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        public Van(string name, string owner,int price, int capacity) : base(name, owner, price)
        {
            this.capacity = capacity;
        }
        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine($"Имя: {Name}, владелец: {Owner}, стоимость: {Price}$, вместимость: {Capacity} человек");
            return " type " + base.GetType();
        }
    }
    public class ForObject : Object
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;
            return true; ;
        }
    }

    public class Printer
    {
        public void IAmPrinting(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }

    struct Time
    {
        int minutes;
        int seconds;
    }
    enum MathOperation { Add=1, Subtract, Multiply, Divide }

    class Program
    {
        static void Main(string[] args)
        {
            Train train1 = new Train("train1", "БелЖД", 500000);
            Car car1 = new Car("car1", "Вася", 12000, 220, 10);
            Car car2 = new Car("car2", "Гоша", 20000, 240, 13);
            Van van1 = new Van("van1", "train1", 35000, 70);
            Engine engine1 = new Engine("engine1", "car1", 300, 20, 220, 10);
            Express express1 = new Express("express1", "БелЖД", 35000, 170);
            train1.Clone();//метод абстрактного класса
            ((IClone)train1).Clone();//метод интерфейса
            Console.WriteLine("train1 is Train: " + (train1 is Train));
            Console.WriteLine("car1 is Car: " + (car1 is Car));
            Console.WriteLine("express1 is Train: " + (express1 is Train));
            Console.WriteLine("express1 is Car: " + (express1 is Car));
            Printer printer = new Printer();
            Vehicle[] vehmass = new Vehicle[] { train1, car1, van1, engine1, express1 };
            foreach (Vehicle vehicle in vehmass)
            {
                printer.IAmPrinting(vehicle);
                Console.WriteLine("-------------------------");
            }
            Train express2 = express1 as Train;

            Agency.Add(train1);
            Agency.Add(car2);
            Agency.Add(car1);
            Agency.Add(van1);
            Agency.Add(express1);
            Agency.Add(engine1);
            Agency.ShowList();
            Agency.Remove(engine1);
            List<Vehicle> car = Controller.SortByExpenditure(Agency.AllVehicles);
            Console.WriteLine("Отсортированный список машин по расходу топлива: ");
            foreach (Vehicle veh in car)
            {
                Console.WriteLine("type: " + veh.GetType());
                veh.ToString();
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("Стоимость всех ТС: "+Controller.FullPrice(Agency.AllVehicles)+"$");
            Console.WriteLine();
            Controller.SpeedInRange(Agency.AllVehicles);
        }
    }
}
