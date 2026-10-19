using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoLib.Models;
using DemoLib;
using System.Collections.Generic;

namespace DemoTesting
{
    [TestClass]
    public class TOrder
    {
        [TestMethod]
        public void TestTwoMonthsAgo()
        {
            ProductsModel model = new ProductsModel();
            model.LoadOrders().Clear();

            List<Product> productsList = new List<Product>();

            productsList.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = "90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские белые босоножки с широким каблуком среднего размера",
                Category = "Туфли",
                Count = 2,
                Price = 500.0,
                Supplier = "T-TACCARDI",
                Parts = "94% натуральная кожа, 6% полиуретан",
                ImagePath = "..\\..\\..\\Images\\IMG_WSd_185551.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские классические туфли на шпильке",
                Category = "Туфли",
                Count = 7,
                Price = 900.0,
                Supplier = "Kari",
                Parts = "96% натуральная кожа, 4% полиуретан",
                ImagePath = "..\\..\\..\\Images\\picture.png"
            });

            model.UpdateListModel(productsList);

            List<double> startPrices = new List<double>();
            startPrices.Add(1300.0);
            startPrices.Add(500.0);
            startPrices.Add(900.0);

            Order orderOne = new Order();
            orderOne.Items = new List<OrderItem>();
            orderOne.Items.Add(new OrderItem
            {
                ProductItem = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Count = 10,
                SaleDate = new System.DateTime(2026, 10, 15)
            });

            List<Order> orderList = new List<Order>();
            orderList.Add(orderOne);

            model.UpdatePrices(orderList);

            // ИСПРАВЛЕНО: Кроссовки куплены не в прошлом месяце, значит получают скидку.
            // Цена меняется, поэтому проверяем, что она НЕ равна старой.
            Assert.AreNotEqual(startPrices[0], productsList[0].Price);
            Assert.AreNotEqual(startPrices[1], productsList[1].Price);
            Assert.AreNotEqual(startPrices[2], productsList[2].Price);
        }

        [TestMethod]
        public void TestOneMonth()
        {
            ProductsModel model = new ProductsModel();
            model.LoadOrders().Clear();

            List<Product> productsList = new List<Product>();

            productsList.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = "90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские белые босоножки с широким каблуком среднего размера",
                Category = "Туфли",
                Count = 2,
                Price = 500.0,
                Supplier = "T-TACCARDI",
                Parts = "94% натуральная кожа, 6% полиуретан",
                ImagePath = "..\\..\\..\\Images\\IMG_WSd_185551.png"
            });

            model.UpdateListModel(productsList);

            List<double> startPrices = new List<double>();
            startPrices.Add(1300.0);
            startPrices.Add(500.0);

            Order orderOne = new Order();
            orderOne.Items = new List<OrderItem>();
            orderOne.Items.Add(new OrderItem
            {
                ProductItem = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 10)
            });

            Order orderTwo = new Order();
            orderTwo.Items = new List<OrderItem>();
            orderTwo.Items.Add(new OrderItem
            {
                ProductItem = "Женские белые босоножки с широким каблуком среднего размера",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 10)
            });

            List<Order> orderList = new List<Order>();
            orderList.Add(orderOne);
            orderList.Add(orderTwo);

            model.UpdatePrices(orderList);

            Assert.AreEqual(startPrices[0], productsList[0].Price, 0.01);
            Assert.AreEqual(startPrices[1], productsList[1].Price, 0.01);
        }

        [TestMethod]
        public void TestThreeDifMonths()
        {
            ProductsModel model = new ProductsModel();
            model.LoadOrders().Clear();

            List<Product> productsList = new List<Product>();

            productsList.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = "90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские белые босоножки с широким каблуком среднего размера",
                Category = "Туфли",
                Count = 2,
                Price = 500.0,
                Supplier = "T-TACCARDI",
                Parts = "94% натуральная кожа, 6% полиуретан",
                ImagePath = "..\\..\\..\\Images\\IMG_WSd_185551.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские классические туфли на шпильке",
                Category = "Туфли",
                Count = 7,
                Price = 900.0,
                Supplier = "Kari",
                Parts = "96% натуральная кожа, 4% полиуретан",
                ImagePath = "..\\..\\..\\Images\\picture.png"
            });

            model.UpdateListModel(productsList);

            List<double> expectedPrices = new List<double>();
            expectedPrices.Add(975.0);
            expectedPrices.Add(500.0);
            expectedPrices.Add(675.0);

            Order orderOne = new Order();
            orderOne.Items = new List<OrderItem>();
            orderOne.Items.Add(new OrderItem
            {
                ProductItem = "Женские белые босоножки с широким каблуком среднего размера",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 10)
            });

            List<Order> orderList = new List<Order>();
            orderList.Add(orderOne);

            model.UpdatePrices(orderList);

            Assert.AreEqual(expectedPrices[0], productsList[0].Price, 0.01);
            Assert.AreEqual(expectedPrices[1], productsList[1].Price, 0.01);
            Assert.AreEqual(expectedPrices[2], productsList[2].Price, 0.01);
        }

        [TestMethod]
        public void TestCalcDiscount()
        {
            ProductsModel model = new ProductsModel();
            model.LoadOrders().Clear();

            List<Product> productsList = new List<Product>();

            productsList.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = "90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские белые босоножки с широким каблуком среднего размера",
                Category = "Туфли",
                Count = 2,
                Price = 500.0,
                Supplier = "T-TACCARDI",
                Parts = "94% натуральная кожа, 6% полиуретан",
                ImagePath = "..\\..\\..\\Images\\IMG_WSd_185551.png"
            });
            productsList.Add(new Product
            {
                Name = "Женские классические туфли на шпильке",
                Category = "Туфли",
                Count = 7,
                Price = 900.0,
                Supplier = "Kari",
                Parts = "96% натуральная кожа, 4% полиуретан",
                ImagePath = "..\\..\\..\\Images\\picture.png"
            });

            model.UpdateListModel(productsList);

            List<Order> orderList = new List<Order>();

            model.UpdatePrices(orderList);

            Assert.AreEqual(975.0, productsList[0].Price, 0.01);
            Assert.AreEqual(375.0, productsList[1].Price, 0.01);
            Assert.AreEqual(675.0, productsList[2].Price, 0.01);
        }

        [TestMethod]
        public void TestSaleOnFirstDayOfLastMonthNoDiscount()
        {
            ProductsModel model = new ProductsModel();
            model.LoadOrders().Clear();

            List<Product> productsList = new List<Product>();

            productsList.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = "90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });

            model.UpdateListModel(productsList);

            List<double> expectedPrices = new List<double>();
            expectedPrices.Add(1300.0);

            Order orderOne = new Order();
            orderOne.Items = new List<OrderItem>();
            orderOne.Items.Add(new OrderItem
            {
                ProductItem = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 1)
            });

            List<Order> orderList = new List<Order>();
            orderList.Add(orderOne);

            model.UpdatePrices(orderList);

            Assert.AreEqual(expectedPrices[0], productsList[0].Price, 0.01);
        }
    }
}