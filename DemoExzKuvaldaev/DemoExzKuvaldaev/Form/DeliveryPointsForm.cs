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
    public partial class DeliveryPointsForm: Form
    {
        private PgDeliveryPointsLoader pointsLoader;
        private BindingList<DeliveryPoint> points;
        private User currentUser;

        public DeliveryPointsForm(User user)
        {
            InitializeComponent();
            pointsLoader = new PgDeliveryPointsLoader();
            currentUser = user;
            LoadPoints();

            if (user.RoleName != "Администратор")
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void LoadPoints()
        {
            points = pointsLoader.Load();
            dgvPoints.DataSource = points;
            dgvPoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPoints();
            txtAddress.Visible = false;
            lblAddress.Visible = false;
            btnAddPoint.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtAddress.Visible = true;
            lblAddress.Visible = true;
            btnAddPoint.Visible = true;
            txtAddress.Clear();
            txtAddress.Focus();
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                pointsLoader.AddDeliveryPoint(txtAddress.Text.Trim());
                LoadPoints();
                txtAddress.Text = "";
                txtAddress.Visible = false;
                lblAddress.Visible = false;
                btnAddPoint.Visible = false;
                MessageBox.Show("Пункт выдачи добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Введите адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPoints.SelectedRows.Count > 0)
            {
                DeliveryPoint selectedPoint = dgvPoints.SelectedRows[0].DataBoundItem as DeliveryPoint;
                if (selectedPoint != null)
                {
                    DialogResult result = MessageBox.Show($"Удалить пункт выдачи №{selectedPoint.Id}?\nАдрес: {selectedPoint.Address}",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        pointsLoader.DeleteDeliveryPoint(selectedPoint.Id);
                        LoadPoints();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пункт для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddPoint_Click(sender, e);
            }
        }
    }
}
