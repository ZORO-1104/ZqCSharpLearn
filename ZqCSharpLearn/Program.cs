using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZqCSharpLearn.Async.A01;
using ZqCSharpLearn.Async.A02;
using ZqCSharpLearn.Async.A03;
using ZqCSharpLearn.Async.A04;
using ZqCSharpLearn.Async.A05;
using ZqCSharpLearn.Async.A06;
using ZqCSharpLearn.Class.A01;
using ZqCSharpLearn.Class.A02;
using ZqCSharpLearn.Class.A03;
using ZqCSharpLearn.Delegate.A01;
using ZqCSharpLearn.MultiThread.A01;
using ZqCSharpLearn.MultiThread.A02;
using ZqCSharpLearn.MultiThread.A03;
using ZqCSharpLearn.MultiThread.B01;
using ZqCSharpLearn.MultiThread.B02;
using ZqCSharpLearn.MultiThread.B03;
using ZqCSharpLearn.MultiThread.B04;
using ZqCSharpLearn.MultiThread.B05;
using ZqCSharpLearn.OO.A01;
using ZqCSharpLearn.OO.K01;
using ZqCSharpLearn.OO.K02;
using ZqCSharpLearn.OO.K03;
using ZqCSharpLearn.OO.K04;
using ZqCSharpLearn.Operator.A01;
using ZqCSharpLearn.Operator.A02;
using ZqCSharpLearn.Operator.A03;
using ZqCSharpLearn.Operator.A04;
using ZqCSharpLearn.Operator.A05;
using ZqCSharpLearn.Operator.A06;
using ZqCSharpLearn.Operator.A07;
using ZqCSharpLearn.Operator.A08;
using ZqCSharpLearn.Operator.A09;
using ZqCSharpLearn.Operator.A10;
using ZqCSharpLearn.Operator.A11;
using ZqCSharpLearn.Statement.A01;
using ZqCSharpLearn.Statement.A02;
using ZqCSharpLearn.Statement.A03;
using ZqCSharpLearn.Try.A01;

namespace ZqCSharpLearn
{
    internal class Program
    {
        private static ICodeTest _ct = null;

        private static void Main(string[] args)
        {
            ExecuteTest();
        }

        private static void ExecuteTest()
        {
            //_ct = new DelegateA01();

            //_ct = new AsyncA01();
            //_ct = new AsyncA02();
            //_ct = new AsyncA03();
            //_ct = new AsyncA04();
            _ct = new AsyncA05();
            //_ct = new AsyncA06();

            //_ct = new OperatorA11();

            //_ct = new StatementA03();

            //_ct = new ClassA01();
            //_ct = new ClassA02();
            //_ct = new ClassA03();
            //_ct = new OOA01();
            _ct = new OOK01();
            _ct = new OOK02();
            _ct = new OOK03();
            _ct = new OOK04();

            //_ct = new MultiThreadA01();
            //_ct = new MultiThreadA02();
            //_ct = new MultiThreadA03();
            //_ct = new MultiThreadB01();
            //_ct = new MultiThreadB02();
            //_ct = new MultiThreadB03();
            //_ct = new MultiThreadB04();
            //_ct = new MultiThreadB05();

            //_ct = new TryA01();

            DoExecute();
        }

        private static void DoExecute()
        {
            _ct.Execute();
            Console.WriteLine($"【现在您可以按任意键，退出程序。。。】");
            Console.ReadLine();
        }
    }
}