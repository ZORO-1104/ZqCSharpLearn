using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B03
{
    internal class MultiThreadB03 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 带返回值的线程
        /// 获取带返回值线程的Result属性，会阻塞当前方法
        /// </summary>
        private void Test01()
        {
            Func<string> func = () =>
            {
                Console.WriteLine("这是带返回值的线程");
                Thread.Sleep(3000);
                return DateTime.Now.ToString();
            };

            Task<string> t = Task.Run(func);

            Console.WriteLine($"{DateTime.Now}>>等待线程返回结果中，调用Result会阻塞当前方法");
            string result = t.Result;
            Console.WriteLine($"{DateTime.Now}>>线程返回结果，结果={result}");
        }
    }
}