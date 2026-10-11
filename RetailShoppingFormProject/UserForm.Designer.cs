namespace RetailShoppingFormProject
{
    partial class UserForm
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
            userIdL = new Label();
            userIdTB = new TextBox();
            searchHintL = new Label();
            usernameL = new Label();
            usernameTB = new TextBox();
            firstNameL = new Label();
            firstNameTB = new TextBox();
            lastNameL = new Label();
            lastNameTB = new TextBox();
            roleL = new Label();
            roleCB = new ComboBox();
            passwordL = new Label();
            passwordTB = new TextBox();
            showPasswordPB = new PictureBox();
            passwordHintL = new Label();
            lockedCB = new CheckBox();
            failedAttemptsL = new Label();
            addUserB = new Button();
            searchUserB = new Button();
            updateUserB = new Button();
            deleteUserB = new Button();
            clearB = new Button();
            closeB = new Button();
            usersListL = new Label();
            usersRTB = new RichTextBox();
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
            titleL.Size = new Size(400, 38);
            titleL.TabIndex = 0;
            titleL.Text = "User Management";
            // 
            // userIdL
            // 
            userIdL.AutoSize = true;
            userIdL.Location = new Point(30, 83);
            userIdL.Name = "userIdL";
            userIdL.Size = new Size(130, 20);
            userIdL.TabIndex = 1;
            userIdL.Text = "User ID:";
            // 
            // userIdTB
            // 
            userIdTB.Location = new Point(170, 80);
            userIdTB.Name = "userIdTB";
            userIdTB.Size = new Size(120, 27);
            userIdTB.TabIndex = 2;
            // 
            // searchHintL
            // 
            searchHintL.AutoSize = true;
            searchHintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchHintL.Location = new Point(300, 83);
            searchHintL.Name = "searchHintL";
            searchHintL.Size = new Size(420, 20);
            searchHintL.TabIndex = 3;
            searchHintL.Text = "Search by user ID, or by username when the ID is empty";
            // 
            // usernameL
            // 
            usernameL.AutoSize = true;
            usernameL.Location = new Point(30, 128);
            usernameL.Name = "usernameL";
            usernameL.Size = new Size(130, 20);
            usernameL.TabIndex = 4;
            usernameL.Text = "Username:";
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(170, 125);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(250, 27);
            usernameTB.TabIndex = 5;
            // 
            // firstNameL
            // 
            firstNameL.AutoSize = true;
            firstNameL.Location = new Point(30, 173);
            firstNameL.Name = "firstNameL";
            firstNameL.Size = new Size(130, 20);
            firstNameL.TabIndex = 6;
            firstNameL.Text = "First name:";
            // 
            // firstNameTB
            // 
            firstNameTB.Location = new Point(170, 170);
            firstNameTB.Name = "firstNameTB";
            firstNameTB.Size = new Size(250, 27);
            firstNameTB.TabIndex = 7;
            // 
            // lastNameL
            // 
            lastNameL.AutoSize = true;
            lastNameL.Location = new Point(30, 218);
            lastNameL.Name = "lastNameL";
            lastNameL.Size = new Size(130, 20);
            lastNameL.TabIndex = 8;
            lastNameL.Text = "Last name:";
            // 
            // lastNameTB
            // 
            lastNameTB.Location = new Point(170, 215);
            lastNameTB.Name = "lastNameTB";
            lastNameTB.Size = new Size(250, 27);
            lastNameTB.TabIndex = 9;
            // 
            // roleL
            // 
            roleL.AutoSize = true;
            roleL.Location = new Point(30, 263);
            roleL.Name = "roleL";
            roleL.Size = new Size(130, 20);
            roleL.TabIndex = 10;
            roleL.Text = "Role:";
            // 
            // roleCB
            // 
            roleCB.DropDownStyle = ComboBoxStyle.DropDownList;
            roleCB.FormattingEnabled = true;
            roleCB.Items.AddRange(new object[] { "Cashier", "Manager", "Admin" });
            roleCB.Location = new Point(170, 260);
            roleCB.Name = "roleCB";
            roleCB.Size = new Size(250, 28);
            roleCB.TabIndex = 11;
            // 
            // passwordL
            // 
            passwordL.AutoSize = true;
            passwordL.Location = new Point(30, 308);
            passwordL.Name = "passwordL";
            passwordL.Size = new Size(130, 20);
            passwordL.TabIndex = 12;
            passwordL.Text = "Password:";
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(170, 305);
            passwordTB.Name = "passwordTB";
            passwordTB.UseSystemPasswordChar = true;
            passwordTB.Size = new Size(250, 27);
            passwordTB.TabIndex = 13;
            // 
            // showPasswordPB
            // 
            showPasswordPB.Cursor = Cursors.Hand;
            showPasswordPB.Location = new Point(426, 305);
            showPasswordPB.Name = "showPasswordPB";
            showPasswordPB.Size = new Size(34, 27);
            showPasswordPB.TabIndex = 14;
            showPasswordPB.TabStop = false;
            showPasswordPB.Click += showPasswordPB_Click;
            showPasswordPB.Paint += showPasswordPB_Paint;
            // 
            // passwordHintL
            // 
            passwordHintL.AutoSize = true;
            passwordHintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            passwordHintL.Location = new Point(170, 337);
            passwordHintL.Name = "passwordHintL";
            passwordHintL.Size = new Size(420, 20);
            passwordHintL.TabIndex = 15;
            passwordHintL.Text = "On Update, leave the password empty to keep the current one";
            // 
            // lockedCB
            // 
            lockedCB.AutoSize = true;
            lockedCB.Location = new Point(170, 370);
            lockedCB.Name = "lockedCB";
            lockedCB.Enabled = false;
            lockedCB.Size = new Size(135, 24);
            lockedCB.TabIndex = 16;
            lockedCB.Text = "Account locked";
            lockedCB.UseVisualStyleBackColor = true;
            // 
            // failedAttemptsL
            // 
            failedAttemptsL.AutoSize = true;
            failedAttemptsL.Location = new Point(330, 371);
            failedAttemptsL.Name = "failedAttemptsL";
            failedAttemptsL.Size = new Size(140, 20);
            failedAttemptsL.TabIndex = 17;
            failedAttemptsL.Text = "";
            // 
            // addUserB
            // 
            addUserB.Location = new Point(30, 415);
            addUserB.Name = "addUserB";
            addUserB.Size = new Size(120, 40);
            addUserB.TabIndex = 18;
            addUserB.Text = "Add User";
            addUserB.UseVisualStyleBackColor = true;
            addUserB.Click += addUserB_Click;
            // 
            // searchUserB
            // 
            searchUserB.Location = new Point(160, 415);
            searchUserB.Name = "searchUserB";
            searchUserB.Size = new Size(120, 40);
            searchUserB.TabIndex = 19;
            searchUserB.Text = "Search User";
            searchUserB.UseVisualStyleBackColor = true;
            searchUserB.Click += searchUserB_Click;
            // 
            // updateUserB
            // 
            updateUserB.Location = new Point(290, 415);
            updateUserB.Name = "updateUserB";
            updateUserB.Size = new Size(120, 40);
            updateUserB.TabIndex = 20;
            updateUserB.Text = "Update User";
            updateUserB.UseVisualStyleBackColor = true;
            updateUserB.Click += updateUserB_Click;
            // 
            // deleteUserB
            // 
            deleteUserB.Location = new Point(420, 415);
            deleteUserB.Name = "deleteUserB";
            deleteUserB.Size = new Size(120, 40);
            deleteUserB.TabIndex = 21;
            deleteUserB.Text = "Delete User";
            deleteUserB.UseVisualStyleBackColor = true;
            deleteUserB.Click += deleteUserB_Click;
            // 
            // clearB
            // 
            clearB.Location = new Point(550, 415);
            clearB.Name = "clearB";
            clearB.Size = new Size(120, 40);
            clearB.TabIndex = 22;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            // 
            // closeB
            // 
            closeB.Location = new Point(680, 415);
            closeB.Name = "closeB";
            closeB.Size = new Size(120, 40);
            closeB.TabIndex = 23;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // usersListL
            // 
            usersListL.AutoSize = true;
            usersListL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usersListL.Location = new Point(30, 475);
            usersListL.Name = "usersListL";
            usersListL.Size = new Size(200, 25);
            usersListL.TabIndex = 24;
            usersListL.Text = "Registered users";
            // 
            // usersRTB
            // 
            usersRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usersRTB.Location = new Point(30, 505);
            usersRTB.Name = "usersRTB";
            usersRTB.ReadOnly = true;
            usersRTB.Size = new Size(770, 170);
            usersRTB.TabIndex = 25;
            usersRTB.Text = "";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 700);
            Controls.Add(usersRTB);
            Controls.Add(usersListL);
            Controls.Add(closeB);
            Controls.Add(clearB);
            Controls.Add(deleteUserB);
            Controls.Add(updateUserB);
            Controls.Add(searchUserB);
            Controls.Add(addUserB);
            Controls.Add(failedAttemptsL);
            Controls.Add(lockedCB);
            Controls.Add(passwordHintL);
            Controls.Add(showPasswordPB);
            Controls.Add(passwordTB);
            Controls.Add(passwordL);
            Controls.Add(roleCB);
            Controls.Add(roleL);
            Controls.Add(lastNameTB);
            Controls.Add(lastNameL);
            Controls.Add(firstNameTB);
            Controls.Add(firstNameL);
            Controls.Add(usernameTB);
            Controls.Add(usernameL);
            Controls.Add(searchHintL);
            Controls.Add(userIdTB);
            Controls.Add(userIdL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Retail Shopping System";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)showPasswordPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label userIdL;
        private TextBox userIdTB;
        private Label searchHintL;
        private Label usernameL;
        private TextBox usernameTB;
        private Label firstNameL;
        private TextBox firstNameTB;
        private Label lastNameL;
        private TextBox lastNameTB;
        private Label roleL;
        private ComboBox roleCB;
        private Label passwordL;
        private TextBox passwordTB;
        private PictureBox showPasswordPB;
        private Label passwordHintL;
        private CheckBox lockedCB;
        private Label failedAttemptsL;
        private Button addUserB;
        private Button searchUserB;
        private Button updateUserB;
        private Button deleteUserB;
        private Button clearB;
        private Button closeB;
        private Label usersListL;
        private RichTextBox usersRTB;
    }
}
