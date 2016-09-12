using NSpec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var ri = new RunnerInvocation(Assembly.GetExecutingAssembly().Location, "", false);
            ri.Run();
        }
    }
}
