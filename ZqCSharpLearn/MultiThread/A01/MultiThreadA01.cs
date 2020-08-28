using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.A01
{
    internal class MultiThreadA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 用Thread实现多线程的简单示例
        /// </summary>
        private void Test01()
        {
            Thread t = new Thread(WriteY);
            t.Start();
            Console.WriteLine(t.IsBackground);
            t.Join();//阻塞当前所处的线程，直到该线程执行完成后才解除阻塞

            WriteX();
        }

        private void WriteX()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("|");
            }
        }

        private void WriteY()
        {
            Thread t = new Thread(WriteZ);
            t.Start();
            t.Join();//阻塞当前所处的线程，直到该线程执行完成后才解除阻塞

            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
        }

        private void WriteZ()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("/");
            }
        }
    }
}