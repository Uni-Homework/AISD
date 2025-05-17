using System.Collections;

public class MyDoubleLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    private Node Head;
    private Node Tail;
    public uint Count;

    public MyDoubleLinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void AddFirst(T value)
    {
        Node newElement = new Node(value) { Next = Head };
        if (Head == null)
        {
            Tail = newElement;
            Head = newElement;
        }
        else
        {
            Head.Prev = newElement;
            newElement.Next = Head;
            Head = newElement;
        }
        Count++;
    }

    public void AddLast(T value)
    {
        Node newElement = new Node(value);
        if (Head == null)
        {
            Head = newElement;
            Tail = newElement;
        }
        else
        {
            Tail.Next = newElement;
            newElement.Prev = Tail;
            Tail = newElement;
        }
        Count++;
    }

    public bool Contains(T value)
    {
        if (Head == null) throw new Exception("List is empty");
        Node current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value)) return true;
            current = current.Next;
        }
        return false;
    }

    public T ElementByIndex(int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Index out of bounds");
        Node current = Head;
        int len = 0;
        while (current != null)
        {
            if (len == index) return current.Value;
            current = current.Next;
            len++;
        }
        return default;
    }

    private Node SearchElementByIndex(int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Invalid index");
        Node current = Head;
        int len = 0;
        while (current != null)
        {
            if (len == index) return current;
            current = current.Next;
            len++;
        }
        return default;
    }

    public void AddBefore(T el, int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Index out of bounds");
        if (index == 0)
        {
            AddFirst(el);
            return;
        }
        Node newEl = new Node(el);
        Node current = SearchElementByIndex(index);
        newEl.Next = current;
        newEl.Prev = current.Prev;
        current.Prev.Next = newEl;
        current.Prev = newEl;
        Count++;
    }

    public void AddAfter(T el, int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Index out of bounds");
        if (index == Count - 1)
        {
            AddLast(el);
            return;
        }
        Node newEl = new Node(el);
        Node current = SearchElementByIndex(index);
        newEl.Prev = current;
        newEl.Next = current.Next;
        current.Next.Prev = newEl;
        current.Next = newEl;
        Count++;
    }

    public T RemoveFirst()
    {
        if (Head == null) throw new Exception("List is empty");
        T value = Head.Value;
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head.Next.Prev = null;
            Head = Head.Next;
        }
        Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (Head == null) throw new Exception("List is empty");
        T value = Tail.Value;
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Tail.Prev.Next = null;
            Tail = Tail.Prev;
        }
        Count--;
        return value;
    }

    public T RemoveBefore(int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Index out of bounds");
        if (index == 0) throw new Exception("No element before index 0");
        if (index == 1) return RemoveFirst();
        Node current = SearchElementByIndex(index);
        T value = current.Prev.Value;
        current.Prev.Prev.Next = current;
        current.Prev = current.Prev.Prev;
        return value;
    }

    public T RemoveAfter(int index)
    {
        if (Head == null) throw new Exception("List is empty");
        if (index < 0 || index >= Count) throw new Exception("Index out of bounds");
        if (index == Count - 1) throw new Exception($"No elements after index {index}");
        if (index == Count - 2) return RemoveLast();
        Node current = SearchElementByIndex(index);
        T value = current.Next.Value;
        current.Next.Next.Prev = current;
        current.Next = current.Next.Next;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (Head == null) return "null";
        List<string> elements = new List<string>();
        Node current = Head;
        while (current != null)
        {
            elements.Add(current.Value.ToString());
            current = current.Next;
        }
        return string.Join(" ", elements);
    }

    public string Reverse()
    {
        if (Tail == null) return "null";
        List<string> elements = new List<string>();
        Node current = Tail;
        while (current != null)
        {
            elements.Add(current.Value.ToString());
            current = current.Prev;
        }
        return string.Join(" ", elements);
    }
}

