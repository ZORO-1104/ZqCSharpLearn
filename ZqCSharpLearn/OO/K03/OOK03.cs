using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.K03
{
    internal class OOK03 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        private void Test01()
        {
            IVehicle vehicle;

            vehicle = new Car();
            vehicle = new Trank();
            vehicle = new LightTank();
            vehicle = new MediumTank();
            vehicle = new HeavyTank();

            Driver driver = new Driver(vehicle);
            driver.Drive();
        }
    }

    internal interface IVehicle
    {
        void Run();
    }

    internal class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("car is running...");
        }
    }

    internal class Trank : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Trank is running...");
        }
    }

    /// <summary>
    /// Driver类内的字段成员为接口IVehicle
    /// 由于Car类和Trank类，都实现了该接口，故可以装配进来
    /// 同时，由于LightTank类、MediumTank类和HeavyTank类，都实现了ITank接口，
    ///      而ITank接口，是继承了IVehicle和IWeapon接口，
    ///      所以LightTank类、MediumTank类和HeavyTank类，也可以装配进入Driver类
    ///      （而且在Driver类中，由于成员为IVehicle接口，）
    ///      （所以，即使是将LightTank等类装配进Driver，也是无法调用到LightTank的Fire方法的）
    ///
    /// ----------------------------
    ///
    /// 所以，站在IVehicle接口的提供方来看，我不会多给，即我提供的Run方法，使用方都用的到，不会提供你不需要的功能。
    ///      （所以如果将ITank接口作为Driver类的成员，那就不好了，相当于多提供了Fire方法功能）
    ///      （这是软性规范，即此时就产生了胖接口）
    /// 而站在IVehicle接口的使用方来看，即Driver类中，我只会用到Run方法，不会向提供方多要。
    ///      （这是硬性规范，即，如果要多了，即使用了接口提供方没有提供的功能，那么编译器就会报错）
    /// </summary>
    internal class Driver
    {
        private IVehicle _vehicle;

        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    //internal interface ITank
    //{
    //    void Run();
    //    void Fire();
    //}

    internal interface IWeapon
    {
        void Fire();
    }

    /// <summary>
    /// 注意，这里的ITank接口是由两个小接口构成的
    /// 它继承了IVehicle和IWeapon
    /// </summary>
    internal interface ITank : IVehicle, IWeapon
    {
    }

    internal class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine($"Boom ...");
        }

        public void Run()
        {
            Console.WriteLine($"ka ka ka ...");
        }
    }

    internal class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine($"Boom! ...");
        }

        public void Run()
        {
            Console.WriteLine($"ka! ka! ka! ...");
        }
    }

    internal class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine($"Boom!!! ...");
        }

        public void Run()
        {
            Console.WriteLine($"ka!!! ka!!! ka!!! ...");
        }
    }
}