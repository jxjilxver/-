using System;

namespace lab4
{
    class Program
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
                DoublyNode<T> head = list2.head;
                while (head != null)
                {
                    list1.tail.Next = head;
                    head.Previous = list1.tail;
                    list1.tail=head;
                    list1.count++;
                    head = head.Next;
                }
                return list1;
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

            public void Out()
            {
                DoublyNode<T> temp = head;
                while (temp != null)
                {
                    Console.Write(temp.Data+" ");
                    temp = temp.Next;
                }
            }
        }
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
            List1 = List1 * List2;
            Console.WriteLine("Объединение двух списков");
            List1.Out();
        }
    }
}
