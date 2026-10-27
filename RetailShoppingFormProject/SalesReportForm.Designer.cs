namespace RetailShoppingFormProject
{
    partial class SalesReportForm
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
            fromDateL = new Label();
            fromDTP = new DateTimePicker();
            toDateL = new Label();
            toDTP = new DateTimePicker();
            salesByDayB = new Button();
            salesByCategoryB = new Button();
            bestSellersB = new Button();
            endOfDayB = new Button();
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
            titleL.Size = new Size(196, 38);
            titleL.TabIndex = 0;
            titleL.Text = "Sales Reports";
            // 
            // infoL
            // 
            infoL.AutoSize = true;
            infoL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            infoL.Location = new Point(34, 68);
            infoL.Name = "infoL";
            infoL.Size = new Size(600, 20);
            infoL.TabIndex = 1;
            infoL.Text = "Choose the period with the calendars, then a report. End of Day Closing reports on the To date.";
            // 
            // fromDateL
            // 
            fromDateL.AutoSize = true;
            fromDateL.Location = new Point(30, 107);
            fromDateL.Name = "fromDateL";
            fromDateL.Size = new Size(46, 20);
            fromDateL.TabIndex = 2;
            fromDateL.Text = "From:";
            // 
            // fromDTP
            // 
            fromDTP.CustomFormat = "yyyy-MM-dd";
            fromDTP.Format = DateTimePickerFormat.Custom;
            fromDTP.Location = new Point(90, 103);
            fromDTP.Name = "fromDTP";
            fromDTP.Size = new Size(150, 27);
            fromDTP.TabIndex = 3;
            // 
            // toDateL
            // 
            toDateL.AutoSize = true;
            toDateL.Location = new Point(265, 107);
            toDateL.Name = "toDateL";
            toDateL.Size = new Size(28, 20);
            toDateL.TabIndex = 4;
            toDateL.Text = "To:";
            // 
            // toDTP
            // 
            toDTP.CustomFormat = "yyyy-MM-dd";
            toDTP.Format = DateTimePickerFormat.Custom;
            toDTP.Location = new Point(305, 103);
            toDTP.Name = "toDTP";
            toDTP.Size = new Size(150, 27);
            toDTP.TabIndex = 5;
            // 
            // salesByDayB
            // 
            salesByDayB.Location = new Point(30, 148);
            salesByDayB.Name = "salesByDayB";
            salesByDayB.Size = new Size(200, 40);
            salesByDayB.TabIndex = 6;
            salesByDayB.Text = "&Sales by Day";
            salesByDayB.UseVisualStyleBackColor = true;
            salesByDayB.Click += salesByDayB_Click;
            // 
            // salesByCategoryB
            // 
            salesByCategoryB.Location = new Point(240, 148);
            salesByCategoryB.Name = "salesByCategoryB";
            salesByCategoryB.Size = new Size(200, 40);
            salesByCategoryB.TabIndex = 7;
            salesByCategoryB.Text = "Sales by &Category";
            salesByCategoryB.UseVisualStyleBackColor = true;
            salesByCategoryB.Click += salesByCategoryB_Click;
            // 
            // bestSellersB
            // 
            bestSellersB.Location = new Point(450, 148);
            bestSellersB.Name = "bestSellersB";
            bestSellersB.Size = new Size(200, 40);
            bestSellersB.TabIndex = 8;
            bestSellersB.Text = "&Best Sellers";
            bestSellersB.UseVisualStyleBackColor = true;
            bestSellersB.Click += bestSellersB_Click;
            // 
            // endOfDayB
            // 
            endOfDayB.Location = new Point(660, 148);
            endOfDayB.Name = "endOfDayB";
            endOfDayB.Size = new Size(200, 40);
            endOfDayB.TabIndex = 9;
            endOfDayB.Text = "&End of Day Closing";
            endOfDayB.UseVisualStyleBackColor = true;
            endOfDayB.Click += endOfDayB_Click;
            // 
            // saveReportB
            // 
            saveReportB.Location = new Point(950, 148);
            saveReportB.Name = "saveReportB";
            saveReportB.Size = new Size(200, 40);
            saveReportB.TabIndex = 10;
            saveReportB.Text = "Sa&ve to File";
            saveReportB.UseVisualStyleBackColor = true;
            saveReportB.Click += saveReportB_Click;
            // 
            // reportRTB
            // 
            reportRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportRTB.Location = new Point(30, 205);
            reportRTB.Name = "reportRTB";
            reportRTB.ReadOnly = true;
            reportRTB.Size = new Size(760, 440);
            reportRTB.TabIndex = 11;
            reportRTB.Text = "";
            reportRTB.WordWrap = false;
            // 
            // chartPB
            // 
            chartPB.BackColor = Color.White;
            chartPB.BorderStyle = BorderStyle.FixedSingle;
            chartPB.Location = new Point(805, 205);
            chartPB.Name = "chartPB";
            chartPB.Size = new Size(345, 440);
            chartPB.TabIndex = 12;
            chartPB.TabStop = false;
            chartPB.Paint += chartPB_Paint;
            // 
            // closeB
            // 
            closeB.DialogResult = DialogResult.Cancel;
            closeB.Location = new Point(1020, 660);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 13;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // SalesReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeB;
            ClientSize = new Size(1180, 715);
            Controls.Add(closeB);
            Controls.Add(chartPB);
            Controls.Add(reportRTB);
            Controls.Add(saveReportB);
            Controls.Add(endOfDayB);
            Controls.Add(bestSellersB);
            Controls.Add(salesByCategoryB);
            Controls.Add(salesByDayB);
            Controls.Add(toDTP);
            Controls.Add(toDateL);
            Controls.Add(fromDTP);
            Controls.Add(fromDateL);
            Controls.Add(infoL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SalesReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sales Reports";
            Load += SalesReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)chartPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label infoL;
        private Label fromDateL;
        private DateTimePicker fromDTP;
        private Label toDateL;
        private DateTimePicker toDTP;
        private Button salesByDayB;
        private Button salesByCategoryB;
        private Button bestSellersB;
        private Button endOfDayB;
        private Button saveReportB;
        private RichTextBox reportRTB;
        private PictureBox chartPB;
        private Button closeB;
    }
}
