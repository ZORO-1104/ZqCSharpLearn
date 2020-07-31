using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Statement.A03
{
    class StatementA03 : ICodeTest
    {
        public void Execute()
        {
            Test03();
        }

        //while语句
        private void Test01()
        {
            int score = 0;
            bool canContinue = true;

            while (canContinue)
            {
                Console.WriteLine("请输入第1个数字");
                string s1 = Console.ReadLine();
                int a = int.Parse(s1);

                Console.WriteLine("请输入第2个数字");
                string s2 = Console.ReadLine();
                int b = int.Parse(s2);

                int sum = a + b;

                if (sum == 100)
                {
                    score++;
                    Console.WriteLine($"Correct >> {a}+{b}={sum}");
                }
                else
                {
                    canContinue = false;
                    Console.WriteLine($"Error >> {a}+{b}={sum}");
                }
            }

            Console.WriteLine($"Gave Over...");
            Console.WriteLine($"Your Score is {score}");
        }

        //for语句
        private void Test02()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}*{i}={i * j}\t");
                }

                //换行
                Console.WriteLine();
            }
        }

        //foreach语句
        private void Test03()
        {
            List<int> arrInt = new List<int>() { 11, 22, 33, 44, 55 };
            //int[] arrInt = new int[] { 11, 22, 33, 44, 55 };
            Console.WriteLine(arrInt is Array);
            IEnumerator ie = arrInt.GetEnumerator();

            while (ie.MoveNext())
            {
                //Console.WriteLine(ie.Current);
                int temp = int.Parse(ie.Current.ToString());
                Console.WriteLine(temp + 1);
            }
        }
    }
}
