using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Component.Concrete
{
    class CompactCar : Car
    {
        public CompactCar()
        {
            Description = "Compact Car";
        }

        public override string getDescription() => Description;

        public override double getPrice() => 1000;
    }
}
