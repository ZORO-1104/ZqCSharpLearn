using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A06
{
    class AsyncA06 : ICodeTest
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
            Console.WriteLine($"哎呀，没盐了");

            CancellationTokenSource source1 = new CancellationTokenSource();
            CancellationTokenSource source2 = new CancellationTokenSource();
            CancellationTokenSource source = CancellationTokenSource.CreateLinkedTokenSource(source1.Token, source2.Token);

            //注册取消时的回调委托
            source1.Token.Register(() =>
            {
                Console.WriteLine($"这是因为【家里有盐】，所以取消，线程Id为：{GetThreadId()}");
            });

            source2.Token.Register((state) =>
            {
                Console.WriteLine($"这是因为【{state}】，所以取消，线程Id为：{GetThreadId()}");
            }, "不做了出去吃");

            source.Token.Register((state) =>
            {
                Console.WriteLine($"这是因为【{state}】，所以取消，线程Id为：{GetThreadId()}");
            }, "没理由a");

            //这里必须传递 CancellationTokenSource.CreateLinkedTokenSource() 方法返回的 Token 对象
            Task<string> task = CommandBuySalt_MultiCancelBuySalt(source.Token);

            Console.WriteLine($"等等，好像不用买了，线程Id为：{ GetThreadId() }");
            Thread.Sleep(100);

            string[] results = new string[] { "家里的盐", "不做了出去吃", "没理由b" };

            int caseTemp = (new Random()).Next(1, 4);
            Console.WriteLine($"caseTemp = {caseTemp}");
            switch (caseTemp)
            {
                case 1:
                    source1.Cancel();//传达取消请求（家里有盐）
                    //source1.CancelAfter(3000);//3秒后才调用取消的回调方法
                    Console.WriteLine($"既然有盐，我就继续炒菜【{results[0]}】，线程Id为：{GetThreadId()}");
                    break;
                case 2:
                    source2.Cancel();//传达取消请求（不做了出去吃）
                    //source2.CancelAfter(3000);//3秒后才调用取消的回调方法
                    Console.WriteLine($"我们出去吃不用买啦【{results[1]}】，线程Id为：{GetThreadId()}");
                    break;
                case 3:
                    source.Cancel();//传达取消请求（没理由）
                    //source1.CancelAfter(3000);//3秒后才调用取消的回调方法
                    Console.WriteLine($"没理由就是不用买啦【{results[2]}】，线程Id为：{GetThreadId()}");
                    break;
                default:
                    break;
            }

            Console.WriteLine($"最终的任务：" +
                $"状态{task.Status}" +
                $"，是否完成{task.IsCompleted}" +
                $"，是否取消{task.IsCanceled}" +
                $"，是否失败{task.IsFaulted}" +
                $"，当前线程Id为：{GetThreadId()}");
        }

        private async Task<string> CommandBuySalt_MultiCancelBuySalt(CancellationToken token)
        {
            Console.WriteLine($"这时我准备去买盐了，线程Id为：{GetThreadId()}");

            //已开始执行的任务不能被取消
            string result = await Task.Run(() =>
            {
                Console.WriteLine("屁颠屁颠的去买盐，线程Id为：{0}", GetThreadId());
                Thread.Sleep(1000);//修改此处的延时时间，可以分情况执行取消异步task的方法
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
