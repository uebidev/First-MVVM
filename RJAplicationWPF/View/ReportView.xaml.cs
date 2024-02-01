using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static RJAplicationWPF.Grapics.ChartViewModel;

namespace RJAplicationWPF.View
{
    /// <summary>
    /// Interação lógica para ReportView.xam
    /// </summary>
    public partial class ReportView : UserControl, INotifyPropertyChanged
    {
        public ReportView()
        {
            InitializeComponent();
        }

        public ObservableCollection<Vendedor> Vendedores { get; set; } = new ObservableCollection<Vendedor>
        {
         new Vendedor{ Nome = "Zezin", Valor = new ObservableCollection<Teste>
            {
                        new Teste ("Venda", 362.5),
                        new Teste ("Venda", 348.4),
                        new Teste ("Venda", 279.0),
                        new Teste ("Venda", 230.9),
                        new Teste ("Venda", 203.5),
                        new Teste ("Venda", 197.1)
            }
                },
            new Vendedor{ Nome = "Joana", Valor = new ObservableCollection<Teste>
            {   
                        new Teste ("Venda", 562.5),
                        new Teste ("Venda", 548.4),
                        new Teste ("Venda", 479.0),
                        new Teste ("Venda", 330.9),
                        new Teste ("Venda", 303.5),
                        new Teste ("Venda", 297.1)
            }
                }
        };


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       
    }
    public class Vendedor
    {
        public string Nome { get; set; }
        public ObservableCollection<Teste> Valor { get; set; }

    }
    public class Teste
    {
        public string Argument { get; set; }
        public double Value { get; set; }
        public Teste(string argument, double value)
        {
            Argument = argument;
            Value = value;
        }
    }
}
