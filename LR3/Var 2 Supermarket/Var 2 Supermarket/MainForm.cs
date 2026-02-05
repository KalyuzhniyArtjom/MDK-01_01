using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Var_2_Supermarket
{
    public partial class MainForm : Form
    {
        private Dictionary<string, List<Product>> products_ = new Dictionary<string, List<Product>>();
        public MainForm()
        {
            InitializeComponent();

            products_.Add("Кондитерские изделия", new List<Product>()
            {
                new Product("Печенье Юбилейное", 50.50, "Юбиленое", new DateTime(2026, 3, 5), "Вкусное печенье", "D:\\VS studio\\LR3\\image\\Печенье.png"),
                new Product("Молочный ломтик", 75.00, "Завод киндер", new DateTime(2026, 2, 15), "Нежная вкуснятина", "D:\\VS studio\\LR3\\image\\Ломтик.jpg"),
                
            }
        );
            products_.Add("Напитки", new List<Product>()
            {
                new Product("Кока-Кола", 100.00, "Кока-Кола", new DateTime(2026, 4, 20), "Хорошо для праздника", "D:\\VS studio\\LR3\\image\\Кола.jpg"),
                new Product("Колокольчик", 45.00, "Фруто", new DateTime(2026, 2, 23), "Вкус детства", "D:\\VS studio\\LR3\\image\\Колокольчик.jpg"),
            }
        );
            List<string> allCategories = products_.Keys.ToList();
            CategoriesListBox.DataSource = allCategories;
        }
        private void CategoriesListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedCategory = CategoriesListBox.SelectedItem.ToString();
            List<Product> productsSelectedCategory = products_[selectedCategory];
            ProductsComboBox.DataSource = productsSelectedCategory;
            ProductsComboBox.DisplayMember = "Name";
        }

        private void ProductsComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Product selectedProduct = ProductsComboBox.SelectedItem as Product;
            if (selectedProduct != null)
            {
                PriceLabel.Text = selectedProduct.Price.ToString();
                ManufacturerLabel.Text = selectedProduct.Manufacturer;
                ExpiryLabel.Text = selectedProduct.Expiry;
                DescriptionLabel.Text = selectedProduct.Description;

                ProductsPictureBox.Load(selectedProduct.Path);

            }
        }

        private void OrderButton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляю!", "Заказ успешно оформлен!");
        }
    }
}
