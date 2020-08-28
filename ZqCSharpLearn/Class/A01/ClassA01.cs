using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Class.A01
{
    internal class ClassA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /// <summary>
        /// 类的索引器测试
        /// </summary>
        private void Test01()
        {
            World w = new World();
            w.ShowInfo();
            w[2] = "AAAA";
            w.ShowInfo();
            Console.WriteLine(w[3]);
        }

        /// <summary>
        /// 测试is（类型检查）操作符
        /// </summary>
        private void Test02()
        {
            World w = new World();
            object o1 = w;
            if (o1 is World w1)
            {
                Console.WriteLine(w1[2]);
            }
            else
            {
                w1 = new World();
            }

            //在这里w1也是有效的
            //w1的作用域目前在整个函数内，都是有效的
            Console.WriteLine(w1[2]);
        }
    }

    internal class World
    {
        private string[] contries = "China USA Japan India English".Split(' ');

        /*
         * 索引器
         */

        public string this[int index]
        {
            get
            {
                return contries.Length > index ? contries[index] : null;
            }

            set
            {
                if (contries.Length > index)
                {
                    contries[index] = value;
                }
            }
        }

        static World()
        {
        }

        public void ShowInfo()
        {
            foreach (var item in contries)
            {
                Console.Write($">>{item}  ");
            }
            Console.WriteLine();
        }
    }
}