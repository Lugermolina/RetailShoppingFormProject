namespace RetailShoppingFormProject
{
    partial class PurchaseForm
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
            orderInfoL = new Label();
            customerIdL = new Label();
            customerIdTB = new TextBox();
            findCustomerB = new Button();
            customerNameL = new Label();
            customerNameTB = new TextBox();
            productCodeL = new Label();
            productCodeTB = new TextBox();
            productSearchB = new Button();
            quantityL = new Label();
            quantityTB = new TextBox();
            addLineB = new Button();
            cartL = new Label();
            cartRTB = new RichTextBox();
            subtotalL = new Label();
            subtotalTB = new TextBox();
            gstL = new Label();
            gstTB = new TextBox();
            qstL = new Label();
            qstTB = new TextBox();
            totalL = new Label();
            totalTB = new TextBox();
            paymentMethodL = new Label();
            paymentMethodCB = new ComboBox();
            amountPaidL = new Label();
            amountPaidTB = new TextBox();
            completePurchaseB = new Button();
            newOrderB = new Button();
            closeB = new Button();
            amountHintL = new Label();
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
            titleL.Text = "Customer Purchase";
            // 
            // orderInfoL
            // 
            orderInfoL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderInfoL.Location = new Point(460, 32);
            orderInfoL.Name = "orderInfoL";
            orderInfoL.Size = new Size(510, 25);
            orderInfoL.TabIndex = 1;
            orderInfoL.Text = "";
            // 
            // customerIdL
            // 
            customerIdL.AutoSize = true;
            customerIdL.Location = new Point(30, 83);
            customerIdL.Name = "customerIdL";
            customerIdL.Size = new Size(160, 20);
            customerIdL.TabIndex = 2;
            customerIdL.Text = "Customer ID:";
            // 
            // customerIdTB
            // 
            customerIdTB.Location = new Point(200, 80);
            customerIdTB.Name = "customerIdTB";
            customerIdTB.Size = new Size(80, 27);
            customerIdTB.TabIndex = 3;
            // 
            // findCustomerB
            // 
            findCustomerB.Location = new Point(295, 77);
            findCustomerB.Name = "findCustomerB";
            findCustomerB.Size = new Size(130, 32);
            findCustomerB.TabIndex = 4;
            findCustomerB.Text = "Find Customer";
            findCustomerB.UseVisualStyleBackColor = true;
            findCustomerB.Click += findCustomerB_Click;
            // 
            // customerNameL
            // 
            customerNameL.AutoSize = true;
            customerNameL.Location = new Point(30, 128);
            customerNameL.Name = "customerNameL";
            customerNameL.Size = new Size(160, 20);
            customerNameL.TabIndex = 5;
            customerNameL.Text = "Customer name:";
            // 
            // customerNameTB
            // 
            customerNameTB.Location = new Point(200, 125);
            customerNameTB.Name = "customerNameTB";
            customerNameTB.ReadOnly = true;
            customerNameTB.Size = new Size(225, 27);
            customerNameTB.TabIndex = 6;
            // 
            // productCodeL
            // 
            productCodeL.AutoSize = true;
            productCodeL.Location = new Point(30, 183);
            productCodeL.Name = "productCodeL";
            productCodeL.Size = new Size(160, 20);
            productCodeL.TabIndex = 7;
            productCodeL.Text = "Product code:";
            // 
            // productCodeTB
            // 
            productCodeTB.Location = new Point(200, 180);
            productCodeTB.Name = "productCodeTB";
            productCodeTB.Size = new Size(100, 27);
            productCodeTB.TabIndex = 8;
            // 
            // productSearchB
            // 
            productSearchB.Location = new Point(315, 177);
            productSearchB.Name = "productSearchB";
            productSearchB.Size = new Size(110, 32);
            productSearchB.TabIndex = 9;
            productSearchB.Text = "Search...";
            productSearchB.UseVisualStyleBackColor = true;
            productSearchB.Click += productSearchB_Click;
            // 
            // quantityL
            // 
            quantityL.AutoSize = true;
            quantityL.Location = new Point(30, 228);
            quantityL.Name = "quantityL";
            quantityL.Size = new Size(160, 20);
            quantityL.TabIndex = 10;
            quantityL.Text = "Quantity:";
            // 
            // quantityTB
            // 
            quantityTB.Location = new Point(200, 225);
            quantityTB.Name = "quantityTB";
            quantityTB.Size = new Size(100, 27);
            quantityTB.TabIndex = 11;
            // 
            // addLineB
            // 
            addLineB.Location = new Point(315, 222);
            addLineB.Name = "addLineB";
            addLineB.Size = new Size(110, 32);
            addLineB.TabIndex = 12;
            addLineB.Text = "Add Line";
            addLineB.UseVisualStyleBackColor = true;
            addLineB.Click += addLineB_Click;
            // 
            // cartL
            // 
            cartL.AutoSize = true;
            cartL.Location = new Point(460, 57);
            cartL.Name = "cartL";
            cartL.Size = new Size(300, 20);
            cartL.TabIndex = 13;
            cartL.Text = "Items in this order:";
            // 
            // cartRTB
            // 
            cartRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cartRTB.Location = new Point(460, 80);
            cartRTB.Name = "cartRTB";
            cartRTB.ReadOnly = true;
            cartRTB.Size = new Size(510, 300);
            cartRTB.TabIndex = 14;
            cartRTB.Text = "";
            cartRTB.WordWrap = false;
            // 
            // subtotalL
            // 
            subtotalL.AutoSize = true;
            subtotalL.Location = new Point(30, 283);
            subtotalL.Name = "subtotalL";
            subtotalL.Size = new Size(160, 20);
            subtotalL.TabIndex = 15;
            subtotalL.Text = "Subtotal:";
            // 
            // subtotalTB
            // 
            subtotalTB.Location = new Point(200, 280);
            subtotalTB.Name = "subtotalTB";
            subtotalTB.ReadOnly = true;
            subtotalTB.Size = new Size(150, 27);
            subtotalTB.TabIndex = 16;
            // 
            // gstL
            // 
            gstL.AutoSize = true;
            gstL.Location = new Point(30, 323);
            gstL.Name = "gstL";
            gstL.Size = new Size(160, 20);
            gstL.TabIndex = 17;
            gstL.Text = "GST (5%):";
            // 
            // gstTB
            // 
            gstTB.Location = new Point(200, 320);
            gstTB.Name = "gstTB";
            gstTB.ReadOnly = true;
            gstTB.Size = new Size(150, 27);
            gstTB.TabIndex = 18;
            // 
            // qstL
            // 
            qstL.AutoSize = true;
            qstL.Location = new Point(30, 363);
            qstL.Name = "qstL";
            qstL.Size = new Size(160, 20);
            qstL.TabIndex = 19;
            qstL.Text = "QST (9.975%):";
            // 
            // qstTB
            // 
            qstTB.Location = new Point(200, 360);
            qstTB.Name = "qstTB";
            qstTB.ReadOnly = true;
            qstTB.Size = new Size(150, 27);
            qstTB.TabIndex = 20;
            // 
            // totalL
            // 
            totalL.AutoSize = true;
            totalL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalL.Location = new Point(30, 403);
            totalL.Name = "totalL";
            totalL.Size = new Size(160, 20);
            totalL.TabIndex = 21;
            totalL.Text = "Total:";
            // 
            // totalTB
            // 
            totalTB.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalTB.Location = new Point(200, 400);
            totalTB.Name = "totalTB";
            totalTB.ReadOnly = true;
            totalTB.Size = new Size(150, 27);
            totalTB.TabIndex = 22;
            // 
            // paymentMethodL
            // 
            paymentMethodL.AutoSize = true;
            paymentMethodL.Location = new Point(30, 458);
            paymentMethodL.Name = "paymentMethodL";
            paymentMethodL.Size = new Size(160, 20);
            paymentMethodL.TabIndex = 23;
            paymentMethodL.Text = "Payment method:";
            // 
            // paymentMethodCB
            // 
            paymentMethodCB.DropDownStyle = ComboBoxStyle.DropDownList;
            paymentMethodCB.FormattingEnabled = true;
            paymentMethodCB.Items.AddRange(new object[] { "Cash", "Debit card", "Credit card" });
            paymentMethodCB.Location = new Point(200, 455);
            paymentMethodCB.Name = "paymentMethodCB";
            paymentMethodCB.Size = new Size(150, 28);
            paymentMethodCB.TabIndex = 24;
            // 
            // amountPaidL
            // 
            amountPaidL.AutoSize = true;
            amountPaidL.Location = new Point(30, 498);
            amountPaidL.Name = "amountPaidL";
            amountPaidL.Size = new Size(160, 20);
            amountPaidL.TabIndex = 25;
            amountPaidL.Text = "Amount paid:";
            // 
            // amountPaidTB
            // 
            amountPaidTB.Location = new Point(200, 495);
            amountPaidTB.Name = "amountPaidTB";
            amountPaidTB.Size = new Size(150, 27);
            amountPaidTB.TabIndex = 26;
            // 
            // completePurchaseB
            // 
            completePurchaseB.Location = new Point(460, 450);
            completePurchaseB.Name = "completePurchaseB";
            completePurchaseB.Size = new Size(180, 45);
            completePurchaseB.TabIndex = 27;
            completePurchaseB.Text = "Complete Purchase";
            completePurchaseB.UseVisualStyleBackColor = true;
            completePurchaseB.Click += completePurchaseB_Click;
            // 
            // newOrderB
            // 
            newOrderB.Location = new Point(655, 450);
            newOrderB.Name = "newOrderB";
            newOrderB.Size = new Size(150, 45);
            newOrderB.TabIndex = 28;
            newOrderB.Text = "New Order";
            newOrderB.UseVisualStyleBackColor = true;
            newOrderB.Click += newOrderB_Click;
            // 
            // closeB
            // 
            closeB.Location = new Point(820, 450);
            closeB.Name = "closeB";
            closeB.Size = new Size(150, 45);
            closeB.TabIndex = 29;
            closeB.Text = "Close";
            closeB.UseVisualStyleBackColor = true;
            closeB.Click += closeB_Click;
            // 
            // amountHintL
            // 
            amountHintL.AutoSize = true;
            amountHintL.Location = new Point(460, 505);
            amountHintL.Name = "amountHintL";
            amountHintL.Size = new Size(510, 20);
            amountHintL.TabIndex = 30;
            amountHintL.Text = "Leave the amount paid empty to pay the exact total.";
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 560);
            Controls.Add(amountHintL);
            Controls.Add(closeB);
            Controls.Add(newOrderB);
            Controls.Add(completePurchaseB);
            Controls.Add(amountPaidTB);
            Controls.Add(amountPaidL);
            Controls.Add(paymentMethodCB);
            Controls.Add(paymentMethodL);
            Controls.Add(totalTB);
            Controls.Add(totalL);
            Controls.Add(qstTB);
            Controls.Add(qstL);
            Controls.Add(gstTB);
            Controls.Add(gstL);
            Controls.Add(subtotalTB);
            Controls.Add(subtotalL);
            Controls.Add(cartRTB);
            Controls.Add(cartL);
            Controls.Add(addLineB);
            Controls.Add(quantityTB);
            Controls.Add(quantityL);
            Controls.Add(productSearchB);
            Controls.Add(productCodeTB);
            Controls.Add(productCodeL);
            Controls.Add(customerNameTB);
            Controls.Add(customerNameL);
            Controls.Add(findCustomerB);
            Controls.Add(customerIdTB);
            Controls.Add(customerIdL);
            Controls.Add(orderInfoL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PurchaseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Purchase";
            Load += PurchaseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label orderInfoL;
        private Label customerIdL;
        private TextBox customerIdTB;
        private Button findCustomerB;
        private Label customerNameL;
        private TextBox customerNameTB;
        private Label productCodeL;
        private TextBox productCodeTB;
        private Button productSearchB;
        private Label quantityL;
        private TextBox quantityTB;
        private Button addLineB;
        private Label cartL;
        private RichTextBox cartRTB;
        private Label subtotalL;
        private TextBox subtotalTB;
        private Label gstL;
        private TextBox gstTB;
        private Label qstL;
        private TextBox qstTB;
        private Label totalL;
        private TextBox totalTB;
        private Label paymentMethodL;
        private ComboBox paymentMethodCB;
        private Label amountPaidL;
        private TextBox amountPaidTB;
        private Button completePurchaseB;
        private Button newOrderB;
        private Button closeB;
        private Label amountHintL;
    }
}
