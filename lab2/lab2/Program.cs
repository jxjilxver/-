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
            Console.WriteLine("введите значение переменной типа bool(true или false):");
            Bool = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("значение переменной bool: " + Bool);
            Console.WriteLine("введите значение переменной типа byte(от 0 до 255):");
            Byte = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("значение переменной byte: " + Byte);
            Console.WriteLine("введите значение переменной типа sbyte(-128 до 127):");
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
            Console.WriteLine("Задание №1-b: Работа с неявно типизированной переменной:");
            var q = 2;
            int g = q + 2;
            Console.WriteLine($"var q=2, ing g=q+2, g={g}");
            Console.WriteLine();

            /*task1_e*/
            int? y = null;

            /*task1_f*/
            //var p = 12;
            //p = String;//ошибка, после присвоения значения неявно типизированный переменной уже нельзя меня его тип

            /*task2_a*/
            Console.WriteLine("Задание №2: строки");
            string s1 = "hello";
            Console.WriteLine("Строка s1: " + s1);
            string s2 = "world";
            Console.WriteLine("Строка s2: " + s2);
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
            Console.WriteLine();

            /*task2_b*/
            Console.WriteLine("Задание №2-b");
            string s3 = s1 + " " + s2; // результат: строка "hello world"
            Console.WriteLine("Cцепление строки 1 и строки 2: " + s3);
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
            Console.WriteLine("Интерполяция строк: " + Z);
            Console.WriteLine();

            /*task2_c*/
            Console.WriteLine("Задание №2-с");
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
            Console.WriteLine();

            /*task2_d*/
            Console.WriteLine("Задание №2-d: Работа с StringBuilder");
            StringBuilder sb = new StringBuilder("привет, мир");
            Console.WriteLine("Исходная строка: " + sb);
            sb.Remove(6, 5);
            Console.WriteLine("строка после удаления 5-и символов начиная с 6-го: " + sb);
            sb.Insert(0, "\"");//добавление в начало строки
            sb.Append("\"");//добавление в конец строки
            Console.WriteLine("строка после добавлоения в начало и в конец по одному символу: " + sb);
            Console.WriteLine();

            /*task3_a*/
            Console.WriteLine("Задание №3: массивы");
            int[,] mass = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write($"{mass[j, k]}\t");//вывод матрицы
                }
                Console.WriteLine();
            }

            /*task3_b*/
            Console.WriteLine("Задание №3-b");
            string[] mas = { "Hello", ", ", "world", "!" };
            Console.Write("Массив строк: ");
            foreach (string str in mas)
            {
                Console.Write(str);
            }
            Console.WriteLine();
            Console.WriteLine("Длина массива: " + mas.Length);
            Console.WriteLine("Введите позицию, которую хотите изменить:");
            int position = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Введите строку:");
            mas[position] = Console.ReadLine();
            Console.WriteLine("Новый массив строк: ");
            foreach (string str in mas)
            {
                Console.Write(str);
            }
            Console.WriteLine();

            /*task3_c*/
            //1 2
            //3 4 5
            //6 7 8 9
            Console.WriteLine("Задание №3-с");
            double[][] masf = new double[3][];
            masf[0] = new double[2];
            masf[1] = new double[3];
            masf[2] = new double[4];
            Console.WriteLine("Введите элементы(9 шт.): ");
            for (int j = 0; j < masf.Length; j++)
            {
                for (int k = 0; k < masf[j].Length; k++)
                {
                    masf[j][k] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("Ступенчатый массив:");
            foreach (double[] row in masf)
            {
                foreach (double num in row)
                {
                    Console.Write($"{num }\t");
                }
                Console.WriteLine();
            }

            /*task3_d*/
            var mas1 = new[] { 1, 2, 3 };
            var mas3 = new int[] { 1, 2, 3 };
            var str2 = "123";

            /*task4_a*/
            Console.WriteLine("Задание №4: кортежи");
            (int, string, char, string, ulong) tuple = (12, "hello", 'F', "world", 21);

            /*task4_b*/
            Console.WriteLine("Вывод кортежа целиком: " + tuple);
            Console.WriteLine($"Выборочный вывод: {tuple.Item2} {tuple.Item4}");
            Console.WriteLine();

            /*task4_c*/
            int item1 = tuple.Item1;//распаковка кортежа

            /*task4_d*/
            Console.WriteLine("Задание №4-d");
            var aa = (5, 6);
            var bb = (5, 6);
            Console.WriteLine($"Кортеж а={aa}, кортеж b={bb}");
            Console.WriteLine($"a равно b: {aa == bb}");
            Console.WriteLine($"a не равно b: {aa != bb}");
            Console.WriteLine();

            /*task5*/
            Console.WriteLine("Задание №5: Функция");
            int[] nums = new int[5];
            string newstr = "";
            Console.WriteLine("Введите пять чисел");
            for (int j = 0; j < nums.Length; j++)
            {
                Console.Write("{0}-е число: ", j + 1);
                nums[j] = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите строку: ");
            newstr = Console.ReadLine();
            Console.WriteLine($"Полученный кортеж: {fun(nums, newstr)}");
            (int, int, int, char) fun(int[] m, string st)//функция
            {
                (int, int, int, char) tupl;
                int temp;
                int sum = 0;
                foreach (int num in m)
                {
                    sum += num;
                }
                for (int j = 0; j < m.Length - 1; j++)
                {
                    for (int k = i + 1; k < m.Length; k++)
                    {
                        if (m[j] > m[k])
                        {
                            temp = m[j];
                            m[j] = m[k];
                            m[k] = temp;
                        }
                    }
                }
                tupl.Item1 = m[4];
                tupl.Item2 = m[0];
                tupl.Item3 = sum;
                tupl.Item4 = st[0];
                return tupl;
            }
            Console.WriteLine();

            /*task6*/
            Console.WriteLine("Задание №6: Работа с checked/unchecked");
            int CheckedMethod()
            {
                int z = 0;
                int maxIntValue = 2147483647;
                try
                {
                    checked
                    {
                        z = maxIntValue + 10;
                    }
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
                }
                return z;
            }
            Console.WriteLine("\nCHECKED output value is: {0}", CheckedMethod());
            int UncheckedMethod()
            {
                int z = 0;
                int maxIntValue = 2147483647;
                try
                {
                    unchecked
                    {
                        z = maxIntValue + 10;
                    }
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
                }
                return z;
            }
            Console.WriteLine("UNCHECKED output value is: {0}", UncheckedMethod());
        }
    }
}
