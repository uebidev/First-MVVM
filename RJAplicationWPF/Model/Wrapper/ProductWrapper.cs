using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RJAplicationWPF.Model.Wrapper
{
    public class ProductWrapper : Product, INotifyPropertyChanged
    {
        private Product _product; // Adicionado um campo para a instância de Product

        public ProductWrapper()
        {

        }
        public ProductWrapper(Product product)
        {
            _product = product; // Inicializa o campo com a instância de Product
        }
        private bool _isModified;
        public bool IsModified
        {
            get { return _isModified; }
            set { _isModified = value; NotifyPropertyChanged(); }
        }
        private bool _isAdd;
        public bool IsAdd
        {
            get { return _isAdd; }
            set { _isAdd = value; NotifyPropertyChanged(); }
        }

        public long Id
        {
            get { return _product.Id; }
            set { _product.Id = value; NotifyPropertyChanged(); }
        }

        public string Title
        {
            get { return _product.Title; }
            set
            {
                _product.Title = value;

                NotifyPropertyChanged();
            }
        }

        public double Price
        {
            get { return _product.Price; }
            set { _product.Price = value; NotifyPropertyChanged(); }
        }

        public string Description
        {
            get { return _product.Description; }
            set { _product.Description = value; NotifyPropertyChanged(); }
        }

        public Product Product { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
