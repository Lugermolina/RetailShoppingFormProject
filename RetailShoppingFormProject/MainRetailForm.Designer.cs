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
            orderSearchToolStripMenuItem = new ToolStripMenuItem();
            productSearchToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            customerManagementToolStripMenuItem = new ToolStripMenuItem();
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            productsReportsToolStripMenuItem = new ToolStripMenuItem();
            salesReportsToolStripMenuItem = new ToolStripMenuItem();
            administrationToolStripMenuItem = new ToolStripMenuItem();
            userManagementToolStripMenuItem = new ToolStripMenuItem();
            adminReportsToolStripMenuItem = new ToolStripMenuItem();
            sessionToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            userGuideToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            welcomeL = new Label();
            subtitleL = new Label();
            accessL = new Label();
            quickAccessL = new Label();
            todayL = new Label();
            todaySalesL = new Label();
            stockAlertL = new Label();
            instructionL = new Label();
            purchaseB = new Button();
            orderSearchB = new Button();
            productSearchB = new Button();
            customersB = new Button();
            productsB = new Button();
            salesReportsB = new Button();
            usersB = new Button();
            adminReportsB = new Button();
            statusStrip1 = new StatusStrip();
            userStatusL = new ToolStripStatusLabel();
            databaseStatusL = new ToolStripStatusLabel();
            dateStatusL = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { salesToolStripMenuItem, customersToolStripMenuItem, inventoryToolStripMenuItem, administrationToolStripMenuItem, sessionToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(890, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerPurchaseToolStripMenuItem, orderSearchToolStripMenuItem, productSearchToolStripMenuItem });
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.Size = new Size(110, 24);
            salesToolStripMenuItem.Text = "&Sales";
            // 
            // customerPurchaseToolStripMenuItem
            // 
            customerPurchaseToolStripMenuItem.Name = "customerPurchaseToolStripMenuItem";
            customerPurchaseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            customerPurchaseToolStripMenuItem.Size = new Size(300, 26);
            customerPurchaseToolStripMenuItem.Text = "Customer &Purchase";
            customerPurchaseToolStripMenuItem.Click += customerPurchaseToolStripMenuItem_Click;
            // 
            // orderSearchToolStripMenuItem
            // 
            orderSearchToolStripMenuItem.Name = "orderSearchToolStripMenuItem";
            orderSearchToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            orderSearchToolStripMenuItem.Size = new Size(300, 26);
            orderSearchToolStripMenuItem.Text = "&Order Search";
            orderSearchToolStripMenuItem.Click += orderSearchToolStripMenuItem_Click;
            // 
            // productSearchToolStripMenuItem
            // 
            productSearchToolStripMenuItem.Name = "productSearchToolStripMenuItem";
            productSearchToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            productSearchToolStripMenuItem.Size = new Size(300, 26);
            productSearchToolStripMenuItem.Text = "Product &Search";
            productSearchToolStripMenuItem.Click += productSearchToolStripMenuItem_Click;
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerManagementToolStripMenuItem });
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(110, 24);
            customersToolStripMenuItem.Text = "&Customers";
            // 
            // customerManagementToolStripMenuItem
            // 
            customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            customerManagementToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            customerManagementToolStripMenuItem.Size = new Size(300, 26);
            customerManagementToolStripMenuItem.Text = "Customer &Management";
            customerManagementToolStripMenuItem.Click += customerManagementToolStripMenuItem_Click;
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productsReportsToolStripMenuItem, salesReportsToolStripMenuItem });
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(110, 24);
            inventoryToolStripMenuItem.Text = "&Inventory";
            // 
            // productsReportsToolStripMenuItem
            // 
            productsReportsToolStripMenuItem.Name = "productsReportsToolStripMenuItem";
            productsReportsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            productsReportsToolStripMenuItem.Size = new Size(300, 26);
            productsReportsToolStripMenuItem.Text = "&Products and Inventory";
            productsReportsToolStripMenuItem.Click += productsReportsToolStripMenuItem_Click;
            // 
            // salesReportsToolStripMenuItem
            // 
            salesReportsToolStripMenuItem.Name = "salesReportsToolStripMenuItem";
            salesReportsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            salesReportsToolStripMenuItem.Size = new Size(300, 26);
            salesReportsToolStripMenuItem.Text = "Sales &Reports";
            salesReportsToolStripMenuItem.Click += salesReportsToolStripMenuItem_Click;
            // 
            // administrationToolStripMenuItem
            // 
            administrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManagementToolStripMenuItem, adminReportsToolStripMenuItem });
            administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            administrationToolStripMenuItem.Size = new Size(110, 24);
            administrationToolStripMenuItem.Text = "&Administration";
            // 
            // userManagementToolStripMenuItem
            // 
            userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            userManagementToolStripMenuItem.Size = new Size(300, 26);
            userManagementToolStripMenuItem.Text = "&User Management";
            userManagementToolStripMenuItem.Click += userManagementToolStripMenuItem_Click;
            // 
            // adminReportsToolStripMenuItem
            // 
            adminReportsToolStripMenuItem.Name = "adminReportsToolStripMenuItem";
            adminReportsToolStripMenuItem.Size = new Size(300, 26);
            adminReportsToolStripMenuItem.Text = "Administration &Reports";
            adminReportsToolStripMenuItem.Click += adminReportsToolStripMenuItem_Click;
            // 
            // sessionToolStripMenuItem
            // 
            sessionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logOutToolStripMenuItem, exitToolStripMenuItem });
            sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            sessionToolStripMenuItem.Size = new Size(110, 24);
            sessionToolStripMenuItem.Text = "Sessio&n";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(300, 26);
            logOutToolStripMenuItem.Text = "&Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(300, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userGuideToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(110, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // userGuideToolStripMenuItem
            // 
            userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            userGuideToolStripMenuItem.ShortcutKeys = Keys.F1;
            userGuideToolStripMenuItem.Size = new Size(300, 26);
            userGuideToolStripMenuItem.Text = "&User Guide";
            userGuideToolStripMenuItem.Click += userGuideToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(300, 26);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // welcomeL
            // 
            welcomeL.AutoSize = true;
            welcomeL.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeL.Location = new Point(30, 45);
            welcomeL.Name = "welcomeL";
            welcomeL.Size = new Size(400, 20);
            welcomeL.TabIndex = 1;
            welcomeL.Text = "Welcome to Retail Shopping System";
            // 
            // subtitleL
            // 
            subtitleL.AutoSize = true;
            subtitleL.Location = new Point(34, 100);
            subtitleL.Name = "subtitleL";
            subtitleL.Size = new Size(400, 20);
            subtitleL.TabIndex = 2;
            subtitleL.Text = "Logged in as";
            // 
            // accessL
            // 
            accessL.AutoSize = true;
            accessL.Location = new Point(34, 128);
            accessL.Name = "accessL";
            accessL.Size = new Size(400, 20);
            accessL.TabIndex = 3;
            accessL.Text = "Access:";
            // 
            // quickAccessL
            // 
            quickAccessL.AutoSize = true;
            quickAccessL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quickAccessL.Location = new Point(30, 175);
            quickAccessL.Name = "quickAccessL";
            quickAccessL.Size = new Size(400, 20);
            quickAccessL.TabIndex = 4;
            quickAccessL.Text = "Quick access";
            // 
            // todayL
            // 
            todayL.AutoSize = true;
            todayL.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            todayL.Location = new Point(30, 355);
            todayL.Name = "todayL";
            todayL.Size = new Size(400, 20);
            todayL.TabIndex = 5;
            todayL.Text = "Today";
            // 
            // todaySalesL
            // 
            todaySalesL.AutoSize = true;
            todaySalesL.Location = new Point(34, 388);
            todaySalesL.Name = "todaySalesL";
            todaySalesL.Size = new Size(400, 20);
            todaySalesL.TabIndex = 6;
            todaySalesL.Text = "Sales today:";
            // 
            // stockAlertL
            // 
            stockAlertL.AutoSize = true;
            stockAlertL.Location = new Point(34, 415);
            stockAlertL.Name = "stockAlertL";
            stockAlertL.Size = new Size(400, 20);
            stockAlertL.TabIndex = 7;
            stockAlertL.Text = "";
            // 
            // instructionL
            // 
            instructionL.AutoSize = true;
            instructionL.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            instructionL.Location = new Point(34, 455);
            instructionL.Name = "instructionL";
            instructionL.Size = new Size(400, 20);
            instructionL.TabIndex = 8;
            instructionL.Text = "Use the buttons, the menu bar or the shortcut keys. F1 opens the user guide. Session > Log Out to change user.";
            // 
            // purchaseB
            // 
            purchaseB.Location = new Point(30, 210);
            purchaseB.Name = "purchaseB";
            purchaseB.Size = new Size(200, 60);
            purchaseB.TabIndex = 9;
            purchaseB.Text = "Customer Purchase\n(Ctrl+P)";
            purchaseB.UseVisualStyleBackColor = true;
            purchaseB.Click += customerPurchaseToolStripMenuItem_Click;
            // 
            // orderSearchB
            // 
            orderSearchB.Location = new Point(240, 210);
            orderSearchB.Name = "orderSearchB";
            orderSearchB.Size = new Size(200, 60);
            orderSearchB.TabIndex = 10;
            orderSearchB.Text = "Order Search\n(Ctrl+O)";
            orderSearchB.UseVisualStyleBackColor = true;
            orderSearchB.Click += orderSearchToolStripMenuItem_Click;
            // 
            // productSearchB
            // 
            productSearchB.Location = new Point(450, 210);
            productSearchB.Name = "productSearchB";
            productSearchB.Size = new Size(200, 60);
            productSearchB.TabIndex = 11;
            productSearchB.Text = "Product Search\n(Ctrl+F)";
            productSearchB.UseVisualStyleBackColor = true;
            productSearchB.Click += productSearchToolStripMenuItem_Click;
            // 
            // customersB
            // 
            customersB.Location = new Point(660, 210);
            customersB.Name = "customersB";
            customersB.Size = new Size(200, 60);
            customersB.TabIndex = 12;
            customersB.Text = "Customer Management\n(Ctrl+U)";
            customersB.UseVisualStyleBackColor = true;
            customersB.Click += customerManagementToolStripMenuItem_Click;
            // 
            // productsB
            // 
            productsB.Location = new Point(30, 282);
            productsB.Name = "productsB";
            productsB.Size = new Size(200, 60);
            productsB.TabIndex = 13;
            productsB.Text = "Products and Inventory\n(Ctrl+I)";
            productsB.UseVisualStyleBackColor = true;
            productsB.Click += productsReportsToolStripMenuItem_Click;
            // 
            // salesReportsB
            // 
            salesReportsB.Location = new Point(240, 282);
            salesReportsB.Name = "salesReportsB";
            salesReportsB.Size = new Size(200, 60);
            salesReportsB.TabIndex = 14;
            salesReportsB.Text = "Sales Reports\n(Ctrl+R)";
            salesReportsB.UseVisualStyleBackColor = true;
            salesReportsB.Click += salesReportsToolStripMenuItem_Click;
            // 
            // usersB
            // 
            usersB.Location = new Point(450, 282);
            usersB.Name = "usersB";
            usersB.Size = new Size(200, 60);
            usersB.TabIndex = 15;
            usersB.Text = "User Management";
            usersB.UseVisualStyleBackColor = true;
            usersB.Click += userManagementToolStripMenuItem_Click;
            // 
            // adminReportsB
            // 
            adminReportsB.Location = new Point(660, 282);
            adminReportsB.Name = "adminReportsB";
            adminReportsB.Size = new Size(200, 60);
            adminReportsB.TabIndex = 16;
            adminReportsB.Text = "Administration Reports";
            adminReportsB.UseVisualStyleBackColor = true;
            adminReportsB.Click += adminReportsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { userStatusL, databaseStatusL, dateStatusL });
            statusStrip1.Location = new Point(0, 494);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(890, 26);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // userStatusL
            // 
            userStatusL.Name = "userStatusL";
            userStatusL.Size = new Size(200, 20);
            userStatusL.Text = "User";
            // 
            // databaseStatusL
            // 
            databaseStatusL.Name = "databaseStatusL";
            databaseStatusL.Spring = true;
            databaseStatusL.Size = new Size(200, 20);
            databaseStatusL.Text = "Database";
            // 
            // dateStatusL
            // 
            dateStatusL.Name = "dateStatusL";
            dateStatusL.Size = new Size(200, 20);
            dateStatusL.Text = "Date";
            // 
            // MainRetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 520);
            Controls.Add(statusStrip1);
            Controls.Add(adminReportsB);
            Controls.Add(usersB);
            Controls.Add(salesReportsB);
            Controls.Add(productsB);
            Controls.Add(customersB);
            Controls.Add(productSearchB);
            Controls.Add(orderSearchB);
            Controls.Add(purchaseB);
            Controls.Add(instructionL);
            Controls.Add(stockAlertL);
            Controls.Add(todaySalesL);
            Controls.Add(todayL);
            Controls.Add(quickAccessL);
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
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem customerPurchaseToolStripMenuItem;
        private ToolStripMenuItem orderSearchToolStripMenuItem;
        private ToolStripMenuItem productSearchToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private ToolStripMenuItem customerManagementToolStripMenuItem;
        private ToolStripMenuItem inventoryToolStripMenuItem;
        private ToolStripMenuItem productsReportsToolStripMenuItem;
        private ToolStripMenuItem salesReportsToolStripMenuItem;
        private ToolStripMenuItem administrationToolStripMenuItem;
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private ToolStripMenuItem adminReportsToolStripMenuItem;
        private ToolStripMenuItem sessionToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem userGuideToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label welcomeL;
        private Label subtitleL;
        private Label accessL;
        private Label quickAccessL;
        private Label todayL;
        private Label todaySalesL;
        private Label stockAlertL;
        private Label instructionL;
        private Button purchaseB;
        private Button orderSearchB;
        private Button productSearchB;
        private Button customersB;
        private Button productsB;
        private Button salesReportsB;
        private Button usersB;
        private Button adminReportsB;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel userStatusL;
        private ToolStripStatusLabel databaseStatusL;
        private ToolStripStatusLabel dateStatusL;
    }
}
