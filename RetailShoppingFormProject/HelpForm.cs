/*  User guide of the Retail Shopping System, iteration 3 (Help > User Guide, F1)
    Input(s): the logged in user
    Processing: the sections of the guide are chosen according to the role of the user
    Output(s): the user guide of the role, with the contact for help
*/
namespace RetailShoppingFormProject
{
    public partial class HelpForm : Form
    {
        private User loggedUser;

        public HelpForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            this.loggedUser = loggedUser;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            titleL.Text = "User Guide, " + loggedUser.Role + " role";
            String guide = "SALES\n"
                + "Customer Purchase (Ctrl+P): find the customer by ID, or check Walk in customer. Enter a product code and a "
                + "quantity, then Add Line; the same product added again goes on the same line. Choose the payment method, "
                + "type the amount paid (empty = exact amount) and click Complete Purchase. The receipt opens; the order is "
                + "saved only if every product still has enough stock.\n"
                + "Order Search (Ctrl+O): by order number (detail of one order), by customer ID (0 = walk in customers) "
                + "or by order date chosen in the calendar.\n"
                + "Product Search (Ctrl+F): part of the name, a category, a price range; every filter is optional.\n\n"
                + "CUSTOMERS\n"
                + "Customer Management (Ctrl+U): Add, Search (by ID, else phone, else last name), Update and Delete. "
                + "First name, last name and phone are required; the phone has 10 digits. A customer with orders "
                + "cannot be deleted.\n\n";
            if (loggedUser.CanManageInventory())
            {
                guide = guide + "INVENTORY\n"
                    + "Products and Inventory (Ctrl+I): Find, Add, Update and Remove a product. The code is P, the category "
                    + "digit and three digits (Groceries P1xxx, Beverages P2xxx...). Typing a new category adds it after a "
                    + "confirmation. A product that was sold cannot be removed: set its stock to 0. Inventory Report and "
                    + "Low Stock List show the status in red (out of stock), amber (low stock) and green (in stock).\n"
                    + "Sales Reports (Ctrl+R): choose the period in the calendars, then Sales by Day, Sales by Category, "
                    + "Best Sellers or End of Day Closing (on the To date). Each report has a chart; Save to File writes it "
                    + "into a text file.\n\n";
            }
            if (loggedUser.IsAdmin())
            {
                guide = guide + "ADMINISTRATION\n"
                    + "User Management: Add, Search, Update and Delete the staff users. The password has at least 6 "
                    + "characters. Uncheck Locked to unlock an account. A user who processed sales cannot be deleted: "
                    + "lock the account instead. You cannot lock, delete or change the role of your own account.\n"
                    + "Administration Reports: All Orders, All Customers, Sales by Staff User, Taxes by Month, Customers "
                    + "without Orders and Locked Accounts, each one can be saved to a file.\n\n";
            }
            guide = guide + "KEYS\n"
                + "Alt + the underlined letter opens a menu or clicks a button. Enter clicks the main button of the "
                + "login and the search forms; Esc closes the report forms.\n\n"
                + "HELP\n"
                + "After three wrong passwords the account is locked. A locked account or a forgotten password is handled "
                + "by the store administrator (Admin role). For a problem with the system, report the message shown "
                + "on the screen, the form and the time to the administrator.";
            guideRTB.Text = guide;
            foreach (String heading in new String[] { "SALES", "CUSTOMERS", "INVENTORY", "ADMINISTRATION", "KEYS", "HELP" })
            {
                RetailReport.ColorWord(guideRTB, heading, RetailTheme.Navy);
            }
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
