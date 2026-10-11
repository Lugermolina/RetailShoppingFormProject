namespace RetailShoppingFormProject
{
    partial class CustomerForm
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
            firstNameL = new Label();
            firstNameTB = new TextBox();
            lastNameL = new Label();
            lastNameTB = new TextBox();
            addressL = new Label();
            addressTB = new TextBox();
            phoneL = new Label();
            phoneTB = new TextBox();
            emailL = new Label();
            emailTB = new TextBox();
            customerIdL = new Label();
            customerIdTB = new TextBox();
            registerB = new Button();
            clearB = new Button();
            readCustomersB = new Button();
            customersListL = new Label();
            customersRTB = new RichTextBox();
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
            titleL.Text = "Customer Registration";
            // 
            // firstNameL
            // 
            firstNameL.AutoSize = true;
            firstNameL.Location = new Point(30, 83);
            firstNameL.Name = "firstNameL";
            firstNameL.Size = new Size(140, 20);
            firstNameL.TabIndex = 1;
            firstNameL.Text = "First name:";
            // 
            // firstNameTB
            // 
            firstNameTB.Location = new Point(180, 80);
            firstNameTB.Name = "firstNameTB";
            firstNameTB.Size = new Size(250, 27);
            firstNameTB.TabIndex = 2;
            // 
            // lastNameL
            // 
            lastNameL.AutoSize = true;
            lastNameL.Location = new Point(30, 128);
            lastNameL.Name = "lastNameL";
            lastNameL.Size = new Size(140, 20);
            lastNameL.TabIndex = 3;
            lastNameL.Text = "Last name:";
            // 
            // lastNameTB
            // 
            lastNameTB.Location = new Point(180, 125);
            lastNameTB.Name = "lastNameTB";
            lastNameTB.Size = new Size(250, 27);
            lastNameTB.TabIndex = 4;
            // 
            // addressL
            // 
            addressL.AutoSize = true;
            addressL.Location = new Point(30, 173);
            addressL.Name = "addressL";
            addressL.Size = new Size(140, 20);
            addressL.TabIndex = 5;
            addressL.Text = "Address:";
            // 
            // addressTB
            // 
            addressTB.Location = new Point(180, 170);
            addressTB.Name = "addressTB";
            addressTB.Size = new Size(250, 27);
            addressTB.TabIndex = 6;
            // 
            // phoneL
            // 
            phoneL.AutoSize = true;
            phoneL.Location = new Point(30, 218);
            phoneL.Name = "phoneL";
            phoneL.Size = new Size(140, 20);
            phoneL.TabIndex = 7;
            phoneL.Text = "Phone:";
            // 
            // phoneTB
            // 
            phoneTB.Location = new Point(180, 215);
            phoneTB.Name = "phoneTB";
            phoneTB.Size = new Size(250, 27);
            phoneTB.TabIndex = 8;
            // 
            // emailL
            // 
            emailL.AutoSize = true;
            emailL.Location = new Point(30, 263);
            emailL.Name = "emailL";
            emailL.Size = new Size(140, 20);
            emailL.TabIndex = 9;
            emailL.Text = "Email:";
            // 
            // emailTB
            // 
            emailTB.Location = new Point(180, 260);
            emailTB.Name = "emailTB";
            emailTB.Size = new Size(250, 27);
            emailTB.TabIndex = 10;
            // 
            // customerIdL
            // 
            customerIdL.AutoSize = true;
            customerIdL.Location = new Point(30, 308);
            customerIdL.Name = "customerIdL";
            customerIdL.Size = new Size(140, 20);
            customerIdL.TabIndex = 11;
            customerIdL.Text = "Customer ID:";
            // 
            // customerIdTB
            // 
            customerIdTB.Location = new Point(180, 305);
            customerIdTB.Name = "customerIdTB";
            customerIdTB.ReadOnly = true;
            customerIdTB.Size = new Size(100, 27);
            customerIdTB.TabIndex = 12;
            // 
            // registerB
            // 
            registerB.Location = new Point(30, 360);
            registerB.Name = "registerB";
            registerB.Size = new Size(130, 40);
            registerB.TabIndex = 13;
            registerB.Text = "Register";
            registerB.UseVisualStyleBackColor = true;
            registerB.Click += registerB_Click;
            // 
            // clearB
            // 
            clearB.Location = new Point(175, 360);
            clearB.Name = "clearB";
            clearB.Size = new Size(130, 40);
            clearB.TabIndex = 14;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            // 
            // readCustomersB
            // 
            readCustomersB.Location = new Point(320, 360);
            readCustomersB.Name = "readCustomersB";
            readCustomersB.Size = new Size(130, 40);
            readCustomersB.TabIndex = 15;
            readCustomersB.Text = "Read Customers";
            readCustomersB.UseVisualStyleBackColor = true;
            readCustomersB.Click += readCustomersB_Click;
            // 
            // customersListL
            // 
            customersListL.AutoSize = true;
            customersListL.Location = new Point(470, 55);
            customersListL.Name = "customersListL";
            customersListL.Size = new Size(300, 20);
            customersListL.TabIndex = 16;
            customersListL.Text = "Registered customers:";
            // 
            // customersRTB
            // 
            customersRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customersRTB.Location = new Point(470, 80);
            customersRTB.Name = "customersRTB";
            customersRTB.ReadOnly = true;
            customersRTB.Size = new Size(400, 300);
            customersRTB.TabIndex = 17;
            customersRTB.Text = "";
            customersRTB.WordWrap = false;
            // 
            // closeB
            // 
            closeB.Location = new Point(740, 400);
            closeB.Name = "closeB";
            closeB.Size = new Size(130, 40);
            closeB.TabIndex = 18;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 460);
            Controls.Add(closeB);
            Controls.Add(customersRTB);
            Controls.Add(customersListL);
            Controls.Add(readCustomersB);
            Controls.Add(clearB);
            Controls.Add(registerB);
            Controls.Add(customerIdTB);
            Controls.Add(customerIdL);
            Controls.Add(emailTB);
            Controls.Add(emailL);
            Controls.Add(phoneTB);
            Controls.Add(phoneL);
            Controls.Add(addressTB);
            Controls.Add(addressL);
            Controls.Add(lastNameTB);
            Controls.Add(lastNameL);
            Controls.Add(firstNameTB);
            Controls.Add(firstNameL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label firstNameL;
        private TextBox firstNameTB;
        private Label lastNameL;
        private TextBox lastNameTB;
        private Label addressL;
        private TextBox addressTB;
        private Label phoneL;
        private TextBox phoneTB;
        private Label emailL;
        private TextBox emailTB;
        private Label customerIdL;
        private TextBox customerIdTB;
        private Button registerB;
        private Button clearB;
        private Button readCustomersB;
        private Label customersListL;
        private RichTextBox customersRTB;
        private Button closeB;
    }
}
