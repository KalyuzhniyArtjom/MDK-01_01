using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSales.Model
{
    internal class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerVisit { get; set; }

        public Section(int id, string name, decimal pricePerVisit)
        {
            Id = id;
            Name = name;
            PricePerVisit = pricePerVisit;
        }

        public override string ToString()
        {
            return $"{Name} - {PricePerVisit:C} за занятие";
        }
    }
}
