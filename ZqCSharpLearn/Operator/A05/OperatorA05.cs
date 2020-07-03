using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Operator.A05
{
    class OperatorA05 : ICodeTest
    {
        public void Execute()
        {
            //Test01();
            //Test02();
            Test03();
        }

        /*
         * 乘法操作符
         */
        private void Test01()
        {
            var x1 = 3 * 4;
            Console.WriteLine(x1);
            Console.WriteLine(x1.GetType().FullName);

            var x2 = 3.0 * 4.0;
            Console.WriteLine(x2);
            Console.WriteLine(x2.GetType().FullName);

            //此处有 “数值提升”
            //3.0是double类型，4是int类型，但是结果为double类型
            //实际上，它是先把4的int类型提升为double类型（不丢失精度），然后再计算的。
            var x3 = 3.0 * 4;
            Console.WriteLine(x3);
            Console.WriteLine(x3.GetType().FullName);

            /*
            12
            System.Int32
            12
            System.Double
            12
            System.Double
             */
        }

        /*
         * 除法操作符
         */
        private void Test02()
        {
            //整数除法
            int x1 = 5;
            int y1 = 4;
            int z1 = x1 / y1;
            Console.WriteLine(z1);//1

            //整数除法，被除数为0，抛异常
            //System.DivideByZeroException:“尝试除以零。”
            //int x2 = 5;
            //int y2 = 0;
            //int z2 = x2 / y2;

            //浮点除法
            double x3 = 5.0;
            double y3 = 4.0;
            double z3 = x3 / y3;
            Console.WriteLine(z3);//1.25

            //浮点除法，被除数为0
            double x4 = 5.0;
            double y4 = 0;
            double z4 = x4 / y4;
            Console.WriteLine(z4);//∞
            x4 = -5.0;
            z4 = x4 / y4;
            Console.WriteLine(z4);//-∞

            Console.WriteLine(double.PositiveInfinity);//∞
            Console.WriteLine(double.NegativeInfinity);//-∞

            //数值提升的情况
            //(double)5，是强制类型转换，将5转换为5.0，
            //强制类型转换运算符优先级高于/除法运算符优先级
            //当一个double类型，除以int类型时，为了不丢失精度，会进行类型提升，自动将int类型的4转为double类型进行运算
            //故结果为1.25
            double x5 = (double)5 / 4;
            Console.WriteLine(x5);//1.25

            //括号改变了优先级
            double x6 = (double)(5 / 4);
            Console.WriteLine(x6);//1
        }

        /*
         * 取余操作符
         */
        private void Test03()
        {
            int x1 = 13;
            int y1 = 10;
            int z1 = x1 % y1;
            Console.WriteLine(z1);//3

            double x2 = 3.5;
            double y2 = 3.0;
            double z2 = x2 % y2;
            Console.WriteLine(z2);//0.5
        }
    }


}
