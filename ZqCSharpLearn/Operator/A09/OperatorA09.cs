using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * is类型检验操作符
 */
namespace ZqCSharpLearn.Operator.A09
{
    class OperatorA09 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /*
         * is 类型检测操作符
         * 检测的是变量所引用的实例的类型
         */
        private void Test01()
        {
            Teacher t = new Teacher();
            var r1 = t is Teacher;
            Console.WriteLine(r1.GetType().FullName);//System.Boolean
            Console.WriteLine(r1);//true
            Console.WriteLine(t is Human);//true
            Console.WriteLine(t is Animal);//true
            Console.WriteLine(t is Car);//false
            Console.WriteLine(t is object);//true

            Teacher t2 = null;
            Console.WriteLine(t2 is Teacher);//false
            //is类型检测操作符，检测的是变量所引用的实例的类型
        }
    }

    class Animal
    {

    }

    class Human:Animal
    {

    }

    class Teacher:Human
    {

    }

    class Car
    {

    }

}
