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
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(MainLayout, true, null);

            string imagePath = Path.Combine(Application.StartupPath, "..\\..\\..\\Import\\Чудо Обувь безфона.png");

            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            IOrderRepository repository = new MemoryOrderRepository();
            model_ = new ProductsModel(repository);

            productsPresenter_ = new ProductsPresenter(model_);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (lblUserInfo != null)
            {
                lblUserInfo.Text = AuthUser.FullName;
            }

            if (lblUserRole != null)
            {
                lblUserRole.Text = AuthUser.Role;
            }

            string avatarPath = Path.Combine(Application.StartupPath, @"..\\..\\..\\Import\\Заглушка фото профиля безфона.png");

            if (File.Exists(avatarPath))
            {
                pictureBox2.Image = Image.FromFile(avatarPath);
            }


            if (AuthUser.Role == "Гость")
            {
                SearchTextBox.Enabled = false;
                PriceSortingComboBox.Enabled = false;
                SearchTextBox.BackColor = Color.LightGray;
                PriceSortingComboBox.BackColor = Color.LightGray;
            }


            int countProducts = model_.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            List<Product> products = model_.Load();
            productsPresenter_.Update(products);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PriceSortingComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (PriceSortingComboBox.SelectedIndex < 0)
            {
                return;
            }

            MainLayout.SuspendLayout();

            SortOrder sortingOrder = (SortOrder)PriceSortingComboBox.SelectedIndex;
            productsPresenter_.SortByPrice(sortingOrder);

            MainLayout.ResumeLayout(true);
        }

        private void SearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            MainLayout.SuspendLayout();

            productsPresenter_.Search(SearchTextBox.Text);

            MainLayout.ResumeLayout(true);
        }
    }
}