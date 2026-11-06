using DemoLib.Models;
using DemoLib.Views;
using System;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ProductsPresenter
    {
        private IProductsModel model_;
        private List<IProductsView> views_ = new List<IProductsView>();

        public ProductsPresenter(IProductsModel model)
        {
            model_ = model;
        }

        public void AddView(IProductsView view)
        {
            views_.Add(view);
        }

        public void SortByPrice(SortOrder sortingOrder)
        {
            List<Product> allProducts = model_.Load();

            if (sortingOrder == SortOrder.Ascending)
            {
                allProducts.Sort(delegate (Product x, Product y)

                {
                    if (x.Price < y.Price) return -1;
                    if (x.Price > y.Price) return 1;
                    return 0;
                });
            }
            else
            {
                allProducts.Sort(delegate (Product x, Product y)

                {
                    if (x.Price < y.Price) return 1;
                    if (x.Price > y.Price) return -1;
                    return 0;
                });
            }
            Update(allProducts);
        }

        public void Update(List<Product> products)
        {

            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];
                IProductsView view = views_[i];

                view.Show(product);
            }
        }
    }
}
