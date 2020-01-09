using DesignPattern.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Decorator.Concrete
{
    class LeatherSeat : CarDecorator
    {
        public LeatherSeat(Car car) : base(car)
        {
            Description = "Leather Seats";
        }

        public override string getDescription() => $"{_car.getDescription()}, {Description}";

        public override double getPrice() => _car.getPrice() + 200;
    }
}
