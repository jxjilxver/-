using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*task 1_a*/
            bool Bool = true;
            byte Byte = 255;
            sbyte Sbyte = -127;
            char Char = 'f';
            decimal Decimal = 200.5m;
            double Double = 2.28;
            float Float = 22.8f;
            int Int = 1337;
            uint Uint = 4_294_967_295;
            long Long = 8_000_000;
            ulong Ulong = 18_000_000;
            short Short = 15000;
            ushort Ushort = 65535;
            string String = "hello";
            object Object = "world";
            dynamic Dynamic = '!';

            Console.WriteLine("Задание №1: типы данных");
            Console.WriteLine("введите значение переменной типа bool:");
            Bool = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("значение переменной bool: " + Bool);
            Console.WriteLine("введите значение переменной типа byte:");
            Byte = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("значение переменной byte: " + Byte);
            Console.WriteLine("введите значение переменной типа sbyte:");
            Sbyte = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("значение переменной sbyte: " + Sbyte);
            Console.WriteLine("введите значение переменной типа char:");
            Char = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("значение переменной char: " + Char);
            Console.WriteLine("введите значение переменной типа decimal:");
            Decimal = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("значение переменной decimal: " + Decimal);
            Console.WriteLine("введите значение переменной типа double:");
            Double = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("значение переменной double: " + Double);

            /*task1_b*/
            int a = 29816484;
            long b = a;//неявное приведение
            byte c = 225;
            short v = c;//неявное приведение
            double x = 1234.5;
            a = (int)x;//явное преобразование
            int f = 152315;
            long h = (long)(a + f);//явное преобразование

            /*task1_c*/
            int i = 123;
            object o = i;//упаковка
            o = 321;
            i = (int)o;//распаковка

            /*task1_d*/
            Console.WriteLine("Работа с неявно типизированной переменной:");
            var q = 2;
            int g = q + 2;
            Console.WriteLine($"var q=2, ing g=q+2, g={g}");

            /*task1_e*/
            int? y = null;

            /*task1_f*/
            //var p = 12;
            //p = String;//ошибка, после присвоения значения неявно типизированный переменной уже нельзя меня его тип

            /*task2_a*/
            Console.WriteLine("Задание №2: строки");
            string s1 = "hello";
            Console.WriteLine("Строка 1: "+s1);
            string s2 = "world";
            Console.WriteLine("Строка 2: "+s2);
            int result = String.Compare(s1, s2);
            if (result < 0)
            {
                Console.WriteLine("Строка s1 перед строкой s2");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка s1 стоит после строки s2");
            }
            else
            {
                Console.WriteLine("Строки s1 и s2 идентичны");
            }

            /*task2_b*/
            string s3 = s1 + " " + s2; // результат: строка "hello world"
            Console.WriteLine("Cцепление строки 1 и строки 2: "+s3);
            string s4 = String.Concat(s3, "!!!"); // результат: строка "hello world!!!"
            string[] words = s3.Split(new char[] { ' ' });//разделение строки
            char[] word = new char[10];
            s3.CopyTo(0, word, 0, 7);//копирвоание
            string cut = "Объктно-ориентированное программирование";
            cut = cut.Substring(23);//выделение подстроки
            cut.Insert(0, "Объктно-ориентированное ");//вставка подстроки 
            string remsubstr = "добрый день!";
            remsubstr.Remove(0, 7);//Результат: строка "день!"
            int X = 1;
            int Y = 2;
            string Z = $"{X}+{Y}={X + Y}";//интерполяция строк; вывод: 1+2=3

            /*task2_c*/
            Console.WriteLine("Работа с IsNullOrEmpty:");
            string empty = "";
            string nul = null;
            string s = "notEmpty";
            bool b1 = String.IsNullOrEmpty(empty);
            bool b2 = String.IsNullOrEmpty(nul);
            bool b3 = String.IsNullOrEmpty(s);
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);

            /*task2_d*/
            Console.WriteLine("Работа с StringBuilder");
            StringBuilder sb = new StringBuilder("привет, мир");
            Console.WriteLine("Исходная строка: "+sb);
            sb.Remove(6, 5);
            Console.WriteLine("строка после удаления 5-и символов начиная с 6-го: "+sb);
            sb.Insert(0, "\"");
            sb.Append("\"");
            Console.WriteLine("строка после добавлоения в начало и в конец по одному символу: "+sb);
        }
    }
}
