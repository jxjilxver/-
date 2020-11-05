using System;

namespace lab5
{
    interface IClone
    {
        void Clone();
    }
    public abstract class Vehicle
    {
        public abstract void Clone();
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
        abstract public void IsTrain();
        public abstract void IsCar(); 
    }
    public class Train : Vehicle, IClone
    {
        
        public Train(string owner)
        {
            this.owner = owner;
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
            Console.WriteLine(Owner);
            return " type " + base.ToString();
        }
    }
    public class Car : Vehicle
    {
        public Car(string owner)
        {
            this.owner = owner;
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
            Console.WriteLine(Owner);
            return " type " + base.ToString();
        }
    }
    public class Express : Train
    {
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
        public Express(string owner, int price) : base(owner)
        {
            this.price = price;
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
        public Engine(string owner, int volume) : base(owner)
        {
            this.volume = volume;
        }
    }
    class Van : Train
    {
        protected int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public Van(string owner, int number ) : base(owner)
        {
            this.number = number;
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

    class Program
    { 
        static void Main(string[] args)
        {
            
        }
    }
}
