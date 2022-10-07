using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Calculadora_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //string[] operators = { "+", "-", "*", "/" };
        string value1 = String.Empty;
        double value2 = 0;
        string mathOperator = String.Empty;

        private void OperatorButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            value1 = Input.Text.ToString();
            mathOperator = (String)button.Content;
            Input.Text = String.Empty;
        }

        private void EqualButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if(value1.Count() > 0)
            {
                double val1 = double.Parse(value1);
                value2 = double.Parse(Input.Text);

                switch (mathOperator)
                {
                    case "+":
                        Input.Text = (val1 + value2).ToString();
                        break;
                    case "-":
                        Input.Text = (val1 - value2).ToString();
                        break;
                    case "*":
                        Input.Text = (val1 * value2).ToString();
                        break;
                    case "/":
                        Input.Text = (val1 / value2).ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void NumberButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            
            if (Input.Text == String.Empty)
            {
                string? actualValue = null;
                actualValue += button.Content;
                Input.Text = actualValue;
            }
            else if (Input.Text.Length < 10)
            {
                string actualValue = Input.Text;
                actualValue += button.Content;
                Input.Text = actualValue;
            }
            else
            {
                Input.FontSize = 30;
                Input.Text = "Too much values!";
                Thread.Sleep(1000);
                Clear();
            }
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ChangeSignalButton(object sender, RoutedEventArgs e)
        {
            var buttom = (Button)sender;

            var modifiedInput = Input.Text.Insert(0, "-");
            Input.Text = modifiedInput;
        }
        private void Clear()
        {
            value1 = String.Empty;
            value2 = 0;
            mathOperator = String.Empty;
            Input.Text = String.Empty;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad0 || e.Key == Key.D0)
            {
                Input.Text += "0";
            }
            if (e.Key == Key.NumPad1 || e.Key == Key.D1)
            {
                Input.Text += "1";
            }
            if (e.Key == Key.NumPad2 || e.Key == Key.D2)
            {
                Input.Text += "2";
            }
            if (e.Key == Key.NumPad3 || e.Key == Key.D3)
            {
                Input.Text += "3";
            }
            if (e.Key == Key.NumPad4 || e.Key == Key.D4)
            {
                Input.Text += "4";
            }
            if (e.Key == Key.NumPad5 || e.Key == Key.D5)
            {
                Input.Text += "5";
            }
            if (e.Key == Key.NumPad6 || e.Key == Key.D6)
            {
                Input.Text += "6";
            }
            if (e.Key == Key.NumPad7 || e.Key == Key.D7)
            {
                Input.Text += "7";
            }
            if (e.Key == Key.NumPad8 || e.Key == Key.D8)
            {
                Input.Text += "8";
            }
            if (e.Key == Key.NumPad9 || e.Key == Key.D9)
            {
                Input.Text += "9";
            }

            if (e.Key == Key.OemComma || e.Key == Key.Decimal)
            {
                Input.Text += ",";
            }

            if (e.Key == Key.Divide)
            {
                value1 = Input.Text.ToString();
                mathOperator = "/";
                Input.Text = String.Empty;
            }
            if (e.Key == Key.Add)
            {
                value1 = Input.Text.ToString();
                mathOperator = "+";
                Input.Text = String.Empty;
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                value1 = Input.Text.ToString();
                mathOperator = "-";
                Input.Text = String.Empty;
            }
            if (e.Key == Key.Multiply)
            {
                value1 = Input.Text.ToString();
                mathOperator = "*";
                Input.Text = String.Empty;
            }

            if (e.Key == Key.OemPlus || e.Key == Key.Return) // =
            {
                if (value1.Count() > 0)
                {
                    double val1 = double.Parse(value1);
                    value2 = double.Parse(Input.Text);

                    switch (mathOperator)
                    {
                        case "+":
                            Input.Text = (val1 + value2).ToString();
                            break;
                        case "-":
                            Input.Text = (val1 - value2).ToString();
                            break;
                        case "*":
                            Input.Text = (val1 * value2).ToString();
                            break;
                        case "/":
                            Input.Text = (val1 / value2).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }

            if (e.Key == Key.C || e.Key == Key.Escape)
            {
                Clear();
            }

            if (e.Key == Key.Back)
            {
                if(Input.Text.Count() > 0)
                {
                    var temp = Input.Text;
                    Input.Text = temp.Remove(temp.Length - 1);
                }
            }
        }
    }
}
