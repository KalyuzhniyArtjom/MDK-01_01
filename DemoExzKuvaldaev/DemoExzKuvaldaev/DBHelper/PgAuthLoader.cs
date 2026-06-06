using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalyuzhniyDemo
{
    public class PgAuthLoader
    {
        private const string connectSetting = "Host=192.168.1.48;Username=st50-12;Password=5012;Database=Kalyuzhniy_Demo2";

        public User Authenticate(string login, string password)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"
                        SELECT u.id, u.full_name, u.login, u.password, u.role_id, r.role_name 
                        FROM users u
                        JOIN user_roles r ON u.role_id = r.id
                        WHERE u.login = @login AND u.password = @password";
                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Login = reader.GetString(2),
                            Password = reader.GetString(3),
                            RoleId = reader.GetInt32(4),
                            RoleName = reader.GetString(5)
                        };
                    }
                }
                return null;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка авторизации: {exception.Message}");
                return null;
            }
        }
    }
}
