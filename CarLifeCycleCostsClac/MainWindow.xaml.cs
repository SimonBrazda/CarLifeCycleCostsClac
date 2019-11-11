using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarLifeCycleCostsClac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CarManager carManager = new CarManager();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = carManager;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carManager.Add(carModelTextBox.Text);
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch { }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if(carListBox != null)
                carManager.Remove(carManager.SelectedCar);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            carManager.SaveCars();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            carManager.updateComparisonCars();
        }

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carManager.compareSelectedCars();
            }
            catch(ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
