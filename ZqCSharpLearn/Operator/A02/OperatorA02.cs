using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 隐式类型转换
 * 1.小类型转大类型
 * 2.子类转父类
 * 
 */
namespace ZqCSharpLearn.Operator.A02
{
    class OperatorA02 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /*
         * 隐式类型转换
         * 小类型隐式转为大类型（因为不会丢失精度）
         */
        public void Test01()
        {
            int x1 = int.MaxValue;//标准整型
            long y1 = x1;//发生隐式类型转换
            /*
             因为x1类型与y1类型不一致，x1类型为标准整型（4字节），y1为长整型（8字节）
             故y1能够完全cover掉x1，所以此处发生隐式类型转换。
             */
        }

        /*
         * 测试 隐式类型转换
         * 子类向父类转换
         * 面向对象语言 中的 多态
         */
        public void Test02()
        {
            Teacher t = new Teacher();
            t.Eat();
            t.Speak();
            t.Teach();

            t.Name = "张三";
            Console.WriteLine(t.Name);//输出 张三

            Animal a = t;//该表达式的意思是，把t所引用的实例的地址赋给a
            /*
            在即时窗口中的测试结果，如下：
            未执行Animal a = t;语句前            
            &t
            0x012ff36c //t是临时变量，t在栈上的地址
                *&t: 0x033824a4 //t中所存储的数值（该值就是实例Teacher在堆中的地址）
            &a
            0x012ff368 //a是临时变量，a在栈上的地址
                *&a: 0x00000000 //a中所存储的数值，此时相当于为null
            
            执行完Animal a = t;语句后           
            &a
            0x012ff368 //a是临时变量，a在栈上的地址
                *&a: 0x033824a4 //t中所存储的数值，与t中所存储的数值相同，表示这两个引用类型变量在引用着同一个实例
             */

            a.Eat();
            /*        
            C#语言规定，当试图拿一个引用变量去访问它所引用着的实例的成员的时候，
            只能访问到这个变量的类型所拥有的成员，
            而不能这个变量所引用的实例所拥有的成员。
            所以，a中没有Speak()和Teach()方法
             */

            a.Name = "李四";
            //因为a与t，引用着同一个实例，所以修改a所引用的实例的属性，会影响t所引用的实例的属性
            Console.WriteLine(t.Name);//输出 李四
        }
    }

    class Animal
    {
        public string Name;

        public void Eat()
        {
            Console.WriteLine("animal eat ...");
        }
    }

    class Human:Animal
    {
        public void Speak()
        {
            Console.WriteLine("human speak ...");
        }
    }

    class Teacher:Human
    {
        public void Teach()
        {
            Console.WriteLine("teacher teach ...");
        }
    }
}
