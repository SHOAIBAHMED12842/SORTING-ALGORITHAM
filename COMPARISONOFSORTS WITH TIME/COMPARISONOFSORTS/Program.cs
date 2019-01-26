using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace COMPARISIONOFSORTS
{
    class Program
    {
        static void Main(string[] args)
        {
            long range;
            Console.Write("ENTER HOW MANY NUMBERS ARE SORTED:");
            range = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("");
            rndom rndm = new rndom();
            rndm.SortComparision(range);
        }
        public void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }
        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public void cocktailSort(int[] a)
        {
            bool swapped = true;
            int start = 0;
            int end = a.Length;

            while (swapped == true)
            {

                // reset the swapped flag on entering the 
                // loop, because it might be true from a 
                // previous iteration. 
                swapped = false;

                // loop from bottom to top same as 
                // the bubble sort 
                for (int i = start; i < end - 1; ++i)
                {
                    if (a[i] > a[i + 1])
                    {
                        int temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                    }
                }

                // if nothing moved, then array is sorted. 
                if (swapped == false)
                    break;

                // otherwise, reset the swapped flag so that it 
                // can be used in the next stage 
                swapped = false;

                // move the end point back by one, because 
                // item at the end is in its rightful spot 
                end = end - 1;

                // from top to bottom, doing the 
                // same comparison as in the previous stage 
                for (int i = end - 1; i >= start; i--)
                {
                    if (a[i] > a[i + 1])
                    {
                        int temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                    }
                }

                // increase the starting point, because 
                // the last stage would have moved the next 
                // smallest number to its rightful spot. 
                start = start + 1;
            }
        }
    }
    public class rndom
    {
        public void SortComparision(long n)
        {
            Random rond = new Random();

            int[] ARRAY = new int[n];
            for (int S = 0; S < ARRAY.Length; S++)
            {
                ARRAY[S] = rond.Next(100000);
            }
            //Console.WriteLine("INSERTION SORT");
            Stopwatch timeI = new Stopwatch();
            int variable;
            timeI.Start();
            for (int R = 0; R < ARRAY.Length - 1; R++)
            {
                for (int IN = R + 1; IN > 0; IN--)
                {
                    if (ARRAY[IN - 1] > ARRAY[IN])
                    {
                        variable = ARRAY[IN - 1];
                        ARRAY[IN - 1] = ARRAY[IN];
                        ARRAY[IN] = variable;
                    }
                }
            }
            timeI.Stop();
            //Console.WriteLine("BUBBLESORT SORT");
            Stopwatch timeB = new Stopwatch();
            int variable1;
            bool noswap = false;
            timeB.Start();
            for (int R = 0; R < ARRAY.Length - 1; R++)
            {
                for (int IN = 0; IN < ARRAY.Length - 1 - R; IN++)
                {
                    if (ARRAY[IN] > ARRAY[IN + 1])
                    {
                        variable1 = ARRAY[IN + 1];
                        ARRAY[IN + 1] = ARRAY[IN];
                        ARRAY[IN] = variable1;
                        noswap = false;
                    }
                    if (noswap == true)
                    {
                        break;
                    }
                }
            }
            timeB.Stop();
            //Console.WriteLine("SELECTION SORT");
            Stopwatch timeS = new Stopwatch();
            int variable2;
            timeS.Start();
            for (int R = 0; R < ARRAY.Length - 1; R++)
            {
                for (int IN = R + 1; IN < ARRAY.Length; IN++)
                {
                    if (ARRAY[R] > ARRAY[IN])
                    {
                        variable2 = ARRAY[IN];
                        ARRAY[IN] = ARRAY[R];
                        ARRAY[R] = variable2;
                    }
                }
            }
            timeS.Stop();
            //Console.WriteLine("QUICK SORT");
            Program quick = new Program();
            Stopwatch timeQ = new Stopwatch();
            timeQ.Start();
            quick.Quick_Sort(ARRAY, 0, ARRAY.Length - 1);
            timeQ.Stop();
            Stopwatch timeC = new Stopwatch();
            timeC.Start();
            quick.cocktailSort(ARRAY);
            timeC.Stop();
            Console.WriteLine("Bubble Sort :{0}", timeB.Elapsed);
            Console.WriteLine("Insertion Sort :{0}", timeI.Elapsed);
            Console.WriteLine("Selection Sort :{0}", timeS.Elapsed);
            Console.WriteLine("Quick Sort :{0}", timeQ.Elapsed);
            Console.WriteLine("Cocktail shaker Sort :{0}", timeC.Elapsed);
            Console.WriteLine("Bubble Sort :{0}", timeB.ElapsedMilliseconds);
            Console.WriteLine("Insertion Sort :{0}", timeI.ElapsedMilliseconds);
            Console.WriteLine("Selection Sort :{0}", timeS.ElapsedMilliseconds);
            Console.WriteLine("Quick Sort :{0}", timeQ.ElapsedMilliseconds);
            Console.WriteLine("Cocktail shaker Sort :{0}", timeC.ElapsedMilliseconds);
        }

    }
}
