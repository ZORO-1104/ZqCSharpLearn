/*
功能：关心是否执行完成，返回 Task 类型
----------------
1) 可见，调用 Wait() 方法后，当前线程被阻塞了，直到 Task 执行完成后，当前线程才继续执行。
2) 注意：由于 CommandOpenMainsSwitch() 是一个异步方法，
虽然返回类型为 Task 类型，但是在我们代码中并没有写（也不能写） return task 语句，
这是为什么呢？
可能是这种返回类型比较特殊，或者编译器自动帮我们完成了吧！
就算写也只能写 return 语句，后面不能跟对象表达式。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZqCSharpLearn.Async.A02
{
    class AsyncA02 : ICodeTest
    {
        public void Execute()
        {
            ClassA classA = new ClassA();
            classA.CleanRoom();

        }
    }

    class ClassA
    {
        public void CleanRoom()
        {
            Console.WriteLine($"我和老婆正在看电视，线程Id为：{ GetThreadId() }");
            Console.WriteLine($"突然停电了，快去看下是不是跳闸了");
            Task task = CommandOpenMainsSwitch();
            Console.WriteLine($"没电了先玩会儿手机吧，线程Id为：{ GetThreadId() }");
            Thread.Sleep(100);
            Console.WriteLine($"手机也没电了只等电源打开，线程Id为：{ GetThreadId() }");

            //等待
            //task.Wait();//所以这里将被阻塞，直到任务完成
            //另一种实现方法
            while (!task.IsCompleted)
            {
                Console.WriteLine($"还没来电，再等会儿，线程Id为：{ GetThreadId() }");
                Thread.Sleep(100);
            }

            Console.WriteLine($"又有电了我们继续看电视，线程Id为：{ GetThreadId() }");

        }

        private async Task CommandOpenMainsSwitch()
        {
            Console.WriteLine($"这时我准备去打开电源开关，线程Id为：{GetThreadId()}");

            await Task.Run(() => {
                Console.WriteLine($"屁颠屁颠的去打开电源开关，线程Id为：{GetThreadId()}");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"打开电源开关完成{1.0 * (i + 1) / 5 * 100}%，线程Id为：{GetThreadId()}");
                }
            });

            Console.WriteLine($"电源开关打开了，线程Id为：{GetThreadId()}");
        }


        private int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
