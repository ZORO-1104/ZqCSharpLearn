using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 自定义类型转换
 * 有显示转换和隐式转换
 * 
 */
namespace ZqCSharpLearn.Operator.A04
{
    class OperatorA04 : ICodeTest
    {
        public void Execute()
        {
            Stone s = new Stone();
            s.Age = 5000;

            //自定义类型（显示）转换
            Monkey m = (Monkey)s;

            //自定义类型（隐式）转换
            //Monkey m = s;

            Console.WriteLine(m.Age);//输出 50
        }
    }

    //石头类
    class Stone
    {
        public int Age;

        /*
         * 显示类型转换（explicit）
         * 将Stone类型，转换为Monkey类型
         * 1.去掉public static explicit operator，看起来就是一个Monkey构造器
         * 2.隐式类型转换，只需将explicit写为implicit
         */
        public static explicit operator Monkey(Stone s)
        {
            Monkey m = new Monkey();
            m.Age = s.Age / 100;
            return m;
        }
    }

    //猴子类
    class Monkey
    {
        public int Age;
    }
}
