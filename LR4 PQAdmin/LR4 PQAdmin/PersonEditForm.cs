using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LR4_PQAdmin
{
    public partial class PersonEditForm : Form
    {
        // Поля ввода
        private TextBox txtFullName;
        private TextBox txtPassportSeries;
        private TextBox txtPassportNumber;
        private NumericUpDown numBirthYear;
        private ComboBox cmbEducation;
        private Button btnOk;
        private Button btnCancel;

        // Результат
        public People ResultPerson { get; private set; }

        // Конструктор для добавления (person = null)
        // Для редактирования передаём существующий объект
        public PersonEditForm(People person = null)
        {
            if (person != null)
            {
                // Заполняем поля для редактирования
                txtFullName.Text = person.Full_name;
                txtPassportSeries.Text = person.Passport_series.ToString();
                txtPassportNumber.Text = person.Passport_number.ToString();
                numBirthYear.Value = person.Birth_year;
                cmbEducation.SelectedItem = person.Education_level;
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Ввод данных переписи";
            this.Size = new System.Drawing.Size(350, 280);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Метки и поля
            Label lblFullName = new Label() { Text = "ФИО:", Location = new System.Drawing.Point(12, 15), Size = new System.Drawing.Size(100, 23) };
            Label lblPassportSeries = new Label() { Text = "Серия паспорта:", Location = new System.Drawing.Point(12, 45), Size = new System.Drawing.Size(100, 23) };
            Label lblPassportNumber = new Label() { Text = "Номер паспорта:", Location = new System.Drawing.Point(12, 75), Size = new System.Drawing.Size(100, 23) };
            Label lblBirthYear = new Label() { Text = "Год рождения:", Location = new System.Drawing.Point(12, 105), Size = new System.Drawing.Size(100, 23) };
            Label lblEducation = new Label() { Text = "Образование:", Location = new System.Drawing.Point(12, 135), Size = new System.Drawing.Size(100, 23) };

            txtFullName = new TextBox() { Location = new System.Drawing.Point(120, 12), Size = new System.Drawing.Size(200, 23) };
            txtPassportSeries = new TextBox() { Location = new System.Drawing.Point(120, 42), Size = new System.Drawing.Size(80, 23) };
            txtPassportNumber = new TextBox() { Location = new System.Drawing.Point(120, 72), Size = new System.Drawing.Size(80, 23) };

            numBirthYear = new NumericUpDown()
            {
                Location = new System.Drawing.Point(120, 102),
                Size = new System.Drawing.Size(80, 23),
                Minimum = 1900,
                Maximum = DateTime.Now.Year
            };

            cmbEducation = new ComboBox()
            {
                Location = new System.Drawing.Point(120, 132),
                Size = new System.Drawing.Size(150, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbEducation.Items.AddRange(new object[] { "Начальное", "Среднее", "Среднее специальное", "Высшее", "Учёная степень" });

            btnOk = new Button() { Text = "OK", Location = new System.Drawing.Point(80, 180), Size = new System.Drawing.Size(75, 30), DialogResult = DialogResult.OK };
            btnCancel = new Button() { Text = "Отмена", Location = new System.Drawing.Point(170, 180), Size = new System.Drawing.Size(75, 30), DialogResult = DialogResult.Cancel };

            btnOk.Click += BtnOk_Click;

            this.Controls.Add(lblFullName);
            this.Controls.Add(lblPassportSeries);
            this.Controls.Add(lblPassportNumber);
            this.Controls.Add(lblBirthYear);
            this.Controls.Add(lblEducation);
            this.Controls.Add(txtFullName);
            this.Controls.Add(txtPassportSeries);
            this.Controls.Add(txtPassportNumber);
            this.Controls.Add(numBirthYear);
            this.Controls.Add(cmbEducation);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (txtPassportSeries.Text.Length != 4 || !int.TryParse(txtPassportSeries.Text, out int series))
            {
                MessageBox.Show("Серия паспорта должна состоять из 4 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (txtPassportNumber.Text.Length != 6 || !int.TryParse(txtPassportNumber.Text, out int number))
            {
                MessageBox.Show("Номер паспорта должен состоять из 6 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (cmbEducation.SelectedItem == null)
            {
                MessageBox.Show("Выберите уровень образования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Создаём объект People
            ResultPerson = new People
            {
                Full_name = txtFullName.Text.Trim(),
                Passport_series = series,
                Passport_number = number,
                Birth_year = (int)numBirthYear.Value,
                Education_level = cmbEducation.SelectedItem.ToString()
            };
        }
    }
}
