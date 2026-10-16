namespace RetailShoppingFormProject
{
    partial class ManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param   name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            productSectionL = new Label();
            productCodeL = new Label();
            productCodeTB = new TextBox();
            findProductB = new Button();
            productNameL = new Label();
            productNameTB = new TextBox();
            categoryL = new Label();
            categoryCB = new ComboBox();
            unitPriceL = new Label();
            unitPriceTB = new TextBox();
            stockQtyL = new Label();
            stockQtyTB = new TextBox();
            minStockL = new Label();
            minStockTB = new TextBox();
            taxableCB = new CheckBox();
            addProductB = new Button();
            updateProductB = new Button();
            removeProductB = new Button();
            clearB = new Button();
            reportSectionL = new Label();
            fromDateL = new Label();
            fromDateTB = new TextBox();
            toDateL = new Label();
            toDateTB = new TextBox();
            salesReportB = new Button();
            inventoryReportB = new Button();
            lowStockB = new Button();
            reportRTB = new RichTextBox();
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
            titleL.Size = new Size(500, 38);
            titleL.TabIndex = 0;
            titleL.Text = "Inventory and Sales Follow-up";
            // 
            // productSectionL
            // 
            productSectionL.AutoSize = true;
            productSectionL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productSectionL.Location = new Point(30, 70);
            productSectionL.Name = "productSectionL";
            productSectionL.Size = new Size(300, 25);
            productSectionL.TabIndex = 1;
            productSectionL.Text = "Product maintenance";
            // 
            // productCodeL
            // 
            productCodeL.AutoSize = true;
            productCodeL.Location = new Point(30, 108);
            productCodeL.Name = "productCodeL";
            productCodeL.Size = new Size(150, 20);
            productCodeL.TabIndex = 2;
            productCodeL.Text = "Product code:";
            // 
            // productCodeTB
            // 
            productCodeTB.Location = new Point(190, 105);
            productCodeTB.Name = "productCodeTB";
            productCodeTB.Size = new Size(220, 27);
            productCodeTB.TabIndex = 3;
            // 
            // findProductB
            // 
            findProductB.Location = new Point(425, 103);
            findProductB.Name = "findProductB";
            findProductB.Size = new Size(110, 32);
            findProductB.TabIndex = 4;
            findProductB.Text = "Find";
            findProductB.UseVisualStyleBackColor = true;
            findProductB.Click += findProductB_Click;
            // 
            // productNameL
            // 
            productNameL.AutoSize = true;
            productNameL.Location = new Point(30, 148);
            productNameL.Name = "productNameL";
            productNameL.Size = new Size(150, 20);
            productNameL.TabIndex = 5;
            productNameL.Text = "Product name:";
            // 
            // productNameTB
            // 
            productNameTB.Location = new Point(190, 145);
            productNameTB.Name = "productNameTB";
            productNameTB.Size = new Size(220, 27);
            productNameTB.TabIndex = 6;
            // 
            // categoryL
            // 
            categoryL.AutoSize = true;
            categoryL.Location = new Point(30, 188);
            categoryL.Name = "categoryL";
            categoryL.Size = new Size(150, 20);
            categoryL.TabIndex = 7;
            categoryL.Text = "Category:";
            // 
            // categoryCB
            // 
            categoryCB.FormattingEnabled = true;
            categoryCB.Location = new Point(190, 185);
            categoryCB.Name = "categoryCB";
            categoryCB.Size = new Size(220, 28);
            categoryCB.TabIndex = 8;
            // 
            // unitPriceL
            // 
            unitPriceL.AutoSize = true;
            unitPriceL.Location = new Point(30, 228);
            unitPriceL.Name = "unitPriceL";
            unitPriceL.Size = new Size(150, 20);
            unitPriceL.TabIndex = 9;
            unitPriceL.Text = "Unit price:";
            // 
            // unitPriceTB
            // 
            unitPriceTB.Location = new Point(190, 225);
            unitPriceTB.Name = "unitPriceTB";
            unitPriceTB.Size = new Size(220, 27);
            unitPriceTB.TabIndex = 10;
            // 
            // stockQtyL
            // 
            stockQtyL.AutoSize = true;
            stockQtyL.Location = new Point(30, 268);
            stockQtyL.Name = "stockQtyL";
            stockQtyL.Size = new Size(150, 20);
            stockQtyL.TabIndex = 11;
            stockQtyL.Text = "Quantity in stock:";
            // 
            // stockQtyTB
            // 
            stockQtyTB.Location = new Point(190, 265);
            stockQtyTB.Name = "stockQtyTB";
            stockQtyTB.Size = new Size(220, 27);
            stockQtyTB.TabIndex = 12;
            // 
            // minStockL
            // 
            minStockL.AutoSize = true;
            minStockL.Location = new Point(30, 308);
            minStockL.Name = "minStockL";
            minStockL.Size = new Size(150, 20);
            minStockL.TabIndex = 13;
            minStockL.Text = "Minimum stock:";
            // 
            // minStockTB
            // 
            minStockTB.Location = new Point(190, 305);
            minStockTB.Name = "minStockTB";
            minStockTB.Size = new Size(220, 27);
            minStockTB.TabIndex = 14;
            // 
            // taxableCB
            // 
            taxableCB.AutoSize = true;
            taxableCB.Checked = true;
            taxableCB.CheckState = CheckState.Checked;
            taxableCB.Location = new Point(190, 345);
            taxableCB.Name = "taxableCB";
            taxableCB.Size = new Size(260, 24);
            taxableCB.TabIndex = 30;
            taxableCB.Text = "Taxable (uncheck for zero rated)";
            taxableCB.UseVisualStyleBackColor = true;
            // 
            // addProductB
            // 
            addProductB.Location = new Point(30, 390);
            addProductB.Name = "addProductB";
            addProductB.Size = new Size(120, 40);
            addProductB.TabIndex = 15;
            addProductB.Text = "Add";
            addProductB.UseVisualStyleBackColor = true;
            addProductB.Click += addProductB_Click;
            // 
            // updateProductB
            // 
            updateProductB.Location = new Point(160, 390);
            updateProductB.Name = "updateProductB";
            updateProductB.Size = new Size(120, 40);
            updateProductB.TabIndex = 16;
            updateProductB.Text = "Update";
            updateProductB.UseVisualStyleBackColor = true;
            updateProductB.Click += updateProductB_Click;
            // 
            // removeProductB
            // 
            removeProductB.Location = new Point(290, 390);
            removeProductB.Name = "removeProductB";
            removeProductB.Size = new Size(120, 40);
            removeProductB.TabIndex = 17;
            removeProductB.Text = "Remove";
            removeProductB.UseVisualStyleBackColor = true;
            removeProductB.Click += removeProductB_Click;
            // 
            // clearB
            // 
            clearB.Location = new Point(420, 390);
            clearB.Name = "clearB";
            clearB.Size = new Size(115, 40);
            clearB.TabIndex = 18;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            // 
            // reportSectionL
            // 
            reportSectionL.AutoSize = true;
            reportSectionL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reportSectionL.Location = new Point(30, 455);
            reportSectionL.Name = "reportSectionL";
            reportSectionL.Size = new Size(300, 25);
            reportSectionL.TabIndex = 19;
            reportSectionL.Text = "Reports";
            // 
            // fromDateL
            // 
            fromDateL.AutoSize = true;
            fromDateL.Location = new Point(30, 493);
            fromDateL.Name = "fromDateL";
            fromDateL.Size = new Size(150, 20);
            fromDateL.TabIndex = 20;
            fromDateL.Text = "From (yyyy-MM-dd):";
            // 
            // fromDateTB
            // 
            fromDateTB.Location = new Point(190, 490);
            fromDateTB.Name = "fromDateTB";
            fromDateTB.Size = new Size(120, 27);
            fromDateTB.TabIndex = 21;
            // 
            // toDateL
            // 
            toDateL.AutoSize = true;
            toDateL.Location = new Point(30, 533);
            toDateL.Name = "toDateL";
            toDateL.Size = new Size(150, 20);
            toDateL.TabIndex = 22;
            toDateL.Text = "To (yyyy-MM-dd):";
            // 
            // toDateTB
            // 
            toDateTB.Location = new Point(190, 530);
            toDateTB.Name = "toDateTB";
            toDateTB.Size = new Size(120, 27);
            toDateTB.TabIndex = 23;
            // 
            // salesReportB
            // 
            salesReportB.Location = new Point(330, 488);
            salesReportB.Name = "salesReportB";
            salesReportB.Size = new Size(205, 70);
            salesReportB.TabIndex = 24;
            salesReportB.Text = "Sales Report by Period";
            salesReportB.UseVisualStyleBackColor = true;
            salesReportB.Click += salesReportB_Click;
            // 
            // inventoryReportB
            // 
            inventoryReportB.Location = new Point(30, 580);
            inventoryReportB.Name = "inventoryReportB";
            inventoryReportB.Size = new Size(160, 40);
            inventoryReportB.TabIndex = 25;
            inventoryReportB.Text = "Inventory Report";
            inventoryReportB.UseVisualStyleBackColor = true;
            inventoryReportB.Click += inventoryReportB_Click;
            // 
            // lowStockB
            // 
            lowStockB.Location = new Point(200, 580);
            lowStockB.Name = "lowStockB";
            lowStockB.Size = new Size(160, 40);
            lowStockB.TabIndex = 26;
            lowStockB.Text = "Low Stock List";
            lowStockB.UseVisualStyleBackColor = true;
            lowStockB.Click += lowStockB_Click;
            // 
            // reportRTB
            // 
            reportRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportRTB.Location = new Point(560, 70);
            reportRTB.Name = "reportRTB";
            reportRTB.ReadOnly = true;
            reportRTB.Size = new Size(590, 535);
            reportRTB.TabIndex = 27;
            reportRTB.Text = "";
            reportRTB.WordWrap = false;
            // 
            // closeB
            // 
            closeB.Location = new Point(1020, 620);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 28;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 675);
            Controls.Add(closeB);
            Controls.Add(reportRTB);
            Controls.Add(lowStockB);
            Controls.Add(inventoryReportB);
            Controls.Add(salesReportB);
            Controls.Add(toDateTB);
            Controls.Add(toDateL);
            Controls.Add(fromDateTB);
            Controls.Add(fromDateL);
            Controls.Add(reportSectionL);
            Controls.Add(clearB);
            Controls.Add(removeProductB);
            Controls.Add(updateProductB);
            Controls.Add(addProductB);
            Controls.Add(taxableCB);
            Controls.Add(minStockTB);
            Controls.Add(minStockL);
            Controls.Add(stockQtyTB);
            Controls.Add(stockQtyL);
            Controls.Add(unitPriceTB);
            Controls.Add(unitPriceL);
            Controls.Add(categoryCB);
            Controls.Add(categoryL);
            Controls.Add(productNameTB);
            Controls.Add(productNameL);
            Controls.Add(findProductB);
            Controls.Add(productCodeTB);
            Controls.Add(productCodeL);
            Controls.Add(productSectionL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inventory and Sales Follow-up";
            Load += ManagerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label productSectionL;
        private Label productCodeL;
        private TextBox productCodeTB;
        private Button findProductB;
        private Label productNameL;
        private TextBox productNameTB;
        private Label categoryL;
        private ComboBox categoryCB;
        private Label unitPriceL;
        private TextBox unitPriceTB;
        private Label stockQtyL;
        private TextBox stockQtyTB;
        private Label minStockL;
        private TextBox minStockTB;
        private CheckBox taxableCB;
        private Button addProductB;
        private Button updateProductB;
        private Button removeProductB;
        private Button clearB;
        private Label reportSectionL;
        private Label fromDateL;
        private TextBox fromDateTB;
        private Label toDateL;
        private TextBox toDateTB;
        private Button salesReportB;
        private Button inventoryReportB;
        private Button lowStockB;
        private RichTextBox reportRTB;
        private Button closeB;
    }
}
