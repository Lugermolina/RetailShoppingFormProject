/*  Business process 3: Managing customer purchases
    Input(s): customerId, productCode and quantity for each line, payment method, amount paid
    Processing: line totals, subtotal, GST (5%), QST (9.975%), total and change;
                the order and its lines are stored and the stock of each product is reduced
    Output(s): the lines and totals of the order on the form, the purchase receipt in a modal form
*/
namespace RetailShoppingFormProject
{
    public partial class PurchaseForm : Form
    {
        PurchaseOrder currentOrder;
        Customer currentCustomer;

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            StartNewOrder();
        }

        private void StartNewOrder()
        {
            currentOrder = new PurchaseOrder(RetailDataFile.NextOrderId(), 0, DateTime.Now.ToString("yyyy-MM-dd"));
            currentCustomer = null;
            customerIdTB.Text = "";
            customerNameTB.Text = "";
            productCodeTB.Text = "";
            quantityTB.Text = "";
            amountPaidTB.Text = "";
            paymentMethodCB.SelectedIndex = 0;
            orderInfoL.Text = "Order #" + currentOrder.OrderId + "     Date: " + currentOrder.OrderDate;
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
            int customerId = int.Parse(customerIdTB.Text);
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
            int quantity = int.Parse(quantityTB.Text);

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
            currentOrder.AddLine(new OrderLine(product.ProductCode, product.ProductName, quantity, product.UnitPrice));

            // output
            ShowOrder();
            productCodeTB.Text = "";
            quantityTB.Text = "";
            productCodeTB.Focus();
        }

        private void ShowOrder()
        {
            cartRTB.Text = "";
            cartRTB.AppendText("Code".PadRight(8) + "Name".PadRight(26) + "Qty".PadLeft(5)
                + "Price".PadLeft(10) + "Total".PadLeft(11) + "\n");
            foreach (OrderLine line in currentOrder.OrderLines)
            {
                cartRTB.AppendText(line.ProductCode.PadRight(8) + line.ProductName.PadRight(26)
                    + line.Quantity.ToString().PadLeft(5) + line.UnitPrice.ToString("N2").PadLeft(10)
                    + line.CalculateLineTotal().ToString("N2").PadLeft(11) + "\n");
            }
            subtotalTB.Text = "$" + currentOrder.CalculateSubtotal().ToString("N2");
            gstTB.Text = "$" + currentOrder.CalculateGST().ToString("N2");
            qstTB.Text = "$" + currentOrder.CalculateQST().ToString("N2");
            totalTB.Text = "$" + currentOrder.CalculateTotal().ToString("N2");
        }

        private void completePurchaseB_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Find the customer before completing the purchase.", "Customer Purchase");
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
                amountPaid = double.Parse(amountPaidTB.Text);
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
            ReceiptForm receiptForm = new ReceiptForm(currentOrder, currentCustomer, payment);
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
