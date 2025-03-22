using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2
{
    internal class TimSort
    {
        private static int[] InsertionSort(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                for(int j=i-1; j>=0; j--)
                {
                    if (v[j] > v[j + 1])
                    {
                        int tmp = v[j];
                        v[j] = v[j + 1];
                        v[j + 1] = tmp;
                        // Program.printArr(v);
                    }
                    else break;
                }
            }
            return v;
        }

        static int[] Sort(int[] nums)
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

            // TODO step1: https://habr.com/ru/companies/infopulse/articles/133303/
            int[,] subarrs;
            for(int i=0; i<n; i++)
            {

            }

            return nums;
        }
    }
}
