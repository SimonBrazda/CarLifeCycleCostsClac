using System;
using System.Collections.Generic;
using System.Linq;
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
        private int maintenance1Years;
        private int maintenance2Years;
        private int maintenance3Years;
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
        public int Maintenance1Years
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance1Years.ToString()))
                {
                    return 0;
                }
                return maintenance1Years;
            }
            set
            {
                maintenance1Years = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1Years");
            }
        }
        public int Maintenance2Years
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance2Years.ToString()))
                {
                    return 0;
                }
                return maintenance2Years;
            }
            set
            {
                maintenance2Years = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance2Years");
            }
        }
        public int Maintenance3Years
        {
            get
            {
                if (string.IsNullOrEmpty(maintenance3Years.ToString()))
                {
                    return 0;
                }
                return maintenance3Years;
            }
            set
            {
                maintenance3Years = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3Years");
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
            int maintenance1Price = 8000, int maintenance2Price = 12000, int maintenance3Price = 16000, int maintenance1Years = 1,
            int maintenance2Years = 2, int maintenance3Years = 4, int mTBF = 65000, int averageRepairCosts = 25000,
            float fuelConsumption = 7.6f)
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
            this.maintenance1Years = maintenance1Years;
            this.maintenance2Years = maintenance2Years;
            this.maintenance3Years = maintenance3Years;
            this.mTBF = mTBF;
            this.averageRepairCosts = averageRepairCosts;
            this.fuelConsumption = fuelConsumption;
            updateLifeCycleCost();
        }
        public void updateLifeCycleCost()
        {
            int preventiveMaintenance = 0;
            int yearsOfUse = 1;
            int localTechnicalLife = technicalLife;
            List<int> maintenances = new List<int> { maintenance1, maintenance2, maintenance3 };
            maintenances.Sort();
            maintenances.Reverse();
            List<int> maintenancePrices = new List<int> { maintenance1Price, maintenance2Price, maintenance3Price };
            maintenancePrices.Sort();
            maintenancePrices.Reverse();


           
                if(maintenance1Years == 0 || maintenance1 == 0 || maintenance1Price == 0)
                {
                    maintenance1Years = 0;
                    maintenance1 = 0;
                    maintenance1Price = 0;
                }
                if (maintenance2Years == 0 || maintenance2 == 0 || maintenance2Price == 0)
                {
                    maintenance2Years = 0;
                    maintenance2 = 0;
                    maintenance2Price = 0;
                }
                if (maintenance3Years == 0 || maintenance3 == 0 || maintenance3Price == 0)
                {
                    maintenance3Years = 0;
                    maintenance3 = 0;
                    maintenance3Price = 0;
                }

                if (expectedRangeOfOperation < maintenances.Where(x => x > 0).Min() && (maintenance1Years > 0 || maintenance2Years > 0 || maintenance3Years > 0))
                {
                    List<int> maintenanceYears = new List<int> { maintenance1Years, maintenance2Years, maintenance3Years };
                    maintenanceYears.Sort();
                    maintenanceYears.Reverse();
                    while (localTechnicalLife > expectedRangeOfOperation)
                    {
                        if (maintenanceYears[0] > 0 && yearsOfUse % maintenanceYears[0] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[0];
                            ++yearsOfUse;
                            localTechnicalLife -= expectedRangeOfOperation;
                        }
                        else if (maintenanceYears[1] > 0 && yearsOfUse % maintenanceYears[1] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[1];
                            ++yearsOfUse;
                            localTechnicalLife -= expectedRangeOfOperation;
                        }
                        else if (maintenanceYears[2] > 0 && yearsOfUse % maintenanceYears[2] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[2];
                            ++yearsOfUse;
                            localTechnicalLife -= expectedRangeOfOperation;
                        }
                    }
                }
                else
                {
                    int minDistance = maintenances.Where(x => x > 0).Min();
                    int distance = minDistance;
                    while (localTechnicalLife > minDistance)
                    {
                        if (maintenances[0] > 0 && distance % maintenances[0] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[0];
                            localTechnicalLife -= minDistance;
                            distance += minDistance;
                        }
                        else if (maintenances[1] > 0 && distance % maintenances[1] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[1];
                            localTechnicalLife -= minDistance;
                            distance += minDistance;
                        }
                        else if (maintenances[2] > 0 && distance % maintenances[2] == 0)
                        {
                            preventiveMaintenance += maintenancePrices[2];
                            localTechnicalLife -= minDistance;
                            distance += minDistance;
                        }
                    }
                }
                LifeCycleCost = purchasePrice + (fuelConsumption / 100 * fuelPrice * technicalLife) + preventiveMaintenance + (technicalLife / mTBF * averageRepairCosts);
            
            
        }
    }
}
