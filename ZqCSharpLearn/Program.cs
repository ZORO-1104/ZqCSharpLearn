using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZqCSharpLearn.Delegate.A01;

namespace ZqCSharpLearn
{
    class Program
    {
        private static ICodeTest _ct = null;

        static void Main(string[] args)
        {
            ExecuteTest();
        }

        static void ExecuteTest()
        {
            _ct = new DelegateA01();

            DoExecute();
        }

        static void DoExecute()
        {
            _ct.Execute();
            Console.ReadLine();
        }
    }
}
