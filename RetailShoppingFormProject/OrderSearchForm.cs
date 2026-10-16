/*  Business process 5: Search for an order
    Input(s): search type (order number, customer ID or order date) and its value
    Processing: orders.txt and orderlines.txt are read; records from an earlier iteration are completed with default values
    Output(s): the detail of one order, or the list of the orders found with their total
*/
namespace RetailShoppingFormProject
{
    public partial class OrderSearchForm : Form
    {
        public OrderSearchForm()
        {
            InitializeComponent();
        }

        private void OrderSearchForm_Load(object sender, EventArgs e)
        {
            searchByCB.Items.Add("Order number");
            searchByCB.Items.Add("Customer ID");
            searchByCB.Items.Add("Order date");
            searchByCB.SelectedIndex = 0;
        }

        private void searchByCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueTB.Text = "";
            if (searchByCB.SelectedIndex == 0)
            {
                hintL.Text = "Detail of one order, example: 5";
            }
            else if (searchByCB.SelectedIndex == 1)
            {
                hintL.Text = "Orders of a customer, 0 for walk in customers";
            }
            else
            {
                hintL.Text = "Orders of a day, format yyyy-MM-dd, example: 2026-10-13";
            }
        }

        private void searchB_Click(object sender, EventArgs e)
        {
            // input
            String searchText = valueTB.Text.Trim();
            if (searchText == "")
            {
                MessageBox.Show("Enter a value to search.", "Order Search");
                valueTB.Focus();
                return;
            }

            if (searchByCB.SelectedIndex == 0)
            {
                int orderId;
                if (!int.TryParse(searchText, out orderId) || orderId < 1)
                {
                    MessageBox.Show("The order number must be a whole number greater than 0.", "Order Search");
                    valueTB.Focus();
                    return;
                }
                ShowOrder(orderId);
            }
            else if (searchByCB.SelectedIndex == 1)
            {
                int customerId;
                if (!int.TryParse(searchText, out customerId) || customerId < 0)
                {
                    MessageBox.Show("The customer ID must be a whole number, 0 for walk in customers.", "Order Search");
                    valueTB.Focus();
                    return;
                }
                if (customerId == Customer.WalkInId)
                {
                    ShowOrderList(2, customerId.ToString(), "ORDERS OF WALK IN CUSTOMERS");
                }
                else
                {
                    Customer customer = RetailDataFile.FindCustomer(customerId);
                    if (customer == null)
                    {
                        MessageBox.Show("Customer ID " + customerId + " does not exist.", "Order Search");
                        valueTB.Focus();
                        return;
                    }
                    ShowOrderList(2, customerId.ToString(),
                        "ORDERS OF CUSTOMER " + customerId + " (" + customer.GetFullName() + ")");
                }
            }
            else
            {
                DateTime orderDate;
                if (!DateTime.TryParseExact(searchText, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out orderDate))
                {
                    MessageBox.Show("The date must have the format yyyy-MM-dd, for example 2026-10-13.", "Order Search");
                    valueTB.Focus();
                    return;
                }
                ShowOrderList(1, searchText, "ORDERS OF " + searchText);
            }
        }

