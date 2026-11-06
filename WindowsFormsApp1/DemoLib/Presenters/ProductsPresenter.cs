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
        public void Search(string searchText)
        {
            List<Product> allProducts = model_.Load();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                Update(allProducts);
                return;
            }

            List<Product> filteredProducts = new List<Product>();
            string lowerText = searchText.ToLower();

            foreach (Product product in allProducts)
            {
                bool matchName = false;
                bool matchDesc = false;

                if (product.Name != null && product.Name.ToLower().Contains(lowerText))
                {
                    matchName = true;
                }

                if (product.Parts != null && product.Parts.ToLower().Contains(lowerText))
                {
                    matchDesc = true;
                }

                if (matchName || matchDesc)
                {
                    filteredProducts.Add(product);
                }
            }

            Update(filteredProducts);
        }

        public void Update(List<Product> products)
        {
            foreach (IProductsView view in views_)
            {
                view.SetVisible(false);
            }

            for (int i = 0; i < products.Count; i++)
            {


                if (i >= views_.Count)
                {
                    break;
                }

                views_[i].Show(products[i]);
                views_[i].SetVisible(true);
            }
        }
    }
}
