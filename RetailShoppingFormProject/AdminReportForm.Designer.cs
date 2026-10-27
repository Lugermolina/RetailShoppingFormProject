namespace RetailShoppingFormProject
{
    partial class AdminReportForm
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
            infoL = new Label();
            allOrdersB = new Button();
            allCustomersB = new Button();
            salesByCashierB = new Button();
            taxesByMonthB = new Button();
            customersWithoutOrdersB = new Button();
            lockedAccountsB = new Button();
            saveReportB = new Button();
            reportRTB = new RichTextBox();
            chartPB = new PictureBox();
            closeB = new Button();
            ((System.ComponentModel.ISupportInitialize)chartPB).BeginInit();
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
            titleL.Text = "Administration Reports";
            // 
            // infoL
            // 
            infoL.AutoSize = true;
            infoL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            infoL.Location = new Point(34, 70);
            infoL.Name = "infoL";
            infoL.Size = new Size(400, 20);
            infoL.TabIndex = 1;
            infoL.Text = "Reports of the whole store, read from the SQL Server database RetailShoppingdb. Only the Admin role can open this form.";
            // 
            // allOrdersB
            // 
            allOrdersB.Location = new Point(30, 105);
            allOrdersB.Name = "allOrdersB";
            allOrdersB.Size = new Size(200, 40);
            allOrdersB.TabIndex = 2;
            allOrdersB.Text = "All &Orders";
            allOrdersB.UseVisualStyleBackColor = true;
            allOrdersB.Click += allOrdersB_Click;
            // 
            // allCustomersB
            // 
            allCustomersB.Location = new Point(240, 105);
            allCustomersB.Name = "allCustomersB";
            allCustomersB.Size = new Size(200, 40);
            allCustomersB.TabIndex = 3;
            allCustomersB.Text = "All C&ustomers";
            allCustomersB.UseVisualStyleBackColor = true;
            allCustomersB.Click += allCustomersB_Click;
            // 
            // salesByCashierB
            // 
            salesByCashierB.Location = new Point(450, 105);
            salesByCashierB.Name = "salesByCashierB";
            salesByCashierB.Size = new Size(200, 40);
            salesByCashierB.TabIndex = 4;
            salesByCashierB.Text = "Sales by &Staff User";
            salesByCashierB.UseVisualStyleBackColor = true;
            salesByCashierB.Click += salesByCashierB_Click;
            // 
            // taxesByMonthB
            // 
            taxesByMonthB.Location = new Point(660, 105);
            taxesByMonthB.Name = "taxesByMonthB";
            taxesByMonthB.Size = new Size(200, 40);
            taxesByMonthB.TabIndex = 5;
            taxesByMonthB.Text = "&Taxes by Month";
            taxesByMonthB.UseVisualStyleBackColor = true;
            taxesByMonthB.Click += taxesByMonthB_Click;
            // 
            // customersWithoutOrdersB
            // 
            customersWithoutOrdersB.Location = new Point(30, 152);
            customersWithoutOrdersB.Name = "customersWithoutOrdersB";
            customersWithoutOrdersB.Size = new Size(200, 40);
            customersWithoutOrdersB.TabIndex = 6;
            customersWithoutOrdersB.Text = "Customers &without Orders";
            customersWithoutOrdersB.UseVisualStyleBackColor = true;
            customersWithoutOrdersB.Click += customersWithoutOrdersB_Click;
            // 
            // lockedAccountsB
            // 
            lockedAccountsB.Location = new Point(240, 152);
            lockedAccountsB.Name = "lockedAccountsB";
            lockedAccountsB.Size = new Size(200, 40);
            lockedAccountsB.TabIndex = 7;
            lockedAccountsB.Text = "&Locked Accounts";
            lockedAccountsB.UseVisualStyleBackColor = true;
            lockedAccountsB.Click += lockedAccountsB_Click;
            // 
            // saveReportB
            // 
            saveReportB.Location = new Point(950, 152);
            saveReportB.Name = "saveReportB";
            saveReportB.Size = new Size(200, 40);
            saveReportB.TabIndex = 8;
            saveReportB.Text = "Sa&ve to File";
            saveReportB.UseVisualStyleBackColor = true;
            saveReportB.Click += saveReportB_Click;
            // 
            // reportRTB
            // 
            reportRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportRTB.Location = new Point(30, 210);
            reportRTB.Name = "reportRTB";
            reportRTB.ReadOnly = true;
            reportRTB.Size = new Size(760, 435);
            reportRTB.TabIndex = 9;
            reportRTB.Text = "";
            reportRTB.WordWrap = false;
            // 
            // chartPB
            // 
            chartPB.BackColor = Color.White;
            chartPB.BorderStyle = BorderStyle.FixedSingle;
            chartPB.Location = new Point(805, 210);
            chartPB.Name = "chartPB";
            chartPB.Size = new Size(345, 435);
            chartPB.TabIndex = 10;
            chartPB.TabStop = false;
            chartPB.Paint += chartPB_Paint;
            // 
            // closeB
            // 
            closeB.DialogResult = DialogResult.Cancel;
            closeB.Location = new Point(1020, 660);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 11;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // AdminReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeB;
            ClientSize = new Size(1180, 715);
            Controls.Add(closeB);
            Controls.Add(chartPB);
            Controls.Add(reportRTB);
            Controls.Add(saveReportB);
            Controls.Add(lockedAccountsB);
            Controls.Add(customersWithoutOrdersB);
            Controls.Add(taxesByMonthB);
            Controls.Add(salesByCashierB);
            Controls.Add(allCustomersB);
            Controls.Add(allOrdersB);
            Controls.Add(infoL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AdminReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administration Reports";
            ((System.ComponentModel.ISupportInitialize)chartPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label infoL;
        private Button allOrdersB;
        private Button allCustomersB;
        private Button salesByCashierB;
        private Button taxesByMonthB;
        private Button customersWithoutOrdersB;
        private Button lockedAccountsB;
        private Button saveReportB;
        private RichTextBox reportRTB;
        private PictureBox chartPB;
        private Button closeB;
    }
}
