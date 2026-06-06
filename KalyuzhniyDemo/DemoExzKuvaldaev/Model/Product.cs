using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KalyuzhniyDemo
{
    public class Product : INotifyPropertyChanged
    {
        private string article_;
        private string name_;
        private string unit_;
        private decimal price_;
        private string supplier_;
        private string manufacturer_;
        private string category_;
        private int discount_;
        private int stock_;
        private string description_;

        [DisplayName("Артикул")]
        public string Article
        {
            get { return article_; }
            set { article_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Наименование")]
        public string Name
        {
            get { return name_; }
            set { name_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Ед.изм")]
        public string Unit
        {
            get { return unit_; }
            set { unit_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Цена")]
        public decimal Price
        {
            get { return price_; }
            set { price_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Поставщик")]
        public string Supplier
        {
            get { return supplier_; }
            set { supplier_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Производитель")]
        public string Manufacturer
        {
            get { return manufacturer_; }
            set { manufacturer_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Категория")]
        public string Category
        {
            get { return category_; }
            set { category_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Скидка %")]
        public int Discount
        {
            get { return discount_; }
            set { discount_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Остаток")]
        public int Stock
        {
            get { return stock_; }
            set { stock_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Цена со скидкой")]
        public decimal PriceWithDiscount => Price * (100 - Discount) / 100;

        [DisplayName("Описание")]
        public string Description
        {
            get { return description_; }
            set { description_ = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
