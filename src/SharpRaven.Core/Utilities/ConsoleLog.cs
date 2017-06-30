using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Utilities
{
    class ConsoleLog : ILog
    {
        public void Error(string v)
        {
            Console.WriteLine(v);
        }
    }
}
