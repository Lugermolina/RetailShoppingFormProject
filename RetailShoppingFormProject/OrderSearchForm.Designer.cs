namespace RetailShoppingFormProject
{
    partial class OrderSearchForm
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
            searchByL = new Label();
            searchByCB = new ComboBox();
            valueL = new Label();
            valueTB = new TextBox();
            hintL = new Label();
            searchB = new Button();
            clearB = new Button();
            resultCountL = new Label();
            resultRTB = new RichTextBox();
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
            titleL.Text = "Order Search";
            //
            // searchByL
            //
            searchByL.AutoSize = true;
            searchByL.Location = new Point(30, 83);
            searchByL.Name = "searchByL";
            searchByL.Size = new Size(180, 20);
            searchByL.TabIndex = 1;
            searchByL.Text = "Search by:";
            //
            // searchByCB
            //
            searchByCB.DropDownStyle = ComboBoxStyle.DropDownList;
            searchByCB.FormattingEnabled = true;
            searchByCB.Location = new Point(220, 80);
            searchByCB.Name = "searchByCB";
            searchByCB.Size = new Size(220, 28);
            searchByCB.TabIndex = 2;
            searchByCB.SelectedIndexChanged += searchByCB_SelectedIndexChanged;
            //
            // valueL
            //
            valueL.AutoSize = true;
            valueL.Location = new Point(30, 128);
            valueL.Name = "valueL";
            valueL.Size = new Size(180, 20);
            valueL.TabIndex = 3;
            valueL.Text = "Value:";
            //
            // valueTB
            //
            valueTB.Location = new Point(220, 125);
            valueTB.Name = "valueTB";
            valueTB.Size = new Size(220, 27);
            valueTB.TabIndex = 4;
            //
            // hintL
            //
            hintL.AutoSize = true;
            hintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            hintL.Location = new Point(220, 160);
            hintL.Name = "hintL";
            hintL.Size = new Size(400, 20);
            hintL.TabIndex = 5;
            hintL.Text = "";
            //
            // searchB
            //
            searchB.Location = new Point(30, 195);
            searchB.Name = "searchB";
            searchB.Size = new Size(130, 40);
            searchB.TabIndex = 6;
            searchB.Text = "Search";
            searchB.UseVisualStyleBackColor = true;
            searchB.Click += searchB_Click;
            //
            // clearB
            //
            clearB.Location = new Point(175, 195);
            clearB.Name = "clearB";
            clearB.Size = new Size(130, 40);
            clearB.TabIndex = 7;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            //
            // resultCountL
            //
            resultCountL.AutoSize = true;
            resultCountL.Location = new Point(330, 205);
            resultCountL.Name = "resultCountL";
            resultCountL.Size = new Size(400, 20);
            resultCountL.TabIndex = 8;
            resultCountL.Text = "";
            //
            // resultRTB
            //
            resultRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultRTB.Location = new Point(30, 255);
            resultRTB.Name = "resultRTB";
            resultRTB.ReadOnly = true;
            resultRTB.Size = new Size(840, 340);
            resultRTB.TabIndex = 9;
            resultRTB.Text = "";
            resultRTB.WordWrap = false;
            //
            // closeB
            //
            closeB.Location = new Point(740, 610);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 10;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            //
            // OrderSearchForm
            //
            AcceptButton = searchB;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 670);
            Controls.Add(closeB);
            Controls.Add(resultRTB);
            Controls.Add(resultCountL);
            Controls.Add(clearB);
            Controls.Add(searchB);
            Controls.Add(hintL);
            Controls.Add(valueTB);
            Controls.Add(valueL);
            Controls.Add(searchByCB);
            Controls.Add(searchByL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "OrderSearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Search";
            Load += OrderSearchForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label searchByL;
        private ComboBox searchByCB;
        private Label valueL;
        private TextBox valueTB;
        private Label hintL;
        private Button searchB;
        private Button clearB;
        private Label resultCountL;
        private RichTextBox resultRTB;
        private Button closeB;
    }
}
