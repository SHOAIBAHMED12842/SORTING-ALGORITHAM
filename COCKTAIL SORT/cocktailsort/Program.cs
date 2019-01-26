using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cocktailsort
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("ENTER THE LENGTH OF ELEMENTS:");  //NUMBER LENGTH.....
                int numbers = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("ENTER THE MINIMUM RANGE:");          //MINIMUM RANGE....
                int range1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("ENTER THE MAXIMUM RANGE:");          //MAXIMUM RANGE....
                int range2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                COCKTAIL sort = new COCKTAIL();                    // CREATE OBJECT OF COCKTAIL CLASS...
                int[] array = new int[numbers];                   // INITIALIZE AN ARRAY.....
                array = sort.RANDOM(numbers, range1, range2);    // PASS LENGTH,MIN AND MAX TO RANDOM FUNCTION...
                Console.WriteLine();
                Console.WriteLine("RANDOM NUMBERS {0} UPTO MINIMUM:{1}:MAXIMUM:{2} ARE", numbers, range1, range2);
                sort.print(array);                                                 // PRINT RANDOM NUMBERS.......
                sort.Sorting(array);                                               // PASS ARRAY TO SORTING FUNCTION....
                Console.WriteLine();
                Console.WriteLine("AFTER APPLYING COCKTAIL SORT SORTED ELEMENT {1}:MAXIMUM:{2} ARE",numbers,range1,range2);
                Console.WriteLine();
                sort.print(array);                                                 // PRINT SORTED ARRAY....
            }
            catch (Exception E)                                        // EXCEPTION IF NOT ENTER DESIRE INPUT BY USER...
            {
                
                Console.WriteLine("{0}",E.Message);                                                              
            }
            
        }
    }
    class COCKTAIL
    {
        // TO GENERATE RANDOM NUMBERS
        public int[] RANDOM(int n,int min,int max)        // NUMBERS,MIN,MAX
        {
            Random rond = new Random();                  // BUILT IN RANDOM CLASS IN VISUAL STUDIO C#

            int[] RAND= new int[n];
            for (int t = 0; t < RAND.Length; t++)
            {
                RAND[t] = rond.Next(min,max);
            }
            return RAND;
        }
        // TO PRINT ELEMENTS
        public void print(int[] sort)                        
        {
            for (int t = 0; t < sort.Length; t++)
            {
                Console.WriteLine("{0} ELEMENT: {1}",t+1, sort[t]);
            }
        }
        // FOR SORTING
        public int[] Sorting(int[] element)
        {
            bool SORT = true;                 // INITIALIZES BOOL.....
            int start = 0;                    // STARTING LENGTH......
            int end = element.Length;         // ENDING LENGTH........

            while (SORT == true)
            {
                        // RESET THE SORT FLAG ON ENTERING THE LOOP, BECAUSE IT COULD BE TRUE FROM ARRAY PREVIOUS ITERATION
                SORT = false;
                                 // LOOP FROM LEFT TO RIGHT TO COMPARE THE ELEMENTS SAME AS THE BUBBLE SORT......

                for (int i = start; i < end - 1; ++i)     
                {
                    if (element[i] > element[i + 1])
                    {
                        // SWAP THE ELEMENT
                        int temp = element[i];
                        element[i] = element[i + 1];
                        element[i + 1] = temp;
                        SORT = true;
                    }
                }
                                             // IF NOTHING MOVED, THEN ARRAY IS SORTED........
                if (SORT == false)
                {
                    break;
                }
                    
                                // OTHERWISE, RESET THE SORT FLAG SO THAT IT CAN BE USED IN THE NEXT COMPARISION.........
                SORT = false;
                                // MOVE THE END POINT BACK BY ONE, BECAUSE  ELEMENT AT THE END IS LARGEST..............
                end = end - 1;

                                // FROM RIGHT TO LEFT, AGAIN COMPARE ELEMENT AS IN BUBBLE SORT............
                for (int t = end - 1; t >= start; t--)
                {
                    if (element[t] > element[t + 1])
                    {
                        // SWAP THE ELEMENT
                        int temp = element[t];
                        element[t] = element[t + 1];
                        element[t + 1] = temp;
                        SORT = true;
                    }
                }
                                     // INCREASE THE STARTING POINT, BECAUSE  ELEMENT AT THE START IS SMALLEST....
                start = start + 1;
            }
            return element;
        }
    }
   
}
