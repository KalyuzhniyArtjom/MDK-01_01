using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyClassAplication
{
    internal class Warehouse
    {
        private int identifier_;
        private string location_;
        public Dictionary<Goods, int> productsCount_ = new Dictionary<Goods, int>();

        public void SetIdentifier(int identifier)
        {
            identifier_ = identifier;
        }

        public int GetIdentifier()
        {
            return identifier_;
        }

        public void SetLocation(string location)
        {
            location_ = location;
        }

        public string GetLocation()
        {
            return location_;
        }

        public void SetProductCount(Goods product, int count)
        {
            productsCount_.Add(product, count);
        }

        public Dictionary<Goods, int> GetProductCount()
        {
            return productsCount_;
        }

        public void CalculateMoney()
        {
            double sum = 0;
            foreach (Goods products in productsCount_.Keys)
            {
                sum += products.GetPrice() * productsCount_[products];
            }
            Console.WriteLine(sum);
        }
    }
}