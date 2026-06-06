using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KalyuzhniyDemo
{
    public class OrderItem : INotifyPropertyChanged
    {
        private int id_;
        private int orderNumber_;
        private string productArticle_;
        private string productName_;
        private int quantity_;
        private decimal price_;
        private decimal total_;

        [DisplayName("ID")]
        public int Id
        {
            get { return id_; }
            set { id_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Номер заказа")]
        public int OrderNumber
        {
            get { return orderNumber_; }
            set { orderNumber_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Артикул")]
        public string ProductArticle
        {
            get { return productArticle_; }
            set { productArticle_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Товар")]
        public string ProductName
        {
            get { return productName_; }
            set { productName_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Количество")]
        public int Quantity
        {
            get { return quantity_; }
            set { quantity_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Цена")]
        public decimal Price
        {
            get { return price_; }
            set { price_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Сумма")]
        public decimal Total
        {
            get { return total_; }
            set { total_ = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
