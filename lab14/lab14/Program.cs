using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace lab14
{
    interface IClone
    {
        void Clone();
    }
    [Serializable]
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
    [Serializable]
    public class Train : Vehicle, IClone
    {
        public Train(string name, string owner, int price)
        {
            this.owner = owner;
            this.price = price;
            this.name = name;
        }
        public Train()
        {

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
    [Serializable]
    public class Car : Vehicle
    {
        [NonSerialized]
        protected int expenditure;
        public int Expenditure { get { return expenditure; } set { expenditure = value; } }
        [NonSerialized]
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
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("train", "БелЖД", 12451235);
            Car car = new Car("car", "Вася", 4000, 220, 14);
            Vehicle[] vehicles = new Vehicle[] { train, car };
            Console.WriteLine("Объект создан");
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
                Console.WriteLine("Объект сериализован (binary)");
            }
            // десериализация из файла train.dat
            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.dat", FileMode.OpenOrCreate))
            {
                Train newTrain = (Train)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newTrain.Name} --- Цена: {newTrain.Price} --- Владелец: {newTrain.Owner}");
            }
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////
            
            DataContractJsonSerializer formatter3 = new DataContractJsonSerializer(typeof(Train));
            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.json", FileMode.OpenOrCreate))
            {
                formatter3.WriteObject(fs, train);

                Console.WriteLine("Объект сериализован (json)");
            }
            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.json", FileMode.OpenOrCreate))
            {
                Train newTrain = (Train)formatter3.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newTrain.Name} --- Цена: {newTrain.Price} --- Владелец: {newTrain.Owner}");
            }
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////

            XmlSerializer formatter4 = new XmlSerializer(typeof(Train));
            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
                Console.WriteLine("Объект сериализован (xml)");

            }

            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\train.xml", FileMode.OpenOrCreate))
            {
                Train newTrain = (Train)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя:{newTrain.Name} --- Цена: {newTrain.Price} --- Владелец: {newTrain.Owner}");

            }
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////

            BinaryFormatter formatter5 = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\vehicles.dat", FileMode.OpenOrCreate))
            {
                formatter5.Serialize(fs, vehicles);

                Console.WriteLine("Массив объектов сериализован");
            }


            using (FileStream fs = new FileStream(@"C:\Users\murug\OOP\lab14\vehicles.dat", FileMode.OpenOrCreate))
            {
                Vehicle[] newVehicles = (Vehicle[])formatter.Deserialize(fs);

                Console.WriteLine("Массив объектов десериализован");
                foreach (Vehicle item in newVehicles)
                {
                    Console.WriteLine($"Имя: {item.Name} --- Цена: {item.Price} --- Владелец: {item.Owner}");
                }

            }
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Первый селектор: имя train1");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\murug\OOP\lab14\task3.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode childnode1 = xRoot.SelectSingleNode("train[@name='train1']");
            if (childnode1 != null)
                Console.WriteLine(childnode1.OuterXml);
            Console.ReadLine();

            Console.WriteLine("Второй селектор: все элементы price");
            XmlNodeList childnodes = xRoot.SelectNodes("//train/price");
            foreach(XmlNode n in childnodes)
                Console.WriteLine(n.InnerText+"$");
            Console.ReadLine();
            ////////////////////////////////////////////////////////////////////////////

            XDocument document = new XDocument();
            XElement root = new XElement("countries");
            XElement country1 = new XElement("country");
            root.Add(country1);
            XAttribute number1 = new XAttribute("number", "1");
            country1.Add(number1);
            XElement CounryName1 = new XElement("name", "Belarus");
            country1.Add(CounryName1);
            XElement square1 = new XElement("square", "207 595 км²");
            country1.Add(square1);
            XElement population1 = new XElement("population", "9.508 million");
            country1.Add(population1);

            XElement country2 = new XElement("country");
            root.Add(country2);
            XAttribute number2 = new XAttribute("number", "2");
            country2.Add(number2);
            XElement CounryName2 = new XElement("name", "Russia");
            country2.Add(CounryName2);
            XElement square2 = new XElement("square", "17 100 000 км²");
            country2.Add(square2);
            XElement population2 = new XElement("population", "144,5 million");
            country2.Add(population2);
            document.Add(root);
            document.Save(@"C:\Users\murug\OOP\lab14\Countries.xml");
            Console.WriteLine("Документ создан при помощи  LINQ to XML");

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"C:\Users\murug\OOP\lab14\Countries.xml");
            XmlElement Root = xdoc.DocumentElement;
            Console.WriteLine("Первый xml запрос (выбор имён):");
            XmlNodeList childnodes4 = Root.SelectNodes("country");
            foreach (XmlNode n in childnodes4)
                Console.WriteLine(n.SelectSingleNode("name").InnerText);
            Console.WriteLine("Второй xml запрос (получаем площадь):");
            XmlNodeList childnodes5 = Root.SelectNodes("//country/square");
            foreach (XmlNode n in childnodes5)
                Console.WriteLine(n.InnerText);

        }
    }
}
