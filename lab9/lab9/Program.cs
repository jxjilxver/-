using System;
using System.Collections.Generic;
namespace lab9
{
    public class Programmer
    {
        public delegate void Deleg();
        public event Deleg Mut;
        public event Deleg Delete;
        string _name;
        int _intelligence;
        public Programmer(string name, int intelligence)
        {
            _name = name;
            _intelligence = intelligence;
        }
        public void NameOut()
        {
            Console.WriteLine("Имя: "+_name);
            Delete?.Invoke();
        }
        public void IntelligencePlusOne()
        {
            _intelligence++;
            Mut?.Invoke();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Programmer proger = new Programmer("Саня", 120);
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            Console.WriteLine("Элементы списка 1:");
            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }
            List<int> list2 = new List<int>();
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            Console.WriteLine("Элементы списка 2:");
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }
            proger.Delete += () => { Remove(list1); Console.WriteLine("Вызвано событие 'Удалить'"); };
            proger.NameOut();
            Console.WriteLine("Элементы списка 1:");
            foreach(int i in list1)
            {
                Console.WriteLine(i);
            }
            proger.Mut += () => { Reverse(list2); Console.WriteLine("Вызвано событие 'Мутировать'"); };
            proger.IntelligencePlusOne();
            Console.WriteLine("Элементы списка 2:");
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }
            string str = "Hey, hOw: aRE\" yoU?";
            Console.WriteLine("------------Делегаты и пользовательские функции обработки строк------------");
            Console.WriteLine("------Простой вызов функций------");
            DeletePunktuation(str);
            DeleteSpaces(str);
            ToUpperCase(str);
            ToLowerCase(str);
            SpaceIntoDog(str);
            Console.WriteLine("------Вызов функций с помощью делегатов------");
            Console.WriteLine("---Делегат Action---");
            Action<string> firstDel;
            firstDel = DeletePunktuation;
            firstDel += DeleteSpaces;
            firstDel += ToUpperCase;
            firstDel(str);
            Console.WriteLine("---Делегат Func---");
            Func<string, string> secondDel;
            secondDel = ToLowerCase;
            secondDel += SpaceIntoDog;
            secondDel(str);
        }
        private static void Remove(List<int> list)
        {
            list.Remove(list[list.Count-1]);
        }
        private static void Reverse(List<int> list)
        {
            list.Reverse();
        }
        //пользовательские методы обработки строк
        static void DeletePunktuation(string str)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '.' && str[i] != ',' && str[i] != ';' && str[i] != ':' && str[i] != '?' && str[i] != ';' && str[i] != '-' && str[i] != '"')
                {
                    buffer += str[i];
                }
            }
            Console.WriteLine(buffer);
        }
        static void DeleteSpaces(string str)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    buffer += str[i];
                }
            }
            Console.WriteLine(buffer);
        }
        static void ToUpperCase(string str)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                buffer += Char.ToUpper(str[i]);
            }
            Console.WriteLine(buffer);
        }
        static string ToLowerCase(string str)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                buffer += char.ToLower(str[i]);
            }
            Console.WriteLine(buffer);
            return buffer;
        }
        static string SpaceIntoDog(string str)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    buffer += '@';
                else
                    buffer += str[i];

            }
            Console.WriteLine(buffer);
            return buffer;
        }
    }
}

