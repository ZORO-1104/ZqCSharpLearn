using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Try.A01
{
    internal class TryA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 测试try语句功能
        /// 执行的方法发生异常，若该方法没有处理异常，那么就会由调用该方法的方法处理异常
        /// </summary>
        private void Test01()
        {
            try
            {
                Fun01();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.StackTrace}>>{ex.Message}");
            }
        }

        private void Fun01()
        {
            int x = 0;
            int y = 10 / x;
        }
    }
}