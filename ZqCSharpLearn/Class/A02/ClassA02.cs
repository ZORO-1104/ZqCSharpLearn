using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Class.A02
{
    internal class ClassA02 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 重写override和隐藏new的区别
        /// </summary>
        private void Test01()
        {
            Vehicle v1 = new RaceCar();
            v1.Move();//race car move

            Vehicle v2 = new GoodsCar();
            v2.Move();//car move （不输出goods car move）

            GoodsCar v3 = new GoodsCar();
            v3.Move();//goods car move
        }
    }

    internal class Vehicle
    {
        public virtual void Move()
        {
            Console.WriteLine("vehicle move");
        }
    }

    internal class Car : Vehicle
    {
        /// <summary>
        /// 重写父类的Move方法
        /// </summary>
        public override void Move()
        {
            Console.WriteLine("car move");
        }
    }

    internal class RaceCar : Car
    {
        /// <summary>
        /// 重写父类的Move方法
        /// </summary>
        public override void Move()
        {
            Console.WriteLine("race car move");
        }
    }

    internal class GoodsCar : Car
    {
        /// <summary>
        /// 隐藏父类的Move方法
        /// </summary>
        public new void Move()
        {
            Console.WriteLine("goods car move");
        }
    }
}