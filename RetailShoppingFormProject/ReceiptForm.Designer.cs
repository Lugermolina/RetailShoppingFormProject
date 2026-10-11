namespace RetailShoppingFormProject
{
    partial class ReceiptForm
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
            receiptTitleL = new Label();
            topSeparatorL = new Label();
            receiptContentL = new Label();
            receiptTotalL = new Label();
            bottomSeparatorL = new Label();
            closeB = new Button();
            SuspendLayout();
            // 
            // receiptTitleL
            // 
            receiptTitleL.AutoSize = true;
            receiptTitleL.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            receiptTitleL.ForeColor = Color.Red;
            receiptTitleL.Location = new Point(20, 15);
            receiptTitleL.Name = "receiptTitleL";
            receiptTitleL.Size = new Size(300, 39);
            receiptTitleL.TabIndex = 0;
            receiptTitleL.Text = "Purchase Receipt";
            // 
            // topSeparatorL
            // 
            topSeparatorL.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topSeparatorL.ForeColor = Color.Blue;
            topSeparatorL.Location = new Point(20, 60);
            topSeparatorL.Name = "topSeparatorL";
            topSeparatorL.Size = new Size(520, 20);
            topSeparatorL.TabIndex = 1;
            topSeparatorL.Text = "==============================================";
            // 
            // receiptContentL
            // 
            receiptContentL.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            receiptContentL.ForeColor = Color.Blue;
            receiptContentL.Location = new Point(20, 85);
            receiptContentL.Name = "receiptContentL";
            receiptContentL.Size = new Size(520, 420);
            receiptContentL.TabIndex = 2;
            receiptContentL.Text = "";
            // 
            // receiptTotalL
            // 
            receiptTotalL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            receiptTotalL.ForeColor = Color.Blue;
            receiptTotalL.Location = new Point(20, 510);
            receiptTotalL.Name = "receiptTotalL";
            receiptTotalL.Size = new Size(520, 25);
            receiptTotalL.TabIndex = 3;
            receiptTotalL.Text = "";
            // 
            // bottomSeparatorL
            // 
            bottomSeparatorL.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bottomSeparatorL.ForeColor = Color.Blue;
            bottomSeparatorL.Location = new Point(20, 540);
            bottomSeparatorL.Name = "bottomSeparatorL";
            bottomSeparatorL.Size = new Size(520, 20);
            bottomSeparatorL.TabIndex = 4;
            bottomSeparatorL.Text = "==============================================";
            // 
            // closeB
            // 
            closeB.Location = new Point(410, 570);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 35);
            closeB.TabIndex = 5;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 620);
            Controls.Add(closeB);
            Controls.Add(bottomSeparatorL);
            Controls.Add(receiptTotalL);
            Controls.Add(receiptContentL);
            Controls.Add(topSeparatorL);
            Controls.Add(receiptTitleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Purchase Receipt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label receiptTitleL;
        private Label topSeparatorL;
        private Label receiptContentL;
        private Label receiptTotalL;
        private Label bottomSeparatorL;
        private Button closeB;
    }
}
