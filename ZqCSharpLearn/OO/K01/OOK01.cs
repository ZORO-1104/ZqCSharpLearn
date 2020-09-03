using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.K01
{
    internal class OOK01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 使用接口，实现松耦合
        /// </summary>
        private void Test01()
        {
            IPhone phone;
            //phone = new NokiaPhone();
            phone = new HonorPhone();

            PhoneUser phoneUser = new PhoneUser(phone);
            phoneUser.UsePhone();
        }
    }

    internal interface IPhone
    {
        void Dail();

        void PickUp();

        void Send();

        void Receive();
    }

    internal class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokia dail success...");
        }

        public void PickUp()
        {
            Console.WriteLine("This is zoro...");
        }

        public void Send()
        {
            Console.WriteLine("Nice to meet you...");
        }

        public void Receive()
        {
            Console.WriteLine("Good evening...");
        }
    }

    internal class HonorPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Honor dail success...");
        }

        public void PickUp()
        {
            Console.WriteLine("This is zoro...");
        }

        public void Send()
        {
            Console.WriteLine("Nice to meet you...");
        }

        public void Receive()
        {
            Console.WriteLine("Good evening...");
        }
    }

    internal class PhoneUser
    {
        //PhoneUser这个类依赖的是接口IPhone
        //这里不能是具体的类（如NokiaPhone、HonorPhone），这样就会导致PhoneUser这个类，紧紧地依赖在具体类上了
        //使用接口，实现松耦合
        private IPhone _phone;

        public PhoneUser(IPhone nokiaPhone)
        {
            _phone = nokiaPhone;
        }

        public void UsePhone()
        {
            _phone.Dail();
            _phone.PickUp();
            _phone.Send();
            _phone.Receive();
        }
    }
}