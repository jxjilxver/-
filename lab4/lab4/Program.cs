using System;

namespace lab4
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
        
        public class DoublyLinkedList<T>
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

            public static bool operator !=(DoublyLinkedList<T> list1, DoublyLinkedList<T> list2)//проверка на неравенство 
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

            public static bool operator ==(DoublyLinkedList<T> list1, DoublyLinkedList<T> list2)//проверка на равенство
            {
                DoublyNode<T> head1 = list1.head;
                DoublyNode<T> head2 = list2.head;
                while (head1 != null && head2 != null)
                {
                    if (Equals(head1.Data,head2.Data))
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

            public static DoublyLinkedList<T> operator *(DoublyLinkedList<T> list1, DoublyLinkedList<T> list2)//объединение двух списков
            {
                DoublyNode<T> head1 = list1.head;
                DoublyNode<T> head2 = list2.head;
                DoublyLinkedList<T> list3 = new DoublyLinkedList<T>();
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
            public static DoublyLinkedList<T> operator +(T data, DoublyLinkedList<T> DLL)//добавлкение в начало
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
            public static DoublyLinkedList<T> operator --(DoublyLinkedList<T> dll)//удаление первого
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
                    Console.Write(temp.Data+" ");
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

        }
        public static class StatisticOperation
        {
            public static int Sum(DoublyLinkedList<int> list)//сумма всех элементов списка
            {
                int sum = 0;
                DoublyNode<int> head = list.head;
                for (int i = 0; i < list.count; i++)
                {
                    sum += head.Data;
                    head = head.Next;
                }
                return sum;
            }

            public static int Difference(DoublyLinkedList<int> list)//разница между максимальным и минимальным
            {
                int difference=0;
                int max = Int32.MinValue;
                int min = Int32.MaxValue;
                DoublyNode<int> head = list.head;
                while (head != null)
                {
                    if (head.Data > max) max = head.Data;
                    head = head.Next;
                }
                head = list.head;
                while (head != null)
                {
                    if (head.Data < min) min = head.Data;
                    head = head.Next;
                }
                difference = max - min;
                return difference;
            }

            public static int Count(DoublyLinkedList<int> list)//кол-во элементов в списке
            {
                int count=0;
                DoublyNode<int> head = list.head;
                while (head != null)
                {
                    count++;
                    head = head.Next;
                }
                return count;
            }

            public static int CountUpper(this string str)//подсчёт заглавных букв в строке
            {
                int count = 0;
                foreach (char letter in str)
                {
                    if (Char.IsUpper(letter)) count++;
                }
                return count;
            }

        public static bool IsPereat(this DoublyLinkedList<int> list)//проверка на повторяющиеся элементы
        {
            DoublyNode<int> head = list.head;
            DoublyNode<int> head1 = head;
            while (head != null)
            {
                while (head1 != null)
                {
                    if (head1.Data == head.Data && head1 != head) return true;
                    head1 = head1.Next;
                }
                head = head.Next;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> List1 = new DoublyLinkedList<int>();
            List1.Add(1);
            List1 = 2 + List1;
            Console.WriteLine($"Список 1: ");
            List1.Out();
            DoublyLinkedList<int> List2 = new DoublyLinkedList<int>();
            List2.Add(1);
            List2.Add(2);
            Console.WriteLine();
            Console.WriteLine("Список 2: ");
            List2.Out();
            Console.WriteLine();
            if (List1 != List2) Console.WriteLine("Списки не равны");
            --List1;
            Console.WriteLine("Список 1 после удаления первого элемента: ");
            List1.Out();
            Console.WriteLine();
            DoublyLinkedList<int> List3 = new DoublyLinkedList<int>();
            List3 = List1 * List2;
            Console.WriteLine("Объединение двух списков");
            List3.Out();
            DoublyLinkedList<int>.Owner owner = new DoublyLinkedList<int>.Owner();
            DoublyLinkedList<int>.Date date = new DoublyLinkedList<int>.Date();
            Console.WriteLine();
            Console.WriteLine($"Сумма элементов третьего списка: {StatisticOperation.Sum(List3)}");
            Console.WriteLine($"Разница между максимальным и минимальным элементом в 3-м списке: {StatisticOperation.Difference(List3)}");
            Console.WriteLine($"Кол-во элементов списка №3: {StatisticOperation.Count(List3)}");
            string str = "СтРоКа";
            Console.WriteLine($"В строке '{str}' {str.CountUpper()} заглавных букв");
            if (List2.IsPereat()) Console.WriteLine("В списке List2 есть повторяющиеся элементы");
            else Console.WriteLine("В списке List2 нет повторяющихся элементов");
            if (List3.IsPereat()) Console.WriteLine("В списке List3 есть повторяющиеся элементы");
            else Console.WriteLine("В списке List3 нет повторяющихся элементов");
        }
    }
}
