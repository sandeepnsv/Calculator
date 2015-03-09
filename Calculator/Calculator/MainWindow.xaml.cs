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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double value = 0, latestvalue = 0, prevalue = 0;
        String operation1 = "", operation2 = "", op = "",check="";
        bool operator_pressed = false;
        double MemoryStore = 0;
        int flag = 0, equaled = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((screen.Text == "0") || operator_pressed)
                screen.Clear();

            operator_pressed = false;
            if ((screen.Text).Length == 16)
                return;
            Button B = (Button)sender;
            screen.Text = screen.Text + B.Content;
            //CMemory.Content = (String)CMemory.Content + B.Content;
            check = (String)B.Content;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button C = (Button)sender;
            operation2 = (String)C.Content;
            equaled = 0;
            operator_pressed = true;

            CMemory.Content = CMemory.Content + screen.Text + operation2;
            
            if (flag == 0)
            {
                flag = 1;
                operation1 = (String)C.Content;
                goto first_time;
            }

            //CMemory.Content = (String)CMemory.Content + screen.Text;

            if (check == "")
                goto first_time;

            switch (operation1)
            {
                case "+":
                    screen.Text = (value + Double.Parse(screen.Text)).ToString();
                    break;

                case "-":
                    screen.Text = (value - Double.Parse(screen.Text)).ToString();
                    break;

                case "*":
                    screen.Text = (value * Double.Parse(screen.Text)).ToString();
                    break;

                case "/":
                    screen.Text = (value / Double.Parse(screen.Text)).ToString();
                    break;

                case "%":
                    screen.Text = (value % Double.Parse(screen.Text)).ToString();
                    break;

                default:
                    break;
            }
            check = "";
            operation1 = operation2;
            first_time:
            value = double.Parse(screen.Text);
        }

        private void BEqual_Click(object sender, RoutedEventArgs e)
        {
            
           if (equaled == 0)
            {
                prevalue = Double.Parse(screen.Text);
                op = operation2;
            }

            if (operation2 == "")
            {
                latestvalue = prevalue;
                operation2 = op;
            }         
            else
                latestvalue = Double.Parse(screen.Text);

            CMemory.Content = "";

            switch (operation2)
            {
                case "+":
                    screen.Text = (value + latestvalue).ToString();
                    break;

                case "-":
                    screen.Text = (value - latestvalue).ToString();
                    break;

                case "*":
                    screen.Text = (value * latestvalue).ToString();
                    break;

                case "/":
                    screen.Text = (value / latestvalue).ToString();
                    break;

                case "%":
                    screen.Text = (value % latestvalue).ToString();
                    break;

                default:
                    break;
            }
            operation1 = ""; operation2 = ""; flag = 0; equaled = 1;
            value = Double.Parse(screen.Text);
            operator_pressed = false;
        }

        private void BBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (equaled == 0)
                screen.Text = (screen.Text).Substring(0, (screen.Text).Length - 1);
            // screen.Text = (screen.Text).Remove((screen.Text).Length - 1);
        }

        private void BAllClear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "0";
            value = 0;
            flag = 0;
            equaled = 0;
            CMemory.Content = "";
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "0";
        }

        private void BPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            CMemory.Content = CMemory.Content + " -" + screen.Text;
            screen.Text = (-1 * Double.Parse(screen.Text)).ToString();
        }

        private void BMC_Click(object sender, RoutedEventArgs e)
        {
            MemoryStore = 0;
            MemoryD.Content = "";
        }

        private void BMR_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = MemoryStore.ToString();
        }

        private void BMS_Click(object sender, RoutedEventArgs e)
        {
            MemoryStore = Double.Parse(screen.Text);
            operator_pressed = true;
            MemoryD.Content = "M";
        }

        private void BMP_Click(object sender, RoutedEventArgs e)
        {
            MemoryStore = MemoryStore + Double.Parse(screen.Text);
        }

        private void BMM_Click(object sender, RoutedEventArgs e)
        {
            MemoryStore = MemoryStore - Double.Parse(screen.Text);
        }

        private void BSqRt_Click(object sender, RoutedEventArgs e)
        {
            if (Double.Parse(screen.Text) >= 0)
            {
                CMemory.Content = CMemory.Content + "Sqrt(" + screen.Text + ")";
                screen.Text = (Math.Sqrt(Double.Parse(screen.Text))).ToString();
            }
            else
                screen.Text = "Invalid input";
        }

        private void BInverse_Click(object sender, RoutedEventArgs e)
        {
            if (Double.Parse(screen.Text) != 0)
            {
                CMemory.Content = CMemory.Content + "reciproc(" + screen.Text + ")";
                screen.Text = (1 / Double.Parse(screen.Text)).ToString();
            }
            else
                screen.Text = "Cannot divide by zero";
        }

        private void BDot_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Contains("."))
                screen.Text = screen.Text;
            else
                screen.Text = screen.Text + ".";
        }

    }
}