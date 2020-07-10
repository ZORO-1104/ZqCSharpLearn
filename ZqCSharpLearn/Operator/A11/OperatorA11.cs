using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 可空类型
 * ??操作符
 * 条件操作符
 */
namespace ZqCSharpLearn.Operator.A11
{
    class OperatorA11 : ICodeTest
    {
        public void Execute()
        {
            Test03();
        }

        //可空类型
        private void Test01()
        {
            Nullable<int> a = null;//相当于int? a = null;
            Console.WriteLine(a.HasValue);//False

            a = 100;
            Console.WriteLine(a.HasValue);//True
            Console.WriteLine(a);//100
        }

        //??代替
        private void Test02()
        {
            int? a = null;
            int b = a ?? 10;//a为空的时候，用10来替代它
            Console.WriteLine(a.HasValue);//False
            //Console.WriteLine(a.Value);//System.InvalidOperationException:“可为空的对象必须具有一个值。”
            Console.WriteLine(a);//输出空白
            Console.WriteLine(b);//10

            a = 15;
            int c = a ?? 12;
            Console.WriteLine(a.HasValue);//True
            Console.WriteLine(a.Value);//15
            Console.WriteLine(a);//15
            Console.WriteLine(c);//15
        }

        //条件操作符
        private void Test03()
        {
            int x = 80;
            //string str = x >= 60 ? "Pass" : "Fail";
            string str = (x >= 60) ? "Pass" : "Fail";//为了程序可读性更好，一般将条件用小括号括起来
            Console.WriteLine(str);
        }
    }
}
