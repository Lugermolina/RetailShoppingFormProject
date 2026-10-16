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
            infoL.Text = "Reports of the whole store, built from orders.txt and customers.txt. Only the Admin role can open this form.";
            //
            // allOrdersB
            //
            allOrdersB.Location = new Point(30, 105);
            allOrdersB.Name = "allOrdersB";
            allOrdersB.Size = new Size(210, 40);
            allOrdersB.TabIndex = 2;
            allOrdersB.Text = "All Orders Report";
            allOrdersB.UseVisualStyleBackColor = true;
            allOrdersB.Click += allOrdersB_Click;
            //
            // allCustomersB
            //
            allCustomersB.Location = new Point(255, 105);
            allCustomersB.Name = "allCustomersB";
            allCustomersB.Size = new Size(210, 40);
            allCustomersB.TabIndex = 3;
            allCustomersB.Text = "All Customers Report";
            allCustomersB.UseVisualStyleBackColor = true;
            allCustomersB.Click += allCustomersB_Click;
            //
            // reportRTB
            //
            reportRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportRTB.Location = new Point(30, 165);
            reportRTB.Name = "reportRTB";
            reportRTB.ReadOnly = true;
            reportRTB.Size = new Size(840, 420);
            reportRTB.TabIndex = 4;
            reportRTB.Text = "";
            reportRTB.WordWrap = false;
            //
            // closeB
            //
            closeB.Location = new Point(740, 600);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 5;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            //
            // AdminReportForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 655);
            Controls.Add(closeB);
            Controls.Add(reportRTB);
            Controls.Add(allCustomersB);
            Controls.Add(allOrdersB);
            Controls.Add(infoL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AdminReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administration Reports";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label infoL;
        private Button allOrdersB;
        private Button allCustomersB;
        private RichTextBox reportRTB;
        private Button closeB;
    }
}
