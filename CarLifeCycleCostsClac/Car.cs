using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

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
        private float comparativeCosts;
        private float comparisonValue;
        private string color;
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
                fuelPrice = (float)Math.Round(value, 2);
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
                fuelConsumption = (float)Math.Round(value, 2);
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
        public float ComparativeCosts
        {
            get { return comparativeCosts; }
            set
            {
                comparativeCosts = value;
                OnPropertyChanged("ComparativeCosts");
            }
        }
        public float ComparisonValue
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
                this.expectedRangeOfOperation = int.Parse(expectedRangeOfOperation);
                this.fuelPrice = float.Parse(fuelPrice);
                this.purchasePrice = int.Parse(purchasePrice);
                this.technicalLife = int.Parse(technicalLife);
                this.maintenance1 = int.Parse(maintenance1);
                this.maintenance2 = int.Parse(maintenance2);
                this.maintenance3 = int.Parse(maintenance3);
                this.maintenance1Price = int.Parse(maintenance1Price);
                this.maintenance2Price = int.Parse(maintenance2Price);
                this.maintenance3Price = int.Parse(maintenance3Price);
                this.maintenance1Years = int.Parse(maintenance1Years);
                this.maintenance2Years = int.Parse(maintenance2Years);
                this.maintenance3Years = int.Parse(maintenance3Years);
                this.mTBF = int.Parse(mTBF);
                this.averageRepairCosts = int.Parse(averageRepairCosts);
                this.fuelConsumption = float.Parse(fuelConsumption);
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
            int preventiveMaintenance = 0;
            int yearsOfUse = 1;
            int localTechnicalLife = technicalLife;
            List<int> maintenances = new List<int> { maintenance1, maintenance2, maintenance3 };
            maintenances.Sort();
            maintenances.Reverse();
            List<int> maintenancePrices = new List<int> { maintenance1Price, maintenance2Price, maintenance3Price };
            maintenancePrices.Sort();
            maintenancePrices.Reverse();

            if (expectedRangeOfOperation < maintenances.Where(x => x > 0).Min()/* && (maintenance1Years > 0 || maintenance2Years > 0 || maintenance3Years > 0)*/)
            {
                List<int> maintenanceYears = new List<int> { maintenance1Years, maintenance2Years, maintenance3Years };
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
            LifeCycleCost = (float)Math.Round(purchasePrice + (fuelConsumption / 100 * fuelPrice * technicalLife) + preventiveMaintenance + (technicalLife / mTBF * averageRepairCosts), 2);
            ComparativeCosts = (float)Math.Round(LifeCycleCost / TechnicalLife, 2);
        }
    }
}
