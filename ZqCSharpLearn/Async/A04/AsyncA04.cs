/*
功能：不止关心是否执行完成，还要获取执行结果。返回 Task<TResult> 类型
    同时在异步方法中开启多个Task
------------------------
当异步方法中有多个 await 时，会依次执行所有的 Task，
只有当所有 Task 执行完成后才表示异步方法执行完成，当前线程才得以执行。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A04
{
    class AsyncA04 : ICodeTest
    {
        public void Execute()
        {
            ClassA classA = new ClassA();
            classA.CookDinner();
        }
    }

    class ClassA
    {
        public void CookDinner()
        {
            Console.WriteLine($"老婆开始做饭，线程Id为：{ GetThreadId() }");
            Console.WriteLine($"哎呀，没盐了，也没酱油了");
            Task task = CommandBuySomeThing();
            Console.WriteLine($"不管他继续炒菜，线程Id为：{ GetThreadId() }");
            Thread.Sleep(100);
            Console.WriteLine($"不用不行了，得等买回来，线程Id为：{ GetThreadId() }");

            //当异步方法中有多个 await 时，会依次执行所有的 Task，
            //只有当所有 Task 执行完成后才表示异步方法执行完成，当前线程才得以执行。
            task.Wait();//会等所有的异步任务执行完，才会继续向下执行（停止炒菜（阻塞线程））

            Console.WriteLine($"用了盐和酱油，炒的菜就是好吃，线程Id为：{ GetThreadId() }");

            Console.WriteLine($"老婆把饭做好了，线程Id为：{ GetThreadId() }");

        }

        private async Task CommandBuySomeThing()
        {
            Console.WriteLine($"这时我准备去买盐和酱油了，线程Id为：{GetThreadId()}");

            await Task.Run(() => {
                Console.WriteLine($"屁颠屁颠的去买盐，线程Id为：{GetThreadId()}");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"买盐完成{1.0 * (i + 1) / 5 * 100}%，线程Id为：{GetThreadId()}");
                }
            });

            await Task.Run(() => {
                Console.WriteLine($"屁颠屁颠的去买酱油，线程Id为：{GetThreadId()}");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine($"买酱油完成{1.0 * (i + 1) / 10 * 100}%，线程Id为：{GetThreadId()}");
                }
            });

            Console.WriteLine($"酱油和盐，都买完了，【异步方法执行结束】，线程Id为：{GetThreadId()}");
        }

        private int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
