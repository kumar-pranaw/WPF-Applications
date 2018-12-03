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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        private SelectedOperator _selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            AcButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (_selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber;
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton_click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == astrixButton)
                _selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisonButton)
                _selectedOperator = SelectedOperator.Division;
            if (sender == addButton)
                _selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                _selectedOperator = SelectedOperator.Substraction;
        }
        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == firstButton)
                selectedValue = 1;
            if (sender == secndButton)
                selectedValue = 2;
            if (sender == thirdButton)
                selectedValue = 3;
            if (sender == fourthButton)
                selectedValue = 4;
            if (sender == fifthButton)
                selectedValue = 5;
            if (sender == sixthButton)
                selectedValue = 6;
            if (sender == seventhButton)
                selectedValue = 7;
            if (sender == eigththButton)
                selectedValue = 8;
            if (sender == ninethButton)
                selectedValue = 9;
            if (sender == zeroButton)
                selectedValue = 0;
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }

        }

        private void PeriodButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}."; 
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1,double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Divison by 0 is not supported", "Wrong Operation", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}
