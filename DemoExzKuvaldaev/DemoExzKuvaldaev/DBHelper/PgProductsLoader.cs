using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalyuzhniyDemo
{
    public class PgProductsLoader
    {
        private BindingList<Product> loader = new BindingList<Product>();
        private const string connectSetting = "Host=192.168.1.48;Username=st50-12;Password=5012;Database=Kalyuzhniy_Demo2";

        public BindingList<Product> Load()
        {
            try
            {
                loader.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "SELECT article, name, unit, price, supplier, manufacturer, category, discount, stock, description FROM products ORDER BY name";
                    var cmd = new NpgsqlCommand(sql, con);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Article = reader.GetString(0),
                            Name = reader.GetString(1),
                            Unit = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            Supplier = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Manufacturer = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Category = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            Discount = reader.GetInt32(7),
                            Stock = reader.GetInt32(8),
                            Description = reader.IsDBNull(9) ? "" : reader.GetString(9)
                        };
                        loader.Add(product);
                    }
                }
                return loader;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {exception.Message}");
                return null;
            }
        }



        public bool AddProduct(Product product)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"INSERT INTO products (article, name, unit, price, supplier, manufacturer, category, discount, stock, description) 
                               VALUES (@article, @name, @unit, @price, @supplier, @manufacturer, @category, @discount, @stock, @description)";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@article", product.Article);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@unit", product.Unit);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@supplier", string.IsNullOrEmpty(product.Supplier) ? DBNull.Value : (object)product.Supplier);
                    cmd.Parameters.AddWithValue("@manufacturer", string.IsNullOrEmpty(product.Manufacturer) ? DBNull.Value : (object)product.Manufacturer);
                    cmd.Parameters.AddWithValue("@category", string.IsNullOrEmpty(product.Category) ? DBNull.Value : (object)product.Category);
                    cmd.Parameters.AddWithValue("@discount", product.Discount);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(product.Description) ? DBNull.Value : (object)product.Description);

                    int execute = cmd.ExecuteNonQuery();
                    if (execute > 0)
                    {
                        loader.Add(product);
                        return true;
                    }
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления товара: {exception.Message}");
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"UPDATE products SET name=@name, unit=@unit, price=@price, supplier=@supplier, 
                               manufacturer=@manufacturer, category=@category, discount=@discount, stock=@stock, description=@description 
                               WHERE article=@article";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@article", product.Article);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@unit", product.Unit);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@supplier", string.IsNullOrEmpty(product.Supplier) ? DBNull.Value : (object)product.Supplier);
                    cmd.Parameters.AddWithValue("@manufacturer", string.IsNullOrEmpty(product.Manufacturer) ? DBNull.Value : (object)product.Manufacturer);
                    cmd.Parameters.AddWithValue("@category", string.IsNullOrEmpty(product.Category) ? DBNull.Value : (object)product.Category);
                    cmd.Parameters.AddWithValue("@discount", product.Discount);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(product.Description) ? DBNull.Value : (object)product.Description);

                    int execute = cmd.ExecuteNonQuery();
                    if (execute > 0)
                    {
                        for (int i = 0; i < loader.Count; i++)
                        {
                            if (loader[i].Article == product.Article)
                            {
                                loader[i] = product;
                                break;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка обновления товара: {exception.Message}");
                return false;
            }
        }

        public bool DeleteProduct(string article)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "DELETE FROM products WHERE article = @article";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@article", article);

                    int execute = cmd.ExecuteNonQuery();
                    if (execute > 0)
                    {
                        for (int i = 0; i < loader.Count; i++)
                        {
                            if (loader[i].Article == article)
                            {
                                loader.RemoveAt(i);
                                break;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка удаления товара: {exception.Message}");
                return false;
            }
        }

        public BindingList<Product> SearchProducts(string searchText)
        {
            try
            {
                BindingList<Product> searchResult = new BindingList<Product>();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"SELECT article, name, unit, price, supplier, manufacturer, category, discount, stock, description 
                               FROM products 
                               WHERE name ILIKE @search OR article ILIKE @search OR category ILIKE @search
                               ORDER BY name";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Article = reader.GetString(0),
                            Name = reader.GetString(1),
                            Unit = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            Supplier = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Manufacturer = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Category = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            Discount = reader.GetInt32(7),
                            Stock = reader.GetInt32(8),
                            Description = reader.IsDBNull(9) ? "" : reader.GetString(9)
                        };
                        searchResult.Add(product);
                    }
                }
                return searchResult;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка поиска: {exception.Message}");
                return null;
            }
        }
    }
}
