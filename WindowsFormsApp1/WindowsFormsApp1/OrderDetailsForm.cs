using DemoLib.Models;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OrderDetailsForm : Form
    {
        public OrderDetailsForm(Order order)
        {
            InitializeComponent();

            // Заголовок окна и Label
            this.Text = $"Заказ №{order.Id} от {order.OrderDate:dd.MM.yyyy}";
            lblTitle.Text = $"Заказ №{order.Id} | Клиент: {order.UserFullName}";

            // Настраиваем таблицу
            ItemsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsGrid.ReadOnly = true;
            ItemsGrid.AllowUserToAddRows = false;
            ItemsGrid.RowHeadersVisible = false;

            // Привязываем список товаров
            ItemsGrid.DataSource = order.Items;
        }
    }
}