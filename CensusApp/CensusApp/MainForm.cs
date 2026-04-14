using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CensusApp
{
    public partial class MainForm : Form
    {
        private string connectionString = "Host=192.168.1.48;Port=5432;Database=PR4_P30Art;Username=st53-11;Password=5311";

        public MainForm()
        {
            InitializeComponent(); // Ваш метод с созданными вручную элементами
            LoadData();

            // Подписка на события
            btnSearch.Click += BtnSearch_Click;
            btnClearSearch.Click += BtnClearSearch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRefresh.Click += BtnRefresh_Click;
        }

        // ЗАГРУЗКА ВСЕХ ЗАПИСЕЙ
        private void LoadData()
        {
            try
            {
                List<CensusRecord> records = new List<CensusRecord>();

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, full_name, passport_series, passport_number, birth_year, education_level FROM census ORDER BY id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new CensusRecord
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                PassportSeries = reader.GetString(2),
                                PassportNumber = reader.GetString(3),
                                BirthYear = reader.GetInt32(4),
                                EducationLevel = reader.GetString(5)
                            });
                        }
                    }
                }

                dgvCensus.DataSource = null;
                dgvCensus.DataSource = records;
                lblStatus.Text = $"Загружено записей: {records.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ПОИСК
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            try
            {
                List<CensusRecord> records = new List<CensusRecord>();

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id, full_name, passport_series, passport_number, birth_year, education_level 
                                   FROM census 
                                   WHERE full_name ILIKE @search OR passport_series ILIKE @search OR passport_number ILIKE @search
                                   ORDER BY id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchText}%");

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new CensusRecord
                                {
                                    Id = reader.GetInt32(0),
                                    FullName = reader.GetString(1),
                                    PassportSeries = reader.GetString(2),
                                    PassportNumber = reader.GetString(3),
                                    BirthYear = reader.GetInt32(4),
                                    EducationLevel = reader.GetString(5)
                                });
                            }
                        }
                    }
                }

                dgvCensus.DataSource = null;
                dgvCensus.DataSource = records;
                lblStatus.Text = $"Найдено записей: {records.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        // ДОБАВЛЕНИЕ
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditForm form = new AddEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Добавление в БД
                    try
                    {
                        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = @"INSERT INTO census (full_name, passport_series, passport_number, birth_year, education_level) 
                                           VALUES (@full_name, @passport_series, @passport_number, @birth_year, @education_level)";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@full_name", form.FullName);
                                cmd.Parameters.AddWithValue("@passport_series", form.PassportSeries);
                                cmd.Parameters.AddWithValue("@passport_number", form.PassportNumber);
                                cmd.Parameters.AddWithValue("@birth_year", form.BirthYear);
                                cmd.Parameters.AddWithValue("@education_level", form.EducationLevel);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LoadData();
                        lblStatus.Text = "Запись добавлена";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // РЕДАКТИРОВАНИЕ
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCensus.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CensusRecord record = new CensusRecord
            {
                Id = (int)dgvCensus.CurrentRow.Cells["Id"].Value,
                FullName = dgvCensus.CurrentRow.Cells["FullName"].Value.ToString(),
                PassportSeries = dgvCensus.CurrentRow.Cells["PassportSeries"].Value.ToString(),
                PassportNumber = dgvCensus.CurrentRow.Cells["PassportNumber"].Value.ToString(),
                BirthYear = (int)dgvCensus.CurrentRow.Cells["BirthYear"].Value,
                EducationLevel = dgvCensus.CurrentRow.Cells["EducationLevel"].Value.ToString()
            };

            using (AddEditForm form = new AddEditForm(record))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = @"UPDATE census SET full_name = @full_name, passport_series = @passport_series, 
                                           passport_number = @passport_number, birth_year = @birth_year, education_level = @education_level 
                                           WHERE id = @id";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", record.Id);
                                cmd.Parameters.AddWithValue("@full_name", form.FullName);
                                cmd.Parameters.AddWithValue("@passport_series", form.PassportSeries);
                                cmd.Parameters.AddWithValue("@passport_number", form.PassportNumber);
                                cmd.Parameters.AddWithValue("@birth_year", form.BirthYear);
                                cmd.Parameters.AddWithValue("@education_level", form.EducationLevel);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LoadData();
                        lblStatus.Text = "Запись обновлена";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // УДАЛЕНИЕ
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCensus.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvCensus.CurrentRow.Cells["Id"].Value;
            string fullName = dgvCensus.CurrentRow.Cells["FullName"].Value.ToString();

            DialogResult result = MessageBox.Show($"Удалить запись: {fullName}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM census WHERE id = @id";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadData();
                    lblStatus.Text = $"Запись \"{fullName}\" удалена";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }
    }
}