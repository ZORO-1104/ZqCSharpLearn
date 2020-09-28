using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Linq.A01
{
    internal class LinqA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            List<string> strArray = new List<string>() { "golbal", "future", "confidence", "world" };

            IEnumerable<string> arr2 = strArray.Where(n => n.Contains("e"));
            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------");

            strArray.Clear();
            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
        }
    }
}