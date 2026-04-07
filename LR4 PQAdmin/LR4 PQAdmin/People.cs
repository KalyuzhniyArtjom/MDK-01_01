using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_PQAdmin
{
    public class People
    {
        [DisplayName("ФИО")]
        public string Full_name { get; set; }
        [DisplayName("Серия паспорта")]
        public int Passport_series { get; set; }
        [DisplayName("Номер паспорта")]
        public int Passport_number { get; set; }
        [DisplayName("Дата рождения")]
        public int Birth_year { get; set; }
        [DisplayName("Уровень образования")]
        public string Education_level { get; set; }
    }
}
