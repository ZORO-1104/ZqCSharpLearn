using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZqCSharpLearn.MultiThread.A02
{
    internal class MultiThreadA02 : ICodeTest
    {
        public void Execute()
        {
            //该事件会在任何线程中出现未处理异常时触发
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Test01();
            //Test02();
        }

        /// <summary>
        /// 测试线程的执行 和 线程创建时所处的try/catch/finally语句块，是无关的
        /// 程序会崩溃，因为在Go方法中，没有处理异常的部分
        /// </summary>
        private void Test01()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                //程序不会运行到这里
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 在产品环境中，应用程序的所有线程的入口方法都需要添加一个异常处理器，来处理异常
        /// </summary>
        private void Test02()
        {
            try
            {
                new Thread(NewGo).Start();
            }
            catch (Exception ex)
            {
                //程序不会运行到这里
                Console.WriteLine(ex.Message);
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"sender={sender}" +
                $",msg={e.ExceptionObject.GetType().Name}");
        }

        private void Go()
        {
            throw new Exception($"Sub Thread Run Error.");
        }

        private void NewGo()
        {
            try
            {
                Console.WriteLine("New Go is running");

                throw new Exception($"Sub Thread Run Error.");
            }
            catch (Exception ex)
            {
                //在这里进行处理异常
                //例如记录log，以及通知其它线程等
                Console.WriteLine("发生异常，要记录log，并通知其它线程等等");
            }
        }
    }
}