using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CarLifeCycleCostsClac
{
    public class CarManager : Screen
    {
        public BindableCollection<Car> Cars { get; set; }
        //DirectoryInfo currDir = new DirectoryInfo(".");
        private string filePath = "C:\\Users\\Simon\\source\\repos\\CarLifeCycleCostsClac\\CarLifeCycleCostsClac\\CarsData\\CarsData.txt";

        private Car selectedCar;

        public Car SelectedCar 
        {
            get { return selectedCar; }
            set
            { 
                selectedCar = value;
                NotifyOfPropertyChange(() => SelectedCar);
            }
        }

        public CarManager()
        {
            
            List<string> lines = File.ReadAllLines(filePath).ToList();
            Cars = new BindableCollection<Car>();
            
            foreach(string line in lines)
            {
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
                
  
                Cars.Add(new Car(words[0], words[1], words[2], words[3], words[4], words[5], words[6],
                    words[7], words[8], words[9], words[10], words[11], words[12]));
            }
            
        }

        public void Add(string carModel)
        {
            if (!string.IsNullOrWhiteSpace(carModel))
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
            else
            {
                throw new ArgumentException("Car model must not be an empty string or a white-space");
            }
        }

        public void Remove(Car carToRemove)
        {
            Cars.Remove(carToRemove);
        }

        public void SaveCars()
        {
            List<string> lines = new List<string>();
            foreach(Car car in Cars)
            {
                lines.Add(car.CarModel + "," + car.ExpectedRangeOfOperation + "," + car.FuelPrice + "," + car.PurchasePrice + "," + car.TechnicalLife +
                    "," + car.Maintenance1 + "," + car.Maintenance2 + "," + car.Maintenance3 + "," + car.Maintenance1Price + "," + car.Maintenance2Price +
                    "," + car.Maintenance3Price + "," + car.MTBF + "," + car.AverageRepairCosts + "," + car.FuelConsumption);
            }
            
            File.WriteAllLines(filePath, lines);
        }
    }
}
