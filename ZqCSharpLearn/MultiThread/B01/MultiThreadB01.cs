using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B01
{
    internal class MultiThreadB01 : ICodeTest
    {
        public void Execute()
        {
            Test01();

            Test02();

            Test03();
        }

        /// <summary>
        /// 测试Wait方法（阻塞当前方法）
        /// </summary>
        private void Test03()
        {
            Task t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Test03,Time={DateTime.Now.ToString()}");
            });

            Console.WriteLine(t.IsCompleted);//false

            //t.Wait();//阻塞当前方法，直到任务完成（类似于调用线程对象中的Join方法）
            t.Wait(1000);//超时时间
            //CancellationToken ct = new CancellationToken();
            //t.Wait(1000, ct);

            Console.WriteLine(t.IsCompleted);//true
        }

        /// <summary>
        /// Task.Run创建的任务是“热”的任务（所以没有在Task.Run之后调用Start）
        /// </summary>
        private void Test01()
        {
            Task.Run(() =>
            {
                Console.WriteLine($"Test01,Time={DateTime.Now.ToString()}");
            });
        }

        /// <summary>
        /// 使用Task的构造器，创建“冷”的任务；之后调用Start方法，启动任务执行
        /// </summary>
        private void Test02()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine($"Test02,Time={DateTime.Now.ToString()}");
            });
            t.Start();
        }
    }
}