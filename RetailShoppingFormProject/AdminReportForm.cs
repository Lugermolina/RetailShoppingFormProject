/*  Business process 6: Administration reports (Admin role), iteration 3
    Input(s): the report chosen with a button
    Processing: SQL Server reads and groups the Orders, Payments, OrderLines, Customers and Users tables
    Output(s): detail reports (all orders, all customers), summary reports (sales by cashier, taxes by month),
               exception reports (customers without orders, locked or at risk accounts),
               a bar chart of the report, and the report saved to a text file on request
*/
namespace RetailShoppingFormProject
{
    public partial class AdminReportForm : Form
    {
        private User loggedUser;
        private String reportName = "";
        private String chartTitle = "";
        private List<String> chartLabels = new List<String>();
        private List<double> chartValues = new List<double>();
        private String chartPrefix = "$";

        // updated: receives the logged in user, printed in the report header
        public AdminReportForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            this.loggedUser = loggedUser;
        }

        private void ShowChart(String title, List<String> labels, List<double> values, String prefix)
        {
            chartTitle = title;
            chartLabels = labels;
            chartValues = values;
            chartPrefix = prefix;
            chartPB.Invalidate();
        }

        // Detail report: one line per order
        private void allOrdersB_Click(object sender, EventArgs e)
        {
            // processing
            List<String[]> orders = RetailDatabase.ReadOrderRecords();
            int walkInCount = 0;
            double subtotalSum = 0;
            double taxSum = 0;
            double totalSum = 0;

            // output
            String text = RetailReport.Header("ALL ORDERS (DETAIL REPORT)", "All the orders recorded", loggedUser);
            text = text + "Order".PadRight(7) + "Date".PadRight(12) + "ID".PadLeft(4) + "  " + "Customer".PadRight(22)
                + "Payment".PadRight(13) + "Total".PadLeft(11) + "  By\n" + RetailReport.Rule('-');
            foreach (String[] order in orders)
            {
                text = text + order[0].PadRight(7) + order[1].PadRight(12) + order[2].PadLeft(4) + "  "
                    + RetailReport.Fit(order[3], 21).PadRight(22) + order[8].PadRight(13)
                    + double.Parse(order[7]).ToString("N2").PadLeft(11) + "  " + order[11] + "\n";
                if (order[2] == Customer.WalkInId.ToString())
                {
                    walkInCount = walkInCount + 1;
                }
                subtotalSum = subtotalSum + double.Parse(order[4]);
                taxSum = taxSum + double.Parse(order[5]) + double.Parse(order[6]);
                totalSum = totalSum + double.Parse(order[7]);
            }
            text = text + RetailReport.Rule('-')
                + "Number of orders: " + orders.Count + " (walk in customers: " + walkInCount + ")\n"
                + "Sales before taxes: $" + subtotalSum.ToString("N2") + "\n"
                + "Taxes collected (GST + QST): $" + taxSum.ToString("N2") + "\n"
                + "Total sales: $" + totalSum.ToString("N2") + "\n";
            if (orders.Count > 0)
            {
                text = text + "Average order: $" + (totalSum / orders.Count).ToString("N2") + "\n";
            }
            text = text + "By = user who processed the sale (n/a before the login existed)\n" + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "AllOrders";
            ShowChart("", new List<String>(), new List<double>(), "$");
        }

