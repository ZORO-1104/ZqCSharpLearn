using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Other.C01
{
    internal class OtherC01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 协变测试
        /// 1.协变类型参数，该参数只能用于输出的位置（例如方法的返回值）
        /// 2.仅泛型接口和泛型委托支持协变类型参数（泛型类不支持协变类型参数）
        ///    在接口和委托的类型参数上指定out修饰符可将其声明为协变参数
        /// 3.（由于历史原因）数组支持协变
        /// </summary>
        private void Test01()
        {
            MyStackA<Cat> catStack = new MyStackA<Cat>();
            //MyStackA<Animal> animalStack = catStack;//编译报错

            MyStackB<Cat> catStackB = new MyStackB<Cat>();
            IPoppable<Animal> animalStackB = catStackB;//利用协变
            Animal a1 = animalStackB.Pop();

            //WashA(catStackB);
            //WashB(catStackB);
            WashC(catStackB);
        }

        private void WashA(MyStackA<Animal> animal)
        {
        }

        private void WashB(MyStackB<Animal> animal)
        {
        }

        private void WashC(IPoppable<Animal> animal)
        {
        }
    }

    internal class Animal
    {
    }

    internal class Cat : Animal
    {
    }

    internal class Dog : Animal
    {
    }

    internal class MyStackA<T>
    {
        private int position = 0;
        private T[] data = new T[10];

        public void Push(T obj)
        {
            data[position++] = obj;
        }

        public T Pop()
        {
            return data[--position];
        }
    }

    internal class MyStackB<T> : IPoppable<T>
    {
        private int position = 0;
        private T[] data = new T[10];

        public void Push(T obj)
        {
            data[position++] = obj;
        }

        public T Pop()
        {
            return data[--position];
        }
    }

    /// <summary>
    /// 协变类型参数T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPoppable<out T>
    {
        T Pop();
    }

    /// <summary>
    /// 逆变类型参数T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPushable<in T>
    {
        void Push(T obj);
    }
}