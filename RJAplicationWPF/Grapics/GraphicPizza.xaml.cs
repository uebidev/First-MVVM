using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RJAplicationWPF.Grapics
{
    /// <summary>
    /// Interação lógica para GraphicPizza.xam
    /// </summary>
    public partial class GraphicPizza : UserControl
    {
        public GraphicPizza()
        {
            InitializeComponent();
        }
    }
    public class ChartViewModel
    {
        public Collection<DataPoint> Data { get; private set; }
        public ChartViewModel()
        {
            Data = new Collection<DataPoint> {
                        new DataPoint ("1st Trim",500),
                        new DataPoint ("2st Trim", 200),
                        new DataPoint ("3st Trim", 500),
                        new DataPoint ("4st Trim", 800)
            };
        }
        public class DataPoint
        {
            public string Argument { get; private set; }
            public double Value { get; private set; }
            public DataPoint(string argument, double value)
            {
                Argument = argument;
                Value = value;
            }
        }
    }
}
