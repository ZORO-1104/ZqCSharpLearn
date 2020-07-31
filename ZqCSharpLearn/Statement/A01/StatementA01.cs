using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Statement.A01
{
    class StatementA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        //if语句
        private void Test01()
        {
            int score = 110;

            if (score>=0&&score<=100)
            {
                if (score >= 80)
                {
                    Console.WriteLine("A");
                }
                else if (score >= 60)
                {
                    Console.WriteLine("B");
                }
                else if (score >= 40)
                {
                    Console.WriteLine("C");
                }
                else
                {
                    Console.WriteLine("D");
                }
            }
            else
            {
                Console.WriteLine("Input Error");
            }
        }

        //switch语句
        private void Test02()
        {
            int score = 90;

            switch (score/10)
            {
                case 10:
                    if (score==100)
                    {
                        goto case 8;
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case 8:
                case 9:
                    Console.WriteLine("A");
                    break;
                case 7:
                case 6:
                    Console.WriteLine("B");
                    break;
                case 5:
                case 4:
                    Console.WriteLine("C");
                    break;
                case 3:
                case 2:
                case 1:
                case 0:
                    Console.WriteLine("D");
                    break;
                default:
                    Console.WriteLine("Input Error");
                    break;
            }
        }

    }


}
