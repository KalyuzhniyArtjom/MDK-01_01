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
    public partial class ProductsForm: Form
    {
        private PgProductsLoader productsLoader;
        private BindingList<Product> products;
        private User currentUser;

        public ProductsForm(User user)
        {
            InitializeComponent();
            productsLoader = new PgProductsLoader();
            currentUser = user;
            LoadProducts();

            if (user.RoleName != "Администратор")
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void LoadProducts()
        {
            products = productsLoader.Load();
            dgvProducts.DataSource = products;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(productsLoader);
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                Product selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (selectedProduct != null)
                {
                    ProductForm productForm = new ProductForm(productsLoader, selectedProduct);
                    if (productForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                Product selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (selectedProduct != null)
                {
                    DialogResult result = MessageBox.Show($"Удалить товар \"{selectedProduct.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        productsLoader.DeleteProduct(selectedProduct.Article);
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                var searchResult = productsLoader.SearchProducts(searchText);
                dgvProducts.DataSource = searchResult;
            }
            else
            {
                LoadProducts();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
