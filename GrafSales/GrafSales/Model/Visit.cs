using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafSales.Model
{
    internal class Visit
    {
        public int SectionId { get; set; }
        public DateTime Date { get; set; }
        public int VisitorCount { get; set; }

        public Visit(int sectionId, DateTime date, int visitorCount)
        {
            SectionId = sectionId;
            Date = date;
            VisitorCount = visitorCount;
        }
    }
}
