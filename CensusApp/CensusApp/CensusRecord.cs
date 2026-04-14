using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusApp
{
    public class CensusRecord
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public int BirthYear { get; set; }
        public string EducationLevel { get; set; }
    }
}
