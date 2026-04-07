using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_PQAdmin
{
    public partial class MainForm : Form
    {
        PGPeapleLoader loader = new PGPeapleLoader();
        List<string> info = new List<string>();
        public MainForm()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BindingList<People> users = loader.Load();
            dataGridView.DataSource = users;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимамние!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                People pip = row.DataBoundItem as People;
                loader.DeleteSelectUser(pip.Full_name);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить все записи?", "Внимамние!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                loader.ClearAllUsers();
            }
        }
       

        }
    }

