using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace LR4_PQAdmin
{
    public class PGPeapleLoader
    {
        BindingList<People> loader = new BindingList<People>();
        private const string ConnectSetting = "Host=192.168.1.48;Username=st53-11;Password=5011;Database=PR4_P30Art";
        public BindingList<People> Load()
        {
            try
            {
                var con = new NpgsqlConnection(ConnectSetting);
                con.Open();
                var sql = "SELECT Full_name, Passport_series, Passport_number, Birth_year,  Education_level FROM census";
                var cmd = new NpgsqlCommand(sql, con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    People people = new People()
                    {
                        Full_name = reader.GetString(0),
                        Passport_series = reader.GetInt32(2),
                        Passport_number = reader.GetInt32(3),
                        Birth_year = reader.GetInt32(4),
                        Education_level = reader.GetString(1)
                    };
                    loader.Add(people);
                }
                return loader;
            }
            catch (NpgsqlException npgsql)
            {
                MessageBox.Show($"Ошибка!: {npgsql.Message}");
                return null;
            }
        }
        public bool DeleteSelectUser(string full_name)
        {
            try
            {
                bool deleteResult = false;
                var con = new NpgsqlConnection(ConnectSetting);
                con.Open();
                var sql = @"DELETE FROM census WHERE full_name = @full_name";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@full_name", full_name);

                int execute = cmd.ExecuteNonQuery();
                if (execute > 0)
                {
                    deleteResult = true;
                    for (int index = 0; index < loader.Count; index++)
                    {
                        if (loader[index].Full_name == full_name)
                        {
                            loader.RemoveAt(index);
                            index--;
                        }
                    }
                }
                return deleteResult;
            }
            catch (NpgsqlException nsql)
            {
                MessageBox.Show($"Ошибка!: {nsql.Message}");
                return false;
            }
        }
        public bool ClearAllUsers()
        {
            try
            {
                bool result = false;
                var con = new NpgsqlConnection(ConnectSetting);
                con.Open();
                var sql = "DELETE FROM ourusers";
                var cmd = new NpgsqlCommand(sql, con);

                int execute = cmd.ExecuteNonQuery();
                if (execute > 0)
                {
                    result = true;
                    loader.Clear();
                }
                return result;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }

        }
    }
}