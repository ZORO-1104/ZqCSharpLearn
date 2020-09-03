using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.K04
{
    internal class OOK04 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            ArrayList arr2 = new ArrayList() { 1, 2, 3, 4, 5, 6, 7 };
            int[] arr3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyReadOnlyList myReadOnlyList = new MyReadOnlyList(arr3);

            Console.WriteLine(Sum(arr1));
            Console.WriteLine(Sum(arr2));
            Console.WriteLine(Sum(arr3));
            //Console.WriteLine(Sum(myReadOnlyList));
        }

        //private int Sum(int[] arr)
        //{
        //    int sum = 0;
        //    foreach (var item in arr)
        //    {
        //        sum += item;
        //    }

        //    return sum;
        //}

        //private int Sum(ArrayList arr)
        //{
        //    int sum = 0;
        //    foreach (var item in arr)
        //    {
        //        sum += (int)item;
        //    }

        //    return sum;
        //}

        /// <summary>
        /// 输入参数应为IEnumerable，因为方法内只用到了foreach语句
        /// 而foreach语句仅依赖IEnumerable，即可运行
        /// 这里接口不能为ICollection（它继承自IEnumerable），不然就会导致MyReadOnlyList类无法使用
        /// 因为MyReadOnlyList类，仅是实现了IEnumerable接口
        /// 所以，如果这里接口为ICollection（这个胖接口），就会把原本符合foreach运算的适合的输入参数，挡在了外面
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int Sum(IEnumerable arr)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += (int)item;
            }

            return sum;
        }
    }

    internal class MyReadOnlyList : IEnumerable
    {
        private int[] _list;
        private int _head;

        public MyReadOnlyList(int[] arr)
        {
            _list = arr;
            _head = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyReadOnlyList.MyEnumerator(this);
        }

        public class MyEnumerator : IEnumerator
        {
            private MyReadOnlyList _myReadOnlyList;

            public MyEnumerator(MyReadOnlyList myReadOnlyList)
            {
                _myReadOnlyList = myReadOnlyList;
            }

            public object Current
            {
                get
                {
                    object o = _myReadOnlyList._list[_myReadOnlyList._head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                if (++_myReadOnlyList._head >= _myReadOnlyList._list.Length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void Reset()
            {
                _myReadOnlyList._head = -1;
            }
        }
    }
}