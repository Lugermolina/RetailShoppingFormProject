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
            customerIdL = new Label();
            customerIdTB = new TextBox();
            searchHintL = new Label();
            firstNameL = new Label();
            firstNameTB = new TextBox();
            lastNameL = new Label();
            lastNameTB = new TextBox();
            addressL = new Label();
            addressTB = new TextBox();
            phoneL = new Label();
            phoneTB = new MaskedTextBox();
            phoneHintL = new Label();
            emailL = new Label();
            emailTB = new TextBox();
            emailHintL = new Label();
            addCustomerB = new Button();
            searchCustomerB = new Button();
            updateCustomerB = new Button();
            deleteCustomerB = new Button();
            clearB = new Button();
            closeB = new Button();
            customersListL = new Label();
            customersRTB = new RichTextBox();
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
            titleL.Text = "Customer Management";
            // 
            // customerIdL
            // 
            customerIdL.AutoSize = true;
            customerIdL.Location = new Point(30, 83);
            customerIdL.Name = "customerIdL";
            customerIdL.Size = new Size(140, 20);
            customerIdL.TabIndex = 1;
            customerIdL.Text = "Customer ID:";
            // 
            // customerIdTB
            // 
            customerIdTB.Location = new Point(180, 80);
            customerIdTB.Name = "customerIdTB";
            customerIdTB.Size = new Size(100, 27);
            customerIdTB.TabIndex = 2;
            // 
            // searchHintL
            // 
            searchHintL.AutoSize = true;
            searchHintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchHintL.Location = new Point(180, 110);
            searchHintL.Name = "searchHintL";
            searchHintL.Size = new Size(330, 20);
            searchHintL.TabIndex = 3;
            searchHintL.Text = "Search by ID, phone or last name";
            // 
            // firstNameL
            // 
            firstNameL.AutoSize = true;
            firstNameL.Location = new Point(30, 143);
            firstNameL.Name = "firstNameL";
            firstNameL.Size = new Size(140, 20);
            firstNameL.TabIndex = 4;
            firstNameL.Text = "First name:";
            // 
            // firstNameTB
            // 
            firstNameTB.Location = new Point(180, 140);
            firstNameTB.Name = "firstNameTB";
            firstNameTB.Size = new Size(330, 27);
            firstNameTB.TabIndex = 5;
            // 
            // lastNameL
            // 
            lastNameL.AutoSize = true;
            lastNameL.Location = new Point(30, 188);
            lastNameL.Name = "lastNameL";
            lastNameL.Size = new Size(140, 20);
            lastNameL.TabIndex = 6;
            lastNameL.Text = "Last name:";
            // 
            // lastNameTB
            // 
            lastNameTB.Location = new Point(180, 185);
            lastNameTB.Name = "lastNameTB";
            lastNameTB.Size = new Size(330, 27);
            lastNameTB.TabIndex = 7;
            // 
            // addressL
            // 
            addressL.AutoSize = true;
            addressL.Location = new Point(30, 233);
            addressL.Name = "addressL";
            addressL.Size = new Size(140, 20);
            addressL.TabIndex = 8;
            addressL.Text = "Address:";
            // 
            // addressTB
            // 
            addressTB.Location = new Point(180, 230);
            addressTB.Name = "addressTB";
            addressTB.Size = new Size(330, 27);
            addressTB.TabIndex = 9;
            // 
            // phoneL
            // 
            phoneL.AutoSize = true;
            phoneL.Location = new Point(30, 278);
            phoneL.Name = "phoneL";
            phoneL.Size = new Size(140, 20);
            phoneL.TabIndex = 10;
            phoneL.Text = "Phone:";
            // 
            // phoneTB
            // 
            phoneTB.Location = new Point(180, 275);
            phoneTB.Mask = "000-000-0000";
            phoneTB.Name = "phoneTB";
            phoneTB.Size = new Size(330, 27);
            phoneTB.TabIndex = 11;
            phoneTB.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // phoneHintL
            // 
            phoneHintL.AutoSize = true;
            phoneHintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            phoneHintL.Location = new Point(180, 305);
            phoneHintL.Name = "phoneHintL";
            phoneHintL.Size = new Size(330, 20);
            phoneHintL.TabIndex = 12;
            phoneHintL.Text = "10 digits, saved as 514-555-0123";
            // 
            // emailL
            // 
            emailL.AutoSize = true;
            emailL.Location = new Point(30, 338);
            emailL.Name = "emailL";
            emailL.Size = new Size(140, 20);
            emailL.TabIndex = 13;
            emailL.Text = "Email:";
            // 
            // emailTB
            // 
            emailTB.Location = new Point(180, 335);
            emailTB.Name = "emailTB";
            emailTB.Size = new Size(330, 27);
            emailTB.TabIndex = 14;
            // 
            // emailHintL
            // 
            emailHintL.AutoSize = true;
            emailHintL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            emailHintL.Location = new Point(180, 365);
            emailHintL.Name = "emailHintL";
            emailHintL.Size = new Size(330, 20);
            emailHintL.TabIndex = 15;
            emailHintL.Text = "Optional, for example name@example.com";
            // 
            // addCustomerB
            // 
            addCustomerB.Location = new Point(30, 410);
            addCustomerB.Name = "addCustomerB";
            addCustomerB.Size = new Size(140, 40);
            addCustomerB.TabIndex = 16;
            addCustomerB.Text = "Add Customer";
            addCustomerB.UseVisualStyleBackColor = true;
            addCustomerB.Click += addCustomerB_Click;
            // 
            // searchCustomerB
            // 
            searchCustomerB.Location = new Point(177, 410);
            searchCustomerB.Name = "searchCustomerB";
            searchCustomerB.Size = new Size(140, 40);
            searchCustomerB.TabIndex = 17;
            searchCustomerB.Text = "Search Customer";
            searchCustomerB.UseVisualStyleBackColor = true;
            searchCustomerB.Click += searchCustomerB_Click;
            // 
            // updateCustomerB
            // 
            updateCustomerB.Location = new Point(324, 410);
            updateCustomerB.Name = "updateCustomerB";
            updateCustomerB.Size = new Size(140, 40);
            updateCustomerB.TabIndex = 18;
            updateCustomerB.Text = "Update Customer";
            updateCustomerB.UseVisualStyleBackColor = true;
            updateCustomerB.Click += updateCustomerB_Click;
            // 
            // deleteCustomerB
            // 
            deleteCustomerB.Location = new Point(471, 410);
            deleteCustomerB.Name = "deleteCustomerB";
            deleteCustomerB.Size = new Size(140, 40);
            deleteCustomerB.TabIndex = 19;
            deleteCustomerB.Text = "Delete Customer";
            deleteCustomerB.UseVisualStyleBackColor = true;
            deleteCustomerB.Click += deleteCustomerB_Click;
            // 
            // clearB
            // 
            clearB.Location = new Point(30, 460);
            clearB.Name = "clearB";
            clearB.Size = new Size(140, 40);
            clearB.TabIndex = 20;
            clearB.Text = "Clear";
            clearB.UseVisualStyleBackColor = true;
            clearB.Click += clearB_Click;
            // 
            // closeB
            // 
            closeB.Location = new Point(177, 460);
            closeB.Name = "closeB";
            closeB.Size = new Size(140, 40);
            closeB.TabIndex = 21;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // customersListL
            // 
            customersListL.AutoSize = true;
            customersListL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customersListL.Location = new Point(650, 55);
            customersListL.Name = "customersListL";
            customersListL.Size = new Size(300, 25);
            customersListL.TabIndex = 22;
            customersListL.Text = "Registered customers";
            // 
            // customersRTB
            // 
            customersRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customersRTB.Location = new Point(650, 85);
            customersRTB.Name = "customersRTB";
            customersRTB.ReadOnly = true;
            customersRTB.Size = new Size(540, 415);
            customersRTB.TabIndex = 23;
            customersRTB.Text = "";
            customersRTB.WordWrap = false;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 525);
            Controls.Add(customersRTB);
            Controls.Add(customersListL);
            Controls.Add(closeB);
            Controls.Add(clearB);
            Controls.Add(deleteCustomerB);
            Controls.Add(updateCustomerB);
            Controls.Add(searchCustomerB);
            Controls.Add(addCustomerB);
            Controls.Add(emailHintL);
            Controls.Add(emailTB);
            Controls.Add(emailL);
            Controls.Add(phoneHintL);
            Controls.Add(phoneTB);
            Controls.Add(phoneL);
            Controls.Add(addressTB);
            Controls.Add(addressL);
            Controls.Add(lastNameTB);
            Controls.Add(lastNameL);
            Controls.Add(firstNameTB);
            Controls.Add(firstNameL);
            Controls.Add(searchHintL);
            Controls.Add(customerIdTB);
            Controls.Add(customerIdL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Management";
            Load += CustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label customerIdL;
        private TextBox customerIdTB;
        private Label searchHintL;
        private Label firstNameL;
        private TextBox firstNameTB;
        private Label lastNameL;
        private TextBox lastNameTB;
        private Label addressL;
        private TextBox addressTB;
        private Label phoneL;
        private MaskedTextBox phoneTB;
        private Label phoneHintL;
        private Label emailL;
        private TextBox emailTB;
        private Label emailHintL;
        private Button addCustomerB;
        private Button searchCustomerB;
        private Button updateCustomerB;
        private Button deleteCustomerB;
        private Button clearB;
        private Button closeB;
        private Label customersListL;
        private RichTextBox customersRTB;
    }
}
