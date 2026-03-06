using ModelViewLib.Model;
using ModelViewLib.ModelViews;
using ModelViewLib.Presenters;
using ModelViewLib.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Library
{
    public partial class MainForm : Form
    {
        IUsersModel model_ = new MemoryUsersModel();
        private UserPresenter presenter_;
        public MainForm()
        {
            InitializeComponent();
            presenter_ = new UserPresenter(new MemoryUsersModel(), UsersView);
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить пользователя?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
               List<User> selectedUsers = UsersView.GetSelectedUsers();
                presenter_.RemoveUsers(selectedUsers);
            }

        }
        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            AddForm addUser = new AddForm(model_);
            if (addUser.ShowDialog() == DialogResult.Yes)
            {
                presenter_.AddUser(addUser.user);
            }
        }

    }
}
