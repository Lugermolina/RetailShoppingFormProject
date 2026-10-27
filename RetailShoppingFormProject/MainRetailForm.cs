/*  Menu-based Retail Shopping System, iteration 3
    Main form of the store: the menu bar, the quick access buttons (switchboard) and the shortcut keys
    open the form of each business process. The menus and buttons shown depend on the role of the user:
    Cashier : Sales, Customers, Session, Help
    Manager : Cashier menus plus Inventory (products, inventory reports, sales reports with charts)
    Admin   : all the menus, including Administration (user management and administration reports)
    The Today panel shows the sales of the day and, for Manager and Admin, the products below the minimum stock.
*/
namespace RetailShoppingFormProject
{
    public partial class MainRetailForm : Form
    {
        private User loggedUser;
        private bool loggedOut = false;

        public MainRetailForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            this.loggedUser = loggedUser;
        }

        // Tells LoginForm whether to show the login again (Log Out) or close the application (Exit)
        public bool LoggedOut
        {
            get { return loggedOut; }
        }

        private void MainRetailForm_Load(object sender, EventArgs e)
        {
            subtitleL.Text = "Logged in as " + loggedUser.GetDisplayName() + "     Date: " + DateTime.Now.ToString("yyyy-MM-dd");
            userStatusL.Text = "User: " + loggedUser.Username + " (" + loggedUser.Role + ")";
            databaseStatusL.Text = "Database: RetailShoppingdb on localhost";
            dateStatusL.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Menus and buttons hidden according to the role; the disabled items also block their shortcut keys
            bool manager = loggedUser.CanManageInventory();
            bool admin = loggedUser.IsAdmin();
            inventoryToolStripMenuItem.Visible = manager;
            productsReportsToolStripMenuItem.Enabled = manager;
            salesReportsToolStripMenuItem.Enabled = manager;
            productsB.Visible = manager;
            salesReportsB.Visible = manager;
            administrationToolStripMenuItem.Visible = admin;
            userManagementToolStripMenuItem.Enabled = admin;
            adminReportsToolStripMenuItem.Enabled = admin;
            usersB.Visible = admin;
            adminReportsB.Visible = admin;

            if (admin)
            {
                accessL.Text = "Access: all the menus, including Administration (users and administration reports).";
            }
            else if (manager)
            {
                accessL.Text = "Access: Sales, Customers and Inventory (products, inventory and sales reports).";
            }
            else
            {
                accessL.Text = "Access: Sales (purchases, order search and product search) and Customers.";
            }
            ShowToday();
        }

        // Sales of the day for everyone; products below the minimum stock for Manager and Admin (exception)
        private void ShowToday()
        {
            List<String[]> orders = RetailDatabase.FindOrdersBetween(DateTime.Now, DateTime.Now);
            double totalSum = 0;
            foreach (String[] order in orders)
            {
                totalSum = totalSum + double.Parse(order[7]);
            }
            todaySalesL.Text = "Sales today: " + orders.Count + " order(s), $" + totalSum.ToString("N2");

            if (!loggedUser.CanManageInventory())
            {
                stockAlertL.Text = "";
                return;
            }
            int lowCount = 0;
            int outCount = 0;
            foreach (Product p in RetailDatabase.ReadProducts())
            {
                if (p.StockQty == 0)
                {
                    outCount = outCount + 1;
                }
                else if (p.IsBelowMinimum())
                {
                    lowCount = lowCount + 1;
                }
            }
            if (lowCount + outCount == 0)
            {
                stockAlertL.Text = "Stock: every product is at or above its minimum.";
                stockAlertL.ForeColor = RetailTheme.StatusGreen;
            }
            else
            {
                stockAlertL.Text = "Stock alert: " + outCount + " product(s) out of stock, " + lowCount
                    + " below the minimum. See Inventory > Products and Inventory > Low Stock List.";
                stockAlertL.ForeColor = RetailTheme.StatusRed;
            }
        }

        // Each business process is opened by its menu item, its button and its shortcut key (same handler)
        private void customerPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(loggedUser);
            purchaseForm.ShowDialog();
            ShowToday();
        }

        private void productSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSearchForm productSearchForm = new ProductSearchForm();
            productSearchForm.ShowDialog();
        }

        private void orderSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSearchForm orderSearchForm = new OrderSearchForm();
            orderSearchForm.ShowDialog();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void productsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loggedUser.CanManageInventory())
            {
                return;
            }
            ManagerForm managerForm = new ManagerForm(loggedUser);
            managerForm.ShowDialog();
            ShowToday();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loggedUser.CanManageInventory())
            {
                return;
            }
            SalesReportForm salesReportForm = new SalesReportForm(loggedUser);
            salesReportForm.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loggedUser.IsAdmin())
            {
                return;
            }
            UserForm userForm = new UserForm(loggedUser);
            userForm.ShowDialog();
        }

        private void adminReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loggedUser.IsAdmin())
            {
                return;
            }
            AdminReportForm adminReportForm = new AdminReportForm(loggedUser);
            adminReportForm.ShowDialog();
        }

        // new: Help > User Guide (F1), the guide of the role of the user
        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(loggedUser);
            helpForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Retail Shopping System, iteration 3 (October 2026)\n\n"
                + "C# Windows Forms (.NET 10) with the SQL Server database RetailShoppingdb.\n"
                + "System Development (420-940-VA), Vanier College.\n"
                + "Developed by Luis Gerardo Molina.\n\n"
                + "Support: a locked account or a forgotten password is handled by the store administrator "
                + "(Admin role) in Administration > User Management.", "About Retail Shopping System");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggedOut = true;
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
