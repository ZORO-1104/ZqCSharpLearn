using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Class.A03
{
    internal class ClassA03 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /// <summary>
        /// 测试调用父类的构造器
        /// </summary>
        private void Test01()
        {
            Vehicle v1 = new Car();
            v1.ShowInfo();

            Vehicle v2 = new Car("大众", "张三");
            v2.ShowInfo();
        }

        /// <summary>
        /// 测试构造器和字段的实例化顺序
        /// 1步. 从子类到父类  a步.初始化字段  b步.计算被调用的基类构造器中的参数
        /// 2步. 从基类到子类  a步.构造器方法体的执行
        /// </summary>
        private void Test02()
        {
            Vehicle v2 = new Car("大众", "张三");
            v2.ShowInfo();
        }
    }

    internal class Vehicle
    {
        protected string onwer = "";

        public Vehicle()
        {
            this.onwer = "未知拥有者";
        }

        public Vehicle(string onwer)
        {
            this.onwer = onwer;
        }

        public virtual void ShowInfo()
        {
        }
    }

    internal class Car : Vehicle
    {
        private string brand = "";

        /// <summary>
        /// 隐式调用父类的无参构造器
        /// </summary>
        public Car()//等价于【public Car():base()】
        {
            brand = "未知品牌";
        }

        /// <summary>
        /// 显式调用父类的有参构造器
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="onwer"></param>
        public Car(string brand, string onwer) : base(onwer + "WW")
        {
            this.brand = brand;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"onwer={base.onwer}, brand={this.brand}");
        }
    }
}