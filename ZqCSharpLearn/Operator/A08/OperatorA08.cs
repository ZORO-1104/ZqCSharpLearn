using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 比较操作符
 */
namespace ZqCSharpLearn.Operator.A08
{
    class OperatorA08 : ICodeTest
    {
        public void Execute()
        {
            //Test01();
            Test02();
        }

        private void Test01()
        {
            int x1 = 5;
            double y1 = 4.0;
            var r1 = x1 > y1;
            Console.WriteLine(r1.GetType().FullName);//System.Boolean
            Console.WriteLine(r1);//True

            char c1 = 'A';
            char c2 = 'a';
            var r2 = c1 > c2;
            Console.WriteLine(r2);//False
            ushort u1 = (ushort)c1;
            ushort u2 = (ushort)c2;
            Console.WriteLine(u1);//65
            Console.WriteLine(u2);//97
        }

        private void Test02()
        {
            string s1 = "abc";
            string s2 = "Abc";

            Console.WriteLine(s1==s2);//false
            Console.WriteLine(s2.ToLower()==s2.ToLower());//true，不区分大小写

            //字符串的复杂比较
            //string.Compare()
        }
    }
}
