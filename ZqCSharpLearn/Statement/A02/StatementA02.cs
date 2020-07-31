using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Statement.A02
{
    class StatementA02 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        //try语句
        private void Test01()
        {
            int result = MyAdd("200", "100");
            Console.WriteLine(result);
        }

        //try语句测试
        private int MyAdd(string s1, string s2)
        {
            int a = 0;
            int b = 0;
            bool isHaveError = false;

            try
            {
                a = int.Parse(s1);
                b = int.Parse(s2);
            }
            catch(ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
                isHaveError = true;
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
                isHaveError = true;
            }
            catch(OverflowException oe)
            {
                //Console.WriteLine(oe.Message);
                //isHaveError = true;

                //将异常抛出，将异常抛给它的调用者
                throw oe;
                //throw;//也可以
            }
            //catch (Exception)
            //{

            //}
            finally
            {
                if (isHaveError)
                {
                    Console.WriteLine("函数运行发生错误。。。。。。。。。。");
                }
            }

            int result = a + b;
            return result;
        }
    }
}
