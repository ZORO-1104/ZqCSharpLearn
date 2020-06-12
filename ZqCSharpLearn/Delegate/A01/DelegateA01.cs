/*
【测试功能】
1.委托基本使用
2.多播委托
3.委托关联同一个方法多次
4.委托调用时，按照方法的关联时的顺序来依次调用执行

【备注】
1.调试时，通过委托变量>>非公共变量>>invocationList，可以查看到当前委托变量中关联的方法信息。
2.invocationList的增长，当容量不够时，是成倍增长的；后面的空闲位置为null。
3.移除方法时，如果存在多个与被移除的方法相同，则会将后添加的方法移除。
4.移除一个不存在的方法，不会报错。
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
            Teacher th1 = new Teacher("卫青");

            //MyDelegate01 md1 = new MyDelegate01(st1.SayHello);
            MyDelegate01 md1 = st1.SayHello;//此处不可以用+=，因为此时委托还未实例化

            md1 += st1.DoHomework;//多播委托（一个委托可以关联多个方法）
            md1 += th1.TeachEnglish;
            md1 += st1.DoHomework;//同一个方法，可以添加多次，这样委托调用时就会执行多次

            //也可以添加静态方法
            md1 += Student.PlayGame;

            Student st2 = new Student("小李");
            Teacher th2 = new Teacher("老李");
            MyDelegate01 md2 = new MyDelegate01(st2.DoHomework);
            //md2 += st2.SayHello;
            md2 += th2.TeachEnglish;

            //将委托md2拥有的方法，添加到md1上
            md1 += md2;

            md1 -= st1.DoHomework;//会将后添加的方法移除
            md1 -= st2.SayHello;//移除一个不存在的方法，不会报错

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
            Console.WriteLine($"大家好，我是{this.GetType().Name}，我叫{_name}。。。");
        }

        public void DoHomework()
        {
            Console.WriteLine($"我叫{_name}，我是{this.GetType().Name}，我在做作业。。。");
        }

        public static void PlayGame()
        {
            Console.WriteLine($"我是static方法，我就是喜欢玩游戏。。。");
        }
    }

    class Teacher
    {
        private string _name;

        public Teacher(string name)
        {
            _name = name;
        }

        public void TeachEnglish()
        {
            Console.WriteLine($"我叫{_name}，我是{this.GetType().Name}，我教学生们学习英语。。。");
        }
    }
}
