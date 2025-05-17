using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

public class MyLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node Head = null;

    public void AddFirst(T value)
    {
        Node newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public override string ToString()
    {
        if (Head == null)
            return "list is empty";

        var result = new List<T>();
        Node current = Head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }
        return string.Join(" ", result);
    }

    public bool Contains(T value) // true or false
    {
        Node current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public T GetByIndex(int index) // return index
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("index cant't be negative");
        if (Head == null) throw new Exception("list is empty");

        Node current = Head;
        int currentIndex = 0;
        while (current != null)
        {
            if (currentIndex == index)
            {
                return current.Value;
            }
            current = current.Next;
            currentIndex++;
        }
        return default;
    }

    public void AddBefore(T el, int index)
    {
        if (Head == null)
            throw new Exception("list is empty");
        if (index < 0)
            throw new Exception("index cant't be negative");

        Node newEl = new Node(el);

        if (index == 0)
        {
            newEl.Next = Head;
            Head = newEl;
            return;
        }

        Node current = Head;
        int currentIndex = 0;

        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current == null || current.Next == null)
            throw new Exception("index not found");


        newEl.Next = current.Next;
        current.Next = newEl;
    }

    public void AddAfter(T el, int index)
    {
        if (Head == null)
            throw new Exception("list is empty");
        if (index < 0)
            throw new Exception("index can't be negative");

        Node newEl = new Node(el);
        Node current = Head;
        int currentIndex = 0;

        while (currentIndex < index)
        {
            current = current.Next;
            if (current == null)
                throw new Exception("index not found");
            currentIndex++;
        }

        newEl.Next = current.Next;
        current.Next = newEl;
    }

    public T RemoveFirst()
    {
        if (Head == null)
            throw new InvalidOperationException("list is empty");
        T el = Head.Value;
        Head = Head.Next;
        return el;
    }

    public T RemoveLast()
    {
        if (Head == null)
            throw new InvalidOperationException("list is empty");

        T el = Head.Value;
        if (Head.Next == null)
        {
            el = Head.Value;
            Head = null;
            return el;
        }

        Node current = Head;
        while (current.Next != null && current.Next.Next != null)
        {
            current = current.Next;
        }
        el = current.Next.Value;
        current.Next = null;
        return el;
    }

    public T RemoveBefore(int index)
    {
        if (Head == null)
            throw new Exception("list is empty");
        if (index < 0)
            throw new Exception("index can't be negative");
        if (index == 0)
            throw new Exception("can't delete an element before 0");

        Node prevPrev = null; 
        Node prev = null;    
        Node current = Head;
        int currentIndex = 0;

        while (currentIndex < index)
        {
            prevPrev = prev;
            prev = current;
            current = current.Next;
            if (current == null && currentIndex < index)
                throw new Exception($"index {index} out of bounds");
            currentIndex++;
        }

        if (prev == null)
            throw new Exception("invalid index");

        T removedData;

        if (index == 1)
        {
            removedData = Head.Value;
            Head = current; 
        }

        else
        {
            if (prevPrev == null)
                throw new Exception("index not found");

            removedData = prev.Value;
            prevPrev.Next = current; 
        }

        return removedData;
    }


    public T RemoveAfter(int index)
    {
        if (Head == null)
            throw new Exception("list is empty");
        if (index < 0)
            throw new Exception("index can't be negative");

        Node current = Head;
        int currentIndex = 0;

        while (currentIndex < index)
        {
            current = current.Next;
            if (current == null)
                throw new Exception("index not found");
            currentIndex++;
        }

        if (current.Next == null)
            throw new Exception($"no elements after index {index}");

        T removedData = current.Next.Value;

        current.Next = current.Next.Next;

        return removedData;
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
    public bool IsEmpty()
    {
        return Head == null;
    }
    public int Length()
    {
        int count = 0;
        Node current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
    public void Clear()
    {
        Head = null;
    }

}

class Program
{
    static MyLinkedList<int> Create(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException("n");
        MyLinkedList<int> b = new MyLinkedList<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"[{i}]");
            b.AddLast(int.Parse(Console.ReadLine()));
        }
        return b;
    }
    static MyLinkedList<int> InputListRandom(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException("n");
        MyLinkedList<int> b = new MyLinkedList<int>();
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            b.AddLast(rand.Next(-99,100));
        }
        return b;
    }
    static void Main()
    {
        MyLinkedList<int> list = InputListRandom(10);

        do
        {
            Console.Clear();
            Console.WriteLine("1. Add an element to the beginning of the list");
            Console.WriteLine("2. Add an element to the end of the list");
            Console.WriteLine("3. Display the list");
            Console.WriteLine("4. Search for an element by value");
            Console.WriteLine("5. Search for an element by index");
            Console.WriteLine("6. Add an element before a specified one");
            Console.WriteLine("7. Add an element after a specified one");
            Console.WriteLine("8. Remove an element from the beginning of the list");
            Console.WriteLine("9. Remove an element from the end of the list");
            Console.WriteLine("10. Remove an element before a specified one");
            Console.WriteLine("11. Remove an element after a specified one");
            Console.WriteLine("12. task 10");
            Console.WriteLine("13. task 30");
            
            Console.WriteLine("for any other input. Exit");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("input value: ");
                        list.AddFirst(int.Parse(Console.ReadLine()));
                        Console.WriteLine("list: " + list);
                        break;
                    case "2":
                        Console.Write("input value: ");
                        list.AddLast(int.Parse(Console.ReadLine()));
                        Console.WriteLine("list: " + list);
                        break;
                    case "3":
                        Console.WriteLine("list: " + list);
                        break;
                    case "4":
                        Console.Write("input value: ");
                        Console.WriteLine(list.Contains(int.Parse(Console.ReadLine())) );
                        break;
                    case "5":
                        Console.Write("input value: ");
                        try { Console.WriteLine("value: " + list.GetByIndex(int.Parse(Console.ReadLine()))); }
                        catch (ArgumentOutOfRangeException) { Console.WriteLine("element not found"); }
                        break;
                    case "6":
                        Console.WriteLine("list: " + list);
                        Console.Write("index to insert before it");
                        int beforeIND = int.Parse(Console.ReadLine());
                        Console.Write("input value: ");
                        list.AddBefore(int.Parse(Console.ReadLine()), beforeIND);
                        Console.WriteLine("list: " + list);
                        break;
                    case "7":
                        Console.WriteLine("list: " + list);
                        Console.Write("index to insert after it: ");
                        int afterIND = int.Parse(Console.ReadLine());
                        Console.Write("input value: ");
                        list.AddAfter(int.Parse(Console.ReadLine()), afterIND);
                        Console.WriteLine("list: " + list);
                        break;
                    case "8":
                        list.RemoveFirst();
                        Console.WriteLine("list: " + list);
                        break;
                    case "9":
                        list.RemoveLast();
                        Console.WriteLine("list: " + list);
                        break;
                    case "10":
                        Console.WriteLine("list: " + list);
                        Console.Write("insert index to delete element before it: ");
                        int removeBefore = int.Parse(Console.ReadLine());
                        try { 
                            list.RemoveBefore(removeBefore);
                            Console.WriteLine("list: " + list);
                        }
                        catch (InvalidOperationException) { Console.WriteLine("index not found or cannot be deleted"); }
                        break;
                    case "11":
                        Console.WriteLine("list: " + list);
                        Console.Write("insert index to delete element after it: ");
                        int removeAfter = int.Parse(Console.ReadLine());
                        try { 
                            list.RemoveAfter(removeAfter);
                            Console.WriteLine("list: " + list);
                        }
                        catch (InvalidOperationException) { Console.WriteLine("element not found or cannot be deleted"); }
                        break;
                    case "12":
                        // 10
                        // id really like to do that using hashsets
                        // but we're only allowed to use lists
                        // so enjoy that O(n^2) complexity lol
                        Console.WriteLine("list: " + list);

                        MyLinkedList<int> list2 = new MyLinkedList<int>();
                        foreach (int i in list) if (!list2.Contains(i)) list2.AddLast(i);
                        list = list2;
                        
                        Console.WriteLine("res: " + list);
                        
                        break;
                    case "13":
                        // 30
                        // add all elems from list2 to the end of list1
                        
                        Console.WriteLine("l1: " + list);
                        MyLinkedList<int> list3 = InputListRandom(10);
                        Console.WriteLine("l2: " + list3);

                        // so slow... damn...
                        while (list3.Length() > 0)
                        {
                            var remEl = list3.RemoveFirst();
                            list.AddLast(remEl);
                        }                        
                        
                        Console.WriteLine("res: " + list);
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();

        } while (true);
    }
}