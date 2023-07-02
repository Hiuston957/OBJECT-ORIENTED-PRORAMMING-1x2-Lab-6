/*
Asynchronous methods don’t block the current thread, so you can execute other
commands while the asynchronous code runs in the background. This is useful when
performing long operations, such as accessing large data or computing heavy functions.
✔ async Task / async Task<...> → denotes a method containing asynchronous code,
✔ Task.Run → makes a given part of code calculate asynchronously
✔ await → forces the current method to wait for the asynchronous code to finish,
while returning the control to the caller (the method outside, so it can go forward),
✔ Task.Wait() → blocks the execution of the current method until the asynchronous
task is finished (the method outside cannot go forward).
Be careful! If you skip or forget to use the await or Task.Wait commands, the method may
not finish before the program ends, therefore not finishing its job at all! Also, it is preferred
to use await, rather than Task.Wait, as await does not block the execution.
Links:
• https://www.pluralsight.com/guides/understand-control-flow-async-await
• https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await
• https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/
• https://stackoverflow.com/questions/13140523/await-vs-task-wait-deadlock
*/

using System;
using System.Threading.Tasks; // needed for asynchronous computation
namespace Ex_06_05
{
    class Program
    {
        const int printNumber = 500;
        static async Task Main(string[] args)
        {
            Task t = AsyncPrint();
            StandardPrint(); // this will run even before AsyncPrint finishes
            await t; // wait with next lines until Task t is finished
            Console.WriteLine("Done!");
        }
        /**********************************************************************/
        // Asynchronous printing
        static async Task AsyncPrint()
        {
            // for learning purposes, we start with a standard (synchronous) part
            for (int i = 0; i < printNumber; i++)
                Console.Write("*");
            // Task.Run creates an asynchronous part of code
            // await forces the method to wait for the asynchronous code to finish
            await Task.Run(() =>
            {
                for (int i = 0; i <= printNumber; i++)
                    Console.Write(i + " ");
            });
        }
        /**********************************************************************/
        // Standard printing
        static void StandardPrint()
        {
            for (int i = 0; i < printNumber; i++)
                Console.Write(".");
        }
    }
}