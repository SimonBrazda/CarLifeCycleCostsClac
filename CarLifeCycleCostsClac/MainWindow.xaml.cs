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
            catch(ArgumentNullException argNullEx)
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
            catch(ArgumentException argEx)
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
            catch(ArgumentException argEx)
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
                expectedRangeOfOperationTextBox.Text = "0";
            }
        }
    }
}
