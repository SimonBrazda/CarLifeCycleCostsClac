using System;
using System.Collections.Generic;
using System.Text;

namespace CarLifeCycleCostsClac
{
    public class ComparisonCar : Car
    {
        private double comparisonValue;
        private string color;

        public ComparisonCar(Car other) : base(other)
        {
            comparisonValue = 0;
        }

        public double ComparisonValue
        {
            get { return comparisonValue; }
            set
            {
                comparisonValue = value;
                OnPropertyChanged("ComparisonValue");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

    }
}
