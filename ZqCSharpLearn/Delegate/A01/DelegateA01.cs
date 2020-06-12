/*
【测试功能】
1.委托基本使用
2.多播委托
3.委托关联同一个方法多次
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Delegate.A01
{
    class DelegateA01 : ICodeTest
    {
        public void Execute()
        {
            Student st1 = new Student("王翦");
            MyDelegate01 md1 = new MyDelegate01(st1.SayHello);
            md1 += st1.DoHomework;//多播委托（一个委托可以关联多个方法）
            md1 += st1.DoHomework;//同一个方法，可以添加多次，这样委托调用时就会执行多次

            //md1.Invoke();//调用执行委托
            md1();//调用执行委托
        }
    }

    delegate void MyDelegate01();

    class Student
    {
        private string _name;

        public Student(string name)
        {
            _name = name;
        }

        public void SayHello()
        {
            Console.WriteLine($"大家好，我叫{_name}。。。");
        }

        public void DoHomework()
        {
            Console.WriteLine($"我叫{_name}，我在做作业。。。");
        }
    }
}
