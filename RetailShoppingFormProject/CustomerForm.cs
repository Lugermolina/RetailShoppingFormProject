/*  Business process 1: Customer management, iteration 3
    Input(s): customer ID, first name, last name, address, phone, email
    Processing: Add, Search, Update and Delete on the Customers table of SQL Server
                the fields are validated: names with letters only, phone with 10 digits, email with a valid form;
                an email cannot belong to two customers; a phone can be shared by a household after a confirmation,
                but the same name with the same phone is refused as a duplicate;
                a new customer gets the highest ID plus one;
                a customer with orders cannot be deleted, so the order history stays complete
    Output(s): the customer on the form and the list of registered customers
*/
namespace RetailShoppingFormProject
{
    public partial class CustomerForm : Form
    {
        private ToolTip tips = new ToolTip();

        public CustomerForm()
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            // new: help text shown when the mouse stays over a control
            tips.SetToolTip(searchCustomerB, "Searches by ID first, else by phone, else by last name");
            tips.SetToolTip(phoneTB, "10 digits; a phone can be shared by the members of a household");
            tips.SetToolTip(emailTB, "Optional, for example name@example.com; one customer per email");
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ShowCustomers(RetailDatabase.ReadCustomers(), "Total customers: ");
        }

        private void addCustomerB_Click(object sender, EventArgs e)
        {
            // input and processing
            int customerId = RetailDatabase.NextCustomerId();
            Customer customer = ReadCustomerFields(customerId);
            if (customer == null)
            {
                return;
            }
            RetailDatabase.AddCustomer(customer);

            // output
            ShowCustomerDetails(customer);
            ShowCustomers(RetailDatabase.ReadCustomers(), "Total customers: ");
            MessageBox.Show("Customer " + customer.GetFullName() + " added with ID " + customerId + ".",
                "Customer Management");
        }

        // The ID is used first, then the phone, then the last name; a last name can match several customers
        private void searchCustomerB_Click(object sender, EventArgs e)
        {
            String idText = customerIdTB.Text.Trim();
            String phoneText = phoneTB.Text.Trim();
            String lastName = lastNameTB.Text.Trim();

            if (idText != "")
            {
                int customerId;
                if (!int.TryParse(idText, out customerId))
                {
                    MessageBox.Show("The customer ID must be a number.", "Customer Management");
                    return;
                }
                Customer customer = RetailDatabase.FindCustomer(customerId);
                if (customer == null)
                {
                    MessageBox.Show("No customer has the ID " + customerId + ".", "Customer Management");
                    return;
                }
                ShowCustomerDetails(customer);
            }
            else if (phoneText != "")
            {
                // A phone can be shared by a household, so it can match several customers
                String phone = Customer.FormatPhone(phoneText);
                if (phone == "")
                {
                    MessageBox.Show("The phone must have 10 digits, for example 514-555-0123.", "Customer Management");
                    phoneTB.Focus();
                    return;
                }
                ShowMatches(RetailDatabase.FindCustomersByPhone(phone), "the phone " + phone);
            }
            else if (lastName != "")
            {
                ShowMatches(RetailDatabase.FindCustomersByLastName(lastName), "the last name " + lastName);
            }
            else
            {
                MessageBox.Show("Enter the customer ID, the phone or the last name.", "Customer Management");
            }
        }

        // One match is opened on the form; several matches are listed so the user can choose the ID
        private void ShowMatches(List<Customer> matches, String searchText)
        {
            if (matches.Count == 0)
            {
                MessageBox.Show("No customer has " + searchText + ".", "Customer Management");
            }
            else if (matches.Count == 1)
            {
                ShowCustomerDetails(matches[0]);
            }
            else
            {
                ShowCustomers(matches, "Customers found: ");
                MessageBox.Show(matches.Count + " customers have " + searchText
                    + ".\nThey are listed on the right: enter the ID of the one to open.", "Customer Management");
            }
        }

        // updated: one UPDATE of the customer row instead of rewriting the whole text file
        private void updateCustomerB_Click(object sender, EventArgs e)
        {
            Customer existing = FindCustomerOnForm();
            if (existing == null)
            {
                return;
            }

            // input and processing
            Customer updated = ReadCustomerFields(existing.CustomerId);
            if (updated == null)
            {
                return;
            }
            RetailDatabase.UpdateCustomer(updated);

            // output
            ShowCustomerDetails(updated);
            ShowCustomers(RetailDatabase.ReadCustomers(), "Total customers: ");
            MessageBox.Show("Customer " + updated.GetFullName() + " updated.", "Customer Management");
        }

