using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.A10
{
    internal class OOA10 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            ClassA c1 = new ClassA();
            //c1.Fun();//无法调用，因为ClassA的接口都显示实现了，必须转换为相应的接口才可调用
            ((IA)c1).Fun();//IA.Fun...
            ((IB)c1).Fun();//Ib.Fun...
        }
    }

    internal interface IA
    {
        void Fun();
    }

    internal interface IB
    {
        int Fun();
    }

    internal class ClassA : IA, IB
    {
        void IA.Fun()
        {
            Console.WriteLine("IA.Fun...");
        }

        int IB.Fun()
        {
            Console.WriteLine("IB.Fun...");
            return 0;
        }
    }
}