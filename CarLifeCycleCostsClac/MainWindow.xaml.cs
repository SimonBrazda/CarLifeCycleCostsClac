using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
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
            try
            {
                carManager.Remove(carManager.SelectedCar);
            }
            catch (ArgumentNullException argNullEx)
            {
                MessageBox.Show(argNullEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carManager.updateComparisonCars();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carManager.compareSelectedCars();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messBoxResult = MessageBox.Show("Do you wish to save all changes?", "Quit", MessageBoxButton.YesNoCancel);
                switch (messBoxResult)
                {
                    case MessageBoxResult.Yes:
                        carManager.SaveCars();
                        MessageBox.Show("All changes successfully saved.", "Data saved");
                        Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;
                    default:
                        break;
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

        private void expRangeOfOperation_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void fuelPrice_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9^.]").IsMatch(e.Text);
        }

        private void purchasePrice_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void technicalLife_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance1_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance2_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance3_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance1Price_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance2Price_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance3Price_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void MTBF_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void averageRepairCosts_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void fuelConsumption_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9^.]").IsMatch(e.Text);
        }

        private void maintenance1Years_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance2Years_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void maintenance3Years_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void expectedRangeOfOperationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(expectedRangeOfOperationTextBox.Text))
            {
                expectedRangeOfOperationTextBox.Text = "100";
            }
        }

        private void PHMpriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PHMpriceTextBox.Text) || PHMpriceTextBox.Text.Count(f => f == '.') == PHMpriceTextBox.Text.Length)
            {
                PHMpriceTextBox.Text = "0";
            }
            else if (PHMpriceTextBox.Text.Count(f => f == '.') > 1)
            {
                int initialIndex = PHMpriceTextBox.Text.IndexOf('.');
                int index = PHMpriceTextBox.Text.IndexOf('.', ++initialIndex);
                PHMpriceTextBox.Text = PHMpriceTextBox.Text.Substring(0, index);
            }
        }

        private void purchasePriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(purchasePriceTextBox.Text))
            {
                purchasePriceTextBox.Text = "0";
            }
        }

        private void technicalLifeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(technicalLifeTextBox.Text))
            {
                technicalLifeTextBox.Text = "1000";
            }
        }

        private void maintenance1TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maintenance1TextBox.Text))
                {
                    maintenance1TextBox.Text = "0";
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                maintenance1TextBox.Text = "25000";
            }
        }

        private void maintenance2TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maintenance2TextBox.Text))
                {
                    maintenance2TextBox.Text = "0";
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                maintenance2TextBox.Text = "25000";
            }
        }

        private void maintenance3TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maintenance3TextBox.Text))
                {
                    maintenance3TextBox.Text = "0";
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                maintenance3TextBox.Text = "25000";
            }
        }

        private void maintenance1PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance1PriceTextBox.Text))
            {
                maintenance1PriceTextBox.Text = "0";
            }
        }

        private void maintenance2PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance2PriceTextBox.Text))
            {
                maintenance2PriceTextBox.Text = "0";
            }
        }

        private void maintenance3PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance3PriceTextBox.Text))
            {
                maintenance3PriceTextBox.Text = "0";
            }
        }

        private void MTBFPriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MTBFPriceTextBox.Text))
            {
                MTBFPriceTextBox.Text = "0";
            }
        }

        private void averageRepairCostsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(averageRepairCostsTextBox.Text))
            {
                averageRepairCostsTextBox.Text = "0";
            }
        }

        private void fuelConsumptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(fuelConsumptionTextBox.Text) || fuelConsumptionTextBox.Text.Count(f => f == '.') == fuelConsumptionTextBox.Text.Length)
            {
                fuelConsumptionTextBox.Text = "0";
            }
            else if (fuelConsumptionTextBox.Text.Count(f => f == '.') > 1)
            {
                int initialIndex = fuelConsumptionTextBox.Text.IndexOf('.');
                int index = fuelConsumptionTextBox.Text.IndexOf('.', ++initialIndex);
                fuelConsumptionTextBox.Text = fuelConsumptionTextBox.Text.Substring(0, index);
            }
        }

        private void maintenance1YearsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance1YearsTextBox.Text))
            {
                maintenance1YearsTextBox.Text = "0";
            }
        }

        private void maintenance2YearsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance2YearsTextBox.Text))
            {
                maintenance2YearsTextBox.Text = "0";
            }
        }

        private void maintenance3yearsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maintenance3yearsTextBox.Text))
            {
                maintenance3yearsTextBox.Text = "0";
            }
        }
        private void removeButton_IsEnabled(object sender, RoutedEventArgs e)
        {

        }
    }
}
