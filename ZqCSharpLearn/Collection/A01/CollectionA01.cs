using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Collection.A01
{
    internal class CollectionA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// IEnumerable和Enumerator枚举器
        /// </summary>
        private void Test01()
        {
            string str = "Hello";

            //获取枚举器
            IEnumerator ie = str.GetEnumerator();
            while (ie.MoveNext())//调用枚举器的MoveNext方法
            {
                char c = (char)ie.Current;//获取枚举器当前位置的元素（object类型，需要强制类型转换）
                Console.Write(c + " ");
            }

            //foreach语句，就是对上述语句的包装重写
            foreach (char c in str)
            {
                Console.Write(c + " ");
            }
        }
    }
}