using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyClassAplication
{
    internal class Report
    {
        public List<ReportRow> reportRows_ = new List<ReportRow>();

        public void AddReport(ReportRow row)
        {
            reportRows_.Add(row);
        }

        static public string ConvertRowToString(ReportRow row)
        {
            return $"{row.Product}, {row.Quantity}, {row.Price}.";
        }

        public void PrintReport()
        {
            foreach (ReportRow row in reportRows_)
            {
                Console.WriteLine(ConvertRowToString(row));
            }
        }
    }
}
