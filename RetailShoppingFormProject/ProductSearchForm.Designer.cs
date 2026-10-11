namespace RetailShoppingFormProject
{
    partial class ProductSearchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleL = new Label();
            productNameL = new Label();
            productNameTB = new TextBox();
            categoryL = new Label();
            categoryCB = new ComboBox();
            minPriceL = new Label();
            minPriceTB = new TextBox();
            maxPriceL = new Label();
            maxPriceTB = new TextBox();
            searchB = new Button();
            showAllB = new Button();
            clearB = new Button();
            resultCountL = new Label();
            productsRTB = new RichTextBox();
            closeB = new Button();
            SuspendLayout();
            // 
            // titleL
            // 
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleL.ForeColor = Color.Blue;
            titleL.Location = new Point(30, 20);
            titleL.Name = "titleL";
            titleL.Size = new Size(400, 38);
            titleL.TabIndex = 0;
            titleL.Text = "Product Search";
            // 
            // productNameL
            // 
            productNameL.AutoSize = true;
            productNameL.Location = new Point(30, 83);
            productNameL.Name = "productNameL";
            productNameL.Size = new Size(180, 20);
            productNameL.TabIndex = 1;
            productNameL.Text = "Product name contains:";
            // 
            // productNameTB
            // 
            productNameTB.Location = new Point(220, 80);
            productNameTB.Name = "productNameTB";
            productNameTB.Size = new Size(220, 27);
            productNameTB.TabIndex = 2;
            // 
            // categoryL
            // 
            categoryL.AutoSize = true;
            categoryL.Location = new Point(30, 128);
            categoryL.Name = "categoryL";
            categoryL.Size = new Size(180, 20);
            categoryL.TabIndex = 3;
            categoryL.Text = "Category:";
            // 
            // categoryCB
            // 
            categoryCB.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCB.FormattingEnabled = true;
            categoryCB.Location = new Point(220, 125);
            categoryCB.Name = "categoryCB";
            categoryCB.Size = new Size(220, 28);
            categoryCB.TabIndex = 4;
            // 
            // minPriceL
            // 
            minPriceL.AutoSize = true;
            minPriceL.Location = new Point(30, 173);
            minPriceL.Name = "minPriceL";
            minPriceL.Size = new Size(180, 20);
            minPriceL.TabIndex = 5;
            minPriceL.Text = "Minimum price:";
            // 
            // minPriceTB
            // 
            minPriceTB.Location = new Point(220, 170);
            minPriceTB.Name = "minPriceTB";
            minPriceTB.Size = new Size(100, 27);
            minPriceTB.TabIndex = 6;
            // 
            // maxPriceL
            // 
            maxPriceL.AutoSize = true;
            maxPriceL.Location = new Point(30, 218);
            maxPriceL.Name = "maxPriceL";
            maxPriceL.Size = new Size(180, 20);
            maxPriceL.TabIndex = 7;
            maxPriceL.Text = "Maximum price:";
            // 
            // maxPriceTB
            // 
            maxPriceTB.Location = new Point(220, 215);
            maxPriceTB.Name = "maxPriceTB";
            maxPriceTB.Size = new Size(100, 27);
            maxPriceTB.TabIndex = 8;
            // 
            // searchB
            // 
            searchB.Location = new Point(30, 265);
            searchB.Name = "searchB";
            searchB.Size = new Size(130, 40);
            searchB.TabIndex = 9;
            searchB.Text = "Search";
            searchB.UseVisualStyleBackColor = true;
            searchB.Click += searchB_Click;
            // 
            // showAllB
            // 
            showAllB.Location = new Point(175, 265);
            showAllB.Name = "showAllB";
            showAllB.Size = new Size(130, 40);
            showAllB.TabIndex = 10;
            showAllB.Text = "Show All";
            showAllB.UseVisualStyleBackColor = true;
            showAllB.Click += showAllB_Click;
            // 
            // clearB
            // 
            clearB.Location = new Point(320, 265);
            clearB.Name = "clearB";
            clearB.Size = new Size(130, 40);
            clearB.TabIndex = 11;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            // 
            // resultCountL
            // 
            resultCountL.AutoSize = true;
            resultCountL.Location = new Point(470, 275);
            resultCountL.Name = "resultCountL";
            resultCountL.Size = new Size(400, 20);
            resultCountL.TabIndex = 12;
            resultCountL.Text = "";
            // 
            // productsRTB
            // 
            productsRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            productsRTB.Location = new Point(30, 320);
            productsRTB.Name = "productsRTB";
            productsRTB.ReadOnly = true;
            productsRTB.Size = new Size(840, 250);
            productsRTB.TabIndex = 13;
            productsRTB.Text = "";
            productsRTB.WordWrap = false;
            // 
            // closeB
            // 
            closeB.Location = new Point(740, 585);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 14;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // ProductSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(closeB);
            Controls.Add(productsRTB);
            Controls.Add(resultCountL);
            Controls.Add(clearB);
            Controls.Add(showAllB);
            Controls.Add(searchB);
            Controls.Add(maxPriceTB);
            Controls.Add(maxPriceL);
            Controls.Add(minPriceTB);
            Controls.Add(minPriceL);
            Controls.Add(categoryCB);
            Controls.Add(categoryL);
            Controls.Add(productNameTB);
            Controls.Add(productNameL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProductSearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product Search";
            Load += ProductSearchForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label productNameL;
        private TextBox productNameTB;
        private Label categoryL;
        private ComboBox categoryCB;
        private Label minPriceL;
        private TextBox minPriceTB;
        private Label maxPriceL;
        private TextBox maxPriceTB;
        private Button searchB;
        private Button showAllB;
        private Button clearB;
        private Label resultCountL;
        private RichTextBox productsRTB;
        private Button closeB;
    }
}
