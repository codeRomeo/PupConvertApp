
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
    public partial class MainWindow : Window
    {
        public struct DataType
        {
            public string type;
            public double value;

            public DataType(string type, double value)
            {
                this.type = type;
                this.value = value;
            }
        }

        static DataType byte_ = new DataType(type: "byte(s)", value: 1.0);
        static DataType kiloByte = new DataType(type: "Kilo Byte(s)", value: 1024.0);
        static DataType megaByte = new DataType(type: "Mega Byte(s)", value: 1024.0 * 1024.0);
        static DataType gigaByte = new DataType(type: "Giga Byte(s)", value: 1024.0 * 1024.0 * 1024.0);
        static DataType teraByte = new DataType(type: "Tera Byte(s)", value: 1024.0 * 1024.0 * 1024.0 * 1024.0);
        static DataType petabyte = new DataType(type: "Peta Byte(s)", value: 1024.0 * 1024.0 * 1024.0 * 1024.0 * 1024.0);

        static DataType mm = new DataType(type: "Millimeter(s)", value: 0.001);
        static DataType cm = new DataType(type: "Centimeter(s)", value: 0.01);
        static DataType m = new DataType(type: "Meter(s)", value: 1.0);
        static DataType km = new DataType(type: "Kilometer(s)", value: 1000.0);
        static DataType foot = new DataType(type: "Foot(s)", value: 0.3048);
        static DataType yard = new DataType(type: "Yard(s)", value: 0.9144);
        static DataType mile = new DataType(type: "Mile(s)", value: 1609.344);

        static DataType MpH = new DataType(type: "Mile(s) per Hour", value: 0.447);
        static DataType KmpH = new DataType(type: "Kilometer(s) per Hour", value: 0.2778);
        static DataType Fps = new DataType(type: "Feet per second", value: 0.3048);
        static DataType mps = new DataType(type: "Meter(s) per second", value: 1.0);
        static DataType knot = new DataType(type: "knot(s)", value: 0.5144);

        static DataType liter  = new DataType(type: "Liter(s)", value: 1.0);
        static DataType gallon = new DataType(type: "Gallon(s)", value: 0.264172);
        static DataType quart  = new DataType(type: "Quart(s)", value: 1.05669);
        static DataType pint   = new DataType(type: "Pint", value: 2.11338);
        static DataType cup    = new DataType(type: "Cup(s)", value: 4.16667);
        static DataType ounce   = new DataType(type: "Ounce(s)", value: 33.814);
        static DataType cubicMeter  = new DataType(type: "Cubic Meter(s)", value: 0.001);
        static DataType milliLiter = new DataType(type: "Milli Liter(s)", value: 1000);
        static DataType cubicFoot = new DataType(type: "Cubic Foot", value: 0.0353147);
        static DataType cubicInch = new DataType(type: "Cubic Inch", value: 61.0237);


        static DataType dummyVal = new DataType(type: "", value: 1.0);
        public static DataType[] initVal = { dummyVal };
        public static DataType[] dataStorage = { dummyVal, byte_, kiloByte, megaByte, gigaByte, teraByte, petabyte };
        public static DataType[] length = { dummyVal, mm, cm, m, km, foot, yard, mile };
        public static DataType[] speed = { dummyVal, MpH, KmpH, Fps, mps, knot };
        public static DataType[] volume = { dummyVal, liter, gallon, quart, pint, cup, ounce, cubicMeter, milliLiter, cubicFoot, cubicInch };


        public static List<string> MainMenuType = new List<string>(){ "Datastorage", "Length", "Speed", "Volume" };


        public class MetricRatio
        {
            public double input = 1;
            public int inputTypeIndex = 1;
            public int outputTypeIndex = 1;
            public DataType[] converTo = initVal;

            /* public MetricRatio()
             {
                 this.input = 1;
                 this.inputType = 1;
                 this.outputType = 1;
                 this.converTo = initVal;
             } */

            public double Convert()
            {
                return input * (converTo[inputTypeIndex].value / converTo[outputTypeIndex].value);
            }

            public string Input_type()
            {
                return converTo[inputTypeIndex].type;
            }

            public string Output_type()
            {
                return converTo[outputTypeIndex].type;
            }

            public List<string> Menu_items()
            {
                List<string> arr = new List<string>();


                for (int i = 1; i <= converTo.GetUpperBound(0); i++)
                {
                    arr.Add(converTo[i].type);
                }


                return arr;

            }
                       
        }
    }
}