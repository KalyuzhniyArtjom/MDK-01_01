using DemoLib;
using DemoLib.Models;
using DemoLib.Presenters;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SortOrder = DemoLib.SortOrder;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private ProductsPresenter productsPresenter_;
        private ProductsModel model_;

        public MainForm()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;             
            tabControl1.Dock = DockStyle.Fill;       
            tabPage2.Dock = DockStyle.Fill;           
            OrdersGrid.Dock = DockStyle.Fill;         
            OrdersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
  
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(MainLayout, true, null);

            string imagePath = Path.Combine(Application.StartupPath, "..\\..\\..\\Import\\Чудо Обувь безфона.png");

            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            IOrderRepository repository = new PostgresOrderRepository();
            model_ = new ProductsModel(repository);

            productsPresenter_ = new ProductsPresenter(model_);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // Вывод ФИО и Роли
            if (lblUserInfo != null)
            {
                lblUserInfo.Text = AuthUser.FullName;
            }

            if (lblUserRole != null)
            {
                lblUserRole.Text = AuthUser.Role;
            }

            // Загрузка аватарки
            string avatarPath = Path.Combine(Application.StartupPath, @"..\\..\\..\\Import\\Заглушка фото профиля безфона.png");

            if (File.Exists(avatarPath))
            {
                pictureBox2.Image = Image.FromFile(avatarPath);
            }

            // Блокировка для гостя
            if (AuthUser.Role == "Гость")
            {
                SearchTextBox.Enabled = false;
                PriceSortingComboBox.Enabled = false;
                SearchTextBox.BackColor = Color.LightGray;
                PriceSortingComboBox.BackColor = Color.LightGray;
            }

            // --- ЗАГРУЗКА ТОВАРОВ ---
            int countProducts = model_.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            List<Product> products = model_.Load();
            productsPresenter_.Update(products);

            // Заполняем ComboBox категориями
            CategoryComboBox.Items.Clear();
            CategoryComboBox.Items.Add("Все категории");

            foreach (Product p in products)
            {
                if (!CategoryComboBox.Items.Contains(p.Category))
                {
                    CategoryComboBox.Items.Add(p.Category);
                }
            }
            CategoryComboBox.SelectedIndex = 0;

            // --- ЗАГРУЗКА ЗАКАЗОВ ---
            LoadOrders();
        }

        private void LoadOrders()
        {
            IOrderRepository repo = new PostgresOrderRepository();
            List<Order> orders = repo.Load();

            OrdersGrid.DataSource = orders;

            // Настройка внешнего вида таблицы
            OrdersGrid.AllowUserToAddRows = false;
            OrdersGrid.ReadOnly = true;
            OrdersGrid.RowHeadersVisible = false;

            // Скрываем лишнюю колонку со списком товаров
            if (OrdersGrid.Columns["Items"] != null)
                OrdersGrid.Columns["Items"].Visible = false;

            // Настраиваем заголовки
            if (OrdersGrid.Columns["Id"] != null)
                OrdersGrid.Columns["Id"].HeaderText = "Номер";

            if (OrdersGrid.Columns["OrderDate"] != null)
                OrdersGrid.Columns["OrderDate"].HeaderText = "Дата";

            if (OrdersGrid.Columns["UserFullName"] != null)
                OrdersGrid.Columns["UserFullName"].HeaderText = "ФИО клиента";
        }

        private void OrdersGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Order selectedOrder = OrdersGrid.Rows[e.RowIndex].DataBoundItem as Order;

            if (selectedOrder != null)
            {
                OrderDetailsForm detailsForm = new OrderDetailsForm(selectedOrder);
                detailsForm.ShowDialog();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PriceSortingComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (PriceSortingComboBox.SelectedIndex < 0) return;

            MainLayout.SuspendLayout();
            SortOrder sortingOrder = (SortOrder)PriceSortingComboBox.SelectedIndex;
            productsPresenter_.SortByPrice(sortingOrder);
            MainLayout.ResumeLayout(true);
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MainLayout.SuspendLayout();
            string selectedCategory = CategoryComboBox.SelectedItem?.ToString();
            productsPresenter_.ApplyFilter(selectedCategory);
            MainLayout.ResumeLayout(true);
        }

        private void SearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            MainLayout.SuspendLayout();
            productsPresenter_.ApplySearch(SearchTextBox.Text);
            MainLayout.ResumeLayout(true);
        }
    }
}
