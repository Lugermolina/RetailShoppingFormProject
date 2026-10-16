namespace RetailShoppingFormProject
{
    partial class MainRetailForm
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
            menuStrip1 = new MenuStrip();
            salesToolStripMenuItem = new ToolStripMenuItem();
            customerPurchaseToolStripMenuItem = new ToolStripMenuItem();
            productSearchToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            customerManagementToolStripMenuItem = new ToolStripMenuItem();
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            productsReportsToolStripMenuItem = new ToolStripMenuItem();
            administrationToolStripMenuItem = new ToolStripMenuItem();
            userManagementToolStripMenuItem = new ToolStripMenuItem();
            sessionToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            welcomeL = new Label();
            subtitleL = new Label();
            accessL = new Label();
            instructionL = new Label();
            menuStrip1.SuspendLayout();
            orderSearchToolStripMenuItem = new ToolStripMenuItem();
            adminReportsToolStripMenuItem = new ToolStripMenuItem();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { salesToolStripMenuItem, customersToolStripMenuItem, inventoryToolStripMenuItem, administrationToolStripMenuItem, sessionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(720, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerPurchaseToolStripMenuItem, orderSearchToolStripMenuItem, productSearchToolStripMenuItem });
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.Size = new Size(55, 24);
            salesToolStripMenuItem.Text = "Sales";
            // 
            // customerPurchaseToolStripMenuItem
            // 
            customerPurchaseToolStripMenuItem.Name = "customerPurchaseToolStripMenuItem";
            customerPurchaseToolStripMenuItem.Size = new Size(224, 26);
            customerPurchaseToolStripMenuItem.Text = "Customer Purchase";
            customerPurchaseToolStripMenuItem.Click += customerPurchaseToolStripMenuItem_Click;
            // 
            // productSearchToolStripMenuItem
            // 
            productSearchToolStripMenuItem.Name = "productSearchToolStripMenuItem";
            productSearchToolStripMenuItem.Size = new Size(224, 26);
            productSearchToolStripMenuItem.Text = "Product Search";
            productSearchToolStripMenuItem.Click += productSearchToolStripMenuItem_Click;
            // 
            // orderSearchToolStripMenuItem
            // 
            orderSearchToolStripMenuItem.Name = "orderSearchToolStripMenuItem";
            orderSearchToolStripMenuItem.Size = new Size(224, 26);
            orderSearchToolStripMenuItem.Text = "Order Search";
            orderSearchToolStripMenuItem.Click += orderSearchToolStripMenuItem_Click;
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerManagementToolStripMenuItem });
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(91, 24);
            customersToolStripMenuItem.Text = "Customers";
            // 
            // customerManagementToolStripMenuItem
            // 
            customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            customerManagementToolStripMenuItem.Size = new Size(240, 26);
            customerManagementToolStripMenuItem.Text = "Customer Management";
            customerManagementToolStripMenuItem.Click += customerManagementToolStripMenuItem_Click;
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productsReportsToolStripMenuItem });
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(84, 24);
            inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // productsReportsToolStripMenuItem
            // 
            productsReportsToolStripMenuItem.Name = "productsReportsToolStripMenuItem";
            productsReportsToolStripMenuItem.Size = new Size(240, 26);
            productsReportsToolStripMenuItem.Text = "Products and Reports";
            productsReportsToolStripMenuItem.Click += productsReportsToolStripMenuItem_Click;
            // 
            // administrationToolStripMenuItem
            // 
            administrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManagementToolStripMenuItem, adminReportsToolStripMenuItem });
            administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            administrationToolStripMenuItem.Size = new Size(122, 24);
            administrationToolStripMenuItem.Text = "Administration";
            // 
            // userManagementToolStripMenuItem
            // 
            userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            userManagementToolStripMenuItem.Size = new Size(240, 26);
            userManagementToolStripMenuItem.Text = "User Management";
            userManagementToolStripMenuItem.Click += userManagementToolStripMenuItem_Click;
            // 
            // adminReportsToolStripMenuItem
            // 
            adminReportsToolStripMenuItem.Name = "adminReportsToolStripMenuItem";
            adminReportsToolStripMenuItem.Size = new Size(240, 26);
            adminReportsToolStripMenuItem.Text = "Administration Reports";
            adminReportsToolStripMenuItem.Click += adminReportsToolStripMenuItem_Click;
            // 
            // sessionToolStripMenuItem
            // 
            sessionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logOutToolStripMenuItem, exitToolStripMenuItem });
            sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            sessionToolStripMenuItem.Size = new Size(70, 24);
            sessionToolStripMenuItem.Text = "Session";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(224, 26);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // welcomeL
            // 
            welcomeL.AutoSize = true;
            welcomeL.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeL.ForeColor = Color.Blue;
            welcomeL.Location = new Point(30, 55);
            welcomeL.Name = "welcomeL";
            welcomeL.Size = new Size(640, 46);
            welcomeL.TabIndex = 1;
            welcomeL.Text = "Welcome to Retail Shopping System";
            // 
            // subtitleL
            // 
            subtitleL.AutoSize = true;
            subtitleL.Location = new Point(34, 115);
            subtitleL.Name = "subtitleL";
            subtitleL.Size = new Size(400, 20);
            subtitleL.TabIndex = 2;
            subtitleL.Text = "Logged in as";
            // 
            // accessL
            // 
            accessL.AutoSize = true;
            accessL.Location = new Point(34, 150);
            accessL.Name = "accessL";
            accessL.Size = new Size(400, 20);
            accessL.TabIndex = 3;
            accessL.Text = "Access:";
            // 
            // instructionL
            // 
            instructionL.AutoSize = true;
            instructionL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            instructionL.Location = new Point(34, 195);
            instructionL.Name = "instructionL";
            instructionL.Size = new Size(400, 20);
            instructionL.TabIndex = 4;
            instructionL.Text = "Use the menu bar to open each business process. Session > Log Out to change user.";
            // 
            // MainRetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 250);
            Controls.Add(instructionL);
            Controls.Add(accessL);
            Controls.Add(subtitleL);
            Controls.Add(welcomeL);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainRetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Retail Shopping System";
            Load += MainRetailForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem customerPurchaseToolStripMenuItem;
        private ToolStripMenuItem productSearchToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private ToolStripMenuItem customerManagementToolStripMenuItem;
        private ToolStripMenuItem inventoryToolStripMenuItem;
        private ToolStripMenuItem productsReportsToolStripMenuItem;
        private ToolStripMenuItem administrationToolStripMenuItem;
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private ToolStripMenuItem sessionToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label welcomeL;
        private Label subtitleL;
        private Label accessL;
        private Label instructionL;
        private ToolStripMenuItem orderSearchToolStripMenuItem;
        private ToolStripMenuItem adminReportsToolStripMenuItem;
    }
}
