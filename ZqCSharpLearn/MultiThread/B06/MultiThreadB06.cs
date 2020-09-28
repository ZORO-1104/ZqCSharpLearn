using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B06
{
    internal class MultiThreadB06 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 编写异步函数 Async await
        /// </summary>
        private void Test01()
        {
            Console.WriteLine($"A1,Start,Time={DateTime.Now}");
            Go(10);
            Console.WriteLine($"A1,End,Time={DateTime.Now}");

            /*
            A1,Start,Time=2020/9/4 9:47:03
            B1,Start,Time=2020/9/4 9:47:03
            C1,Start,Time=2020/9/4 9:47:03
            A1,End,Time=2020/9/4 9:47:03
            150
            C1,End,Time=2020/9/4 9:47:06
            Done!
            B1,End,Time=2020/9/4 9:47:06
             */
        }

        private async Task PrintAnswer(int x)
        {
            Console.WriteLine($"C1,Start,Time={DateTime.Now}");
            await Task.Delay(3000);
            int result = 15 * x;
            Console.WriteLine(result);
            Console.WriteLine($"C1,End,Time={DateTime.Now}");
        }

        private async void Go(int a)
        {
            await PrintAnswer(a);
            Console.WriteLine($"B1,Start,Time={DateTime.Now}");
            Console.WriteLine("Done!");
            Console.WriteLine($"B1,End,Time={DateTime.Now}");
        }
    }
}