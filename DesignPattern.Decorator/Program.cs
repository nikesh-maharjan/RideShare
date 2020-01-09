using DesignPattern.Decorator.Component;
using DesignPattern.Decorator.Component.Concrete;
using DesignPattern.Decorator.Decorator.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Car theCar = new CompactCar();
            theCar = new LeatherSeat(theCar);
            theCar = new AllWheelDrive(theCar);
            theCar = new Navigation(theCar);

            Console.WriteLine(theCar.getDescription());
            Console.WriteLine($"{theCar.getPrice():C2}");
        }
    }
}
