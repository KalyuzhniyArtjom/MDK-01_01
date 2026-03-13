using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSales.Model
{
    internal class SportsData
    {
        public List<Section> Sections { get; private set; }
        public List<Visit> Visits { get; private set; }

        public SportsData()
        {
            Sections = new List<Section>();
            Visits = new List<Visit>();
            InitializeData();
        }

        /// <summary>
        /// Инициализация тестовых данных (март 2024)
        /// </summary>
        private void InitializeData()
        {
            Sections.Add(new Section(1, "Футбол", 500));
            Sections.Add(new Section(2, "Плавание", 600));
            Sections.Add(new Section(3, "Теннис", 800));
            Sections.Add(new Section(4, "Баскетбол", 450));
            Sections.Add(new Section(5, "Волейбол", 400));
            Sections.Add(new Section(6, "Хоккей", 700));

            // Футбол 
            Visits.Add(new Visit(1, new DateTime(2024, 3, 10), 22));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 11), 18));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 12), 24));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 13), 20));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 14), 25));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 15), 19));
            Visits.Add(new Visit(1, new DateTime(2024, 3, 16), 23));

            // Плавание
            Visits.Add(new Visit(2, new DateTime(2024, 3, 10), 15));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 11), 14));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 12), 18));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 13), 16));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 14), 20));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 15), 17));
            Visits.Add(new Visit(2, new DateTime(2024, 3, 16), 19));

            // Теннис 
            Visits.Add(new Visit(3, new DateTime(2024, 3, 10), 8));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 11), 10));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 12), 12));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 13), 9));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 14), 11));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 15), 14));
            Visits.Add(new Visit(3, new DateTime(2024, 3, 16), 10));

            // Баскетбол 
            Visits.Add(new Visit(4, new DateTime(2024, 3, 10), 16));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 11), 14));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 12), 18));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 13), 20));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 14), 17));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 15), 19));
            Visits.Add(new Visit(4, new DateTime(2024, 3, 16), 21));

            // Волейбол 
            Visits.Add(new Visit(5, new DateTime(2024, 3, 10), 12));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 11), 10));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 12), 14));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 13), 11));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 14), 13));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 15), 15));
            Visits.Add(new Visit(5, new DateTime(2024, 3, 16), 12));

            // Хоккей 
            Visits.Add(new Visit(6, new DateTime(2024, 3, 10), 10));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 11), 12));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 12), 14));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 13), 9));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 14), 11));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 15), 13));
            Visits.Add(new Visit(6, new DateTime(2024, 3, 16), 15));
        }

        public List<Visit> GetVisitsForSection(int sectionId)
        {
            return Visits.Where(v => v.SectionId == sectionId).ToList();
        }
        public Dictionary<string, decimal> GetRevenueBySection()
        {
            var revenue = new Dictionary<string, decimal>();

            foreach (var section in Sections)
            {
                decimal totalRevenue = Visits
                    .Where(v => v.SectionId == section.Id)
                    .Sum(v => v.VisitorCount * section.PricePerVisit);

                revenue.Add(section.Name, totalRevenue);
            }

            return revenue;
        }
    }
}
