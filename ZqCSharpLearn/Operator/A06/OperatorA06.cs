using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 加法操作符
 */
namespace ZqCSharpLearn.Operator.A06
{
    class OperatorA06 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            //注意“类型提升”
            var x = 3.0 + 4;
            Console.WriteLine(x.GetType().FullName);//System.Double
            Console.WriteLine(x);//7

            string s1 = "123";
            string s2 = "abc";
            string s3 = s1 + s2;
            Console.WriteLine(s3);//123abc
        }
    }
}
