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
                
  
                Cars.Add(new Car(words[0], int.Parse(words[1]), float.Parse(words[2]), int.Parse(words[3]), int.Parse(words[4]),
                    int.Parse(words[5]), int.Parse(words[6]), int.Parse(words[7]), int.Parse(words[8]), int.Parse(words[9]),
                    int.Parse(words[10]), int.Parse(words[11]), int.Parse(words[12]), int.Parse(words[13]), int.Parse(words[14]),
                    int.Parse(words[15]), float.Parse(words[16])));
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
                    "," + car.Maintenance3Price + "," + car.Maintenance1Years + "," + car.Maintenance2Years + "," + car.Maintenance3Years + "," + car.MTBF +
                    "," + car.AverageRepairCosts + "," + car.FuelConsumption);
            }
            
            File.WriteAllLines(filePath, lines);
        }
    }
}
