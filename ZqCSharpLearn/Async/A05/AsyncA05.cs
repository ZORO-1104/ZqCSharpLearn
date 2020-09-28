/*
功能：取消异步操作
借助 System.Threading.CancellationTokenSource
和 System.Threading.Tasks.CancellationToken 对象来完成
----------------------
1) 刚开始我以为调用 source.Cancel() 方法后会立即取消 Task 的执行，
仔细一想也不太可能。
如果需要在 Task 执行前或者执行期间完成取消操作，
我们自己写代码判断 cancellationToken.IsCancellationRequested 属性是否为 true
（该属性在调用 source.Cancel() 后或者 source.CancelAfter() 方法到达指定时间后为 true），
如果为 true 结束执行即可。
2) 这里所说的“传达取消请求”的意思是，
每个 Task 在执行之前都会检查 cancellationToken.IsCancellationRequested 属性是否为 true，
如果为 true 则不执行 Task，并将设置 Status、IsCompleted、IsCanceled 等。
3) 所以，在 Task 的源码中有这样一段代码

if (cancellationToken.IsCancellationRequested)
{
    // Fast path for an already-canceled cancellationToken
    this.InternalCancel(false);
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A05
{
    internal class AsyncA05 : ICodeTest
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

            CancellationTokenSource source = new CancellationTokenSource();
            Task<string> task = CommandBuySalt_CancleBySalt(source.Token);

            Console.WriteLine($"不管他继续炒菜，线程Id为：{ GetThreadId() }");
            Thread.Sleep(20);

            string result = "家里有盐";
            if (!string.IsNullOrEmpty(result))
            {
                source.Cancel();//传达取消请求
                Console.WriteLine($"家里有盐，不用买了，线程Id为：{ GetThreadId() }");
            }
            else
            {
                //如果已取消就不能再获得结果了（否则将抛出 System.Threading.Tasks.TaskCanceledException 异常）
                //你都叫我不要买了，我拿什么给你？
                result = task.Result;
            }

            Console.WriteLine($"有盐了，我继续炒菜，【{result}】，线程Id为：{ GetThreadId() }");

            Console.WriteLine($"老婆把饭做好了，线程Id为：{ GetThreadId() }");

            Console.WriteLine($"最终的任务：状态{task.Status}，是否完成{task.IsCompleted}" +
                $"，是否取消{task.IsCanceled}，是否失败{task.IsFaulted}，当前线程Id为：{GetThreadId()}");
        }

        private async Task<string> CommandBuySalt_CancleBySalt(CancellationToken token)
        {
            Console.WriteLine($"这时我准备去买盐了，线程Id为：{GetThreadId()}");

            //已开始执行的任务不能被取消
            string result = await Task.Run(() =>
            {
                Console.WriteLine("屁颠屁颠的去买盐，线程Id为：{0}", GetThreadId());
                Thread.Sleep(2000);//修改此处的延时时间，可以分情况执行取消异步task的方法
            }, token).ContinueWith((t) => //若没有取消就继续执行
            {
                Console.WriteLine("我买好盐了，线程Id为：{0}", GetThreadId());
                Thread.Sleep(1000);

                return "盐买回来了，顺便我还买了一包烟";
            }, token);

            Console.WriteLine($"买盐完成，【{result}】，线程Id为：{GetThreadId()}");

            return result;
        }

        private int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}