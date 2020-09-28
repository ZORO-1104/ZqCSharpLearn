/*
功能：不关心结果，返回 void 类型
----------
以上代码在 CommandDropLitter() 方法上加了 async 修饰符，
并且使用 await 运算符开启了一个新的 Task 去执行另一个任务。
注意：当前线程遇到 await 时，则立刻跳回调用方法继续往下执行。
而 Task 执行完成之后将执行 await 之后的代码，并且与 await 之前的线程不是同一个。
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A01
{
    internal class AsyncA01 : ICodeTest
    {
        public void Execute()
        {
            ClassA classA = new ClassA();
            classA.CleanRoom();
        }
    }

    internal class ClassA
    {
        public void CleanRoom()
        {
            Console.WriteLine($"老婆开始打扫房间，线程Id为：{ GetThreadId() }");
            Console.WriteLine($"垃圾满了，快去扔垃圾");
            CommandDropLitter();
            Console.WriteLine($"不管他继续打扫，线程Id为：{ GetThreadId() }");
            Thread.Sleep(100);
            Console.WriteLine($"老婆把房间打扫好了，线程Id为：{ GetThreadId() }");
        }

        private async void CommandDropLitter()
        {
            Console.WriteLine($"这时我准备去扔垃圾，线程Id为：{GetThreadId()}");
            await Task.Run(() =>
            {
                Console.WriteLine($"屁颠屁颠的去扔垃圾，线程Id为：{GetThreadId()}");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"扔垃圾完成{1.0 * (i + 1) / 5 * 100}%，线程Id为：{GetThreadId()}");
                }
            });
            Console.WriteLine($"垃圾扔了还有啥吩咐，线程Id为：{GetThreadId()}");
        }

        private int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}