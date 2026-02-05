using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var_2_Supermarket
{
    public class Product
    {
        private string name_;
        private double price_;
        private string manufacturer_;
        private DateTime expiry_;
        private string description_;
        private string path_;
        public Product(string name, double price, string manufacturer, DateTime expiry, string description, string path)
        {
            name_ = name;
            price_ = price;
            manufacturer_ = manufacturer;
            expiry_ = expiry;
            description_ = description;
            path_ = path;
        }
        public string Name
        {
            get { return name_; }
        }
        public double Price
        {
            get { return price_; }
        }
        public string Manufacturer
        {
            get { return manufacturer_; }
        }
        public string Expiry
        {
            get
            {
                return expiry_.ToString("dd.MM.yyyy");
            }
        }
        public string Description
        {
            get { return description_; }
        }
        public string Path
        { get { return path_; } }
    }
}