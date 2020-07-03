using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 显示类型转换
 * 1.cast (T)x
 * 2.Convert类
 */
namespace ZqCSharpLearn.Operator.A03
{
    class OperatorA03 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /*
         * 显示类型转换 (T)x  cast
         */
        public void Test01()
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

        /*
         * Convert类
         */
        public void Test02()
        {
            uint x1 = 100;
            ushort u1 = Convert.ToUInt16(x1);//运行正常

            uint x2 = 65537;
            ushort u2 = Convert.ToUInt16(x2);//运行报错，抛出异常 
            //异常为：System.OverflowException:“值对于 UInt16 太大或太小。”

            //但是用cast，即使用(T)x强制类型转换，并不会报错，
            //结果是对数据进行截取
        }
    }
}
