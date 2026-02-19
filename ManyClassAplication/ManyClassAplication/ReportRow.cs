using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyClassAplication
{
    internal class ReportRow
    {
        public string Product { get; internal set; }
        public int Quantity { get; internal set; }
        public int Price { get; internal set; }

        public struct RepportRow
        {
            public string Product;
            public double Price;
            public int Quantity;
        }
    }
}
