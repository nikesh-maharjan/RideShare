using DesignPattern.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Decorator.Concrete
{
    class Navigation : CarDecorator
    {
        public Navigation(Car car) : base(car)
        {
            Description = "Navigation";
        }

        public override string getDescription() => $"{_car.getDescription()}, {Description}";

        public override double getPrice() => _car.getPrice() + 200;
    }
}
