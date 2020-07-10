using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 类型检测操作符
 * as和is
 */
namespace ZqCSharpLearn.Operator.A10
{
    class OperatorA10 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        //is操作符
        private void Test01()
        {
            object obj1 = new Teacher();
            if (obj1 is Teacher)
            {
                Teacher t = (Teacher)obj1;
                t.Teach();
            }

            Console.WriteLine(obj1 is Teacher);//true
        }

        //as操作符
        private void Test02()
        {
            object obj1 = new Teacher();

            //as操作符，如果obj1是否跟Teacher一样，是的话，则将地址赋给t，否则将null赋给t
            Teacher t = obj1 as Teacher;
            if (t != null)
            {
                t.Teach();
            }

            Console.WriteLine(obj1 as Teacher);//ZqCSharpLearn.Operator.A10.Teacher

        }
    }

    class Teacher
    {
        public void Teach()
        {
            Console.WriteLine("I teach programming...");
        }
    }
}
