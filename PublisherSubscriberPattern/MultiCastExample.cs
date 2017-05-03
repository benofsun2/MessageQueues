using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    class MultiCastExample
    {
        public delegate void WheretoCall(string status); // Step 1
        public WheretoCall wheretocall = null; // Step 2
        public void Search()
        {
            // File search is happening
            for (int i = 0; i < 100; i++)
            {
                string str = "File " + i;
                wheretocall(str); // Step 3
            }
        }
    }
}
