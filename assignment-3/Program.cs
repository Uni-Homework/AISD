using System.Diagnostics;

namespace assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sWatch = new Stopwatch();

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
                Console.WriteLine("4.Поиск способ 2 - interp search");
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

                            sWatch.Start();
                            int ans = BinarySearch(arr, tosearch);
                            sWatch.Stop();
                            TimeSpan tSpan;
                            tSpan = sWatch.Elapsed;
                            Console.WriteLine(tSpan.ToString());

                            if (ans == -1) Console.WriteLine("Элемент не найден!");
                            else Console.WriteLine($"Найден элемент {tosearch} на позиции {ans}!");

                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:// если нажата клавиша с цифрой 4
                        {
                            // действие 
                            AssignTosearch();

                            sWatch.Start();
                            int ans = InterpolationSearch(arr, tosearch);
                            sWatch.Stop();
                            TimeSpan tSpan;
                            tSpan = sWatch.Elapsed;
                            Console.WriteLine(tSpan.ToString());

                            if (ans == -1) Console.WriteLine("Элемент не найден!");
                            else Console.WriteLine($"Найден элемент {tosearch} на позиции {ans}!");
                            break;
                        }


                    default: break;
                }
                // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                System.Threading.Thread.Sleep(2000); // 2 сек.
            }
            while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc

        }

        // wip
        /// <summary>
        /// Возвращает индекс элемента со значением toFind или -1, если такого элемента не существует
        /// </summary>
        /// <param name="sortedArray">отсортированный список, в котором будем искать элемент</param>
        /// <param name="toFind">искомый элемнет</param>
        /// <returns>индекс искомого элемента</returns>
        public static int InterpolationSearch(int[] sortedArray, int toFind)
        {
            int mid;
            int low = 0;
            int high = sortedArray.Length - 1;

            // искомый элемент слева или справа от текущего расматриваемого диапазона
            while (sortedArray[low] < toFind && sortedArray[high] > toFind)
            {
                if (sortedArray[high] == sortedArray[low]) // Защита от деления на 0
                    break;
                // 
                mid = low + ((toFind - sortedArray[low]) * (high - low)) / (sortedArray[high] - sortedArray[low]);

                if (sortedArray[mid] < toFind)
                    low = mid + 1;
                else if (sortedArray[mid] > toFind)
                    high = mid - 1;
                else
                    return mid;
            }

            if (sortedArray[low] == toFind)
                return low;
            if (sortedArray[high] == toFind)
                return high;

            return -1; // Not found
        }

        // done!
        /// <summary>
        /// Возвращает индекс элемента со значением element или -1, если такого элемента не существует
        /// </summary>
        /// <param name="sortedArr">Отсортированный массив, в котором будем искать элемент</param>
        /// <param name="element">Искомый элемент</param>
        /// <returns>Индекс искомого элемента</returns>
        static int BinarySearch(int[] sortedArr, int element)
        {
            int n = sortedArr.Length;
            int low = 0, high = n - 1;

            // possible error
            int mid = (high + low) / 2;

            while (high - low > 1)
            {
                // искомый элемент посередине 
                if (sortedArr[mid] == element || sortedArr[mid + 1] == element)
                {
                    return sortedArr[mid] == element ? mid : mid + 1;
                }
                else
                {
                    // искомый элемент меньше (слева) от серединного
                    if (element < sortedArr[mid])
                    {
                        high = mid - 1;
                        mid = (high + low) / 2;
                    }
                    // искомый элемент больше (справа) от серединного 
                    else
                    {
                        low = mid + 1;
                        mid = (high + low) / 2;
                    }
                }
                // debug
                // Console.WriteLine();
                // trimNOut(sortedArr, low, high);
            }
            return -1;
        }

        /// <summary>
        /// outs the trim of an array
        /// </summary>
        /// <param name="arr">array to trim</param>
        /// <param name="a">index first element</param>
        /// <param name="b">index of last element (included)</param>
        private static void trimNOut(int[] arr, int a, int b)
        {
            Console.WriteLine();
            for (int i = a; i <= b; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
