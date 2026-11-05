using DemoLib.Models;
using DemoLib.Presenters;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private ProductsPresenter productsPresenter_;
        private ProductsModel model_;

        public MainForm()
        {

            InitializeComponent();
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#D2F6E7");
            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#D2F6E7");
            string imagePath = Path.Combine(Application.StartupPath, "..\\..\\..\\Import\\Чудо Обувь.png");

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
            int countProducts = model_.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            productsPresenter_.Update();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}