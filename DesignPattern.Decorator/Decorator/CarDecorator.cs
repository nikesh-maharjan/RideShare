using DesignPattern.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Decorator
{
    class CarDecorator : Car
    {
        protected Car _car;
        public CarDecorator(Car car)
        {
            _car = car;
        }
        public override string getDescription() => _car.getDescription();

        public override double getPrice() => _car.getPrice();
    }
}
