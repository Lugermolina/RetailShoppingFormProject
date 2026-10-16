/*  Business process 6: Administration reports (Admin role)
    Input(s): the report chosen with a button
    Processing: orders.txt and customers.txt are read; the orders are added up per customer
    Output(s): all the orders with their totals, or all the customers with their number of orders and amount spent
*/
namespace RetailShoppingFormProject
{
    public partial class AdminReportForm : Form
    {
        public AdminReportForm()
        {
            InitializeComponent();
        }

        private void allOrdersB_Click(object sender, EventArgs e)
        {
            // processing
            List<String[]> orders = RetailDataFile.ReadOrderRecords();
            reportRTB.Text = "";
            reportRTB.AppendText("ALL ORDERS REPORT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\n\n");
            if (orders.Count == 0)
            {
                reportRTB.AppendText("No sales have been recorded yet.");
                return;
            }
            int walkInCount = 0;
            double subtotalSum = 0;
            double taxSum = 0;
            double totalSum = 0;

            // output
            reportRTB.AppendText("Order".PadRight(7) + "Date".PadRight(12) + "ID".PadLeft(4) + "  " + "Customer".PadRight(22)
                + "Payment".PadRight(13) + "Total".PadLeft(11) + "  By\n");
            foreach (String[] order in orders)
            {
                reportRTB.AppendText(order[0].PadRight(7) + order[1].PadRight(12) + order[2].PadLeft(4) + "  "
                    + RetailDataFile.Fit(order[3], 21).PadRight(22) + order[8].PadRight(13)
                    + double.Parse(order[7]).ToString("N2").PadLeft(11) + "  " + order[11] + "\n");
                if (order[2] == Customer.WalkInId.ToString())
                {
                    walkInCount = walkInCount + 1;
                }
                subtotalSum = subtotalSum + double.Parse(order[4]);
                taxSum = taxSum + double.Parse(order[5]) + double.Parse(order[6]);
                totalSum = totalSum + double.Parse(order[7]);
            }
            reportRTB.AppendText("\nNumber of orders: " + orders.Count + " (walk in customers: " + walkInCount + ")\n");
            reportRTB.AppendText("Sales before taxes: $" + subtotalSum.ToString("N2") + "\n");
            reportRTB.AppendText("Taxes collected (GST + QST): $" + taxSum.ToString("N2") + "\n");
            reportRTB.AppendText("Total sales: $" + totalSum.ToString("N2") + "\n");
            reportRTB.AppendText("Average order: $" + (totalSum / orders.Count).ToString("N2"));
        }

        private void allCustomersB_Click(object sender, EventArgs e)
        {
            // processing: the walk in customer (ID 0) is listed first so its sales are included
            List<Customer> customers = RetailDataFile.ReadCustomers();
            int registeredCount = customers.Count;
            customers.Insert(0, Customer.CreateWalkIn());
            List<String[]> orders = RetailDataFile.ReadOrderRecords();
            int customersWithOrders = 0;
            int orderSum = 0;
            double spentSum = 0;

            // output
            reportRTB.Text = "";
            reportRTB.AppendText("ALL CUSTOMERS REPORT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\n\n");
            reportRTB.AppendText("ID".PadLeft(4) + "  " + "Name".PadRight(22) + "Phone".PadRight(14)
                + "Orders".PadLeft(7) + "Spent".PadLeft(12) + "  Email\n");
            foreach (Customer c in customers)
            {
                int orderCount = 0;
                double spent = 0;
                foreach (String[] order in orders)
                {
                    if (order[2] == c.CustomerId.ToString())
                    {
                        orderCount = orderCount + 1;
                        spent = spent + double.Parse(order[7]);
                    }
                }
                reportRTB.AppendText(c.CustomerId.ToString().PadLeft(4) + "  "
                    + RetailDataFile.Fit(c.GetFullName(), 21).PadRight(22) + c.Phone.PadRight(14)
                    + orderCount.ToString().PadLeft(7) + spent.ToString("N2").PadLeft(12) + "  " + c.Email + "\n");
                if (orderCount > 0 && c.CustomerId != Customer.WalkInId)
                {
                    customersWithOrders = customersWithOrders + 1;
                }
                orderSum = orderSum + orderCount;
                spentSum = spentSum + spent;
            }
            reportRTB.AppendText("\nRegistered customers: " + registeredCount + "\n");
            reportRTB.AppendText("Registered customers with at least one order: " + customersWithOrders + "\n");
            reportRTB.AppendText("Orders in total: " + orderSum + "\n");
            reportRTB.AppendText("Amount spent in total: $" + spentSum.ToString("N2") + "\n");
            reportRTB.AppendText("ID 0 groups the sales to walk in customers.");
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
