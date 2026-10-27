namespace RetailShoppingFormProject
{
    public partial class ReceiptForm : Form
    {
        // updated: servedBy is the full name of the staff user who processed the sale
        public ReceiptForm(PurchaseOrder order, Customer customer, Payment payment, String servedBy)
        {
            InitializeComponent();
            RetailTheme.Apply(this);

            // processing
            double subtotal = order.CalculateSubtotal();
            double taxableSubtotal = order.CalculateTaxableSubtotal();
            double gst = order.CalculateGST();
            double qst = order.CalculateQST();
            double total = order.CalculateTotal();
            double change = payment.CalculateChange(Math.Round(total, 2));

            // output
            String receipt = "Order #: " + order.OrderId + "      Date: " + order.OrderDate + "\n"
                + CustomerLine(customer) + "\n"
                + "Served by: " + servedBy + "\n\n"
                + "Item".PadRight(26) + "Qty".PadLeft(5) + "Price".PadLeft(10) + "Total".PadLeft(11) + "\n"
                + "".PadRight(54, '-') + "\n";
            // updated: T marks the taxable items; the taxes apply to the taxable amount only
            foreach (OrderLine line in order.OrderLines)
            {
                receipt = receipt + line.ProductName.PadRight(26) + line.Quantity.ToString().PadLeft(5)
                    + line.UnitPrice.ToString("N2").PadLeft(10) + line.CalculateLineTotal().ToString("N2").PadLeft(11)
                    + " " + line.GetTaxMark() + "\n";
            }
            receipt = receipt + "".PadRight(54, '-') + "\n"
                + "Subtotal:".PadRight(41) + ("$" + subtotal.ToString("N2")).PadLeft(11) + "\n"
                + "Taxable amount (T):".PadRight(41) + ("$" + taxableSubtotal.ToString("N2")).PadLeft(11) + "\n"
                + "GST (5%):".PadRight(41) + ("$" + gst.ToString("N2")).PadLeft(11) + "\n"
                + "QST (9.975%):".PadRight(41) + ("$" + qst.ToString("N2")).PadLeft(11) + "\n"
                + "Total:".PadRight(41) + ("$" + total.ToString("N2")).PadLeft(11) + "\n\n"
                + "Payment method: " + payment.Method + "\n"
                + "Amount paid:".PadRight(41) + ("$" + payment.AmountPaid.ToString("N2")).PadLeft(11) + "\n"
                + "Change:".PadRight(41) + ("$" + change.ToString("N2")).PadLeft(11) + "\n\n"
                + "T = taxable item. Items without T are zero rated.";
            receiptContentL.Text = receipt;
            receiptTotalL.Text = "Thank you for your purchase! Total: $" + total.ToString("N2");
        }

        // A walk in customer has no ID to print
        private String CustomerLine(Customer customer)
        {
            if (customer.CustomerId == Customer.WalkInId)
            {
                return "Customer: " + customer.GetFullName();
            }
            return "Customer: " + customer.GetFullName() + " (ID " + customer.CustomerId + ")";
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
