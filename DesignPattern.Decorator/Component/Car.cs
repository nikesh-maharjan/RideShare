﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Component
{
    public abstract class Car
    {
        public string Description { get; set; }
        public abstract string getDescription();
        public abstract double getPrice();
    }
}