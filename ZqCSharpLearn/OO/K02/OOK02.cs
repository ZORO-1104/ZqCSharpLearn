using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.OO.K02
{
    internal class OOK02 : ICodeTest
    {
        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 接口实现松耦合
        /// </summary>
        private void Test01()
        {
            IVehicle vehicle;
            AbsDriver absDriver;

            vehicle = new Trank();
            //absDriver = new HumanDriver("zoro", vehicle);
            absDriver = new AiDriver("Baidu.Ltd", vehicle);

            absDriver.Drive();
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
            Console.WriteLine($"car is running...");
        }
    }

    internal class Trank : IVehicle
    {
        public void Run()
        {
            Console.WriteLine($"trank is running...");
        }
    }

    internal abstract class AbsDriver
    {
        protected IVehicle _vehicle;

        protected AbsDriver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public virtual void Drive()
        {
            _vehicle.Run();
        }
    }

    internal class HumanDriver : AbsDriver
    {
        private string driverName;

        public HumanDriver(string driverName, IVehicle vehicle) : base(vehicle)
        {
            this.driverName = driverName;
        }

        public override void Drive()
        {
            Console.Write($"DriverName={driverName} >> ");
            base.Drive();
        }
    }

    internal class AiDriver : AbsDriver
    {
        private string companyName;

        public AiDriver(string companyName, IVehicle vehicle) : base(vehicle)
        {
            this.companyName = companyName;
        }

        public override void Drive()
        {
            Console.Write($"CompanyName={companyName} >> ");
            base.Drive();
        }
    }
}