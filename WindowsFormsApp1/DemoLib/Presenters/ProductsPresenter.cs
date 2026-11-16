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

        // Храним текущее состояние фильтров
        private string _currentSearchText = "";
        private string _currentCategory = "Все категории";

        public ProductsPresenter(IProductsModel model)
        {
            model_ = model;
        }

        public void AddView(IProductsView view)
        {
            views_.Add(view);
        }

        // ================= 1. СОРТИРОВКА =================
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

        // ================= 2. ФИЛЬТР ПО КАТЕГОРИИ =================
        public void ApplyFilter(string category)
        {
            _currentCategory = category;
            ApplyFilterAndSearch();
        }

        // ================= 3. ПОИСК ПО ТЕКСТУ =================
        public void ApplySearch(string searchText)
        {
            _currentSearchText = searchText;
            ApplyFilterAndSearch();
        }

        // ================= 4. ОБЩИЙ МЕТОД (Совмещает фильтр и поиск) =================
        private void ApplyFilterAndSearch()
        {
            List<Product> allProducts = model_.Load();
            List<Product> filteredProducts = new List<Product>();

            string lowerText = _currentSearchText.ToLower();

            foreach (Product product in allProducts)
            {
                // 1. Проверка по категории
                bool matchCategory = true;
                if (_currentCategory != "Все категории" && !string.IsNullOrEmpty(_currentCategory))
                {
                    matchCategory = (product.Category == _currentCategory);
                }

                // 2. Проверка по тексту (название или описание)
                bool matchText = true;
                if (!string.IsNullOrWhiteSpace(_currentSearchText))
                {
                    matchText = (product.Name != null && product.Name.ToLower().Contains(lowerText)) ||
                                (product.Parts != null && product.Parts.ToLower().Contains(lowerText));
                }

                // Если товар прошел и фильтр, и поиск — добавляем
                if (matchCategory && matchText)
                {
                    filteredProducts.Add(product);
                }
            }

            Update(filteredProducts);
        }

        // ================= 5. ОБНОВЛЕНИЕ КАРТОЧЕК =================
        public void Update(List<Product> products)
        {
            // Сначала прячем все карточки
            for (int i = 0; i < views_.Count; i++)
            {
                views_[i].SetVisible(false);
            }

            // Показываем и заполняем только подходящие
            for (int i = 0; i < products.Count; i++)
            {
                if (i >= views_.Count) break;

                views_[i].Show(products[i]);
                views_[i].SetVisible(true);
            }
        }
    }
}