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

namespace PupConvertApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        // **************** Global Variables ******************
        String Main_Input = "";
        String Main_Output = "";
        Double Conversion_result = 1.0;
        bool decimalPoint = false;

        readonly MetricRatio mymetric = new MetricRatio
        {
            converTo = length,
            input = 1,
            inputTypeIndex = 1,
            outputTypeIndex = 2
        };

        //*****************************************************
        public MainWindow()
        {
            InitializeComponent();
                        
            Type_Menu();

            Init_Menu();
            
            Init_display();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (Input_validate())
            {
                Update_Display();
            }
            else
            {
               /* if (Input_TextBox.Text.Length >= 1)
                {
                    Input_TextBox.Text = Input_TextBox.Text.Substring(0,Input_TextBox.Text.Length - 1);
                    Input_TextBox.SelectionStart = Input_TextBox.Text.Length;
                    Input_TextBox.SelectionLength = 0;
                    Console.WriteLine("Removed");
                    Console.WriteLine(Input_TextBox.Text);
                    Console.WriteLine(Input_TextBox.Text.Length);

                }
                */
                
            }
            
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("clear");
            if (Output_TextBlock != null)
            {
                Init_display();

            }
        }


        void Init_display()
        {

            if (Output_TextBlock != null || Input_TextBox != null)
            {
                Input_TextBox.BorderThickness = new Thickness(0.0);
                Output_TextBlock.Text = "";
                Input_TextBox.Text = "";
                Input_TextBox.Focus();

            }
        }

        void Update_Display()
        {
            Conversion_result = mymetric.Convert();
            Decimal value = Convert.ToDecimal(Conversion_result);
            String Result_String;
            String Input_String;

            if (Conversion_result > 1.0)    {
                Result_String = value.ToString("N2"); 
            }
            else
            {
                Result_String = value.ToString("N8");
            }

            if (mymetric.input > 1.0)
            {
                Input_String = mymetric.input.ToString("N02");
            }
            else
            {
                Input_String = mymetric.input.ToString("N08");
            }
            
            Main_Output = $"{Input_String}\n{mymetric.Input_type()}\nis\n{ Result_String }\n{mymetric.Output_type()}";
            Console.WriteLine(Main_Output);
           

            if (Output_TextBlock != null)
            {
                if (Main_Input != "")
                {
                    Output_TextBlock.Text = Main_Output;
                    Input_TextBox.Focus();
                }
                else
                {
                    Output_TextBlock.Text = "";
                    Input_TextBox.Focus();
                }

            }
        }

        private void Input_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(Input_select.SelectedIndex);
            mymetric.inputTypeIndex = Input_select.SelectedIndex + 1;
            Update_Display();
        }

        private void Output_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(Output_select.SelectedIndex);
            mymetric.outputTypeIndex = Output_select.SelectedIndex + 1;
            Update_Display();
        }

        void Init_Menu()
        {
            if (mymetric.converTo != null)
            {
                Input_select.Items.Clear();
                Output_select.Items.Clear();

                Console.WriteLine(mymetric.converTo.GetUpperBound(0));
                
                foreach (var item in mymetric.Menu_items())
                {
                    Console.WriteLine(item);
                    Input_select.Items.Add(item);
                    Output_select.Items.Add(item);
                }

                Input_select.SelectedIndex = 1;
                Output_select.SelectedIndex = 2;
            }

        }

        void Type_Menu()
        {
            if (mymetric.converTo != null)
            {
                Type_Select.Items.Clear();
                
                Console.WriteLine(MainMenuType.Count);
               
                foreach (var item in MainMenuType)
                {
                    Console.WriteLine(item);
                    Type_Select.Items.Add(item);
                    
                }

                Type_Select.SelectedIndex = 1;
                                
            }

            Update_Display();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           switch (Type_Select.SelectedIndex)
            {
                case 0: mymetric.converTo = dataStorage; break;

                case 1: mymetric.converTo = length; break;

                case 2: mymetric.converTo = speed; break;

                case 3: mymetric.converTo = volume; break;
            }

            Init_Menu();
            Init_display();

        }

        private bool Input_validate()
        {
            Main_Input = Input_TextBox.Text;

            if (Main_Input.Length<1)
            {
                Input_TextBox.Text = "";
                return false;
            }

            if (Main_Input.Length >= 16)
            {
                Input_TextBox.Text = Input_TextBox.Text.Substring(0, Input_TextBox.Text.Length - 1);
                Input_TextBox.SelectionStart = Input_TextBox.Text.Length;
                Input_TextBox.SelectionLength = 0;
                Console.WriteLine("Removed");
                Console.WriteLine(Input_TextBox.Text);
                Console.WriteLine(Input_TextBox.Text.Length);
                return false;
            }

            string ch = Main_Input.Substring(Main_Input.Length - 1);
            Console.WriteLine(ch);

            switch (ch)
            {
                case "0": break;
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": break;
                case "5": break;
                case "6": break;
                case "7": break;
                case "8": break;
                case "9": break;
                case ".": break;

                default:
                    {
                        if (Input_TextBox.Text.Length >= 1)
                        {
                            Input_TextBox.Text = Input_TextBox.Text.Substring(0, Input_TextBox.Text.Length - 1);
                            Input_TextBox.SelectionStart = Input_TextBox.Text.Length;
                            Input_TextBox.SelectionLength = 0;
                            Console.WriteLine("Removed");
                            Console.WriteLine(Input_TextBox.Text);
                            Console.WriteLine(Input_TextBox.Text.Length);

                        }
                        return false;
                    }
                    
            }
            // end check non-numeric

                    
            if (double.TryParse(Main_Input, out double doubleValue))
            {
                // Here you already can use a valid double 'doubleValue'
                mymetric.input = doubleValue;
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                Console.WriteLine("Invalid Input");
                if (Input_TextBox.Text.Length >= 1)
                {
                    Input_TextBox.Text = Input_TextBox.Text.Substring(0, Input_TextBox.Text.Length - 1);
                    Input_TextBox.SelectionStart = Input_TextBox.Text.Length;
                    Input_TextBox.SelectionLength = 0;
                    Console.WriteLine("Removed");
                    Console.WriteLine(Input_TextBox.Text);
                    Console.WriteLine(Input_TextBox.Text.Length);

                }
                //Main_Input = "";
            }

            return true;
        }
    }

   

}
