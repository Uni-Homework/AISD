using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2
{
    internal class TimSort
    {
        // Реализация сортировки вставками.
        private static void InsertionSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= left && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        // Слияние двух массивов в один
        private static void Merge(int[] array, int l, int m, int r)
        {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];

            Array.Copy(array, l, left, 0, len1);
            Array.Copy(array, m + 1, right, 0, len2);

            int i = 0, j = 0, k = l;

            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < len1)
            {
                array[k] = left[i];
                k++;
                i++;
            }

            while (j < len2)
            {
                array[k] = right[j];
                k++;
                j++;
            }
        }

        public static int[] Sort(int[] nums)
        {
            // getting minrun
            int r = 0;
            int n = nums.Length;
            int nmnrn = n;

            // n > 64 (00111111) ? двигает биты вправо: 
            // если хоть 1 бит равен единице из любых, кроме старших шести,
            // то прибавить 1 к nmnrn - старшим 6 битам числа элементов в массиве
            // и получить minrun.
            // n = 1111111 (iter 1)
            while (nmnrn >= 64)
            {
                // r = r | (n & 1)
                // r = 0000000 | (1111111 & 0000001) = 0000000 | 0000001 = 0000001 = 1
                r |= nmnrn & 1;
                // n = n >> 1 = 1111111 >> 1 = 0111111
                nmnrn >>= 1;
            }
            int minrun = nmnrn + r;

            // Сортировка подмассивов
            for (int i = 0; i < n; i += minrun)
            {
                int end = Math.Min(i + minrun - 1, n - 1);
                InsertionSort(nums, i, end);
            } 

            // Слияние каждого подмассива, пока не получится один
            for (int size = minrun; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    if (mid < right)
                    {
                        Merge(nums, left, mid, right);
                    }
                }
            }
            return nums;
        }
    }
}
