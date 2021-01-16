using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubArrayDivideAndConquer
{
    class Program
    {
        static int maxCrossingSum(int[] array, int l, int m, int h)//MCS(m/2)
        { 
            int sum = 0;
            int left_sum = int.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum = sum + array[i];
                if (sum > left_sum)
                    left_sum = sum;
                
            }
            
            sum = 0;
            int right_sum = int.MinValue;
            for (int i = m + 1; i <= h; i++)
            {
                sum = sum + array[i];
                if (sum > right_sum)
                    right_sum = sum;
            }
            
            return left_sum + right_sum;
        }

        //Rasti me i mire => h - l = 1, Big Omega = O(1).
        //Rasti me i keq => h - l = n, Big O = O(n log(n)) kur zgjidhja e kalon mesin.
        //Kompleksiteti hapsinore => n + n/2 + n/4 + n/2^i, ku i => thellesia e perçarjes. 
        static int maxSubArraySum(int[] array, int l, int h)
        {
            if (h - l == 1)
                return Sum(array, l, h);
            
            int m = (l + h) / 2;
            
            return Math.Max(Math.Max(maxSubArraySum(array, l, m), maxSubArraySum(array, m + 1, h)), maxCrossingSum(array, l, m, h));
        }
        
        public static void Main()
        {
            Console.WriteLine("---------- Shuma maksimale e nenvargut duke perdorur tekniken 'Perçaj dhe sundo' --------------\n\n");
            Console.Write("Ju lutem jepni vargun e numrave, duke i ndare elementet me presje:: ");
            string inputArray = Console.ReadLine();
            int[] array = Array.ConvertAll(inputArray.Split(","), int.Parse);
            int n = array.Length;
            int maxSum = maxSubArraySum(array, 0, n - 1);//MSAS(log n)
            Console.Write("\nShuma maksimale e nenvargut eshte " + maxSum); //Per { -1, -4, 7, -3, -2, 1, 3, -8} shuma maksimale e nenvargut eshte 6(nenvargu {7, -3, -2, 1, 3});
            Console.ReadKey();
        }

        public static int Sum(int[] arr, int from, int to)//S(to-from)
        {
            int sum = 0;
            for (int i = from; i <= to; i++)
                sum += arr[i];
            return sum;
        }
    }
}
