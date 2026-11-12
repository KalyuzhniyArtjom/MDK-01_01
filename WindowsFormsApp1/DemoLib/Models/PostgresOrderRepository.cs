using Npgsql;
using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Models
{
    public class PostgresOrderRepository : IOrderRepository
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1991;Database=Demo_Bashmak";

        // 1. Метод для загрузки ТОВАРОВ (тот, что мы написали)
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

        // 2. Метод для загрузки ЗАКАЗОВ (заглушка, чтобы интерфейс был реализован)
        public List<Order> Load()
        {
            return new List<Order>();
        }
    }
}