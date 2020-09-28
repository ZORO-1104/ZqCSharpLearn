using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Other.B01
{
    internal class OtherB01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            Student s1 = new Student() { Name = "zoro", Age = 25, Score = 95.8 };
            Student s2 = new Student() { Name = "luffy", Age = 25, Score = 90 };

            Console.WriteLine(s1 == s2);

            Console.WriteLine(s1 > s2);
            //Console.WriteLine(s1>=s2);//会报错，需要单独重载运算符>=和<=
            Console.WriteLine(s1 < s2);
        }
    }

    internal class Student
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private double score;

        public double Score
        {
            get { return score; }
            set { score = value; }
        }

        public static bool operator ==(Student s1, Student s2)
        {
            if (s1.name == s2.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Student s1, Student s2)
        {
            if (s1.name != s2.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return this == (Student)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator >(Student s1, Student s2)
        {
            if (s1.score > s2.score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Student s1, Student s2)
        {
            if (s1.score < s2.score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}