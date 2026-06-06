using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KalyuzhniyDemo
{
    public class Order : INotifyPropertyChanged
    {
        private int orderNumber_;
        private DateTime orderDate_;
        private DateTime deliveryDate_;
        private int deliveryPointId_;
        private string deliveryPointAddress_;
        private int userId_;
        private string userFullName_;
        private string pickupCode_;
        private string status_;

        [DisplayName("Номер заказа")]
        public int OrderNumber
        {
            get { return orderNumber_; }
            set { orderNumber_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Дата заказа")]
        public DateTime OrderDate
        {
            get { return orderDate_; }
            set { orderDate_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Дата доставки")]
        public DateTime DeliveryDate
        {
            get { return deliveryDate_; }
            set { deliveryDate_ = value; OnPropertyChanged(); }
        }

        [DisplayName("ID пункта")]
        public int DeliveryPointId
        {
            get { return deliveryPointId_; }
            set { deliveryPointId_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Адрес выдачи")]
        public string DeliveryPointAddress
        {
            get { return deliveryPointAddress_; }
            set { deliveryPointAddress_ = value; OnPropertyChanged(); }
        }

        [DisplayName("ID клиента")]
        public int UserId
        {
            get { return userId_; }
            set { userId_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Клиент")]
        public string UserFullName
        {
            get { return userFullName_; }
            set { userFullName_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Код получения")]
        public string PickupCode
        {
            get { return pickupCode_; }
            set { pickupCode_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Статус")]
        public string Status
        {
            get { return status_; }
            set { status_ = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
