using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Reflection.A01
{
    internal class ReflectionA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type t = asm.GetType("ZqCSharpLearn.Reflection.A01" + "." + "Student");
            MemberInfo[] memberInfoArray = t.GetMembers();
            foreach (var item in memberInfoArray)
            {
                Console.WriteLine(item);
            }

            //无参构造器
            object o1 = Activator.CreateInstance(t);

            //无参方法
            MethodInfo methodInfo = t.GetMethod("DoHomework");
            methodInfo.Invoke(o1, null);

            //有参构造器
            object[] parm1 = { "张三" };
            object o2 = Activator.CreateInstance(t, parm1);

            //有参方法
            MethodInfo methodInfo2 = t.GetMethod("DoHomeworkByCount");
            object[] parm2 = { 5 };
            methodInfo2.Invoke(o2, parm2);

            //静态方法
            BindingFlags bf1 = BindingFlags.Public | BindingFlags.Static;
            MethodInfo method3 = t.GetMethod("Show", bf1);
            method3.Invoke(null, null);
        }
    }

    internal class Student
    {
        private string name;

        public int Age { get; set; } = 0;

        public static int Count { get; set; } = 0;

        public static void Show()
        {
            Console.WriteLine($"Student Count = {Count}");
        }

        public Student()
        {
            this.name = "无名";
            Count++;
        }

        public Student(string name)
        {
            this.name = name;
            Count++;
        }

        public void DoHomework()
        {
            Console.WriteLine($"{name} is do homework...");
        }

        public void DoHomeworkByCount(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{name} is do homework...");
            }
        }
    }
}