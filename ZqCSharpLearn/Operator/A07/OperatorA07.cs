using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 移位操作符
 * 注意溢出问题
 * 注意补位数值问题
 */
namespace ZqCSharpLearn.Operator.A07
{
    class OperatorA07 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            int x1 = 7;
            int y1 = x1 << 1;
            int z1 = x1 >> 1;

            Console.WriteLine(Convert.ToString(x1,2).PadLeft(8,'0'));
            Console.WriteLine(Convert.ToString(y1,2).PadLeft(8,'0'));
            Console.WriteLine(Convert.ToString(z1,2).PadLeft(8,'0'));

            //左移1位，就是乘2
            //右移1位，就是除2
            Console.WriteLine(x1);//7
            Console.WriteLine(y1);//14
            Console.WriteLine(z1);//3

            /*
            00000111
            00001110
            00000011
            7
            14
            3
             */
        }

    }
}
