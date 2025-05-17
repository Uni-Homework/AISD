using System.Collections;

namespace lab_06;

public class DoublyNode<T>
{
    public DoublyNode(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}


public class Deque<T> : IEnumerable<T>
{
    private DoublyNode<T> _head;
    private DoublyNode<T> _tail;
    public int Count { get; private set; } = 0;

    public void AddLast(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        
        if(_head == null) _head = newNode;
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
        }

        _tail = newNode;
        Count++;
    }

    // test
    public void AddFirst(T data)
    {
        DoublyNode<T> node = new DoublyNode<T>(data);
        
        if(_head == null) _head = node;
        else
        {
            _head.Next = node;
            node.Previous = _head;
        }
        _head = node;
        Count++;
        
    }


    public T RemoveFirst()
    {
        if (Count == 0)
            throw new InvalidOperationException();
        T output = _head.Data;
        if(Count==1)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Previous = null;
        }
        Count--;
        return output;
    }
    
    public T RemoveLast()
    {
        if (Count == 0) throw new InvalidOperationException();
        T output = _tail.Data;
        if (Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }
        Count--;
        return output;
    }
    
    public T First
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _head.Data;
        }
    }
    public T Last
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _tail.Data;
        }
    }

    public bool IsEmpty { get { return Count == 0; } }

    public void Clear()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public bool Contains(T data)
    {
        DoublyNode<T> current = _head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        DoublyNode<T> current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}