/*  Menu-based Retail Shopping System, iteration 2
    Main form of the store: the menu bar opens the form of each business process.
    The menus shown depend on the role of the user who logged in:
    Cashier : Sales, Customers, Session
    Manager : Cashier menus plus Inventory
    Admin   : all the menus, including Administration (user management)
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
            this.loggedUser = loggedUser;
        }

        // new: tells LoginForm whether to show the login again (Log Out) or close the application (Exit)
        public bool LoggedOut
        {
            get { return loggedOut; }
        }

        private void MainRetailForm_Load(object sender, EventArgs e)
        {
            RetailDataFile.CreateSampleProducts();
            subtitleL.Text = "Logged in as " + loggedUser.GetDisplayName() + "     Date: " + DateTime.Now.ToString("yyyy-MM-dd");

            // new: menus hidden according to the role
            inventoryToolStripMenuItem.Visible = loggedUser.CanManageInventory();
            administrationToolStripMenuItem.Visible = loggedUser.IsAdmin();

            if (loggedUser.IsAdmin())
            {
                accessL.Text = "Access: all the menus, including Administration (users and reports).";
            }
            else if (loggedUser.CanManageInventory())
            {
                accessL.Text = "Access: Sales, Customers and Inventory (products, sales and stock reports).";
            }
            else
            {
                accessL.Text = "Access: Sales (purchases, order search and product search) and Customers.";
            }
        }

        private void customerPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(loggedUser);
            purchaseForm.ShowDialog();
        }

        private void productSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSearchForm productSearchForm = new ProductSearchForm();
            productSearchForm.ShowDialog();
        }

        // new: Sales > Order Search, all roles
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
            ManagerForm managerForm = new ManagerForm();
            managerForm.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(loggedUser);
            userForm.ShowDialog();
        }

        // new: Administration > Administration Reports, Admin only (the menu is hidden for the other roles)
        private void adminReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminReportForm adminReportForm = new AdminReportForm();
            adminReportForm.ShowDialog();
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
