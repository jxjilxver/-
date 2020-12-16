using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;


namespace lab15
{
    class Program
    {

        static object locker = new object();
        static void Main(string[] args)
        {
            TimerCallback timer = new TimerCallback(Smile);
            Timer timer2 = new Timer(timer, null, 0, 5000);
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                try
                {
                    Console.WriteLine($"Id: {proc.Id}");
                    Console.WriteLine($"Name: {proc.ProcessName}");
                    Console.WriteLine($"Priority: {proc.PriorityClass}");
                    Console.WriteLine($"Start: {proc.StartTime}");
                    Console.WriteLine($"Responding: {proc.Responding}");

                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Name: {proc.ProcessName} {ex.Message}");
                }

                Console.WriteLine("-------------------------------------------------");
            }


            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Id: {domain.Id}");
            Console.WriteLine($"Path: {domain.BaseDirectory}");
            Console.WriteLine("All assemblies:");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly assem in assemblies)
            {
                Console.WriteLine($"Name: {assem.GetName().Name} Version: {assem.GetName().Version}");
            }




            //AppDomain app = AppDomain.CreateDomain("Slava");
            //Console.WriteLine($"\nДомен: {app.FriendlyName}");
            //app.ExecuteAssembly(@"C:\Users\murug\OOP\lab15\lab15\bin\Debug\netcoreapp3.1\lab15.exe");
            //Assembly[] assemblies2 = domain.GetAssemblies();
            //foreach (Assembly asm in assemblies2)
            //{
            //    Console.WriteLine($"Имя - {asm.GetName().Name}");
            //}
            //AppDomain.Unload(app);


            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Введите число до которого будет идти счёт:");
            int number1 = int.Parse(Console.ReadLine());
            Thread thread1 = new Thread(new ParameterizedThreadStart(YourNumbers));
            thread1.Name = "NumberThread";
            thread1.Start(number1);


            int number2 = int.Parse(Console.ReadLine());


            Thread thread2 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            thread2.Name = "EvenNumberThread";
            thread2.Priority = ThreadPriority.Normal;
            Console.WriteLine($"Поток:{thread2.Name} Приоритет:{thread2.Priority}");
            thread2.Start(number2);

            Thread thread3 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            thread3.Name = "OddNumberThread";
            thread3.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine($"Поток:{thread3.Name} Приоритет:{thread3.Priority}");
            thread3.Start(number2);




        }

        public static void Smile(object NoParametr)
        {
            Console.WriteLine("(-_-)");

        }

        public static void YourNumbers(object n)
        {
            string writePath = @"C:\Users\murug\OOP\lab15\lab15\numbers.txt";
            Thread t = Thread.CurrentThread;
            for (int i = 1; i <= (int)n; i++)
            {

                Console.WriteLine(i);
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(i);
                }

                if (i == (int)n)
                {
                    Console.WriteLine($"Имя потока: {t.Name}");

                    Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
                    Console.WriteLine($"Приоритет потока: {t.Priority}");
                    Console.WriteLine($"Статус потока: {t.ThreadState}");
                }

                Thread.Sleep(1000);

            }
        }

        public static void EvenAndOdd(object n)
        {
            string writePath = @"C:\Users\murug\OOP\lab15\lab15\AllNumbers.txt";
            Thread t = Thread.CurrentThread;
            lock (locker)
            {
                for (int i = 1; i <= (int)n; i++)
                {
                    if (t.Name == "EvenNumberThread")
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }

                        Thread.Sleep(200);
                    }

                    if (t.Name == "OddNumberThread")
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(200);
                    }

                }

            }
        }
    }
}