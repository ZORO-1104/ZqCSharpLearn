using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.A03
{
    internal class OOA03 : ICodeTest
    {
        public void Execute()
        {
            //Test01();
            Test02();
        }

        /// <summary>
        /// 隐藏Hide测试（子类隐藏父类的相同成员）
        /// 变量引用的类型是谁（而不是变量指向的实例类型是谁），这时候调用执行的就是谁的成员
        /// </summary>
        private void Test02()
        {
            BaseClassB bc1 = new BaseClassB();
            Console.WriteLine(bc1.Name);//BaseClassB

            BaseClassB bc2 = new SubClassB();
            Console.WriteLine(bc2.Name);//SubClassB

            BaseClassB bc3 = new DeepSubClassB();
            Console.WriteLine(bc3.Name);//SubClassB
            /*
             bc3的变量类型是BaseClassB，而它指向的对象类型为DeepSubClassB
             执行bc3.Name，则按照从BaseClassB开始，沿着继承链，直到DeepSubClassB，查找Name成员
             查找结果为：
                在BaseClassB中有Name成员，
                在SubClassB中有Name成员，
                在DeepSubClassB中没有Name成员（隐藏成员功能，其实表示它和它的父类没有关系，可以理解为截断了）
             所以此时调用SubClassB类型中的Name成员
             */

            //-------------------------------------

            SubClassB sc1 = new SubClassB();
            Console.WriteLine(sc1.Name);//SubClassB

            SubClassB sc2 = new DeepSubClassB();
            Console.WriteLine(sc2.Name);//SubClassB

            //-------------------------------------

            DeepSubClassB dc1 = new DeepSubClassB();
            Console.WriteLine(dc1.Name);//DeepSubClassB
        }

        /// <summary>
        /// 隐藏Hide测试（子类隐藏父类的相同成员）
        /// 变量引用的类型是谁（而不是变量指向的实例类型是谁），这时候调用执行的就是谁的成员
        /// </summary>
        private void Test01()
        {
            BaseClassA bc1 = new BaseClassA();
            Console.WriteLine(bc1.Name);//BaseClassA

            SubClassA sc1 = new SubClassA();
            Console.WriteLine(sc1.Name);//SubClassA

            BaseClassA bc2 = new SubClassA();
            Console.WriteLine(bc2.Name);//BaseClassA
            /*
             bc2的变量类型是BaseClassA，而它指向的对象类型为SubClassA
             执行bc2.Name，则按照从BaseClassA开始，沿着继承链，直到SubClassA，查找Name成员
             查找结果为：
                在BaseClassA中有Name成员，
                在SubClassA中没有Name成员（隐藏成员功能，其实表示它和它的父类没有关系，可以理解为截断了）
             所以此时调用BaseClassA类型中的Name成员
             */
        }
    }

    internal class BaseClassA
    {
        public string Name { get => "BaseClassA"; }
    }

    internal class SubClassA : BaseClassA
    {
        //隐藏父类中的字段Name
        public string Name { get => "SubClassA"; }

        //该写法与上一行等价
        //加上new修饰符，只是去掉了编译时的警告而已
        //如果主观上想要隐藏父类中的成员，则建议加上new，这样会更加明确，而不会让其他人以为误写了
        //new修饰符可以明确将你的意图告知编译器和其它开发者，重复的成员是有意义的
        //public new string Name { get => "SubClassA"; }
    }

    internal class BaseClassB
    {
        public virtual string Name { get => "BaseClassB"; }
    }

    internal class SubClassB : BaseClassB
    {
        //重写父类中的字段Name
        public override string Name { get => "SubClassB"; }
    }

    internal class DeepSubClassB : SubClassB
    {
        //覆盖父类中的字段Name
        public string Name { get => "DeepSubClassB"; }

        //该写法与上一行等价
        //加上new修饰符，只是去掉了编译时的警告而已
        //如果主观上想要隐藏父类中的成员，则建议加上new，这样会更加明确，而不会让其他人以为误写了
        //public new string Name { get => "DeepSubClassB"; }
    }
}