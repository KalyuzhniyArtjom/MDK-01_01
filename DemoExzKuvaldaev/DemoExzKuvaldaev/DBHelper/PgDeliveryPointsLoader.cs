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
    public class PgDeliveryPointsLoader
    {
        private BindingList<DeliveryPoint> loader = new BindingList<DeliveryPoint>();
        private const string connectSetting = "Host=192.168.1.48;Username=st50-12;Password=5012;Database=Kalyuzhniy_Demo2";

        public BindingList<DeliveryPoint> Load()
        {
            try
            {
                loader.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "SELECT id, address FROM delivery_points ORDER BY id";
                    var cmd = new NpgsqlCommand(sql, con);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DeliveryPoint point = new DeliveryPoint
                        {
                            Id = reader.GetInt32(0),
                            Address = reader.GetString(1)
                        };
                        loader.Add(point);
                    }
                }
                return loader;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки пунктов выдачи: {exception.Message}");
                return null;
            }
        }

        public bool AddDeliveryPoint(string address)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "INSERT INTO delivery_points (address) VALUES (@address) RETURNING id";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@address", address);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    if (newId > 0)
                    {
                        DeliveryPoint point = new DeliveryPoint { Id = newId, Address = address };
                        loader.Add(point);
                        return true;
                    }
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления пункта: {exception.Message}");
                return false;
            }
        }

        public bool DeleteDeliveryPoint(int id)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "DELETE FROM delivery_points WHERE id = @id";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    int execute = cmd.ExecuteNonQuery();
                    if (execute > 0)
                    {
                        for (int i = 0; i < loader.Count; i++)
                        {
                            if (loader[i].Id == id)
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
                MessageBox.Show($"Ошибка удаления пункта: {exception.Message}");
                return false;
            }
        }
    }
}
