/*  Business process 1: Customer registration
    Input(s): firstName, lastName, address, phone, email
    Processing: the next customer ID is assigned and the record is appended to customers.txt
    Output(s): the customer ID on the form, the list of registered customers
*/
namespace RetailShoppingFormProject
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void registerB_Click(object sender, EventArgs e)
        {
            // input
            String firstName = firstNameTB.Text.Trim();
            String lastName = lastNameTB.Text.Trim();
            String address = addressTB.Text.Trim();
            String phone = phoneTB.Text.Trim();
            String email = emailTB.Text.Trim();

            if (firstName == "" || lastName == "" || phone == "")
            {
                MessageBox.Show("First name, last name and phone are required.", "Customer Registration");
                return;
            }

            // processing
            int customerId = RetailDataFile.NextCustomerId();
            Customer customer = new Customer(customerId, firstName, lastName, address, phone, email);
            RetailDataFile.AppendCustomer(customer);

            // output
            customerIdTB.Text = customerId.ToString();
            MessageBox.Show("Customer " + customer.GetFullName() + " registered with ID " + customerId + ".",
                "Customer Registration");
            ShowCustomers();
        }

        private void readCustomersB_Click(object sender, EventArgs e)
        {
            ShowCustomers();
        }

        private void ShowCustomers()
        {
            List<Customer> customers = RetailDataFile.ReadCustomers();
            customersRTB.Text = "";
            customersRTB.AppendText("ID".PadRight(5) + "Name".PadRight(24) + "Phone".PadRight(16) + "Email\n");
            foreach (Customer c in customers)
            {
                customersRTB.AppendText(c.CustomerId.ToString().PadRight(5) + c.GetFullName().PadRight(24)
                    + c.Phone.PadRight(16) + c.Email + "\n");
            }
            customersRTB.AppendText("\nTotal customers: " + customers.Count);
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            firstNameTB.Text = "";
            lastNameTB.Text = "";
            addressTB.Text = "";
            phoneTB.Text = "";
            emailTB.Text = "";
            customerIdTB.Text = "";
            firstNameTB.Focus();
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
