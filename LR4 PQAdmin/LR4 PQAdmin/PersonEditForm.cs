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
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.lblEducation = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassportSeries = new System.Windows.Forms.TextBox();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.numBirthYear = new System.Windows.Forms.NumericUpDown();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(0, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 23);
            this.lblFullName.TabIndex = 0;
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.Location = new System.Drawing.Point(0, 0);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(100, 23);
            this.lblPassportSeries.TabIndex = 1;
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.Location = new System.Drawing.Point(0, 0);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(100, 23);
            this.lblPassportNumber.TabIndex = 2;
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.Location = new System.Drawing.Point(0, 0);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(100, 23);
            this.lblBirthYear.TabIndex = 3;
            // 
            // lblEducation
            // 
            this.lblEducation.Location = new System.Drawing.Point(0, 0);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(100, 23);
            this.lblEducation.TabIndex = 4;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(100, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // txtPassportSeries
            // 
            this.txtPassportSeries.Location = new System.Drawing.Point(0, 0);
            this.txtPassportSeries.Name = "txtPassportSeries";
            this.txtPassportSeries.Size = new System.Drawing.Size(100, 20);
            this.txtPassportSeries.TabIndex = 6;
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.Location = new System.Drawing.Point(0, 0);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPassportNumber.TabIndex = 7;
            // 
            // numBirthYear
            // 
            this.numBirthYear.Location = new System.Drawing.Point(3, 3);
            this.numBirthYear.Name = "numBirthYear";
            this.numBirthYear.Size = new System.Drawing.Size(120, 20);
            this.numBirthYear.TabIndex = 8;
            // 
            // cmbEducation
            // 
            this.cmbEducation.Items.AddRange(new object[] {
            "Начальное",
            "Среднее",
            "Среднее специальное",
            "Высшее",
            "Учёная степень"});
            this.cmbEducation.Location = new System.Drawing.Point(0, 0);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(121, 21);
            this.cmbEducation.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Серия паспорта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Номер паспорта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Дата рождения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Уровень образования";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(203, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(203, 79);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 20;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(203, 120);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 21;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(203, 156);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 22;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(203, 195);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 23;
            // 
            // PersonEditForm
            // 
            this.ClientSize = new System.Drawing.Size(508, 378);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPassportSeries);
            this.Controls.Add(this.lblPassportNumber);
            this.Controls.Add(this.lblBirthYear);
            this.Controls.Add(this.lblEducation);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtPassportSeries);
            this.Controls.Add(this.txtPassportNumber);
            this.Controls.Add(this.numBirthYear);
            this.Controls.Add(this.cmbEducation);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PersonEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ввод данных переписи";
            ((System.ComponentModel.ISupportInitialize)(this.numBirthYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private Label lblFullName;
        private Label lblPassportSeries;
        private Label lblPassportNumber;
        private Label lblBirthYear;
        private Label lblEducation;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
    }
}
