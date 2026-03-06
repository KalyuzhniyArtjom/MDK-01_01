using ModelViewLib.Model;
using ModelViewLib.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Class_Library
{
    public partial class AddForm: Form
    {
        public IUsersModel usersModel_;
        public User user_;
        public User user
        {
            get { return user_; }

            set { user_ = value; }  
        }
        public AddForm(IUsersModel model)
        {
            InitializeComponent();
            usersModel_ = model;
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            List<User> Allusers = new List<User>();
            user_ = new User(textBoxLogin.Text, textBoxPassword.Text, textBoxName.Text);
            bool result = usersModel_.AddUser(user);
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Введите все поля!");
            }
            else
            {
                if (result)
                {
                    MessageBox.Show("Пользователь успешно добавлен", "Внимание!", MessageBoxButtons.OK);
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("Пользователь уже существует(", "ОШИБКА!", MessageBoxButtons.OK);
                    DialogResult = DialogResult.Yes;
                }
            }
        }
    }
}
