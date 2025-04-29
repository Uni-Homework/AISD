using System.Collections;

public class Element<T>
{
    public T Data { get; set; }
    public Element<T> Next { get; set; }

    public Element(T data)
    {
        Data = data;
        Next = null;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}

public class Queue<T> : IEnumerable<T>
{
    private Element<T> front;
    private Element<T> rear;
    public int Count { get; private set; }

    public Queue()
    {
        front = rear = null;
        Count = 0;
    }

    public void Enqueue(T data)
    {
        Element<T> newElement = new Element<T>(data);

        if (rear == null) front = rear = newElement;
        else
        {
            rear.Next = newElement;
            rear = newElement;
        }

        Count++;
    }

    public T Dequeue()
    {
        if (front == null) throw new InvalidOperationException("Queue is empty");

        T data = front.Data;
        front = front.Next;
        if (front == null) rear = null;
        Count--;
        return data;
    }

    public T Peek()
    {
        if (front == null) throw new InvalidOperationException("Queue is empty");
        return front.Data;
    }

    public void Clear()
    {
        front = rear = null;
        Count = 0;
    }

    public bool IsEmpty()
    {
        return front == null;
    }

    public override string ToString()
    {
        if (IsEmpty()) return "Queue: empty";

        string result = "Queue: ";
        Element<T> current = front;
        while (current != null)
        {
            result += current.ToString() + " ";
            current = current.Next;
        }

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Element<T> current = front;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // создать объект пользовательского класса
        ConsoleKeyInfo K;

        // add queue
        Queue<int> queue = new Queue<int>();

        // add random instance
        Random r = new Random();
        do
        {
            // 15, 30
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine("1. Create queue");
            Console.WriteLine("2. Task 20");
            Console.WriteLine("3. Task 27");
            Console.WriteLine("4. Out the queue");
            K = Console.ReadKey(); //считывание кода вводимой клавиши
            switch (K.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: // если нажата клавиша с цифрой 1
                {
                    // действие
                    queue.Clear();
                    for (int i = 0; i < 10; i++) queue.Enqueue(r.Next(1, 5));
                    OutQueue(queue);
                    break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2: // если нажата клавиша с цифрой 2
                {
                    // действие
                    // 20

                    Console.WriteLine("Initial queue:");
                    OutQueue(queue);

                    int min = queue.Min();
                    Console.WriteLine($"Min: {min}");

                    Queue<int> newQueue = new Queue<int>();
                    while (!queue.IsEmpty())
                    {
                        newQueue.Enqueue(min);
                        newQueue.Enqueue(queue.Dequeue());
                    }

                    queue = newQueue;
                    Console.WriteLine("Result:");
                    OutQueue(queue);

                    break;
                }
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3: // если нажата клавиша с цифрой 3
                {
                    // действие
                    // 27
                    Console.WriteLine($"\nInitial queue:");
                    OutQueue(queue);

                    int max = queue.Max();
                    Console.WriteLine($"Max: {max}");

                    Queue<int> newQueue = new Queue<int>();
                    newQueue.Enqueue(max);
                    while (!queue.IsEmpty())
                    {
                        int el = queue.Dequeue();
                        if (el != max) newQueue.Enqueue(el);
                    }

                    queue = newQueue;
                    Console.WriteLine("Out queue: ");
                    OutQueue(queue);


                    break;
                }
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4: // если нажата клавиша с цифрой 4
                {
                    // действие
                    OutQueue(queue);
                    break;
                }
            }
            // Приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
            Thread.Sleep(2000); // 2 сек.
        } while (K.Key != ConsoleKey.Escape); // цикл заканчивается, если нажата клавиша Esc
    }

    /// <summary>
    /// outs a queue in the console
    /// </summary>
    /// <param name="inQueue">queue to out (copy)</param>
    private static void OutQueue(Queue<int> inQueue)
    {
        Console.WriteLine();
        Console.WriteLine(inQueue);
    }
}
