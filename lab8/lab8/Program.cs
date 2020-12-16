using System;
using System.IO;
namespace lab8
{
    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode(T data)
        {
            Data = data;
        }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    //--------------------------------------------------------------------------

    interface IAction<T>
    {
        void Add(T data);
        bool Remove(T data);
        void Out();
    }
    public class CollectionType<T>:IAction<T> where T:class
    {
        public DoublyNode<T> head; // головной/первый элемент
        public DoublyNode<T> tail; // последний/хвостовой элемент
        public int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        //---------------------------------------------------

        public static bool operator !=(CollectionType<T> list1, CollectionType<T> list2)//проверка на неравенство 
        {
            DoublyNode<T> head1 = list1.head;
            DoublyNode<T> head2 = list2.head;
            while (head1 != null && head2 != null)
            {
                if (Equals(head1.Data, head2.Data))
                {
                    head1 = head1.Next;
                    head2 = head2.Next;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //---------------------------------------------------

        public static bool operator ==(CollectionType<T> list1, CollectionType<T> list2)//проверка на равенство
        {
            DoublyNode<T> head1 = list1.head;
            DoublyNode<T> head2 = list2.head;
            while (head1 != null && head2 != null)
            {
                if (Equals(head1.Data, head2.Data))
                {
                    head1 = head1.Next;
                    head2 = head2.Next;
                }
                else
                {
                    return false;

                }
            }
            return true;
        }

        //---------------------------------------------------

        public static CollectionType<T> operator *(CollectionType<T> list1, CollectionType<T> list2)//объединение двух списков
        {
            DoublyNode<T> head1 = list1.head;
            DoublyNode<T> head2 = list2.head;
            CollectionType<T> list3 = new CollectionType<T>();
            while (head1 != null)
            {
                list3.Add(head1.Data);
                head1 = head1.Next;
            }
            while (head2 != null)
            {
                list3.Add(head2.Data);
                head2 = head2.Next;
            }
            return list3;
        }

        //---------------------------------------------------
        public static CollectionType<T> operator +(T data, CollectionType<T> DLL)//добавлкение в начало
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = DLL.head;
            node.Next = temp;
            DLL.head = node;
            if (DLL.count == 0)
                DLL.tail = DLL.head;
            else
                temp.Previous = node;
            DLL.count++;
            return DLL;
        }

        //---------------------------------------------------
        public static CollectionType<T> operator --(CollectionType<T> dll)//удаление первого
        {
            dll.head = dll.head.Next;
            dll.count--;
            return dll;
        }

        // удаление
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        //---------------------------------------------------

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        //---------------------------------------------------

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        //---------------------------------------------------

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        //---------------------------------------------------

        public void Out()//вывод всех элементов списка
        {
            DoublyNode<T> temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
        }

        public class Owner
        {
            int ID;
            public int Id
            {
                get
                {
                    return ID;
                }
                set
                {
                    ID = value;
                }
            }
            string name;
            public string Name { get; set; }
            string company;
            public string Company { get; set; }
        }

        public class Date
        {
            string date;
            public string String { get; set; }
        }
        
            
        
        public void FileRead()
        {
            try
            {
                string path = @"C:\Users\murug\forlab8.txt";
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    Console.WriteLine("Вывод из файла:");
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            finally
            {
                Console.WriteLine("Вывод из файла закончен");
            }
        }
    }
    public class Car
    {
        public int speed;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            Car car2 = new Car();
            car1.speed = 200;
            car2.speed = 250;
            CollectionType<Car> list = new CollectionType<Car>();
            list.Add(car1);
            list.Add(car2);
            string path = @"C:\Users\murug\forlab8.txt";
            DoublyNode<Car> temp = list.head;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    while (temp != null)
                    {
                        sw.WriteLine(temp.Data.speed);
                        temp = temp.Next;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Запись в файл");
            }
            list.FileRead();

        }
    }
}
