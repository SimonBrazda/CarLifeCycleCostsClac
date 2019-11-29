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
                selectButton.IsEnabled = isSelectButtEnabled();
                compareButton.IsEnabled = isCompareButtEnabled();
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

        private void float_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Contains('.'))
            {
                int dotIndex = textBox.Text.IndexOf('.');
                if (textBox.Text.Substring(dotIndex, textBox.Text.Length - dotIndex).Length > 2)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
                }
            }
            else
            {
                e.Handled = !new Regex(@"^\d*\.?\d?$").IsMatch(e.Text);
            }
            
        }
       
        private void int_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void carListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            removeButton.IsEnabled = e.AddedItems.Count == 0 ? false : true;
            selectButton.IsEnabled = isSelectButtEnabled();
        }
        /*
        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
        */
        private void floatTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        private void carListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                carManager.updateComparisonCars();
                selectButton.IsEnabled = isSelectButtEnabled();
                compareButton.IsEnabled = isCompareButtEnabled();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool isCompareButtEnabled()
        {
            return carManager.ComparisonCar1 != null && carManager.ComparisonCar2 != null ? true : false;
        }

        public bool isSelectButtEnabled()
        {
            return carManager.ComparisonCar1 != null && carManager.SelectedCar.CarModel == carManager.ComparisonCar1.CarModel ? false : true;
        }

        private void inputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
