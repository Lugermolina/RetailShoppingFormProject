namespace RetailShoppingFormProject
{
    partial class LoginForm
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
            subtitleL = new Label();
            usernameL = new Label();
            usernameTB = new TextBox();
            passwordL = new Label();
            passwordTB = new TextBox();
            showPasswordPB = new PictureBox();
            loginB = new Button();
            exitB = new Button();
            ((System.ComponentModel.ISupportInitialize)showPasswordPB).BeginInit();
            SuspendLayout();
            //
            // titleL
            //
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleL.ForeColor = Color.Blue;
            titleL.Location = new Point(30, 20);
            titleL.Name = "titleL";
            titleL.Size = new Size(300, 38);
            titleL.TabIndex = 0;
            titleL.Text = "Staff Login";
            //
            // subtitleL
            //
            subtitleL.AutoSize = true;
            subtitleL.Location = new Point(34, 65);
            subtitleL.Name = "subtitleL";
            subtitleL.Size = new Size(340, 20);
            subtitleL.TabIndex = 1;
            subtitleL.Text = "Retail Shopping System, enter your credentials";
            //
            // usernameL
            //
            usernameL.AutoSize = true;
            usernameL.Location = new Point(34, 113);
            usernameL.Name = "usernameL";
            usernameL.Size = new Size(78, 20);
            usernameL.TabIndex = 2;
            usernameL.Text = "Username:";
            //
            // usernameTB
            //
            usernameTB.Location = new Point(140, 110);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(220, 27);
            usernameTB.TabIndex = 3;
            //
            // passwordL
            //
            passwordL.AutoSize = true;
            passwordL.Location = new Point(34, 158);
            passwordL.Name = "passwordL";
            passwordL.Size = new Size(73, 20);
            passwordL.TabIndex = 4;
            passwordL.Text = "Password:";
            //
            // passwordTB
            //
            passwordTB.Location = new Point(140, 155);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(220, 27);
            passwordTB.TabIndex = 5;
            passwordTB.UseSystemPasswordChar = true;
            //
            // showPasswordPB
            //
            showPasswordPB.Cursor = Cursors.Hand;
            showPasswordPB.Location = new Point(366, 155);
            showPasswordPB.Name = "showPasswordPB";
            showPasswordPB.Size = new Size(34, 27);
            showPasswordPB.TabIndex = 6;
            showPasswordPB.TabStop = false;
            showPasswordPB.Click += showPasswordPB_Click;
            showPasswordPB.Paint += showPasswordPB_Paint;
            //
            // loginB
            //
            loginB.Location = new Point(140, 210);
            loginB.Name = "loginB";
            loginB.Size = new Size(105, 40);
            loginB.TabIndex = 7;
            loginB.Text = "Log In";
            loginB.UseVisualStyleBackColor = true;
            loginB.Click += loginB_Click;
            //
            // exitB
            //
            exitB.Location = new Point(255, 210);
            exitB.Name = "exitB";
            exitB.Size = new Size(105, 40);
            exitB.TabIndex = 8;
            exitB.Text = "Exit";
            exitB.UseVisualStyleBackColor = true;
            exitB.Click += exitB_Click;
            //
            // LoginForm
            //
            AcceptButton = loginB;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 280);
            Controls.Add(exitB);
            Controls.Add(loginB);
            Controls.Add(showPasswordPB);
            Controls.Add(passwordTB);
            Controls.Add(passwordL);
            Controls.Add(usernameTB);
            Controls.Add(usernameL);
            Controls.Add(subtitleL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Retail Shopping System";
            ((System.ComponentModel.ISupportInitialize)showPasswordPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label subtitleL;
        private Label usernameL;
        private TextBox usernameTB;
        private Label passwordL;
        private TextBox passwordTB;
        private PictureBox showPasswordPB;
        private Button loginB;
        private Button exitB;
    }
}
