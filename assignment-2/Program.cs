using System.Data;

namespace assignment_2
{
    internal class Program
    {
        public static void printArr(int[] v)
        {
            foreach (int i in v) Console.Write("" + i + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];

            for(int i=0; i<n; i++) arr[i] = Convert.ToInt32(Console.ReadLine());

            arr = OddEvenSort(arr);

            printArr(arr);
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
}