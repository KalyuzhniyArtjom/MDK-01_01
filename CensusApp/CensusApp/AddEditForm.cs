using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CensusApp
{
    public partial class AddEditForm : Form
    {
        public string FullName => txtFullName.Text.Trim();
        public string PassportSeries => txtPassportSeries.Text.Trim();
        public string PassportNumber => txtPassportNumber.Text.Trim();
        public int BirthYear => (int)numBirthYear.Value;
        public string EducationLevel => cmbEducation.SelectedItem?.ToString();


        public AddEditForm(CensusRecord record = null)
        {
            InitializeComponent(); // Ваш метод с созданными вручную элементами

            this.Text = record == null ? "Добавление записи" : "Редактирование записи";

            // Заполнение ComboBox
            cmbEducation.Items.AddRange(new string[]
            {
                "Высшее",
                "Незаконченное высшее",
                "Среднее профессиональное",
                "Среднее общее",
                "Основное общее",
                "Начальное общее"
            });

            // Если редактирование - заполняем поля
            if (record != null)
            {
                txtFullName.Text = record.FullName;
                txtPassportSeries.Text = record.PassportSeries;
                txtPassportNumber.Text = record.PassportNumber;
                numBirthYear.Value = record.BirthYear;
                cmbEducation.SelectedItem = record.EducationLevel;
            }

            btnSave.Click += (s, e) =>
            {
                if (ValidateForm())
                    DialogResult = DialogResult.OK;
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassportSeries.Text.Length != 4)
            {
                MessageBox.Show("Серия паспорта - 4 цифры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassportNumber.Text.Length != 6)
            {
                MessageBox.Show("Номер паспорта - 6 цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEducation.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите уровень образования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

