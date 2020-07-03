using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Operator.A03
{
    class OperatorA03 : ICodeTest
    {
        /*
         * 显示类型转换 (T)x  cast
         */
        public void Execute()
        {
            ushort u = ushort.MaxValue;//65535
            Console.WriteLine(u);
            Console.WriteLine(Convert.ToString(u, 2).PadLeft(32, '0'));

            //byte b = u;//这样写会报错，因为ushort所占的字节比byte所占字节大，所以需要下面的显示类型转换
            byte b = (byte)u;//显示类型转换  操作符(T)x
            Console.WriteLine(b);
            Console.WriteLine(Convert.ToString(b, 2).PadLeft(32, '0'));

            sbyte b2 = (sbyte)u;//显示类型转换  操作符(T)x
            Console.WriteLine(b2);
            Console.WriteLine(Convert.ToString(b2, 2).PadLeft(32, '0'));

            Console.WriteLine("------------------");

            uint x = 65537;
            ushort u2 = (ushort)x;//显示类型转换 cast ，处理就是直接截掉
            Console.WriteLine(x);
            Console.WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
            Console.WriteLine(u2);
            Console.WriteLine(Convert.ToString(u2, 2).PadLeft(32, '0')); 

            /*
            输出结果
            65535
            00000000000000001111111111111111
            255
            00000000000000000000000011111111
            -1
            00000000000000001111111111111111
            ------------------
            65537
            00000000000000010000000000000001
            1
            00000000000000000000000000000001
             */
        }
    }
}
