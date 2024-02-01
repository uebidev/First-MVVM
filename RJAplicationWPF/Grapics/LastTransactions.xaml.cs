using FontAwesome.Sharp;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static RJAplicationWPF.Grapics.Transactions;

namespace RJAplicationWPF.Grapics
{
    /// <summary>
    /// Interação lógica para LastTransactions.xam
    /// </summary>
    public partial class LastTransactions : UserControl
    {
        private ObservableCollection<Transactions> displayedTransaction = new ObservableCollection<Transactions>();
        public LastTransactions()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;
        }
        
        public async Task LoadAllTransactionsAsync()
        {
            displayedTransaction.Add(new Transactions(0, "Venda", 1526));
            displayedTransaction.Add(new Transactions(0, "Venda", 1206));
            displayedTransaction.Add(new Transactions((DeposityType)1, "Compra", 1026));
            displayedTransaction.Add(new Transactions(0, "Venda", 2536));
            displayedTransaction.Add(new Transactions((DeposityType)1, "Compra", 2660));
            displayedTransaction.Add(new Transactions((DeposityType)1, "Compra", 3106));
            displayedTransaction.Add(new Transactions(0, "Venda", 6203));
            displayedTransaction.Add(new Transactions(0, "Venda", 4610));

            TransactionsListView.ItemsSource = displayedTransaction;
           
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadAllTransactionsAsync();
        }
    }

    public class Transactions
    {

        public Transactions(DeposityType deposity, string name, double valor)
        {
            if (deposity == 0)
            {
                DeposityName = "Deposit";
            }
            else
            {
                DeposityName = "Transfer";
            }
            DeposityId = deposity;
            Name = name;
            ValorPersonalizado = "$" + valor;
            HoraFormatada = $"{DateTime.Now:yyyy-MM-dd hh:mm}";
        }

        public DeposityType DeposityId { get; set; }
        public string DeposityName { get; set; }
        public string Name { get; private set; }
        public double Valor { get; private set; }
        public string ValorPersonalizado { get; set; }
        public string HoraFormatada { get; set; }
        public DateTime Hora { get; private set; } = DateTime.Now;

        public enum DeposityType : int
        {
            Deposity = 0,
            Transfer = 1
        }
        public string GetDeposityColor()
        {
            if (DeposityId == DeposityType.Deposity)
            {
                return "#FFC047"; // Cor para Deposity
            }
            else if (DeposityId == DeposityType.Transfer)
            {
                return "#FB539B"; // Cor para Transfer
            }
            // Pode adicionar lógica adicional para outros tipos, se necessário
            return ""; // Retornar uma cor padrão ou vazia se não houver correspondência
        }
    }
}
