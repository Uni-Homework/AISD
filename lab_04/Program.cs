internal class Program
{
    private static void Main(string[] args)
    {
        // создать объект пользовательского класса
        ConsoleKeyInfo K;
        
        // add stack
        Stack<int> stack = new Stack<int>();
        int stackSize = 10;
        
        // add random instance
        Random r = new Random();
        do
        {
            // 15, 30
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine("1. Создать стек");
            Console.WriteLine("2. Номер Вашего задания 1");
            Console.WriteLine("3. Номер Вашего задания 2");
            Console.WriteLine("4. Вывести стек на экран");
            K = Console.ReadKey(); //считывание кода вводимой клавиши
            switch (K.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: // если нажата клавиша с цифрой 1
                {
                    // действие 
                    for(int i=0; i<stackSize; i++) stack.Push(r.Next(1000));
                    
                    OutStack(stack);
                    break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2: // если нажата клавиша с цифрой 2
                {
                    // действие 
                    // 4
                    Console.WriteLine("source stack:");
                    OutStack(stack);
                    Stack<int> helperStack = new Stack<int>();
                    int fEl = stack.Peek();
                    while (stack.Count > 0)
                    {
                        stack.Pop();
                        helperStack.Push(stack.Pop());
                    }
                    stack.Clear();
                    stack.Push(fEl);
                    while (helperStack.Count > 0) if(helperStack.Peek() != fEl) stack.Push(helperStack.Pop());
                    
                    Console.WriteLine("out stack:");
                    OutStack(stack);
                    
                    break;
                }
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3: // если нажата клавиша с цифрой 3
                {
                    // действие 
                    // 30
                    // find min, find max; pop min, max; 
                    Console.WriteLine("initial stack: ");
                    OutStack(stack);
                    int min, max;
                    min = max = stack.Peek();
                    Stack<int> helperStack = new Stack<int>();
                    while (stack.Count > 0)
                    {
                        int el = stack.Pop();
                        min = int.Min(min, el);
                        max = int.Max(max, el);
                        helperStack.Push(el);
                    }
                    
                    Console.WriteLine($"min: {min}, max: {max}");
                    
                    // stack empty
                    stack.Push(max);
                    for (int i = 0; i < stackSize; i++)
                    {
                        int el = helperStack.Pop();
                        if (el != min && el != max)
                        {
                            stack.Push(el);
                        }
                    }
                    stack.Push(min);
                    
                    OutStack(stack);
                    break;
                }
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4: // если нажата клавиша с цифрой 4
                {
                    // действие 
                    OutStack(stack);
                    Console.WriteLine();
                    break;
                }
            }
            // Приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
            Thread.Sleep(2000); // 2 сек.
        } while (K.Key != ConsoleKey.Escape); // цикл заканчивается, если нажата клавиша Esc
    }

    /// <summary>
    /// outs a stack in the console 
    /// </summary>
    /// <param name="inStack">stack to out (copy)</param>
    private static void OutStack(Stack<int> inStack)
    {
        // out stack (create stack)
        Stack<int> stack = new Stack<int>(inStack);
        Console.WriteLine("\nstack: ");
        while(stack.Count > 0) Console.Write($"{stack.Pop()} ");
        Console.WriteLine();
    }
}