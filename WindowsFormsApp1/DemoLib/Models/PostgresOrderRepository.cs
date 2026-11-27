using Npgsql;
using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Models
{
    public class PostgresOrderRepository : IOrderRepository
    {
        private string connectionString = "Host=192.168.1.48;Port=5432;Username=st52-03;Password=5203;Database=Demo_Bashmak";

        // 1. Метод для загрузки ТОВАРОВ
        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT p.name, p.category, p.supplier, p.parts, p.image_path, p.price,
                           COALESCE(SUM(s.quantity), 0) as total_count
                    FROM products p
                    LEFT JOIN stock_items s ON p.name = s.product_name AND p.supplier = s.supplier
                    GROUP BY p.id, p.name, p.category, p.supplier, p.parts, p.image_path, p.price";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Name = reader.GetString(0),
                            Category = reader.GetString(1),
                            Supplier = reader.GetString(2),
                            Parts = reader.GetString(3),
                            ImagePath = reader.GetString(4),
                            Price = (double)reader.GetDecimal(5),
                            Count = reader.GetInt32(6)
                        });
                    }
                }
            }
            return products;
        }

        // 2. Метод для загрузки ЗАКАЗОВ
        public List<Order> Load()
        {
            List<Order> orders = new List<Order>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Шаг 1: Загружаем сами заказы (шапку)
                string sqlOrders = "SELECT order_id, order_date, user_full_name FROM orders ORDER BY order_id";

                using (var cmd = new NpgsqlCommand(sqlOrders, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1),
                            UserFullName = reader.GetString(2),
                            Items = new List<OrderItem>() // Создаем пустой список для товаров
                        });
                    }
                }

                // Шаг 2: Для каждого заказа загружаем его товары
                foreach (var order in orders)
                {
                    string sqlItems = @"
                        SELECT product_name, supplier, size, quantity, price_per_unit 
                        FROM order_items 
                        WHERE order_id = @id";

                    using (var cmd = new NpgsqlCommand(sqlItems, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", order.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                order.Items.Add(new OrderItem
                                {
                                    ProductItem = reader.GetString(0),
                                    Supplier = reader.GetString(1),
                                    Size = reader.GetDecimal(2),
                                    Count = reader.GetInt32(3),
                                    Price = (double)reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                }
            }

            return orders;
        }
    }
}