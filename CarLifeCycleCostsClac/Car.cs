using System;
using System.Collections.Generic;
using System.Text;

namespace CarLifeCycleCostsClac
{
    public class Car : ObservableObject
    {
        private string carModel;
        private string expectedRangeOfOperation;
        private string fuelPrice;
        private string purchasePrice;
        private string technicalLife;
        private string maintenance1;
        private string maintenance2;
        private string maintenance3;
        private string maintenance1Price;
        private string maintenance2Price;
        private string maintenance3Price;
        private string mTBF;
        private string averageRepairCosts;
        private string fuelConsumption;
        public string CarModel
        {
            get { return carModel; }
            set
            {
                carModel = value;
                OnPropertyChanged("CarModel");
            }
        }
        public string ExpectedRangeOfOperation
        {
            get
            {
                if (string.IsNullOrEmpty(expectedRangeOfOperation))
                {
                    return "0";
                }
                return expectedRangeOfOperation;
            }
            set
            {
                expectedRangeOfOperation = value;
                OnPropertyChanged("ExpectedRangeOfOperation");
            }
        }
        public string FuelPrice
        {
            get
            {
                if (string.IsNullOrEmpty(fuelPrice))
                {
                    return "0";
                }
                return fuelPrice;
            }
            set
            {
                fuelPrice = value;
                OnPropertyChanged("FuelPrice");
            }
        }
        public string PurchasePrice
        {
            get
            {
                if (string.IsNullOrEmpty(purchasePrice))
                {
                    return "0";
                }
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
                OnPropertyChanged("PurchasePrice");
            }
        }
        public string TechnicalLife
        {
            get
            {
                if (string.IsNullOrEmpty(technicalLife))
                {
                    return "0";
                }
                return technicalLife;
            }
            set
            {
                technicalLife = value;
                OnPropertyChanged("TechnicalLife");
            }
        }
        public string Maintenance1
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance1))
                {
                    return "0";
                }
                return maintenance1;
            }
            set
            {
                maintenance1 = value;
                OnPropertyChanged("Maintenance1");
            }
        }
        public string Maintenance2
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance2))
                {
                    return "0";
                }
                return maintenance2;
            }
            set
            {
                maintenance2 = value;
                OnPropertyChanged("Maintenance2");
            }
        }
        public string Maintenance3
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance3))
                {
                    return "0";
                }
                return maintenance3;
            }
            set
            {
                maintenance3 = value;
                OnPropertyChanged("Maintenance3");
            }
        }
        public string Maintenance1Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance1Price))
                {
                    return "0";
                }
                return maintenance1Price;
            }
            set
            {
                maintenance1Price = value;
                OnPropertyChanged("Maintenance1Price");
            }
        }
        public string Maintenance2Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance2Price))
                {
                    return "0";
                }
                return maintenance2Price;
            }
            set
            {
                maintenance2Price = value;
                OnPropertyChanged("Maintenance2Price");
            }
        }
        public string Maintenance3Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance3Price))
                {
                    return "0";
                }
                return maintenance3Price;
            }
            set
            {
                maintenance3Price = value;
                OnPropertyChanged("Maintenance3Price");
            }
        }
        public string MTBF
        {
            get
            {
                if (string.IsNullOrEmpty(mTBF))
                {
                    return "0";
                }
                return mTBF;
            }
            set
            {
                mTBF = value;
                OnPropertyChanged("MTBF");
            }
        }
        public string AverageRepairCosts
        {
            get
            {
                if (string.IsNullOrEmpty(averageRepairCosts))
                {
                    return "0";
                }
                return averageRepairCosts;
            }
            set
            {
                averageRepairCosts = value;
                OnPropertyChanged("AverageRepairCosts");
            }
        }
        public string FuelConsumption
        {
            get
            {
                if (string.IsNullOrEmpty(fuelConsumption))
                {
                    return "0.0";
                }
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
                OnPropertyChanged("FuelConsumption");
            }
        }


        public Car(string carModel, string expectedRangeOfOperation = "15000", string fuelPrice = "30", string purchasePrice = "340000",
            string technicalLife = "250000", string maintenance1 = "25000", string maintenance2 = "50000", string maintenance3 = "100000",
            string maintenance1Price = "8000", string maintenance2Price = "12000", string maintenance3Price = "16000", string MTBF = "65000",
            string averageRepairCosts = "25000", string fuelConsumption = "7.6")
        {
            CarModel = carModel;
            ExpectedRangeOfOperation = expectedRangeOfOperation;
            FuelPrice = fuelPrice;
            PurchasePrice = purchasePrice;
            TechnicalLife = technicalLife;
            Maintenance1 = maintenance1;
            Maintenance2 = maintenance2;
            Maintenance3 = maintenance3;
            Maintenance1Price = maintenance1Price;
            Maintenance2Price = maintenance2Price;
            Maintenance3Price = maintenance2Price;
            this.MTBF = MTBF;
            AverageRepairCosts = averageRepairCosts;
            FuelConsumption = fuelConsumption;
        }
    }
}
