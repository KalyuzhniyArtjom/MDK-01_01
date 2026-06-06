using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalyuzhniyDemo
{
    public partial class OrdersForm: Form
    {
        private PgOrdersLoader ordersLoader;
        private BindingList<Order> orders;
        private User currentUser;

        public OrdersForm(User user)
        {
            InitializeComponent();
            ordersLoader = new PgOrdersLoader();
            currentUser = user;
            LoadOrders();
        }

        private void LoadOrders()
        {
            orders = ordersLoader.Load();
            dgvOrders.DataSource = orders;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                Order selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    var items = ordersLoader.GetOrderItems(selectedOrder.OrderNumber);
                    dgvItems.DataSource = items;
                    dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Показываем панель с составом заказа
                    splitContainer.Panel2Collapsed = false;
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                Order selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    cmbStatus.Text = selectedOrder.Status;
                }
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                Order selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as Order;
                if (selectedOrder != null && !string.IsNullOrEmpty(cmbStatus.Text))
                {
                    DialogResult result = MessageBox.Show($"Изменить статус заказа №{selectedOrder.OrderNumber} на \"{cmbStatus.Text}\"?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ordersLoader.UpdateOrderStatus(selectedOrder.OrderNumber, cmbStatus.Text);
                        LoadOrders();
                        MessageBox.Show("Статус обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHideItems_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2Collapsed = true;
        }
    }
}
