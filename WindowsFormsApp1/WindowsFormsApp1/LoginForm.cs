using DemoLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, (string FullName, string Role)> _users;
        public LoginForm()
        {
            InitializeComponent();
            LoadUsersData();
            string imagePath = Path.Combine(Application.StartupPath, @"..\\..\\..\\Import\\Чудо Обувь.png");

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void LoadUsersData()
        {
            _users = new Dictionary<string, (string, string)>(StringComparer.OrdinalIgnoreCase)
            {
                { "isivanov", ("Иванов Иван Сергеевич", "Администратор") },
                { "papetrov", ("Петров Пётр Алексеевич", "Менеджер") },
                { "asidorova", ("Сидорова Анна Дмитриевна", "Авторизованный пользователь") },
                { "ekuznetsova", ("Кузнецова Екатерина Андреевна", "Менеджер") },
                { "dsmirnov", ("Смирнов Дмитрий Владимирович", "Авторизованный пользователь") },
                { "apopov", ("Попов Алексей Николаевич", "Администратор") },
                { "ovasileva", ("Васильева Ольга Игоревна", "Авторизованный пользователь") },
                { "psokolov", ("Соколов Павел Викторович", "Менеджер") },
                { "tmikhailova", ("Михайлова Татьяна Юрьевна", "Авторизованный пользователь") },
                { "nnovikova", ("Новикова Наталья Сергеевна", "Менеджер") },
                { "afedorov", ("Фёдоров Андрей Максимович", "Администратор") },
                { "smorozov", ("Морозов Сергей Павлович", "Авторизованный пользователь") },
                { "jvolkova", ("Волкова Юлия Александровна", "Менеджер") },
                { "aalekseev", ("Алексеев Артём Евгеньевич", "Авторизованный пользователь") },
                { "ilebedeva", ("Лебедева Ирина Владимировна", "Авторизованный пользователь") },
                { "negorov", ("Егоров Никита Денисович", "Менеджер") },
                { "epavlova", ("Павлова Елена Петровна", "Авторизованный пользователь") },
                { "rkozlov", ("Козлов Роман Олегович", "Администратор") },
                { "vstepanova", ("Степанова Виктория Романовна", "Менеджер") },
                { "vnikolaev", ("Николаев Владимир Иванович", "Авторизованный пользователь") }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredLogin = textBox1.Text.Trim(); 

            if (string.IsNullOrEmpty(enteredLogin))
            {
                MessageBox.Show("Пожалуйста, введите логин. Поле не может быть пустым.",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_users.TryGetValue(enteredLogin, out var userData))
            {

                AuthUser.FullName = userData.FullName;
                AuthUser.Role = userData.Role;

                OpenMainForm();
            }
            else
            {

                MessageBox.Show($"Пользователь с логином '{enteredLogin}' не найден.\n\n" +
                                "Проверьте правильность ввода или обратитесь к администратору.\n" +
                                "Примеры логинов: isivanov, papetrov",
                    "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            AuthUser.FullName = "Гость";
            AuthUser.Role = "Гость";

            MessageBox.Show("Вы вошли как гость. Вам доступен только просмотр каталога.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenMainForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите закрыть программу?",
                "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void OpenMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); 
        }
    }
}