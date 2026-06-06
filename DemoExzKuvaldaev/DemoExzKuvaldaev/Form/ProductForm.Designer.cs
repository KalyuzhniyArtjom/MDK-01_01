namespace KalyuzhniyDemo
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblArticle = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Location = new System.Drawing.Point(20, 20);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(65, 16);
            this.lblArticle.TabIndex = 0;
            this.lblArticle.Text = "Артикул:";
            // 
            // txtArticle
            // 
            this.txtArticle.Location = new System.Drawing.Point(120, 17);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(200, 22);
            this.txtArticle.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Название:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 80);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(45, 16);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Цена:";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(120, 78);
            this.numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(200, 22);
            this.numPrice.TabIndex = 5;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(20, 110);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(79, 16);
            this.lblSupplier.TabIndex = 6;
            this.lblSupplier.Text = "Поставщик:";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(120, 107);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(200, 22);
            this.txtSupplier.TabIndex = 7;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(20, 140);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(96, 16);
            this.lblManufacturer.TabIndex = 8;
            this.lblManufacturer.Text = "Производитель:";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(120, 137);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(200, 22);
            this.txtManufacturer.TabIndex = 9;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 170);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(71, 16);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Категория:";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(120, 167);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 22);
            this.txtCategory.TabIndex = 11;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 200);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(60, 16);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Скидка %:";
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(120, 198);
            this.numDiscount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(200, 22);
            this.numDiscount.TabIndex = 13;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(20, 230);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(64, 16);
            this.lblStock.TabIndex = 14;
            this.lblStock.Text = "Остаток:";
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(120, 228);
            this.numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(200, 22);
            this.numStock.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 260);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(73, 16);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 257);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 17;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 330);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 30);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 380);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtArticle);
            this.Controls.Add(this.lblArticle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Товар";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}