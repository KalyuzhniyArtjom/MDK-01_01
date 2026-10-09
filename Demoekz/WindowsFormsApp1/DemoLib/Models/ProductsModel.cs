using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_ = new List<Product>();

        public ProductsModel()
        {
            data_.Add(new Product { Name = "Противоскользящие немецкие кеды PAUL FRANK для женщин", Category = "Кроссовки", Count = 4, Price = 2296.0, Supplier = "PAUL FRANK", Parts = " 87% Искусственная кожа, 13% Поливинилхлорид (ПВХ)",
                ImagePath = "D:\\testart\\Demoekz\\WindowsFormsApp1\\Images\\pfff.png"
            });
            data_.Add(new Product { Name = "Повседневная мужская обувь Nike Air max Correlate", Category = "Кроссовки", Count = 11, Price = 5500.0, Supplier = "Nike", Parts = " 80% Искусственная кожа, 11% Поливинилхлорид (ПВХ), 9% Сетка",
            ImagePath = "D:\\testart\\Demoekz\\WindowsFormsApp1\\Images\\nkkk.jpg"
            });
            data_.Add(new Product
            {
                Name = "OSOCE Низкий Топ Повседневная Обувь Женская",
                Category = "Угги",
                Count = 7,
                Price = 1100.0,
                Supplier = "OSOCE",
                Parts = "89% Замша, 11% Резина",
                ImagePath = ""
            });
        }

        public List<Product> Load()
        {
            return data_;
        }

        public int GetCountProducts()
        {
            return data_.Count;
        }
    }
}
