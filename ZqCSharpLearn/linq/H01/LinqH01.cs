using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Linq.H01
{
    internal class LinqH01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            List<Worker> lstA = new List<Worker>() {
             new Worker(1, "张三A", new WorkExperience("A", new DateTime(2008,10,1), new DateTime(2009,1, 1))),
             new Worker(2, "李四A", new WorkExperience("B", new DateTime(2018,10,1), new DateTime(2019,1, 1))),
             new Worker(3, "赵五A", new WorkExperience("C", new DateTime(2010,10,1), new DateTime(2012,1, 1))),
             new Worker(4, "王六A", new WorkExperience("D", new DateTime(2005,10,1), new DateTime(2007,1, 1))),
             new Worker(5, "王翦A", new WorkExperience("X", new DateTime(2009,10,1), new DateTime(2020,1, 1))),
            };

            List<Worker> lstB = new List<Worker>() {
             new Worker(11, "张三B", new WorkExperience("D", new DateTime(2008,10,1), new DateTime(2009,1, 1))),
             new Worker(2, "李四B", new WorkExperience("C", new DateTime(2018,10,1), new DateTime(2019,1, 1))),
             new Worker(3, "赵五B", new WorkExperience("B", new DateTime(2010,10,1), new DateTime(2012,1, 1))),
             new Worker(14, "王六B", new WorkExperience("A", new DateTime(2005,10,1), new DateTime(2007,1, 1))),
             new Worker(15, "王翦B", new WorkExperience("Y", new DateTime(2009,10,1), new DateTime(2020,1, 1))),
            };

            Console.WriteLine("获取两个集合的交集的元素");
            IEnumerable<Worker> lstC = lstA.Intersect<Worker>(lstB, new WorkerCompare_2());
            foreach (var item in lstC)
            {
                item.ShowMsg();
            }

            Console.WriteLine("获取存在第一个集合A，且不存在第二个集合B中的元素");
            IEnumerable<Worker> lstD = lstA.Except(lstB, new WorkerCompare_2());
            foreach (var item in lstD)
            {
                item.ShowMsg();
            }

            Console.WriteLine("获取存在第一个集合B，且不存在第二个集合中A的元素");
            IEnumerable<Worker> lstE = lstB.Except(lstA, new WorkerCompare_2());
            foreach (var item in lstE)
            {
                item.ShowMsg();
            }
        }
    }

    internal class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WorkExperience WorkExperience { get; set; }

        public Worker(int id, string name, WorkExperience workExperience)
        {
            Id = id;
            Name = name;
            WorkExperience = workExperience;
        }

        public void ShowMsg()
        {
            string str = $"Id={Id},\tName={Name},\tWorkExperience=[{WorkExperience.CompanyName},{WorkExperience.StartWorkDate},{WorkExperience.EndWorkDate}]";
            Console.WriteLine(str);
        }
    }

    internal class WorkerCompare_1 : IEqualityComparer<Worker>
    {
        public bool Equals(Worker x, Worker y)
        {
            if (x.Id == y.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Worker obj)
        {
            return obj.Id;
        }
    }

    internal class WorkerCompare_2 : IEqualityComparer<Worker>
    {
        public bool Equals(Worker x, Worker y)
        {
            if (x.WorkExperience.CompanyName == y.WorkExperience.CompanyName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Worker obj)
        {
            return obj.WorkExperience.CompanyName.GetHashCode();
            //return obj.GetHashCode();
        }
    }

    internal class WorkExperience
    {
        public string CompanyName { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime EndWorkDate { get; set; }

        public WorkExperience(string companyName, DateTime startDate, DateTime endDate)
        {
            CompanyName = companyName;
            StartWorkDate = startDate;
            EndWorkDate = endDate;
        }
    }
}