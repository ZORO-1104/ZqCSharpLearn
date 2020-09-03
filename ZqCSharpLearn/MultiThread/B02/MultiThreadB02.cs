using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.B02
{
    internal class MultiThreadB02 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /// <summary>
        /// 长任务，不用线程池任务
        /// </summary>
        private void Test02()
        {
            Action act = () =>
            {
                Console.WriteLine(">>>>我是长任务（长时间执行的任务）。");
                Thread.Sleep(2000);
                Console.WriteLine(">>>>长任务，应尽量避免使用线程池线程");
                Thread.Sleep(2000);
                Console.WriteLine(">>>>因为如果并行运行多个长时间运行的任务【特别是会造成阻塞的任务】，则会对性能造成影响");
            };
            Task t = Task.Factory.StartNew(act, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// 线程池任务适合短小的计算密集的任务
        /// </summary>
        private void Test01()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("----使用Task创建的任务，默认情况下CLR会将其运行在线程池上。");
                Thread.Sleep(1000);
                Console.WriteLine("----我是线程池上的任务");
                Thread.Sleep(1000);
                Console.WriteLine("----线程池上的任务，非常适合执行短小的计算密集的任务");
            });

            t.Start();
        }
    }
}