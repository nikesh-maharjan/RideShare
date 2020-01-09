using DesignPattern.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Decorator.Concrete
{
    class AllWheelDrive : CarDecorator
    {
        public AllWheelDrive(Car car) : base(car)
        {
            Description = "All Wheel Drive";
        }

        public override string getDescription() => $"{_car.getDescription()}, {Description}";

        public override double getPrice() => _car.getPrice() + 200;
    }
}
