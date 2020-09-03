using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B04
{
    internal class MultiThreadB04 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            //Test02();
        }

        /// <summary>
        /// awaiter.OnCompleted实现线程的延续
        /// </summary>
        private void Test01()
        {
            Task<int> t = Task.Run(() =>
            {
                int ret = Enumerable.Range(2, 800000).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
                Console.WriteLine($"线程完成计算的时间：{DateTime.Now}");
                return ret;
            });

            //Task<int> t = Task.Run(() =>
            //     Enumerable.Range(2, 300000).Count(n =>
            //        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0))
            //);

            //var awaiter = t.GetAwaiter();
            var awaiter = t.ConfigureAwait(false).GetAwaiter();
            Console.WriteLine($"完成awaiter创建的时间：{DateTime.Now}");
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine($"进入OnCompleted的时间：{DateTime.Now}");
                //int result = awaiter.GetResult();
                int result = t.Result;//这样也可以获取结果 int result = awaiter.GetResult();
                Console.WriteLine($"时间：{DateTime.Now}，result={result}");
            });

            Console.WriteLine("标志记录01");
            Console.ReadLine();

            //Task<int> t = Task.Run(() =>
            //{
            //    return Enumerable.Range(2, 300000).Count(n =>
            //    {
            //        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i =>
            //            {
            //                n % i > 0;
            //            });
            //    });
            //});
        }

        /// <summary>
        /// Task.ContinueWith实现线程的延续
        /// </summary>
        private void Test02()
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine($"t1.Begin:{DateTime.Now}");
                Thread.Sleep(2000);
                Console.WriteLine($"t1:{DateTime.Now}");
            });
            t1.Start();

            Task t2 = t1.ContinueWith(t =>
            {
                Console.WriteLine($"t1.Continue.Begin:{DateTime.Now}");
                Thread.Sleep(2000);
                Console.WriteLine($"t1.Continue:{DateTime.Now}");
            });

            Task t3 = t2.ContinueWith(t =>
            {
                Console.WriteLine($"t2.Continue.Begin:{DateTime.Now}");
                Thread.Sleep(2000);
                Console.WriteLine($"t2.Continue:{DateTime.Now}");
            });

            Task t4 = t3.ContinueWith(t =>
            {
                Console.WriteLine($"t3.Continue.Begin:{DateTime.Now}");
                Thread.Sleep(2000);
                Console.WriteLine($"t3.Continue:{DateTime.Now}");
            });

            t4.ContinueWith(t =>
            {
                Console.WriteLine($"t4.Continue.Begin:{DateTime.Now}");
                Thread.Sleep(2000);
                Console.WriteLine($"t4.Continue:{DateTime.Now}");
            });
        }
    }
}