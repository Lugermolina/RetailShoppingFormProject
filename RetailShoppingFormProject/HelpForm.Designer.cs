namespace RetailShoppingFormProject
{
    partial class HelpForm
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
            guideRTB = new RichTextBox();
            closeB = new Button();
            SuspendLayout();
            // 
            // titleL
            // 
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleL.Location = new Point(30, 20);
            titleL.Name = "titleL";
            titleL.Size = new Size(160, 38);
            titleL.TabIndex = 0;
            titleL.Text = "User Guide";
            // 
            // guideRTB
            // 
            guideRTB.BackColor = Color.White;
            guideRTB.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guideRTB.Location = new Point(30, 75);
            guideRTB.Name = "guideRTB";
            guideRTB.ReadOnly = true;
            guideRTB.Size = new Size(740, 470);
            guideRTB.TabIndex = 1;
            guideRTB.Text = "";
            // 
            // closeB
            // 
            closeB.DialogResult = DialogResult.Cancel;
            closeB.Location = new Point(640, 560);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 2;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeB;
            ClientSize = new Size(800, 620);
            Controls.Add(closeB);
            Controls.Add(guideRTB);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "HelpForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Guide";
            Load += HelpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private RichTextBox guideRTB;
        private Button closeB;
    }
}
