using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KalyuzhniyDemo
{
    public partial class ProductForm: Form
    {
        private PgProductsLoader loader;
        private Product editingProduct;
        private bool isEditMode;

        public ProductForm(PgProductsLoader productsLoader)
        {
            InitializeComponent();
            loader = productsLoader;
            isEditMode = false;
            this.Text = "Добавление товара";
        }

        public ProductForm(PgProductsLoader productsLoader, Product product)
        {
            InitializeComponent();
            loader = productsLoader;
            editingProduct = product;
            isEditMode = true;
            this.Text = "Редактирование товара";
            LoadProductData();
        }

        private void LoadProductData()
        {
            if (editingProduct != null)
            {
                txtArticle.Text = editingProduct.Article;
                txtArticle.ReadOnly = true;
                txtName.Text = editingProduct.Name;
                numPrice.Value = editingProduct.Price;
                txtSupplier.Text = editingProduct.Supplier;
                txtManufacturer.Text = editingProduct.Manufacturer;
                txtCategory.Text = editingProduct.Category;
                numDiscount.Value = editingProduct.Discount;
                numStock.Value = editingProduct.Stock;
                txtDescription.Text = editingProduct.Description;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArticle.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Заполните артикул и название товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product product = new Product
            {
                Article = txtArticle.Text,
                Name = txtName.Text,
                Unit = "шт.",
                Price = numPrice.Value,
                Supplier = txtSupplier.Text,
                Manufacturer = txtManufacturer.Text,
                Category = txtCategory.Text,
                Discount = (int)numDiscount.Value,
                Stock = (int)numStock.Value,
                Description = txtDescription.Text
            };

            if (isEditMode)
            {
                loader.UpdateProduct(product);
            }
            else
            {
                loader.AddProduct(product);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
