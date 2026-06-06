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
    public partial class MainForm: Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.Text = $"Магазин обуви - {currentUser.FullName} ({currentUser.RoleName})";
            ConfigureMenuByRole();
        }

        private void ConfigureMenuByRole()
        {
            if (currentUser.RoleName == "Менеджер")
            {
                пользователиToolStripMenuItem.Visible = false;
            }
            else if (currentUser.RoleName == "Авторизированный клиент")
            {
                товарыToolStripMenuItem.Visible = false;
                пунктыВыдачиToolStripMenuItem.Visible = false;
                пользователиToolStripMenuItem.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Пользователь: {currentUser.FullName} ({currentUser.RoleName})";
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsForm form = new ProductsForm(currentUser);
            form.MdiParent = this;
            form.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm form = new OrdersForm(currentUser);
            form.MdiParent = this;
            form.Show();
        }

        private void пунктыВыдачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryPointsForm form = new DeliveryPointsForm(currentUser);
            form.MdiParent = this;
            form.Show();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.RoleName == "Администратор")
            {
                MessageBox.Show("Форма управления пользователями в разработке", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Доступ запрещен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
