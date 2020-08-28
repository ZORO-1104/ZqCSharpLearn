using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Try.A02
{
    internal class TryA02 : ICodeTest
    {
        public void Execute()
        {
            Test02();
            Test03();
            Test04();
            Test05();
            Test06();
        }

        /// <summary>
        /// 测试try语句功能
        /// 在try块中执行return
        /// </summary>
        private void Test02()
        {
            try
            {
                Console.WriteLine("执行...");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("不会执行...");
            }
            finally
            {
                Console.WriteLine("执行...");
            }

            Console.WriteLine($"不会执行...");
        }

        /// <summary>
        /// 测试try语句功能
        /// 在try块中执行return
        /// </summary>
        private void Test03()
        {
            try
            {
                Console.WriteLine("执行...");
                //return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("不会执行...");
            }
            finally
            {
                Console.WriteLine("执行...");
            }

            Console.WriteLine($"执行...");
        }

        /// <summary>
        /// 测试try语句功能
        /// 在try块中执行return
        /// </summary>
        private void Test04()
        {
            try
            {
                Console.WriteLine("执行...");
                int x = 0;
                int y = 10 / x;

                Console.WriteLine("不会执行...");
                //return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行...");
            }
            finally
            {
                Console.WriteLine("执行...");
            }

            Console.WriteLine($"执行...");
        }

        /// <summary>
        /// 测试try语句功能
        /// 在try块中执行return
        /// </summary>
        private void Test05()
        {
            try
            {
                Console.WriteLine("执行...");
                int x = 0;
                int y = 10 / x;

                Console.WriteLine("不会执行...");
                //return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行...");
                return;
            }
            finally
            {
                Console.WriteLine("执行...");
            }

            Console.WriteLine($"不会执行...");
        }

        /// <summary>
        /// 测试try语句功能
        /// 在try块中执行return
        /// </summary>
        private void Test06()
        {
            try
            {
                Console.WriteLine("执行...");
                int x = 0;
                int y = 10 / x;

                Console.WriteLine("执行...");
                //return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行...");
            }
            finally
            {
                Console.WriteLine("执行...");
                //return;这会编译报错（控制不能离开finally字句主体）
            }

            Console.WriteLine($"执行...");
        }
    }
}