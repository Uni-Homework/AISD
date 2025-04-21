using System.Diagnostics;
using assignment_2;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[0];
        int[] sorted = new int[0];
        Stopwatch sw = new Stopwatch();

        // создать объект пользовательского класса
        ConsoleKeyInfo K;
        do
        {
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine("1.Создать массив");
            Console.WriteLine("2.Вывести исходный массив");
            Console.WriteLine("3.Сортировка способ 1");
            Console.WriteLine("4.Сортировка способ 2");
            Console.WriteLine("5.Вывести отсортированный массив");
            Console.WriteLine("Esc. Выход из программы");
            K = Console.ReadKey(); //считывание кода вводимой клавиши
            switch (K.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    {
                        // действие
                        Console.WriteLine("\nВведите чило элементов в массиве:");
                        int n = Convert.ToInt32(Console.ReadLine());

                        // иницализация массива
                        arr = new int[n];

                        Random r = new Random();
                        for (int i = 0; i < n; i++) arr[i] = r.Next(1000);

                        // Console.WriteLine($"Вводите с каждой новой строки элемент массива (целое число) ({n} раз):");
                        // for (int i = 0; i < n; i++) arr[i] = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ваш массив: ");
                        printArr(arr);

                        break;
                    }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                {
                        // действие
                        Console.WriteLine("\nВаш массив: ");
                        printArr(arr);

                        break;
                    }
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                {
                        Console.WriteLine("\nСортировка чёт-нечёт.\nИсходный массив: ");
                        printArr(arr);

                        sw.Restart();
                        sorted = OddEvenSort(arr);
                        sw.Stop();

                        TimeSpan timeSpan = sw.Elapsed;

                        Console.WriteLine("Отсортированный массив: ");
                        printArr(sorted);
                        Console.WriteLine($"Время на сортировку: {timeSpan.ToString()}");

                        // действие
                        break;
                    }
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                {

                        // действие
                        Console.WriteLine("\nСортировка TimSort.\nИсходный массив: ");
                        printArr(arr);

                        sw.Restart();
                        sorted = TimSort.Sort(arr);
                        sw.Stop();

                        TimeSpan timeSpan = sw.Elapsed;

                        Console.WriteLine("Отсортированный массив: ");
                        printArr(sorted);
                        Console.WriteLine($"Время на сортировку: {timeSpan.ToString()}");
                        break;
                    }
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                {

                        // действие
                        Console.WriteLine("\nОтсортированный массив: ");
                        printArr(sorted);
                        break;
                    }
                default: break;
            }
            
        System.Threading.Thread.Sleep(2000);
        }
        while (K.Key != ConsoleKey.Escape);
    }

    public static void printArr(int[] v)
    {
        foreach (int i in v) Console.Write("" + i + " ");
        Console.WriteLine();
    }

    static int[] OddEvenSort(int[] nums)
    {
        bool isSorted = false;
        while (!isSorted)
        {
            isSorted = true;
            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                if (nums[i] > nums[i + 1])
                {
                    int tmp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = tmp;
                    isSorted = false;
                }
            }
            for (int i = 1; i < nums.Length - 1; i += 2)
            {
                if (nums[i] > nums[i + 1])
                {
                    int tmp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = tmp;
                    isSorted = false;
                }
            }
        }
        return nums;
    }
}