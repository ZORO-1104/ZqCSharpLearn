/*
功能：不止关心是否执行完成，还要获取执行结果。返回 Task<TResult> 类型
--------------------
1) 以上代码 task.Result 会阻塞当前线程，与 task.Wait() 类似。
2) 注意：与前面返回类型为 Task 的 CommandOpenMainsSwitch() 方法一样，
虽然 CommandBuySalt() 方法返回类型为 Task<string>，
但是我们的返回语句是 return 字符串。
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A03
{
    internal class AsyncA03 : ICodeTest
    {
        public void Execute()
        {
            ClassA classA = new ClassA();
            classA.CookDinner();
        }
    }

    internal class ClassA
    {
        public void CookDinner()
        {
            Console.WriteLine($"老婆开始做饭，线程Id为：{ GetThreadId() }");
            Console.WriteLine($"哎呀，没盐了");
            Task<string> task = CommandBuySalt();
            Console.WriteLine($"不管他继续炒菜，线程Id为：{ GetThreadId() }");
            Thread.Sleep(100);
            Console.WriteLine($"不用盐不行了，得等盐买回来，线程Id为：{ GetThreadId() }");

            string result = task.Result;    //必须要用盐了，等我把盐回来（停止炒菜（阻塞线程））

            Console.WriteLine($"用了盐炒的菜就是好吃【{result}】，线程Id为：{ GetThreadId() }");

            Console.WriteLine($"老婆把饭做好了，线程Id为：{ GetThreadId() }");
        }

        private async Task<string> CommandBuySalt()
        {
            Console.WriteLine($"这时我准备去买盐了，线程Id为：{GetThreadId()}");

            var t = await Task.Run(() =>
            {
                Console.WriteLine($"屁颠屁颠的去买盐，线程Id为：{GetThreadId()}");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"买盐完成{1.0 * (i + 1) / 5 * 100}%，线程Id为：{GetThreadId()}");
                }

                return "盐买回来了，顺便我还买了一包烟";
            });

            Console.WriteLine($"买盐完成，线程Id为：{GetThreadId()}");

            return t;
        }

        private int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}