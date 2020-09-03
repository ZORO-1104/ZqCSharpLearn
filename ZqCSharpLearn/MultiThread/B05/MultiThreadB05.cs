using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B05
{
    internal class MultiThreadB05 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /// <summary>
        /// 利用Task.Delay进行异步延时判断
        /// </summary>
        private void Test02()
        {
            Task<int> txxxx = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 100;
            });

            Task.Delay(5000).ContinueWith(t =>
            {
                if (txxxx.IsCompleted == true)
                {
                    Console.WriteLine($"task completed.");
                }
                else
                {
                    Console.WriteLine($"task not completed.");
                }
            });

            Console.WriteLine($"test02 is end.");
        }

        /// <summary>
        /// Task.Delay 是一个异步延时方法
        /// （Thread.Sleep是同步延时）
        /// </summary>
        private void Test01()
        {
            Console.WriteLine($"Time={DateTime.Now}，Test01 start running...");

            Task.Delay(5000).ContinueWith(t =>
            {
                Console.WriteLine($"Time={DateTime.Now}，delay running...");
                Thread.Sleep(5000);
                Console.WriteLine($"Time={DateTime.Now}，delay end...");
            });

            Console.WriteLine($"Time={DateTime.Now}，Test01 end...");
        }
    }
}