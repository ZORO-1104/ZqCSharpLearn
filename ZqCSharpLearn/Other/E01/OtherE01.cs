using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ZqCSharpLearn.Other.D01;

namespace ZqCSharpLearn.Other.E01
{
    internal class OtherE01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
            Test03();
        }

        private void Test03()
        {
            int x = 1;
            Console.WriteLine(x.ToString());

            object o = x;
            Console.WriteLine(o.ToString());
        }

        private void Test02()
        {
            object o1 = 11;
            Console.WriteLine(o1);
            Console.WriteLine(o1.GetType().FullName);
        }

        private void Test01()
        {
            ObjectStack os1 = new ObjectStack();
            os1.Push("Hello");
            os1.Push(3.25);
            os1.Push(10);
            os1.Push(true);
            os1.Push(new Func<int, int>(o => o + 1));

            object obj;
            obj = os1.Pop();
            while (obj != null)
            {
                Console.WriteLine($"{obj} \n {obj.GetType().Name } \n {obj.GetType().FullName }");
                Console.WriteLine();
                Console.WriteLine();

                obj = os1.Pop();
            }
        }
    }

    internal class ObjectStack
    {
        private const int Count = 10;
        private int pos = 0;
        private object[] values = new object[Count];

        public void Push(object o)
        {
            if (Count - 1 >= pos)
            {
                values[pos++] = o;
            }
        }

        public object Pop()
        {
            if (pos - 1 >= 0)
            {
                return values[--pos];
            }
            else
            {
                return null;
                //throw new Exception("No values in stack.");
            }
        }
    }
}