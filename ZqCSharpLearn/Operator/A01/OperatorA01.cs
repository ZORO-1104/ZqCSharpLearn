using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 一元操作符
 * 1.按位取反
 * 2.取相反数
 * 3.前置操作
 * 
 */
namespace ZqCSharpLearn.Operator.A01
{
    class OperatorA01 : ICodeTest
    {
        public void Execute()
        {
            ClassA.SingleOperator_04();
        }
    }

    class ClassA
    {
        /*
         * 按位取反
         */
        public static void SingleOperator_01()
        {
            int x = 157;
            int y = ~x;//按位取反
            string strBinX = Convert.ToString(x, 2).PadLeft(32, '0');
            string strBinY = Convert.ToString(y, 2).PadLeft(32, '0');
            Console.WriteLine(strBinX);
            Console.WriteLine(strBinY);
            Console.WriteLine(y);

            int x2 = -150;
            int y2 = ~x2;
            Console.WriteLine(y2);
            /*
            输出结果：
            00000000000000000000000010011101
            11111111111111111111111101100010
            -158
            149
             */
        }

        /*
         * 取相反数
         */
        public static void SingleOperator_02()
        {
            int x = int.MinValue;
            int y = ~x;//按位取反
            int y2 = -x;//取相反数
            string strBinX = Convert.ToString(x, 2).PadLeft(32, '0');
            string strBinY = Convert.ToString(y, 2).PadLeft(32, '0');
            string strBinY2 = Convert.ToString(y2, 2).PadLeft(32, '0');
            Console.WriteLine(strBinX);
            Console.WriteLine(strBinY);
            Console.WriteLine(strBinY2);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(y2);

            /*
            输出结果：
            10000000000000000000000000000000
            01111111111111111111111111111111
            10000000000000000000000000000000
            -2147483648
            2147483647
            -2147483648
             */
        }

        /*
         * 取非的应用场景
         */
        public void SingleOperator_03()
        {
            //Student stu = new Student(null);
            Student stu = new Student("zoro");
            Console.WriteLine(stu.Name);
        }

        /*
         * 前置操作和后置操作
         * 自增，自减
         */
        public static void SingleOperator_04()
        {
            int x1 = 100;
            int y1 = 0;
            y1 = x1++;
            /*
             等价于（后置操作，先赋值，然后再调整）
             y1 = x1;
             x1 = x1 + 1;
             */
            Console.WriteLine(x1);//输出101
            Console.WriteLine(y1);//输出100

            int x2 = 100;
            int y2 = 0;
            y2 = x2--;
            /*
             等价于（后置操作，先赋值，然后再调整）
             y2 = x2;
             x2 = x2 - 1;
             */
            Console.WriteLine(x2);//输出99
            Console.WriteLine(y2);//输出100

            int x3 = 100;
            int y3 = 0;
            y3 = ++x3;
            /*
             等价于（前置操作，先调整，然后再赋值）
             x3 = x1 + 1;
             y3 = x3;
             */
            Console.WriteLine(x3);//输出101
            Console.WriteLine(y3);//输出101

            int x4 = 100;
            int y4 = 0;
            y4 = --x4;
            /*
             等价于（前置操作，先调整，然后再赋值）
             x4 = x4 - 1;
             y4 = x4;
             */
            Console.WriteLine(x4);//输出99
            Console.WriteLine(y4);//输出99
        }
    }

    class Student
    {
        public string Name;

        public Student(string initName)
        {
            //取非的应用场景
            if (!string.IsNullOrEmpty(initName))
            {
                this.Name = initName;
            }
            else
            {
                throw new ArgumentException("initName can not be null or empty.");
            }
        }
    }
}
