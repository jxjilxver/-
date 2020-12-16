using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab12
{
    static class Reflector
    {
        static public void AllClassContent(object obj)
        {
            string writePath = @"C:\Users\murug\OOP\lab12\write.txt";


            StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default);


            Type m = obj.GetType();
            MemberInfo[] members = m.GetMembers();
            foreach (MemberInfo item in members)
            {
                sw.WriteLine($"{item.DeclaringType} {item.MemberType} {item.Name}");
            }
            sw.Close();

        }



        static public void PublicMethods(object obj)
        {
            Type m = obj.GetType();
            MethodInfo[] pubMethods = m.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine("Только публичные методы:");
            foreach (MethodInfo item in pubMethods)
            {
                Console.WriteLine(item.ReturnType.Name + " " + item.Name);
            }

        }



        static public void FieldsAndProperties(object obj)
        {
            Type m = obj.GetType();
            Console.WriteLine("Поля:");
            FieldInfo[] fields = m.GetFields();

            foreach (FieldInfo item in fields)
            {
                Console.WriteLine(item.FieldType + " " + item.Name);

            }
            Console.WriteLine("Свойства:");
            PropertyInfo[] properties = m.GetProperties();
            foreach (PropertyInfo item in properties)
            {
                Console.WriteLine($"{item.PropertyType} {item.Name}");
            }

        }


        static public void Interfaces(object obj)
        {
            Type m = obj.GetType();
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type item in m.GetInterfaces())
            {
                Console.WriteLine(item.Name);
            }

        }

        static public void MethodsWithParams(object obj)
        {
            Console.WriteLine("Введите название типа для параметров:");
            string findType = Console.ReadLine();


            Type m = obj.GetType();
            MethodInfo[] methods = m.GetMethods();
            foreach (MethodInfo item in methods)
            {
                ParameterInfo[] p = item.GetParameters();

                foreach (ParameterInfo param in p)
                {
                    if (param.ParameterType.Name == findType)
                    {
                        Console.WriteLine("Метод:" + item.ReturnType.Name + " " + item.Name);
                    }
                }


            }

        }
        public static void LastTask(string Class, string MethodName)
        {
            StreamReader reader = new StreamReader(@"C:\Users\murug\OOP\lab12\read.txt", Encoding.Default);
            string param1, param2, param3;
            param1 = reader.ReadLine();
            param2 = reader.ReadLine();
            param3 = reader.ReadLine();
            reader.Close();

            Type m = Type.GetType(Class, true);

            object st = Activator.CreateInstance(m, null);
            MethodInfo method = m.GetMethod(MethodName);
            method.Invoke(st, new object[] { param1, char.Parse(param2), int.Parse(param3) });
        }
    }
    public class TestParams
    {
        public static void showParams(string str, char symbol, int number)
        {
            Console.WriteLine($"{str} {symbol} {number}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("train1", "БелЖД", 600000);
            Car car = new Car("car1", "Вася", 300, 220, 23);
            Reflector.AllClassContent(train);
            Console.WriteLine("----------------Поля и свойства объекта train----------------");
            Reflector.FieldsAndProperties(train);
            Console.WriteLine("----------------Интерфейсы, реализованные объектом car----------------");
            Reflector.Interfaces(car);
            Console.WriteLine("----------------Для объекта car----------------");
            Reflector.PublicMethods(car);
            Reflector.MethodsWithParams(train);
            Reflector.LastTask("lab12.TestParams", "showParams");
        }
    }
}
