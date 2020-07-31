using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 实例字段 和 静态字段
 */
namespace ZqCSharpLearn.OO.A01
{
    class OOA01 : ICodeTest
    {
        public void Execute()
        {
            Test02();
        }

        //实例字段 和 静态字段
        private void Test01()
        {
            //Student stu1 = new Student();
            //stu1.Age = 25;
            //stu1.Score = 70;

            //Student stu2 = new Student();
            //stu2.Age = 30;
            //stu2.Score = 80;

            List<Student> lstStu = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                Student stu = new Student(i);
                stu.Age = 25;
                stu.Score = i;
                lstStu.Add(stu);
            }

            double totalAge = 0;
            double totalScore = 0;
            foreach (var current in lstStu)
            {
                Console.WriteLine($"{current.Age},{current.Score}");
                totalAge += current.Age;
                totalScore += current.Score;
            }

            Student.AverageAge = totalAge / Student.Amount;
            Student.AverageScore = totalScore / Student.Amount;

            Student.ReportAmount();
            Student.ReportAverageAge();
            Student.ReportAverageScore();
        }

        //结构体 与 类 的区别
        private void Test02()
        {
            List<Student> lstStu = new List<Student>();
            List<Teacher> lstTec = new List<Teacher>();


            //Student 是 类，是引用类型
            for (int i = 0; i < 10; i++)
            {
                Student stu = new Student(i);
                stu.Age = i + 1;
                stu.Score = i * 10;
                lstStu.Add(stu);
            }

            //Teacher 是 结构体，是值类型
            Teacher tec = new Teacher();
            for (int i = 0; i < 10; i++)
            {
                tec.Name = "TH_" + i.ToString();
                tec.Age = i + 10;
                lstTec.Add(tec);
            }

            foreach (var item in lstStu)
            {
                item.ShowInfo();
            }

            Console.WriteLine("------------------");

            foreach (var item in lstTec)
            {
                item.ShowInfo();
            }
        }
    }

    class Student
    {
        //实例字段
        public readonly int Id = 5;
        public int Age = 0;
        public double Score;

        //静态字段
        public static int Amount = 0;//学生数量
        public static double AverageAge;//平均年龄
        public static double AverageScore;//平均分数

        //实例初始化器
        public Student(int id)
        {
            Id = id;
            Student.Amount++;
        }

        //静态初始化器
        static Student()
        {
            AverageAge = 0;
            AverageScore = 0;
        }

        public static void ReportAmount()
        {
            Console.WriteLine($"Student count is {Student.Amount}.");
        }

        public static void ReportAverageAge()
        {
            Console.WriteLine($"Student AverageAge is {Student.AverageAge}.");
        }

        public static void ReportAverageScore()
        {
            Console.WriteLine($"Student AverageScore is {Student.AverageScore}.");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Age={Age},Score={Score}.");
        }
    }

    struct Teacher
    {
        public string Name;
        public int Age;

        public void ShowInfo()
        {
            Console.WriteLine($"Name={Name},Age={Age}.");
        }
    }
}
