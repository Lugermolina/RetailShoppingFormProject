/*  Business process 3: Managing customer purchases
    Input(s): customerId (or walk in customer), productCode and quantity for each line, payment method, amount paid
    Processing: line totals, subtotal, GST (5%) and QST (9.975%) on the taxable lines only, total and change;
                the order and its lines are stored and the stock of each product is reduced
                the username of the staff user who processed the sale is stored with the order (audit trail)
    Output(s): the lines and totals of the order on the form, the purchase receipt in a modal form
*/
namespace RetailShoppingFormProject
{
    public partial class PurchaseForm : Form
    {
        PurchaseOrder currentOrder;
        Customer currentCustomer;
        private User loggedUser;

        // updated: receives the logged in user, recorded on each order
        public PurchaseForm(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            StartNewOrder();
        }

        private void StartNewOrder()
        {
            currentOrder = new PurchaseOrder(RetailDataFile.NextOrderId(), 0, DateTime.Now.ToString("yyyy-MM-dd"));
            currentOrder.ProcessedBy = loggedUser.Username;
            currentCustomer = null;
            walkInCB.Checked = false;
            customerIdTB.Text = "";
            customerNameTB.Text = "";
            productCodeTB.Text = "";
            quantityTB.Text = "";
            amountPaidTB.Text = "";
            paymentMethodCB.SelectedIndex = 0;
            orderInfoL.Text = "Order #" + currentOrder.OrderId + "     Date: " + currentOrder.OrderDate
                + "     Cashier: " + loggedUser.GetFullName();
            ShowOrder();
            customerIdTB.Focus();
        }

        private void findCustomerB_Click(object sender, EventArgs e)
        {
            if (customerIdTB.Text.Trim() == "")
            {
                MessageBox.Show("Enter the customer ID.", "Customer Purchase");
                return;
            }
            int customerId;
            if (!int.TryParse(customerIdTB.Text.Trim(), out customerId))
            {
                MessageBox.Show("The customer ID must be a number.", "Customer Purchase");
                return;
            }
            Customer customer = RetailDataFile.FindCustomer(customerId);
            if (customer == null)
            {
                MessageBox.Show("No customer is registered with ID " + customerId + ".", "Customer Purchase");
                customerNameTB.Text = "";
                currentCustomer = null;
                return;
            }
            currentCustomer = customer;
            currentOrder.CustomerId = customer.CustomerId;
            customerNameTB.Text = customer.GetFullName();
        }

        // new: a walk in customer buys without registration; the order is saved with the customer ID 0
        private void walkInCB_CheckedChanged(object sender, EventArgs e)
        {
            if (walkInCB.Checked)
            {
                currentCustomer = Customer.CreateWalkIn();
                currentOrder.CustomerId = currentCustomer.CustomerId;
                customerIdTB.Text = "";
                customerNameTB.Text = currentCustomer.GetFullName();
                customerIdTB.Enabled = false;
                findCustomerB.Enabled = false;
                productCodeTB.Focus();
            }
            else
            {
                currentCustomer = null;
                currentOrder.CustomerId = 0;
                customerNameTB.Text = "";
                customerIdTB.Enabled = true;
                findCustomerB.Enabled = true;
            }
        }

        private void productSearchB_Click(object sender, EventArgs e)
        {
            ProductSearchForm productSearchForm = new ProductSearchForm();
            productSearchForm.ShowDialog();
        }

        private void addLineB_Click(object sender, EventArgs e)
        {
            // input
            String productCode = productCodeTB.Text.Trim();
            if (quantityTB.Text.Trim() == "")
            {
                MessageBox.Show("Enter the quantity.", "Customer Purchase");
                return;
            }
            int quantity;
            if (!int.TryParse(quantityTB.Text.Trim(), out quantity))
            {
                MessageBox.Show("The quantity must be a whole number.", "Customer Purchase");
                return;
            }

            // processing
            Product product = RetailDataFile.FindProduct(productCode);
            if (product == null)
            {
                MessageBox.Show("No product has the code " + productCode + ".", "Customer Purchase");
                return;
            }
            if (quantity <= 0)
            {
                MessageBox.Show("The quantity must be greater than zero.", "Customer Purchase");
                return;
            }
            int alreadyInOrder = currentOrder.GetQuantityOfProduct(product.ProductCode);
            if (alreadyInOrder + quantity > product.StockQty)
            {
                MessageBox.Show("Insufficient stock for " + product.ProductName + ".\n"
                    + "In stock: " + product.StockQty + "\n"
                    + "Already in this order: " + alreadyInOrder, "Customer Purchase");
                return;
            }
            currentOrder.AddLine(new OrderLine(product.ProductCode, product.ProductName, quantity, product.UnitPrice,
                product.Taxable));

            // output
            ShowOrder();
            productCodeTB.Text = "";
            quantityTB.Text = "";
            productCodeTB.Focus();
        }

        private void ShowOrder()
        {
            cartRTB.Text = "";
            // updated: the Tax column marks the taxable lines with T
            cartRTB.AppendText("Code".PadRight(8) + "Name".PadRight(26) + "Qty".PadLeft(5)
                + "Price".PadLeft(10) + "Total".PadLeft(11) + "  Tax\n");
            foreach (OrderLine line in currentOrder.OrderLines)
            {
                cartRTB.AppendText(line.ProductCode.PadRight(8) + line.ProductName.PadRight(26)
                    + line.Quantity.ToString().PadLeft(5) + line.UnitPrice.ToString("N2").PadLeft(10)
                    + line.CalculateLineTotal().ToString("N2").PadLeft(11) + "  " + line.GetTaxMark() + "\n");
            }
            cartRTB.AppendText("\nTaxable amount: $" + currentOrder.CalculateTaxableSubtotal().ToString("N2"));
            subtotalTB.Text = "$" + currentOrder.CalculateSubtotal().ToString("N2");
            gstTB.Text = "$" + currentOrder.CalculateGST().ToString("N2");
            qstTB.Text = "$" + currentOrder.CalculateQST().ToString("N2");
            totalTB.Text = "$" + currentOrder.CalculateTotal().ToString("N2");
        }

        private void completePurchaseB_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Find the customer, or check Walk in customer, before completing the purchase.",
                    "Customer Purchase");
                return;
            }
            if (currentOrder.OrderLines.Count == 0)
            {
                MessageBox.Show("Add at least one product to the order.", "Customer Purchase");
                return;
            }

            // input
            double total = Math.Round(currentOrder.CalculateTotal(), 2);
            String method = paymentMethodCB.Text;
            double amountPaid = total;
            if (amountPaidTB.Text.Trim() != "")
            {
                if (!double.TryParse(amountPaidTB.Text.Trim(), out amountPaid))
                {
                    MessageBox.Show("The amount paid must be a number, for example 40 or 40.00.", "Customer Purchase");
                    return;
                }
            }
            if (amountPaid < total)
            {
                MessageBox.Show("The amount paid is lower than the total of $" + total.ToString("N2") + ".",
                    "Customer Purchase");
                return;
            }

            // processing
            Payment payment = new Payment(currentOrder.OrderId, method, amountPaid);
            RetailDataFile.SaveOrder(currentOrder, currentCustomer, payment);

            // output
            ReceiptForm receiptForm = new ReceiptForm(currentOrder, currentCustomer, payment, loggedUser.GetFullName());
            receiptForm.ShowDialog();
            StartNewOrder();
        }

        private void newOrderB_Click(object sender, EventArgs e)
        {
            StartNewOrder();
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
