using DemoLib;
using DemoLib.Views;
using System.Drawing;
using System.IO; // Добавили для работы с файлами
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : UserControl, IProductsView
    {
        private Product product_;

        private Color normalColor_ = ColorTranslator.FromHtml("#D2F6E7");
        private Color enteringColor_ = ColorTranslator.FromHtml("#70B2AF");
        private Color deficitColor_ = ColorTranslator.FromHtml("#FF8080");

        public ProductCard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            foreach (Control c in Controls)
            {
                c.MouseMove += ProductCard_MouseMove;
                c.MouseLeave += ProductCard_MouseLeave;
            }
        }

        private string CountText()
        {
            if (product_.Count > 5)
            {
                return product_.Count.ToString() + " (много)";
            }
            return product_.Count.ToString() + " (мало)";
        }

        // Исправленный метод получения пути к картинке
        private string ImagePath()
        {
            // Базовая папка с картинками
            string basePath = Path.Combine(Application.StartupPath, @"..\..\..\Import\Images\");

            // Если в базе пусто - показываем заглушку
            if (string.IsNullOrEmpty(product_.ImagePath))
            {
                return Path.Combine(basePath, "picture.png");
            }

            // Склеиваем путь и имя файла из базы
            string fullPath = Path.Combine(basePath, product_.ImagePath);

            // Если файла нет - показываем заглушку
            if (!File.Exists(fullPath))
            {
                return Path.Combine(basePath, "picture.png");
            }

            return fullPath;
        }

        private Color GetColor()
        {
            if (product_.Count <= 3)
            {
                return deficitColor_;
            }
            return normalColor_;
        }

        public void Show(Product product)
        {
            product_ = product;

            CategoryLabel.Text = product.Category;
            CountLabel.Text = CountText();
            PartsLabel.Text = product.Parts;

            PriceProductLabel.Text = product.Price.ToString("0.##") + " руб.";
            SupplierLabel.Text = product.Supplier + " | " + product.Name;

            string finalPath = ImagePath();
            ImagePictureBox.ImageLocation = finalPath;

            BackColor = GetColor();
        }

        private void ProductCard_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = enteringColor_;
        }

        private void ProductCard_MouseLeave(object sender, System.EventArgs e)
        {
            BackColor = GetColor();
        }

        public void SetVisible(bool visible)
        {
            this.Visible = visible;
        }
    }
}