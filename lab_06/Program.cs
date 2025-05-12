using lab_06;

internal class Program
{
    private static void Main(string[] args)
    {
        // создать объект пользовательского класса
        ConsoleKeyInfo K;

        Deque<int> deque = new Deque<int>();

        // add random instance
        Random r = new Random();
        do
        {
            // 15, 30
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine("1. Create deque");
            Console.WriteLine("2. Task 18");
            Console.WriteLine("3. Task 22");
            Console.WriteLine("4. Out the deque");
            K = Console.ReadKey(); //считывание кода вводимой клавиши
            switch (K.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: // если нажата клавиша с цифрой 1
                {
                    // действие
                    deque.Clear();
                    for (int i = 0; i < 10; i++) deque.AddLast(r.Next(1, 20));
                    OutDeque(deque);
                    break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2: // если нажата клавиша с цифрой 2
                {
                    // действие
                    // 18
                    OutDeque(deque);
                    int sum = 0;
                    foreach (int i in deque) sum += i;

                    Deque<int> newDeque = new Deque<int>();
                    while (deque.Count > 0)
                    {
                        var element = deque.RemoveFirst();
                        newDeque.AddLast(element);
                        newDeque.AddLast(sum);
                    }
                    OutDeque(newDeque);
                    
                    break;
                }
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3: // если нажата клавиша с цифрой 3
                {
                    OutDeque(deque);
                    
                    Deque<int> newDeque = new Deque<int>();
                    while (deque.Count > 0)
                    {
                        var element = deque.RemoveLast();
                        newDeque.AddLast(element);
                    }
                    
                    OutDeque(newDeque);
                        
                    break;
                }
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4: // если нажата клавиша с цифрой 4
                {
                    // действие
                    OutDeque(deque);
                    break;
                }
            }
            // Приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
            Thread.Sleep(2000); // 2 сек.
        } while (K.Key != ConsoleKey.Escape); // цикл заканчивается, если нажата клавиша Esc
    }


    static void OutDeque(Deque<int> deque)
    {
        Console.WriteLine();
        foreach (var item in deque) Console.Write($"{item} ");
    }
}
