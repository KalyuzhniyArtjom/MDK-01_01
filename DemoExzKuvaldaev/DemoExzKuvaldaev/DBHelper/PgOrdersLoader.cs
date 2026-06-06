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
    public class PgOrdersLoader
    {
        private BindingList<Order> loader = new BindingList<Order>();
        private const string connectSetting = "Host=192.168.1.48;Username=st50-12;Password=5012;Database=Kalyuzhniy_Demo2";

        public BindingList<Order> Load()
        {
            try
            {
                loader.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"
                        SELECT o.order_number, o.order_date, o.delivery_date, o.delivery_point_id, 
                               dp.address, o.user_id, u.full_name, o.pickup_code, o.status
                        FROM orders o
                        JOIN delivery_points dp ON o.delivery_point_id = dp.id
                        JOIN users u ON o.user_id = u.id
                        ORDER BY o.order_date DESC";
                    var cmd = new NpgsqlCommand(sql, con);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderNumber = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1),
                            DeliveryDate = reader.GetDateTime(2),
                            DeliveryPointId = reader.GetInt32(3),
                            DeliveryPointAddress = reader.GetString(4),
                            UserId = reader.GetInt32(5),
                            UserFullName = reader.GetString(6),
                            PickupCode = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            Status = reader.GetString(8)
                        };
                        loader.Add(order);
                    }
                }
                return loader;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {exception.Message}");
                return null;
            }
        }

        public bool UpdateOrderStatus(int orderNumber, string status)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "UPDATE orders SET status = @status WHERE order_number = @orderNumber";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@status", status);

                    int execute = cmd.ExecuteNonQuery();
                    if (execute > 0)
                    {
                        for (int i = 0; i < loader.Count; i++)
                        {
                            if (loader[i].OrderNumber == orderNumber)
                            {
                                loader[i].Status = status;
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
                MessageBox.Show($"Ошибка обновления статуса: {exception.Message}");
                return false;
            }
        }

        public BindingList<OrderItem> GetOrderItems(int orderNumber)
        {
            try
            {
                BindingList<OrderItem> items = new BindingList<OrderItem>();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"
                        SELECT oi.id, oi.order_number, oi.product_article, p.name, oi.quantity, p.price,
                               (p.price * (100 - p.discount) / 100 * oi.quantity) as total
                        FROM order_items oi
                        JOIN products p ON oi.product_article = p.article
                        WHERE oi.order_number = @orderNumber";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderItem item = new OrderItem
                        {
                            Id = reader.GetInt32(0),
                            OrderNumber = reader.GetInt32(1),
                            ProductArticle = reader.GetString(2),
                            ProductName = reader.GetString(3),
                            Quantity = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            Total = reader.GetDecimal(6)
                        };
                        items.Add(item);
                    }
                }
                return items;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки состава заказа: {exception.Message}");
                return null;
            }
        }
    }
}
