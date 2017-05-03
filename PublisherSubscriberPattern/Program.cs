using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Example 1a
            // pointer to a function
            MethodPtr ptrObj = TestMethod;
            ptrObj.Invoke();

            // Example 1b
            // call back
            CallBackExample f1 = new CallBackExample();
            f1.wheretocall = CallHere; // Step 1
            f1.Search();

            // Example 1c
            // Multicast Delegate
            messages = new List<string>();
            MultiCastExample f2 = new MultiCastExample();
            f2.wheretocall += CallHereForConsole;
            f2.wheretocall += CallHereToWriteInternally;
            f2.wheretocall += CallHereToWriteToFile;
            f2.Search();

            // Example 1d
            // invoking from the outside
            MultiCastExample f3 = new MultiCastExample();
            f3.wheretocall += CallHereForConsole;
            f3.wheretocall.Invoke("Subscriber is sending the message!!!");// The client can invoke.
            f3.wheretocall = null; // The delegate can be modified.
            f3.wheretocall += CallHereToWriteInternally;
            f3.Search();

            // Example 1e
            // Using Event, Encapsulating the delegate
            EventEncaplsulationExample f4 = new EventEncaplsulationExample();
            f4.wheretocall += CallHereForConsole;

            // following 2 lines will Error 
            // f4.wheretocall.Invoke("Subscriber is sending the message!!!");
            // f4.wheretocall = null; // The delegate can be modified.

            // The Error is:
            //       "The event 'DelegateExamples.EventEncaplsulationExample.wheretocall' can only appear 
            //        on the left hand side of += or -= (except when used from within the type 'DelegateExamples.EventEncaplsulationExample')
            //        I:\SandBox\GeekQuiz\ConsoleApplication2\ConsoleApplication2\Program.cs	47	16	ConsoleApplication2"

            

            f4.wheretocall += CallHereToWriteInternally;
            f4.Search();


        }

        // Example 1a
        // 
        delegate void MethodPtr();

        static void TestMethod()
        {
            Console.WriteLine("Inside TestMethod");
        }

        // Example 1b
        // 
        static void CallHere(string message)
        {
            Console.WriteLine(message);
        }

        // Example 1c,d,e
        // 

        static List<string> messages { get; set; }

        static void CallHereToWriteToFile(string message)
        {
            
            System.IO.File.WriteAllText(@"c:\sometext.txt", message);
        }
        static void CallHereForConsole(string message)
        {
            Console.WriteLine(message);
        }
        static void CallHereToWriteInternally(string message)
        {
            messages.Add(message);
        }
    }
}
