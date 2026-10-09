using DemoLib;
using DemoLib.Views;
using System.Drawing;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard: UserControl, IProductsView
    {
        public ProductCard()
        {
            InitializeComponent();
            foreach(Control c in Controls)
            {
                c.MouseMove += ProductCard_MouseMove;
                c.MouseLeave += ProductCard_MouseLeave;
            }
            
        }

        public void Show(Product product)
        {
            CategoryLabel.Text = product.Category;
            if (product.Count > 5)
            {
                CountLabel.Text = product.Count.ToString() + " (много)";
            }
            else
            {
                CountLabel.Text = product.Count.ToString() + " (мало)";
            }
                PartsLabel.Text = product.Parts;
            PriceProductLabel.Text = product.Price.ToString() + " руб.";
            SupplierLabel.Text = product.Supplier + " | " + product.Name; 

            if (product.ImagePath == "" || product.ImagePath == null)
            {
                ImagePictureBox.ImageLocation = "D:\\testart\\Demoekz\\WindowsFormsApp1\\Images\\picture.png";
            }
            else
            {
                ImagePictureBox.ImageLocation = product.ImagePath;
            }      
            
            if (product.Count <= 3)
            {
                string hexColor = "#FF8080";
                Color color = ColorTranslator.FromHtml(hexColor);
                BackColor = color;
                //if (ProductCard_MouseLeave)
                //{
                //    BackColor = color;
                //}

            }

        }

        private void ProductCard_MouseMove(object sender, MouseEventArgs e)
        {
            string hexColor = "#70B2AF"; 
            Color color = ColorTranslator.FromHtml(hexColor); 
            BackColor = color;
        }

        private void ProductCard_MouseLeave(object sender, System.EventArgs e)
        {

            string hexColor = "#D2F6E7";
            Color color = ColorTranslator.FromHtml(hexColor);
            BackColor = color;
            
        }

        private void ProductCard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void ProductCard_Load(object sender, System.EventArgs e)
        {

        }
    }
}
