using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CarLifeCycleCostsClac
{
    public class Car : ObservableObject
    {
        protected string carModel;
        protected ulong expectedRangeOfOperation;
        protected double fuelPrice;
        protected ulong purchasePrice;
        protected ulong technicalLife;
        protected ulong maintenance1;
        protected ulong maintenance2;
        protected ulong maintenance3;
        protected ulong maintenance1Price;
        protected ulong maintenance2Price;
        protected ulong maintenance3Price;
        protected ulong maintenance1Years;
        protected ulong maintenance2Years;
        protected ulong maintenance3Years;
        protected ulong mTBF;
        protected ulong averageRepairCosts;
        protected double fuelConsumption;
        protected double lifeCycleCost;
        protected double comparativeCosts;
        protected double comparisonValue;
        protected string color;
        public string CarModel
        {
            get { return carModel; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    carModel = value;
                    OnPropertyChanged("CarModel");
                }
                else
                {
                    throw new ArgumentException("Car model must not be an empty string or a white-space", "Car Model");
                }
                    
            }
        }
        public ulong ExpectedRangeOfOperation
        {
            get
            {
                return expectedRangeOfOperation;
            }
            set
            {
                if(value < 100)
                {
                    expectedRangeOfOperation = 100;
                }
                else
                {
                    expectedRangeOfOperation = value;
                }
                
                updateLifeCycleCost();
                OnPropertyChanged("ExpectedRangeOfOperation");
            }
        }
        public double FuelPrice
        {
            get
            {
                return fuelPrice;
            }
            set
            {
                fuelPrice = (double)Math.Round(value, 2);
                updateLifeCycleCost();
                OnPropertyChanged("FuelPrice");
            }
        }
        public ulong PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
                updateLifeCycleCost();
                OnPropertyChanged("PurchasePrice");
            }
        }
        public ulong TechnicalLife
        {
            get
            {
                return technicalLife;
            }
            set
            {
                if(value < 1000)
                {
                    technicalLife = 1000;
                }
                else
                {
                    technicalLife = value;
                }
                updateLifeCycleCost();
                OnPropertyChanged("TechnicalLife");
            }
        }
        public ulong Maintenance1
        {
            get
            {
                return maintenance1;
            }
            set
            {
                if(maintenance2 == 0 && maintenance3 == 0)
                {
                    throw new ArgumentException("All maintenances cannot be 0");
                }
                else
                {
                    maintenance1 = value;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1");
            }
        }
        public ulong Maintenance2
        {
            get
            {
                return maintenance2;
            }
            set
            {
                if (maintenance1 == 0 && maintenance3 == 0)
                {
                    throw new ArgumentException("All maintenances cannot be 0");
                }
                else
                {
                    maintenance2 = value;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance2");
            }
        }
        public ulong Maintenance3
        {
            get
            {
                return maintenance3;
            }
            set
            {
                if (maintenance1 == 0 && maintenance2 == 0)
                {
                    throw new ArgumentException("All maintenances cannot be 0");
                }
                else
                {
                    maintenance3 = value;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3");
            }
        }
        public ulong Maintenance1Price
        {
            get
            {
                return maintenance1Price;
            }
            set
            {
                maintenance1Price = value;
                if (value <= 0)
                {
                    Maintenance1 = 0;
                    Maintenance1Years = 0;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1Price");
            }
        }
        public ulong Maintenance2Price
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
                if (value <= 0)
                {
                    Maintenance2 = 0;
                    Maintenance2Years = 0;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance2Price");
            }
        }
        public ulong Maintenance3Price
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
                if(value <= 0)
                {
                    Maintenance3 = 0;
                    Maintenance3Years = 0;
                }
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3Price");
            }
        }
        public ulong Maintenance1Years
        {
            get
            {
                return maintenance1Years;
            }
            set
            {
                maintenance1Years = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance1Years");
            }
        }
        public ulong Maintenance2Years
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
        public ulong Maintenance3Years
        {
            get
            {
                return maintenance3Years;
            }
            set
            {
                maintenance3Years = value;
                updateLifeCycleCost();
                OnPropertyChanged("Maintenance3Years");
            }
        }
        public ulong MTBF
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
        public ulong AverageRepairCosts
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
        public double FuelConsumption
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
                fuelConsumption = (double)Math.Round(value, 2);
                updateLifeCycleCost();
                OnPropertyChanged("FuelConsumption");
            }
        }
        public double LifeCycleCost
        {
            get { return lifeCycleCost; }
            set
            {
                lifeCycleCost = value;
                OnPropertyChanged("LifeCycleCost");
            }
        }
        public double ComparativeCosts
        {
            get { return comparativeCosts; }
            set
            {
                comparativeCosts = value;
                OnPropertyChanged("ComparativeCosts");
            }
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

        public Car(string carModel, string expectedRangeOfOperation = "15000", string fuelPrice = "30.0", string purchasePrice = "340000",
            string technicalLife = "250000", string maintenance1 = "25000", string maintenance2 = "50000", string maintenance3 = "100000",
            string maintenance1Price = "8000", string maintenance2Price = "12000", string maintenance3Price = "16000", string maintenance1Years = "1",
            string maintenance2Years = "2", string maintenance3Years = "4", string mTBF = "65000", string averageRepairCosts = "25000",
            string fuelConsumption = "7.6", string color = "Black")
        {
            try
            {
                CarModel = carModel;
                this.expectedRangeOfOperation = ulong.Parse(expectedRangeOfOperation);
                this.fuelPrice = double.Parse(fuelPrice);
                this.purchasePrice = ulong.Parse(purchasePrice);
                this.technicalLife = ulong.Parse(technicalLife);
                this.maintenance1 = ulong.Parse(maintenance1);
                this.maintenance2 = ulong.Parse(maintenance2);
                this.maintenance3 = ulong.Parse(maintenance3);
                this.maintenance1Price = ulong.Parse(maintenance1Price);
                this.maintenance2Price = ulong.Parse(maintenance2Price);
                this.maintenance3Price = ulong.Parse(maintenance3Price);
                this.maintenance1Years = ulong.Parse(maintenance1Years);
                this.maintenance2Years = ulong.Parse(maintenance2Years);
                this.maintenance3Years = ulong.Parse(maintenance3Years);
                this.mTBF = ulong.Parse(mTBF);
                this.averageRepairCosts = ulong.Parse(averageRepairCosts);
                this.fuelConsumption = double.Parse(fuelConsumption);
                this.color = color;
            }
            catch(ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException formEx)
            {
                MessageBox.Show(formEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException overflowEx) 
            {
                MessageBox.Show(overflowEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            updateLifeCycleCost();
            }
        public void updateLifeCycleCost()
        {
            ulong preventiveMaintenance = 0;
            ulong yearsOfUse = 1;
            ulong localTechnicalLife = technicalLife;
            List<ulong> maintenances = new List<ulong> { maintenance1, maintenance2, maintenance3 };
            maintenances.Sort();
            maintenances.Reverse();
            List<ulong> maintenancePrices = new List<ulong> { maintenance1Price, maintenance2Price, maintenance3Price };
            maintenancePrices.Sort();
            maintenancePrices.Reverse();

            if (expectedRangeOfOperation < maintenances.Where(x => x > 0).Min())
            {
                List<ulong> maintenanceYears = new List<ulong> { maintenance1Years, maintenance2Years, maintenance3Years };
                maintenanceYears.Sort();
                maintenanceYears.Reverse();
                while (localTechnicalLife > expectedRangeOfOperation)
                {
                    if (maintenanceYears[0] > 0 && yearsOfUse % maintenanceYears[0] == 0)
                    {
                        preventiveMaintenance += maintenancePrices[0];
                    }
                    else if (maintenanceYears[1] > 0 && yearsOfUse % maintenanceYears[1] == 0)
                    {
                        preventiveMaintenance += maintenancePrices[1];
                    }
                    else if (maintenanceYears[2] > 0 && yearsOfUse % maintenanceYears[2] == 0)
                    {
                        preventiveMaintenance += maintenancePrices[2];
                    }
                    localTechnicalLife -= expectedRangeOfOperation;
                    ++yearsOfUse;
                }
            }
            else
            {
                ulong minDistance = maintenances.Where(x => x > 0).Min();
                ulong distance = minDistance;
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
            LifeCycleCost = (double)Math.Round(purchasePrice + (fuelConsumption / 100 * fuelPrice * technicalLife) + preventiveMaintenance + (technicalLife / mTBF * averageRepairCosts), 2);
            ComparativeCosts = (double)Math.Round(LifeCycleCost / TechnicalLife, 2);
        }
    }
}
