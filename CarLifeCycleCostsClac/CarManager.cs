using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows;
using System.Security;

namespace CarLifeCycleCostsClac
{
    public class CarManager : Screen
    {
        public BindableCollection<Car> Cars { get; set; }
        
        string path = Path.Combine(Directory.GetCurrentDirectory(),"CarsData\\CarsData.csv");
        

        private Car selectedCar;
        private Car comparisonCar1;
        private Car comparisonCar2;

        public Car SelectedCar 
        {
            get { return selectedCar; }
            set
            { 
                selectedCar = value;
                NotifyOfPropertyChange(() => SelectedCar);
            }
        }

        public Car ComparisonCar1
        {
            get { return comparisonCar1; }
            set
            {
                comparisonCar1 = value;
                NotifyOfPropertyChange(() => ComparisonCar1);
            }
        }

        public Car ComparisonCar2
        {
            get { return comparisonCar2; }
            set
            {
                comparisonCar2 = value;
                NotifyOfPropertyChange(() => ComparisonCar2);
            }
        }
        public CarManager()
        {
            try
            {
                Cars = new BindableCollection<Car>();
                List<string> lines = File.ReadAllLines(path).ToList();

                foreach (string line in lines)
                {
                    /*
                    int startIndex = 0;
                    int lastIndex = line.IndexOf(',');
                    List<string> words = new List<string>();
                    while (lastIndex < line.Length && lastIndex != -1)
                    {
                        words.Add(line.Substring(startIndex, lastIndex - startIndex));
                        startIndex = lastIndex + 1;
                        lastIndex = line.IndexOf(',', startIndex);
                    }
                    words.Add(line.Substring(startIndex, line.Length - startIndex));
                    */

                    List<string> words = new List<string>(line.Split(','));

                    Cars.Add(new Car(words[0], words[1], words[2], words[3], words[4],
                        words[5], words[6], words[7], words[8], words[9],
                        words[10], words[11], words[12], words[13], words[14],
                        words[15], words[16]));
                }
                if (Cars.Any())
                {
                    SelectedCar = Cars.Last();
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PathTooLongException pathLongEx)
            {
                MessageBox.Show(pathLongEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException IOEx)
            {
                MessageBox.Show(IOEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException unAuthorisedEx)
            {
                MessageBox.Show(unAuthorisedEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException notSuporptedEx)
            {
                MessageBox.Show(notSuporptedEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SecurityException securityEx)
            {
                MessageBox.Show(securityEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Add(string carModel)
        {
            
                if (Cars.Count <= 0)
                {
                    Cars.Add(new Car(carModel));
                }
                else
                {
                    foreach (Car car in Cars)
                    {
                        if (car.CarModel != carModel)
                        {
                            Car newCar = new Car(carModel);
                            Cars.Add(newCar);
                        }
                        else
                        {
                            throw new ArgumentException("Car model: \"" + carModel + "\" is already in the list");
                        }
                    }
                }
           
        }

        public void Remove(Car carToRemove)
        {
            if (carToRemove != null)
            {
                Cars.Remove(carToRemove);
                if (Cars.Any())
                    SelectedCar = Cars.Last();
                else
                    SelectedCar = null;
            }
            else
            {
                throw new ArgumentNullException("There are no Car Models to be removed.");
            }
        }

        public void SaveCars()
        {
            List<string> lines = new List<string>();
            foreach(Car car in Cars)
            {
                lines.Add(car.CarModel + "," + car.ExpectedRangeOfOperation + "," + car.FuelPrice + "," + car.PurchasePrice + "," + car.TechnicalLife +
                    "," + car.Maintenance1 + "," + car.Maintenance2 + "," + car.Maintenance3 + "," + car.Maintenance1Price + "," + car.Maintenance2Price +
                    "," + car.Maintenance3Price + "," + car.Maintenance1Years + "," + car.Maintenance2Years + "," + car.Maintenance3Years + "," + car.MTBF +
                    "," + car.AverageRepairCosts + "," + car.FuelConsumption);
            }
            
            File.WriteAllLines(path, lines);
        }

        public void updateComparisonCars()
        {
            if(ComparisonCar1 != null && ComparisonCar2 != null)
            {
                ComparisonCar1 = SelectedCar;
                ComparisonCar1.ComparisonValue = 0;
                ComparisonCar1.Color = "Black";
                ComparisonCar2 = null;
            }
            else if(ComparisonCar1 != null && ComparisonCar2 == null)
            {
                if (ComparisonCar1 == SelectedCar)
                {
                    throw new ArgumentException("Can not compare same Car Models.\nPlease select different one.");
                }
                ComparisonCar2 = SelectedCar;
                ComparisonCar2.ComparisonValue = 0;
                ComparisonCar2.Color = "Black";
            }
            else
            {
                ComparisonCar1 = SelectedCar;
                ComparisonCar1.ComparisonValue = 0;
                ComparisonCar1.Color = "Black";
            }
        }

        public void compareSelectedCars()
        {
            if(ComparisonCar1 == null && ComparisonCar2 == null)
            {
                throw new ArgumentException("Please select cars which you want to compare");
            }
            else if(ComparisonCar1 == null && ComparisonCar2 != null)
            {
                throw new ArgumentException("Please select Car Model 1 to proceed comparison");
            }
            else if (ComparisonCar1 != null && ComparisonCar2 == null)
            {
                throw new ArgumentException("Please select Car Model 2 to proceed comparison");
            }
            else
            {
                ComparisonCar1.ComparisonValue = (float)Math.Round(ComparisonCar1.LifeCycleCost - ComparisonCar2.LifeCycleCost, 2);
                ComparisonCar2.ComparisonValue = (float)Math.Round(ComparisonCar2.LifeCycleCost - ComparisonCar1.LifeCycleCost, 2);
                if (ComparisonCar1.ComparisonValue > ComparisonCar2.ComparisonValue)
                {
                    ComparisonCar1.Color = "Green";
                    ComparisonCar2.Color = "Red";
                }
                else
                {
                    ComparisonCar2.Color = "Green";
                    ComparisonCar1.Color = "Red";
                }
            }
        }
    }
}
