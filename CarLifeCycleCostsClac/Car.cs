using System;
using System.Collections.Generic;
using System.Text;

namespace CarLifeCycleCostsClac
{
    public class Car : ObservableObject
    {
        private string carModel;
        private int expectedRangeOfOperation;
        private float fuelPrice;
        private int purchasePrice;
        private int technicalLife;
        private int maintenance1;
        private int maintenance2;
        private int maintenance3;
        private int maintenance1Price;
        private int maintenance2Price;
        private int maintenance3Price;
        private int mTBF;
        private int averageRepairCosts;
        private float fuelConsumption;
        private float lifeCycleCost;
        public string CarModel
        {
            get { return carModel; }
            set
            {
                carModel = value;
                OnPropertyChanged("CarModel");
            }
        }
        public int ExpectedRangeOfOperation
        {
            get
            {
                if (string.IsNullOrEmpty(expectedRangeOfOperation.ToString()))
                {
                    return 0;
                }
                return expectedRangeOfOperation;
            }
            set
            {

                expectedRangeOfOperation = value;
                updateLifeCycleCost();
                OnPropertyChanged("ExpectedRangeOfOperation");
            }
        }
        public float FuelPrice
        {
            get
            {
                if (string.IsNullOrEmpty(fuelPrice.ToString()))
                {
                    return 0.0f;
                }
                return fuelPrice;
            }
            set
            {
                fuelPrice = value;
                updateLifeCycleCost();
                OnPropertyChanged("FuelPrice");
            }
        }
        public int PurchasePrice
        {
            get
            {
                if (string.IsNullOrEmpty(purchasePrice.ToString()))
                {
                    return 0;
                }
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
                updateLifeCycleCost();
                OnPropertyChanged("PurchasePrice");
            }
        }
        public int TechnicalLife
        {
            get
            {
                if (string.IsNullOrEmpty(technicalLife.ToString()))
                {
                    return 0;
                }
                return technicalLife;
            }
            set
            {
                technicalLife = value;
                updateLifeCycleCost();
                OnPropertyChanged("TechnicalLife");
            }
        }
        public int Maintenance1
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance1.ToString()))
                {
                    return 0;
                }
                return maintenance1;
            }
            set
            {
                maintenance1 = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1");
            }
        }
        public int Maintenance2
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance2.ToString()))
                {
                    return 0;
                }
                return maintenance2;
            }
            set
            {
                maintenance2 = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance2");
            }
        }
        public int Maintenance3
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance3.ToString()))
                {
                    return 0;
                }
                return maintenance3;
            }
            set
            {
                maintenance3 = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3");
            }
        }
        public int Maintenance1Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance1Price.ToString()))
                {
                    return 0;
                }
                return maintenance1Price;
            }
            set
            {
                maintenance1Price = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1Price");
            }
        }
        public int Maintenance2Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance2Price.ToString()))
                {
                    return 0;
                }
                return maintenance2Price;
            }
            set
            {
                maintenance2Price = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance2Price");
            }
        }
        public int Maintenance3Price
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance3Price.ToString()))
                {
                    return 0;
                }
                return maintenance3Price;
            }
            set
            {
                maintenance3Price = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3Price");
            }
        }
        public int MTBF
        {
            get
            {
                if (string.IsNullOrEmpty(mTBF.ToString()))
                {
                    return 0;
                }
                return mTBF;
            }
            set
            {
                mTBF = value;
                updateLifeCycleCost();
                OnPropertyChanged("MTBF");
            }
        }
        public int AverageRepairCosts
        {
            get
            {
                if (string.IsNullOrEmpty(averageRepairCosts.ToString()))
                {
                    return 0;
                }
                return averageRepairCosts;
            }
            set
            {
                averageRepairCosts = value;
                updateLifeCycleCost();
                OnPropertyChanged("AverageRepairCosts");
            }
        }
        public float FuelConsumption
        {
            get
            {
                if (string.IsNullOrEmpty(fuelConsumption.ToString()))
                {
                    return 0.0f;
                }
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
                updateLifeCycleCost();
                OnPropertyChanged("FuelConsumption");
            }
        }
        public float LifeCycleCost
        {
            get { return lifeCycleCost; }
            set
            {
                lifeCycleCost = value;
                OnPropertyChanged("LifeCycleCost");
            }
        }

        public Car(string carModel, int expectedRangeOfOperation = 15000, float fuelPrice = 30.0f, int purchasePrice = 340000,
            int technicalLife = 250000, int maintenance1 = 25000, int maintenance2 = 50000, int maintenance3 = 100000,
            int maintenance1Price = 8000, int maintenance2Price = 12000, int maintenance3Price = 16000, int MTBF = 65000,
            int averageRepairCosts = 25000, float fuelConsumption = 7.6f)
        {
            this.carModel = carModel;
            this.expectedRangeOfOperation = expectedRangeOfOperation;
            this.fuelPrice = fuelPrice;
            this.purchasePrice = purchasePrice;
            this.technicalLife = technicalLife;
            this.maintenance1 = maintenance1;
            this.maintenance2 = maintenance2;
            this.maintenance3 = maintenance3;
            this.maintenance1Price = maintenance1Price;
            this.maintenance2Price = maintenance2Price;
            this.maintenance3Price = maintenance3Price;
            this.MTBF = MTBF;
            this.averageRepairCosts = averageRepairCosts;
            this.fuelConsumption = fuelConsumption;
            updateLifeCycleCost();
        }
        public void updateLifeCycleCost()
        {
            int preventiveMaintenance = 0;
            int yearsOfUse = 0;
            int localTechnicalLife = technicalLife;
            if (expectedRangeOfOperation < maintenance1)
            {
                while (localTechnicalLife > expectedRangeOfOperation)
                {
                    if ( yearsOfUse == 0 || yearsOfUse % 2 == 1)
                    {
                        preventiveMaintenance += maintenance1Price;
                        ++yearsOfUse;
                        localTechnicalLife -= expectedRangeOfOperation;
                    }
                    else if(yearsOfUse % 2 == 0)
                    {
                        preventiveMaintenance += maintenance2Price;
                        ++yearsOfUse;
                        localTechnicalLife -= expectedRangeOfOperation;
                    }
                    else if(yearsOfUse % 4 == 0)
                    {
                        preventiveMaintenance += maintenance3Price;
                        ++yearsOfUse;
                        localTechnicalLife -= expectedRangeOfOperation;
                    }
                }
            }
            else
            {
                int distance = 0;
                while (localTechnicalLife > maintenance1)
                {
                    if (distance % maintenance1 == 0)
                    {
                        preventiveMaintenance += maintenance1Price;
                        localTechnicalLife -= expectedRangeOfOperation;
                        distance += maintenance1;
                    }
                    else if (distance % maintenance2 == 0)
                    {
                        preventiveMaintenance += maintenance2Price;
                        localTechnicalLife -= expectedRangeOfOperation;
                        distance += maintenance2;
                    }
                    else if (distance % maintenance3 == 0)
                    {
                        preventiveMaintenance += maintenance3Price;
                        localTechnicalLife -= expectedRangeOfOperation;
                        distance += maintenance3;
                    }
                }
            }
            LifeCycleCost = (fuelConsumption / 100 * fuelPrice * technicalLife) + (technicalLife / mTBF * averageRepairCosts) + preventiveMaintenance;
        }
    }
}