        // Detail report: one line per customer with the number of orders and the amount spent
        private void allCustomersB_Click(object sender, EventArgs e)
        {
            // processing: the walk in customer (ID 0) is listed first so its sales are included
            List<Customer> customers = RetailDatabase.ReadCustomers();
            int registeredCount = customers.Count;
            customers.Insert(0, Customer.CreateWalkIn());
            List<String[]> orders = RetailDatabase.ReadOrderRecords();
            int customersWithOrders = 0;
            int orderSum = 0;
            double spentSum = 0;
            List<String> labels = new List<String>();
            List<double> values = new List<double>();

            // output
            String text = RetailReport.Header("ALL CUSTOMERS (DETAIL REPORT)", "Registered customers and walk in sales", loggedUser);
            text = text + "ID".PadLeft(4) + "  " + "Name".PadRight(22) + "Phone".PadRight(14)
                + "Orders".PadLeft(7) + "Spent".PadLeft(12) + "  Email\n" + RetailReport.Rule('-');
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
                text = text + c.CustomerId.ToString().PadLeft(4) + "  "
                    + RetailReport.Fit(c.GetFullName(), 21).PadRight(22) + c.Phone.PadRight(14)
                    + orderCount.ToString().PadLeft(7) + spent.ToString("N2").PadLeft(12) + "  " + c.Email + "\n";
                if (orderCount > 0 && c.CustomerId != Customer.WalkInId)
                {
                    customersWithOrders = customersWithOrders + 1;
                }
                if (spent > 0)
                {
                    labels.Add(c.GetFullName());
                    values.Add(spent);
                }
                orderSum = orderSum + orderCount;
                spentSum = spentSum + spent;
            }
            text = text + RetailReport.Rule('-')
                + "Registered customers: " + registeredCount + "\n"
                + "Registered customers with at least one order: " + customersWithOrders + "\n"
                + "Orders in total: " + orderSum + "\n"
                + "Amount spent in total: $" + spentSum.ToString("N2") + "\n"
                + "ID 0 groups the sales to walk in customers.\n" + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "AllCustomers";
            ShowChart("Amount spent by customer", labels, values, "$");
        }

        // Summary report: sales of each staff user (audit trail of the Orders table)
        private void salesByCashierB_Click(object sender, EventArgs e)
        {
            // processing: grouping and sums by SQL Server
            List<String[]> rows = RetailDatabase.SalesByUser();
            String[] withoutUser = RetailDatabase.SalesWithoutUser();
            int orderSum = int.Parse(withoutUser[0]);
            double salesSum = double.Parse(withoutUser[1]);

            // output
            String text = RetailReport.Header("SALES BY STAFF USER (SUMMARY REPORT)", "All the orders recorded", loggedUser);
            text = text + "Username".PadRight(14) + "Name".PadRight(24) + "Role".PadRight(10) + "Orders".PadLeft(8)
                + "Sales".PadLeft(13) + "Average".PadLeft(12) + "\n" + RetailReport.Rule('-');
            List<String> labels = new List<String>();
            List<double> values = new List<double>();
            foreach (String[] row in rows)
            {
                int orders = int.Parse(row[3]);
                double sales = double.Parse(row[4]);
                String average = "";
                if (orders > 0)
                {
                    average = (sales / orders).ToString("N2");
                }
                text = text + RetailReport.Fit(row[0], 13).PadRight(14) + RetailReport.Fit(row[1], 23).PadRight(24)
                    + row[2].PadRight(10) + orders.ToString().PadLeft(8) + sales.ToString("N2").PadLeft(13)
                    + average.PadLeft(12) + "\n";
                orderSum = orderSum + orders;
                salesSum = salesSum + sales;
                labels.Add(row[0]);
                values.Add(sales);
            }
            text = text + "(no user)".PadRight(14) + "Orders before the login".PadRight(34)
                + withoutUser[0].PadLeft(8) + double.Parse(withoutUser[1]).ToString("N2").PadLeft(13) + "\n"
                + RetailReport.Rule('-')
                + "Total".PadRight(48) + orderSum.ToString().PadLeft(8) + salesSum.ToString("N2").PadLeft(13) + "\n"
                + "Users without sales are listed with 0 orders.\n" + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "SalesByUser";
            ShowChart("Total sales by staff user", labels, values, "$");
        }

        // Summary report for the tax returns: GST and QST collected each month
        private void taxesByMonthB_Click(object sender, EventArgs e)
        {
            // processing: grouping by month by SQL Server
            List<String[]> rows = RetailDatabase.TaxesByMonth();
            double subtotalSum = 0;
            double taxableSum = 0;
            double gstSum = 0;
            double qstSum = 0;
            double totalSum = 0;

            // output
            String text = RetailReport.Header("TAXES COLLECTED BY MONTH (SUMMARY REPORT)", "GST 5% and QST 9.975% on the taxable sales", loggedUser);
            text = text + "Month".PadRight(9) + "Orders".PadLeft(7) + "Before tax".PadLeft(12) + "Taxable".PadLeft(11)
                + "Zero rated".PadLeft(12) + "GST".PadLeft(9) + "QST".PadLeft(9) + "Total".PadLeft(12) + "\n"
                + RetailReport.Rule('-');
            List<String> labels = new List<String>();
            List<double> values = new List<double>();
            foreach (String[] row in rows)
            {
                double subtotal = double.Parse(row[2]);
                double taxable = double.Parse(row[3]);
                double gst = double.Parse(row[4]);
                double qst = double.Parse(row[5]);
                double total = double.Parse(row[6]);
                text = text + row[0].PadRight(9) + row[1].PadLeft(7) + subtotal.ToString("N2").PadLeft(12)
                    + taxable.ToString("N2").PadLeft(11) + (subtotal - taxable).ToString("N2").PadLeft(12)
                    + gst.ToString("N2").PadLeft(9) + qst.ToString("N2").PadLeft(9) + total.ToString("N2").PadLeft(12) + "\n";
                subtotalSum = subtotalSum + subtotal;
                taxableSum = taxableSum + taxable;
                gstSum = gstSum + gst;
                qstSum = qstSum + qst;
                totalSum = totalSum + total;
                labels.Add(row[0]);
                values.Add(gst + qst);
            }
            text = text + RetailReport.Rule('-')
                + "Total".PadRight(16) + subtotalSum.ToString("N2").PadLeft(12) + taxableSum.ToString("N2").PadLeft(11)
                + (subtotalSum - taxableSum).ToString("N2").PadLeft(12) + gstSum.ToString("N2").PadLeft(9)
                + qstSum.ToString("N2").PadLeft(9) + totalSum.ToString("N2").PadLeft(12) + "\n"
                + "Zero rated = basic groceries, no GST and no QST.\n"
                + "The orders of iteration 1 were all taxed, before the zero rated products existed.\n"
                + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "TaxesByMonth";
            ShowChart("Taxes collected by month (GST + QST)", labels, values, "$");
        }

        // Exception report: only the registered customers who never bought anything
        private void customersWithoutOrdersB_Click(object sender, EventArgs e)
        {
            // processing
            List<Customer> customers = RetailDatabase.CustomersWithoutOrders();

            // output
            String text = RetailReport.Header("CUSTOMERS WITHOUT ORDERS (EXCEPTION REPORT)",
                "Registered customers who never placed an order", loggedUser);
            text = text + "ID".PadLeft(4) + "  " + "Name".PadRight(24) + "Phone".PadRight(14) + "Email\n" + RetailReport.Rule('-');
            foreach (Customer c in customers)
            {
                text = text + c.CustomerId.ToString().PadLeft(4) + "  " + RetailReport.Fit(c.GetFullName(), 23).PadRight(24)
                    + c.Phone.PadRight(14) + c.Email + "\n";
            }
            if (customers.Count == 0)
            {
                text = text + "Every registered customer has at least one order.\n";
            }
            text = text + RetailReport.Rule('-') + "Customers to contact: " + customers.Count + "\n" + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "CustomersWithoutOrders";
            ShowChart("", new List<String>(), new List<double>(), "$");
        }

        // Exception report: accounts that are locked or have failed login attempts
        private void lockedAccountsB_Click(object sender, EventArgs e)
        {
            // processing
            List<User> users = RetailDatabase.ReadUsers();
            int count = 0;

            // output
            String text = RetailReport.Header("LOCKED AND AT RISK ACCOUNTS (EXCEPTION REPORT)",
                "Accounts locked, or with failed login attempts", loggedUser);
            text = text + "ID".PadLeft(4) + "  " + "Username".PadRight(16) + "Name".PadRight(24) + "Role".PadRight(10)
                + "Status".PadRight(9) + "Failed".PadLeft(7) + "\n" + RetailReport.Rule('-');
            foreach (User u in users)
            {
                if (u.Locked || u.FailedAttempts > 0)
                {
                    text = text + u.UserId.ToString().PadLeft(4) + "  " + RetailReport.Fit(u.Username, 15).PadRight(16)
                        + RetailReport.Fit(u.GetFullName(), 23).PadRight(24) + u.Role.PadRight(10) + u.GetStatus().PadRight(9)
                        + u.FailedAttempts.ToString().PadLeft(7) + "\n";
                    count = count + 1;
                }
            }
            if (count == 0)
            {
                text = text + "No account is locked or has failed attempts.\n";
            }
            text = text + RetailReport.Rule('-') + "Accounts listed: " + count + " of " + users.Count + "\n"
                + "A locked account is unlocked in Administration > User Management.\n" + RetailReport.Footer();
            reportRTB.Text = text;
            RetailReport.ColorWord(reportRTB, "Locked", RetailTheme.StatusRed);
            RetailReport.ColorWord(reportRTB, "Active", RetailTheme.StatusAmber);
            reportName = "LockedAccounts";
            ShowChart("", new List<String>(), new List<double>(), "$");
        }

        private void saveReportB_Click(object sender, EventArgs e)
        {
            if (reportRTB.Text == "")
            {
                MessageBox.Show("Show a report first, then save it.", "Administration Reports");
                return;
            }
            RetailReport.SaveToFile(reportRTB.Text, reportName);
        }

        private void chartPB_Paint(object sender, PaintEventArgs e)
        {
            if (chartTitle == "")
            {
                String message = "The chart of the report appears here.";
                if (reportName != "")
                {
                    message = "This report has no chart.";
                }
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawString(message, Font, Brushes.Gray, 10, 10);
                return;
            }
            RetailReport.DrawBarChart(e.Graphics, chartPB.ClientRectangle, chartTitle, chartLabels, chartValues, chartPrefix);
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
