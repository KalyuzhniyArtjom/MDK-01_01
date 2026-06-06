using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KalyuzhniyDemo
{
    public class DeliveryPoint : INotifyPropertyChanged
    {
        private int id_;
        private string address_;

        [DisplayName("ID")]
        public int Id
        {
            get { return id_; }
            set { id_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Адрес")]
        public string Address
        {
            get { return address_; }
            set { address_ = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