class Program
{
    static MyDoubleLinkedList<int> InputListRandom(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException("n");
        MyDoubleLinkedList<int> list = new MyDoubleLinkedList<int>();
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            list.AddLast(rand.Next(-99, 100));
        }
        return list;
    }

    static void Main()
    {
        MyDoubleLinkedList<int> list = new MyDoubleLinkedList<int>();

        do
        {
            Console.Clear();
            Console.WriteLine("1. Add element to beginning");
            Console.WriteLine("2. Add element to end");
            Console.WriteLine("3. Display list");
            Console.WriteLine("4. Search by value");
            Console.WriteLine("5. Search by index");
            Console.WriteLine("6. Add element before index");
            Console.WriteLine("7. Add element after index");
            Console.WriteLine("8. Remove first element");
            Console.WriteLine("9. Remove last element");
            Console.WriteLine("10. Remove element before index");
            Console.WriteLine("11. Remove element after index");
            Console.WriteLine("12. Fill with random elements");
            Console.WriteLine("13. task 19");
            Console.WriteLine("14. task 24");
            Console.WriteLine("0. Exit");
            Console.Write("Choose action: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter value: ");
                        list.AddFirst(int.Parse(Console.ReadLine()));
                        break;
                    case "2":
                        Console.Write("Enter value: ");
                        list.AddLast(int.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("List: " + list);
                        break;
                    case "4":
                        Console.Write("Enter value: ");
                        Console.WriteLine(list.Contains(int.Parse(Console.ReadLine())));
                        break;
                    case "5":
                        Console.Write("Enter index: ");
                        Console.WriteLine("Value: " + list.ElementByIndex(int.Parse(Console.ReadLine())));
                        break;
                    case "6":
                        Console.WriteLine("List: " + list);
                        Console.Write("Index to insert before: ");
                        int beforeIndex = int.Parse(Console.ReadLine());
                        Console.Write("Enter value: ");
                        list.AddBefore(int.Parse(Console.ReadLine()), beforeIndex);
                        break;
                    case "7":
                        Console.WriteLine("List: " + list);
                        Console.Write("Index to insert after: ");
                        int afterIndex = int.Parse(Console.ReadLine());
                        Console.Write("Enter value: ");
                        list.AddAfter(int.Parse(Console.ReadLine()), afterIndex);
                        break;
                    case "8":
                        list.RemoveFirst();
                        break;
                    case "9":
                        list.RemoveLast();
                        break;
                    case "10":
                        Console.Write("Enter index before which to remove: ");
                        list.RemoveBefore(int.Parse(Console.ReadLine()));
                        break;
                    case "11":
                        Console.Write("Enter index after which to remove: ");
                        list.RemoveAfter(int.Parse(Console.ReadLine()));
                        break;
                    case "12":
                        Console.Write("List length: ");
                        int len = int.Parse(Console.ReadLine());
                        list = InputListRandom(len);
                        break;
                    case "13":
                        //19
                        // append all elements in reverse order

                        Console.WriteLine("List: " + list);

                        uint counter = 0;
                        uint initCount = list.Count;
                        while (counter < initCount)
                        {
                            list.AddLast(list.ElementByIndex((int)(initCount - counter - 1)));
                            counter++;
                        }
                        for(int i = 0; i < counter; i++) list.RemoveFirst();
                        Console.WriteLine("List: " + list);

                        break;
                    
                    case "14":
                        // 24
                        // Insert element into sorted list to keep ascending order


                        Console.WriteLine("List: " + list);
                        Console.Write("Enter value to insert: ");
                        int val = int.Parse(Console.ReadLine());

                        int insertIndex = 0;
                        bool inserted = false;
                        foreach (int element in list)
                        {
                            if (element > val)
                            {
                                list.AddBefore(val, insertIndex);
                                inserted = true;
                                break;
                            }
                            insertIndex++;
                        }

                        if (!inserted)
                            list.AddLast(val); // Если val больше всех

                        Console.WriteLine("New list: " + list);
                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        } while (true);
    }
}