        // Refused when the customer has orders (foreign key of the Orders table)
        private void deleteCustomerB_Click(object sender, EventArgs e)
        {
            Customer existing = FindCustomerOnForm();
            if (existing == null)
            {
                return;
            }

            int orderCount = RetailDatabase.CountOrdersOfCustomer(existing.CustomerId);
            if (orderCount > 0)
            {
                MessageBox.Show(existing.GetFullName() + " has " + orderCount + " order(s) and cannot be deleted:\n"
                    + "the order history must stay complete. The customer data can still be updated.",
                    "Customer Management");
                return;
            }

            DialogResult answer = MessageBox.Show("Delete the customer " + existing.CustomerId + ", "
                + existing.GetFullName() + "?", "Customer Management", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            RetailDatabase.DeleteCustomer(existing.CustomerId);

            ClearFields();
            ShowCustomers(RetailDatabase.ReadCustomers(), "Total customers: ");
            MessageBox.Show("Customer " + existing.GetFullName() + " deleted.", "Customer Management");
        }

        // Validates the fields and builds the customer; shows the first problem found and returns null
        private Customer ReadCustomerFields(int customerId)
        {
            String firstName = CleanText(firstNameTB.Text);
            String lastName = CleanText(lastNameTB.Text);
            String address = CleanText(addressTB.Text);
            String email = CleanText(emailTB.Text).ToLower();

            if (firstName == "" || lastName == "" || phoneTB.Text.Trim() == "")
            {
                MessageBox.Show("First name, last name and phone are required.", "Customer Management");
                return null;
            }
            if (!Customer.IsValidName(firstName) || !Customer.IsValidName(lastName))
            {
                MessageBox.Show("First and last name can only contain letters, spaces, hyphens and apostrophes.",
                    "Customer Management");
                return null;
            }
            String phone = Customer.FormatPhone(phoneTB.Text);
            if (phone == "")
            {
                MessageBox.Show("The phone must have 10 digits, for example 514-555-0123.", "Customer Management");
                phoneTB.Focus();
                return null;
            }
            if (email != "" && !Customer.IsValidEmail(email))
            {
                MessageBox.Show("The email is not valid. Example: name@example.com", "Customer Management");
                emailTB.Focus();
                return null;
            }

            // The same name with the same phone is the same person; another name with the phone is a household
            String sharedWith = "";
            foreach (Customer c in RetailDatabase.ReadCustomers())
            {
                if (c.CustomerId != customerId && c.Phone == phone)
                {
                    if (c.FirstName.ToUpper() == firstName.ToUpper() && c.LastName.ToUpper() == lastName.ToUpper())
                    {
                        MessageBox.Show(c.GetFullName() + " is already registered with this phone, customer ID "
                            + c.CustomerId + ".", "Customer Management");
                        return null;
                    }
                    sharedWith = sharedWith + "\n   " + c.CustomerId + "  " + c.GetFullName();
                }
                if (c.CustomerId != customerId && email != "" && c.Email.ToLower() == email)
                {
                    MessageBox.Show("The email " + email + " already belongs to customer " + c.CustomerId
                        + ", " + c.GetFullName() + ".", "Customer Management");
                    return null;
                }
            }
            if (sharedWith != "")
            {
                DialogResult answer = MessageBox.Show("The phone " + phone + " is already used by:" + sharedWith
                    + "\n\nSave it anyway (same household)?", "Customer Management", MessageBoxButtons.YesNo);
                if (answer != DialogResult.Yes)
                {
                    return null;
                }
            }

            return new Customer(customerId, firstName, lastName, address, phone, email);
        }

        // A tab would break the column alignment of the lists and reports, so it is replaced by a space
        private String CleanText(String text)
        {
            return text.Replace("\t", " ").Trim();
        }

        // Update and Delete work on the customer whose ID is on the form
        private Customer FindCustomerOnForm()
        {
            int customerId;
            if (customerIdTB.Text.Trim() == "")
            {
                MessageBox.Show("Search the customer first.", "Customer Management");
                return null;
            }
            if (!int.TryParse(customerIdTB.Text.Trim(), out customerId))
            {
                MessageBox.Show("The customer ID must be a number.", "Customer Management");
                return null;
            }
            Customer customer = RetailDatabase.FindCustomer(customerId);
            if (customer == null)
            {
                MessageBox.Show("No customer has the ID " + customerId + ".", "Customer Management");
            }
            return customer;
        }

        private void ShowCustomerDetails(Customer customer)
        {
            customerIdTB.Text = customer.CustomerId.ToString();
            firstNameTB.Text = customer.FirstName;
            lastNameTB.Text = customer.LastName;
            addressTB.Text = customer.Address;
            phoneTB.Text = customer.Phone;
            emailTB.Text = customer.Email;
        }

        private void ShowCustomers(List<Customer> customers, String totalLabel)
        {
            customersRTB.Text = "";
            customersRTB.AppendText("ID".PadRight(5) + "Last name".PadRight(14) + "First name".PadRight(13)
                + "Phone".PadRight(14) + "Email\n");
            foreach (Customer c in customers)
            {
                customersRTB.AppendText(c.CustomerId.ToString().PadRight(5) + c.LastName.PadRight(14)
                    + c.FirstName.PadRight(13) + c.Phone.PadRight(14) + c.Email + "\n");
            }
            customersRTB.AppendText("\n" + totalLabel + customers.Count);
        }

        private void ClearFields()
        {
            customerIdTB.Text = "";
            firstNameTB.Text = "";
            lastNameTB.Text = "";
            addressTB.Text = "";
            phoneTB.Text = "";
            emailTB.Text = "";
            customerIdTB.Focus();
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            ClearFields();
            ShowCustomers(RetailDatabase.ReadCustomers(), "Total customers: ");
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
