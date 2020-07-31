
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.A02
{
    class OOA02 : ICodeTest
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    class Student
    {
        private int age;

        public int Age
        { 
            get => age; 
            protected set => age = value;
        }

        //被动的，外界调用属性时，再根据年龄计算是否可以工作
        public bool CanWork
        {
            get
            {
                return this.age >= 16 ? true : false;
            }
        }
    }

    //主动计算的方式
    class Student2
    {
        private int age;

        public int Age
        {
            get => age;
            set
            {
                age = value;
                //每当对年龄进行设置数值时，主动调用私有方法，计算是否可以工作的属性
                CalculateIsCanWork();
            }
        }

        private bool canWork;

        public bool CanWork
        {
            get { return canWork; }
        }

        private void CalculateIsCanWork()
        {
            if (this.age>=16)
            {
                this.canWork = true;
            }
            else
            {
                this.canWork = false;
            }
        }
    }
}
