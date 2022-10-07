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
        //myKeyPressClass myKeyPressHandler = new myKeyPressClass();
        //public Form1()
        //{
        //    InitializeComponent();

        //    textBox1.KeyPress += new KeyPressEventHandler(myKeyPressHandler.myKeyCounter);
        //}

        public MainWindow()
        {
            InitializeComponent();
        }
        
        string[] operators = { "+", "-", "*", "/" };
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
    }
}
