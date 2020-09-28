using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Other.A01
{
    internal class OtherA01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 测试属性值更改事件
        /// </summary>
        private void Test01()
        {
            Person p1 = new Person() { Name = "zoro", Age = 25, IsMale = true };
            p1.PropertyChanged += PropertyChanged;
            p1.Name = "Luffy";
            p1.Age = 22;
            p1.IsMale = false;
            p1.Name = "Luffy2";
            p1.Name = "Luffy3";
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"sender={sender}" +
                $", PropertyName={e.PropertyName}");
        }
    }

    internal class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string memberName = null)
        {
            //PropertyChanged?.BeginInvoke(this, new PropertyChangedEventArgs(memberName), null, null);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                {
                    return;
                }
                else
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (age == value)
                {
                    return;
                }
                else
                {
                    age = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isMale;

        public bool IsMale
        {
            get { return isMale; }
            set
            {
                if (isMale == value)
                {
                    return;
                }
                else
                {
                    isMale = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}