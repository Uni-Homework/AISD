namespace assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[0];
            int n = 0;
            int tosearch = 0;

            void AssignTosearch()
            {
                Console.WriteLine("\nВведите искомый элемент:");
                tosearch = Convert.ToInt32(Console.ReadLine());
            }

            // создать объект пользовательского класса
            ConsoleKeyInfo K;
            do
            {
                Console.Clear(); //очистка экрана перед выводом меню
                Console.WriteLine("1.Создать массив");
                Console.WriteLine("2.Вывести массив");
                Console.WriteLine("3.Поиск способ 1 - binary search");
                Console.WriteLine("4.Поиск способ 2");
                Console.WriteLine("Esc. Выход из программы");
                K = Console.ReadKey(); //считывание кода вводимой клавиши
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1: // если нажата клавиша с цифрой 1
                        {
                            // действие 
                            Console.WriteLine("\nВведите чило элементов в массиве:");
                            n = Convert.ToInt32(Console.ReadLine());

                            arr = new int[n];
                            Random r = new Random();
                            for (int i = 0; i < n; i++) arr[i] = r.Next(1000);
                            Array.Sort(arr);

                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:// если нажата клавиша с цифрой 2
                        {
                            // действие 
                            Console.WriteLine();
                            for (int i = 0; i < n; i++) Console.Write("" + arr[i] + " ");
                            
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:// если нажата клавиша с цифрой 3
                        {
                            // действие 
                            AssignTosearch();

                            int ans = BinarySearch(arr, tosearch);
                            if (ans == -1) Console.WriteLine("Элемент не найден!");
                            else Console.WriteLine($"Найден элемент {tosearch} на позиции {ans}!");

                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:// если нажата клавиша с цифрой 4
                        {

                            // действие 
                            AssignTosearch();
                            break;
                        }


                    default: break;
                }
                // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                System.Threading.Thread.Sleep(2000); // 2 сек.
            }
            while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc

        }

        static int BinarySearch(int[] sortedArr, int element)
        {
            int n = sortedArr.Length;
            int low = 0, mid = (n - 1) / 2, high = n - 1;

            while (low - high > 1)
            {
                if (sortedArr[mid] == element) return mid;
                else
                {
                    if (sortedArr[mid] > element)
                    {
                        low = mid + 1;
                        mid = (n - 1) / 2;
                    }
                    else
                    {
                        high = mid - 1;
                        mid = (n - 1) / 2;
                    }
                }
            }
            return -1;
        }
    }
}
