using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyClassAplication
{
    internal class Goods
    {
        private string name_;
        private int price_;

        public void SetName(string name)
        {
            name_ = name;
        }

        public string GetName()
        {
            return name_;
        }

        public void SetPrice(int price)
        {
            price_ = price;
        }

        public double GetPrice()
        {
            return price_;
        }
    }
}