        private void ShowOrder(int orderId)
        {
            // processing: the order header is searched with a found flag
            List<String[]> orders = RetailDataFile.ReadOrderRecords();
            bool found = false;
            String[] order = new String[12];
            int index = 0;
            while (index < orders.Count && !found)
            {
                if (orders[index][0] == orderId.ToString())
                {
                    found = true;
                    order = orders[index];
                }
                index = index + 1;
            }
            if (!found)
            {
                resultRTB.Text = "";
                resultCountL.Text = "";
                MessageBox.Show("Order #" + orderId + " was not found.", "Order Search");
                return;
            }

            List<String[]> lines = RetailDataFile.ReadOrderLineRecords(orderId);
            double taxableAmount = 0;
            foreach (String[] line in lines)
            {
                if (bool.Parse(line[6]))
                {
                    taxableAmount = taxableAmount + double.Parse(line[5]);
                }
            }
            // a stored -0.00 is shown as 0.00
            double change = double.Parse(order[10]);
            if (change == 0)
            {
                change = 0;
            }

            // output
            String customerText = "Customer: " + order[3];
            if (order[2] != Customer.WalkInId.ToString())
            {
                customerText = customerText + " (ID " + order[2] + ")";
            }
            resultRTB.Text = "";
            resultRTB.AppendText("Order #: " + order[0] + "      Date: " + order[1] + "\n"
                + customerText + "\n"
                + "Processed by: " + order[11] + "\n\n"
                + "Item".PadRight(26) + "Qty".PadLeft(5) + "Price".PadLeft(10) + "Total".PadLeft(11) + "\n"
                + "".PadRight(54, '-') + "\n");
            foreach (String[] line in lines)
            {
                String taxMark = "";
                if (bool.Parse(line[6]))
                {
                    taxMark = "T";
                }
                resultRTB.AppendText(RetailDataFile.Fit(line[2], 25).PadRight(26) + line[3].PadLeft(5)
                    + double.Parse(line[4]).ToString("N2").PadLeft(10)
                    + double.Parse(line[5]).ToString("N2").PadLeft(11) + " " + taxMark + "\n");
            }
            resultRTB.AppendText("".PadRight(54, '-') + "\n"
                + "Subtotal:".PadRight(41) + ("$" + double.Parse(order[4]).ToString("N2")).PadLeft(11) + "\n"
                + "Taxable amount (T):".PadRight(41) + ("$" + taxableAmount.ToString("N2")).PadLeft(11) + "\n"
                + "GST (5%):".PadRight(41) + ("$" + double.Parse(order[5]).ToString("N2")).PadLeft(11) + "\n"
                + "QST (9.975%):".PadRight(41) + ("$" + double.Parse(order[6]).ToString("N2")).PadLeft(11) + "\n"
                + "Total:".PadRight(41) + ("$" + double.Parse(order[7]).ToString("N2")).PadLeft(11) + "\n\n"
                + "Payment method: " + order[8] + "\n"
                + "Amount paid:".PadRight(41) + ("$" + double.Parse(order[9]).ToString("N2")).PadLeft(11) + "\n"
                + "Change:".PadRight(41) + ("$" + change.ToString("N2")).PadLeft(11) + "\n\n"
                + "T = taxable item. Items without T are zero rated.");
            resultCountL.Text = lines.Count + " line(s) in the order";
        }

        // fieldIndex: 1 = order date, 2 = customer ID
        private void ShowOrderList(int fieldIndex, String wanted, String title)
        {
            // processing
            List<String[]> orders = RetailDataFile.ReadOrderRecords();
            int orderCount = 0;
            double totalSum = 0;
            String rows = "";
            foreach (String[] order in orders)
            {
                if (order[fieldIndex] == wanted)
                {
                    rows = rows + order[0].PadRight(7) + order[1].PadRight(12) + RetailDataFile.Fit(order[3], 21).PadRight(22)
                        + order[8].PadRight(13) + double.Parse(order[7]).ToString("N2").PadLeft(11)
                        + "  " + order[11] + "\n";
                    orderCount = orderCount + 1;
                    totalSum = totalSum + double.Parse(order[7]);
                }
            }

            // output
            resultRTB.Text = "";
            if (orderCount == 0)
            {
                resultCountL.Text = "";
                MessageBox.Show("No orders were found for this search.", "Order Search");
                return;
            }
            resultRTB.AppendText(title + "\n\n");
            resultRTB.AppendText("Order".PadRight(7) + "Date".PadRight(12) + "Customer".PadRight(22)
                + "Payment".PadRight(13) + "Total".PadLeft(11) + "  By\n");
            resultRTB.AppendText(rows);
            resultRTB.AppendText("\nNumber of orders: " + orderCount + "\n");
            resultRTB.AppendText("Total: $" + totalSum.ToString("N2"));
            resultCountL.Text = orderCount + " order(s) found";
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            searchByCB.SelectedIndex = 0;
            valueTB.Text = "";
            resultRTB.Text = "";
            resultCountL.Text = "";
            valueTB.Focus();
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
