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

            //Console.WriteLine("введите значение переменной типа bool:");
            //Bool = Convert.ToBoolean(Console.ReadLine());
            //Console.WriteLine("значение переменной bool: "+Bool);
            //Console.WriteLine("введите значение переменной типа byte:");
            //Byte = Convert.ToByte(Console.ReadLine());
            //Console.WriteLine("значение переменной byte: "+Byte);
            //Console.WriteLine("введите значение переменной типа sbyte:");
            //Sbyte = Convert.TosByte(Console.Readline());
            //Console.WriteLine("значение переменной sbyte: "+Sbyte);
            //Console.WriteLine("введите значение переменной типа char:");
            //Char = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine("значение переменной char: "+Char);
            //Console.WriteLine("введите значение переменной типа decimal:");
            //Decimal = Convert.ToDecimal(Console.ReadLine());
            //Console.WriteLine("значение переменной decimal: " + Decimal);
            //Console.WriteLine("введите значение переменной типа double:");
            //Double = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("значение переменной double: " + Double);

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
            var q = 2;
            int g = q + 2;
            Console.WriteLine(g);

            /*task1_e*/
            int? y = null;

            /*task1_f*/
            //var p = 12;
            //p = String;
        }
    }
}
