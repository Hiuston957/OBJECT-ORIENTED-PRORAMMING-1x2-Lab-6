/*
The standard(sequential) for loop runs using a single thread - each iteration is executed
only after the previous one has finished. With parallel for, iterations are run simultaneously,
using multiple threads – many iterations can be run at the same time, however not in
order. Using parallel programming can often significantly speed up calculations.
Links:
• https://dotnettutorials.net/lesson/parallel-for-method-csharp/
• https://www.dotnetperls.com/parallel-for
Creating threads takes time. This is why going parallel sometimes slows the computation.
It is always recommended to check the computation time - you can use for example the
built-in classes Stopwatch or DateTime. Stopwatch is more precise. Links:
• https://stackoverflow.com/questions/10418493/why-was-the-parallel-version-slowerthan-the-sequential-version-in-this-example
• https://stackoverflow.com/questions/2923283/stopwatch-vs-using-system-datetimenow-for-timing-events
*/


using System;
using System.Diagnostics; // needed for Stopwatch
using System.Threading.Tasks; // needed for Parallel.For
namespace Ex_06_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Logical processors: " + Environment.ProcessorCount);
            // Two large arrays
            int length = 100000; // try also 10 or 100
            int[] tab1 = new int[length];
            int[] tab2 = new int[length];
            ////////////////////////////////////////////////////////
            // Standard (sequential) for loop
            Console.WriteLine("Standard for");
            Stopwatch sw1 = Stopwatch.StartNew(); // start measuring time 1
            for (int i = 0; i < length; i++)
            {
                tab1[i] = SumNumbersUpTo(i);
            }
            sw1.Stop(); // finish measuring time 1
                        ////////////////////////////////////////////////////////
                        // Parallel for loop
            Console.WriteLine("Parallel for");
            Stopwatch sw2 = Stopwatch.StartNew(); // start measuring time 2
            Parallel.For(0, length, i =>
            {
                tab2[i] = SumNumbersUpTo(i);
            });
            sw2.Stop(); // finish measuring time 2
                        ////////////////////////////////////////////////////////
                        // Results
            Console.WriteLine("Standard time: " + sw1.Elapsed);
            Console.WriteLine("Parallel time: " + sw2.Elapsed);
        }
        /**********************************************************************/
        // This method sums all numbers from 0 to n
        static int SumNumbersUpTo(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += i;
            return sum;
        }
    }
}
