/*  Business process 4b: Sales reports of the store manager, iteration 3 (Manager and Admin roles)
    Input(s): period chosen with two calendars (from date, to date)
    Processing: SQL Server selects and groups the orders of the period (detail with control breaks per day,
                summary per category, best sellers, end of day closing per payment method)
    Output(s): the report with header, column headings, subtotals, grand totals and footer,
               a bar chart of the report, and the report saved to a text file on request
*/
namespace RetailShoppingFormProject
{
    public partial class SalesReportForm : Form
    {
        private User loggedUser;
        private String reportName = "";
        private String chartTitle = "";
        private List<String> chartLabels = new List<String>();
        private List<double> chartValues = new List<double>();
        private String chartPrefix = "$";

        public SalesReportForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            this.loggedUser = loggedUser;
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            fromDTP.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            toDTP.Value = DateTime.Now;
        }

        // Range check of the period; returns false after showing the problem
        private bool PeriodIsValid()
        {
            if (fromDTP.Value.Date > toDTP.Value.Date)
            {
                MessageBox.Show("The From date cannot be after the To date.", "Sales Reports");
                fromDTP.Focus();
                return false;
            }
            return true;
        }

        private String PeriodText()
        {
            return "Period: " + fromDTP.Value.ToString("yyyy-MM-dd") + " to " + toDTP.Value.ToString("yyyy-MM-dd");
        }

        private void ShowChart(String title, List<String> labels, List<double> values, String prefix)
        {
            chartTitle = title;
            chartLabels = labels;
            chartValues = values;
            chartPrefix = prefix;
            chartPB.Invalidate();
        }

        // Detail report with a control break on the date: each day has its orders and a subtotal line
        private void salesByDayB_Click(object sender, EventArgs e)
        {
            if (!PeriodIsValid())
            {
                return;
            }

            // processing
            List<String[]> orders = RetailDatabase.FindOrdersBetween(fromDTP.Value, toDTP.Value);
            List<String> dayLabels = new List<String>();
            List<double> dayTotals = new List<double>();
            String currentDay = "";
            int dayOrders = 0;
            double daySubtotal = 0;
            double dayTaxes = 0;
            double dayTotal = 0;
            double subtotalSum = 0;
            double taxSum = 0;
            double totalSum = 0;
            String text = RetailReport.Header("SALES BY DAY (DETAIL REPORT WITH CONTROL BREAKS)", PeriodText(), loggedUser);
            text = text + "Order".PadRight(7) + "Customer".PadRight(22) + "Payment".PadRight(13) + "By".PadRight(10)
                + "Subtotal".PadLeft(11) + "Taxes".PadLeft(10) + "Total".PadLeft(11) + "\n" + RetailReport.Rule('-');

            foreach (String[] order in orders)
            {
                // control break: a new date closes the group of the previous date
                if (order[1] != currentDay)
                {
                    if (currentDay != "")
                    {
                        text = text + DaySubtotal(currentDay, dayOrders, daySubtotal, dayTaxes, dayTotal);
                        dayLabels.Add(currentDay.Substring(5));
                        dayTotals.Add(dayTotal);
                    }
                    currentDay = order[1];
                    dayOrders = 0;
                    daySubtotal = 0;
                    dayTaxes = 0;
                    dayTotal = 0;
                    text = text + "Date: " + currentDay + "\n";
                }
                double subtotal = double.Parse(order[4]);
                double taxes = double.Parse(order[5]) + double.Parse(order[6]);
                double total = double.Parse(order[7]);
                text = text + order[0].PadRight(7) + RetailReport.Fit(order[3], 21).PadRight(22) + order[8].PadRight(13)
                    + RetailReport.Fit(order[11], 9).PadRight(10) + subtotal.ToString("N2").PadLeft(11)
                    + taxes.ToString("N2").PadLeft(10) + total.ToString("N2").PadLeft(11) + "\n";
                dayOrders = dayOrders + 1;
                daySubtotal = daySubtotal + subtotal;
                dayTaxes = dayTaxes + taxes;
                dayTotal = dayTotal + total;
                subtotalSum = subtotalSum + subtotal;
                taxSum = taxSum + taxes;
                totalSum = totalSum + total;
            }
            if (currentDay != "")
            {
                text = text + DaySubtotal(currentDay, dayOrders, daySubtotal, dayTaxes, dayTotal);
                dayLabels.Add(currentDay.Substring(5));
                dayTotals.Add(dayTotal);
            }

            // output: report footer with the grand totals
            text = text + "\nGRAND TOTALS\n"
                + "Days with sales:".PadRight(30) + dayLabels.Count.ToString().PadLeft(14) + "\n"
                + "Orders:".PadRight(30) + orders.Count.ToString().PadLeft(14) + "\n"
                + "Sales before taxes:".PadRight(30) + ("$" + subtotalSum.ToString("N2")).PadLeft(14) + "\n"
                + "Taxes collected (GST + QST):".PadRight(30) + ("$" + taxSum.ToString("N2")).PadLeft(14) + "\n"
                + "Total sales:".PadRight(30) + ("$" + totalSum.ToString("N2")).PadLeft(14) + "\n";
            if (dayLabels.Count > 0)
            {
                text = text + "Average per day with sales:".PadRight(30)
                    + ("$" + (totalSum / dayLabels.Count).ToString("N2")).PadLeft(14) + "\n";
            }
            text = text + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "SalesByDay";

            // the chart shows the last 12 days of the period that have sales
            while (dayLabels.Count > 12)
            {
                dayLabels.RemoveAt(0);
                dayTotals.RemoveAt(0);
            }
            ShowChart("Total sales per day (MM-dd)", dayLabels, dayTotals, "$");
        }

        private String DaySubtotal(String day, int orderCount, double subtotal, double taxes, double total)
        {
            String orderWord = " orders)";
            if (orderCount == 1)
            {
                orderWord = " order)";
            }
            return "".PadRight(52) + "".PadRight(32, '-') + "\n"
                + ("Subtotal " + day + " (" + orderCount + orderWord).PadRight(52)
                + subtotal.ToString("N2").PadLeft(11) + taxes.ToString("N2").PadLeft(10) + total.ToString("N2").PadLeft(11)
                + "\n\n";
        }

        // Summary report: one line per category, with its share of the sales
        private void salesByCategoryB_Click(object sender, EventArgs e)
        {
            if (!PeriodIsValid())
            {
                return;
            }

            // processing: grouping and sums by SQL Server
            List<String[]> rows = RetailDatabase.SalesByCategory(fromDTP.Value, toDTP.Value);
            double salesSum = 0;
            int unitSum = 0;
            foreach (String[] row in rows)
            {
                salesSum = salesSum + double.Parse(row[3]);
                unitSum = unitSum + int.Parse(row[2]);
            }

            // output
            String text = RetailReport.Header("SALES BY CATEGORY (SUMMARY REPORT)", PeriodText(), loggedUser);
            text = text + "Category".PadRight(20) + "Orders".PadLeft(8) + "Units".PadLeft(8)
                + "Sales before taxes".PadLeft(22) + "Share".PadLeft(9) + "\n" + RetailReport.Rule('-');
            List<String> labels = new List<String>();
            List<double> values = new List<double>();
            foreach (String[] row in rows)
            {
                double sales = double.Parse(row[3]);
                double share = 0;
                if (salesSum > 0)
                {
                    share = sales / salesSum * 100;
                }
                text = text + RetailReport.Fit(row[0], 19).PadRight(20) + row[1].PadLeft(8) + row[2].PadLeft(8)
                    + sales.ToString("N2").PadLeft(22) + (share.ToString("N1") + "%").PadLeft(9) + "\n";
                labels.Add(row[0]);
                values.Add(sales);
            }
            if (rows.Count == 0)
            {
                text = text + "No sales in this period.\n";
            }
            text = text + RetailReport.Rule('-')
                + "Total".PadRight(28) + unitSum.ToString().PadLeft(8) + salesSum.ToString("N2").PadLeft(22) + "100.0%".PadLeft(9) + "\n"
                + "An order with products of several categories counts once in each category.\n"
                + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "SalesByCategory";
            ShowChart("Sales before taxes by category", labels, values, "$");
        }

        // Summary report: the ten products with the most units sold in the period
        private void bestSellersB_Click(object sender, EventArgs e)
        {
            if (!PeriodIsValid())
            {
                return;
            }

            // processing
            List<String[]> rows = RetailDatabase.BestSellers(fromDTP.Value, toDTP.Value, 10);

            // output
            String text = RetailReport.Header("BEST SELLERS, TOP 10 BY UNITS SOLD (SUMMARY REPORT)", PeriodText(), loggedUser);
            text = text + "Rank".PadRight(6) + "Code".PadRight(7) + "Product".PadRight(26) + "Category".PadRight(15)
                + "Units".PadLeft(7) + "Sales".PadLeft(12) + "\n" + RetailReport.Rule('-');
            List<String> labels = new List<String>();
            List<double> values = new List<double>();
            int rank = 0;
            foreach (String[] row in rows)
            {
                rank = rank + 1;
                text = text + rank.ToString().PadRight(6) + row[0].PadRight(7) + RetailReport.Fit(row[1], 25).PadRight(26)
                    + RetailReport.Fit(row[2], 14).PadRight(15) + row[3].PadLeft(7)
                    + double.Parse(row[4]).ToString("N2").PadLeft(12) + "\n";
                labels.Add(row[1]);
                values.Add(double.Parse(row[3]));
            }
            if (rows.Count == 0)
            {
                text = text + "No sales in this period.\n";
            }
            text = text + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "BestSellers";
            ShowChart("Units sold, best sellers", labels, values, "");
        }

        // Closing of one day (the To date): totals by payment method and the cash expected in the drawer
        private void endOfDayB_Click(object sender, EventArgs e)
        {
            DateTime day = toDTP.Value.Date;

            // processing
            List<String[]> methods = RetailDatabase.SalesByPaymentMethod(day);
            List<String[]> orders = RetailDatabase.FindOrdersBetween(day, day);
            int orderSum = 0;
            int walkInCount = 0;
            double totalSum = 0;
            double subtotalSum = 0;
            double gstSum = 0;
            double qstSum = 0;
            double cashExpected = 0;
            foreach (String[] order in orders)
            {
                subtotalSum = subtotalSum + double.Parse(order[4]);
                gstSum = gstSum + double.Parse(order[5]);
                qstSum = qstSum + double.Parse(order[6]);
                if (order[2] == Customer.WalkInId.ToString())
                {
                    walkInCount = walkInCount + 1;
                }
            }

            // output
            String text = RetailReport.Header("END OF DAY CLOSING REPORT", "Business day: " + day.ToString("yyyy-MM-dd"), loggedUser);
            text = text + "Payment method".PadRight(18) + "Orders".PadLeft(8) + "Sales".PadLeft(13)
                + "Received".PadLeft(13) + "Change given".PadLeft(15) + "\n" + RetailReport.Rule('-');
            List<String> labels = new List<String>();
            List<double> values = new List<double>();
            foreach (String[] row in methods)
            {
                double sales = double.Parse(row[2]);
                text = text + row[0].PadRight(18) + row[1].PadLeft(8) + sales.ToString("N2").PadLeft(13)
                    + double.Parse(row[3]).ToString("N2").PadLeft(13) + double.Parse(row[4]).ToString("N2").PadLeft(15) + "\n";
                orderSum = orderSum + int.Parse(row[1]);
                totalSum = totalSum + sales;
                if (row[0] == "Cash")
                {
                    cashExpected = sales;
                }
                labels.Add(row[0]);
                values.Add(sales);
            }
            if (methods.Count == 0)
            {
                text = text + "No sales on this day.\n";
            }
            text = text + RetailReport.Rule('-')
                + "Total".PadRight(18) + orderSum.ToString().PadLeft(8) + totalSum.ToString("N2").PadLeft(13) + "\n\n"
                + "Orders of walk in customers:".PadRight(34) + walkInCount.ToString().PadLeft(14) + "\n"
                + "Sales before taxes:".PadRight(34) + ("$" + subtotalSum.ToString("N2")).PadLeft(14) + "\n"
                + "GST collected (5%):".PadRight(34) + ("$" + gstSum.ToString("N2")).PadLeft(14) + "\n"
                + "QST collected (9.975%):".PadRight(34) + ("$" + qstSum.ToString("N2")).PadLeft(14) + "\n"
                + "Cash expected in the drawer:".PadRight(34) + ("$" + cashExpected.ToString("N2")).PadLeft(14) + "\n"
                + "(cash received minus change given, to compare with the count of the drawer)\n"
                + RetailReport.Footer();
            reportRTB.Text = text;
            reportName = "EndOfDay_" + day.ToString("yyyyMMdd");
            ShowChart("Sales by payment method, " + day.ToString("yyyy-MM-dd"), labels, values, "$");
        }

        private void saveReportB_Click(object sender, EventArgs e)
        {
            if (reportRTB.Text == "")
            {
                MessageBox.Show("Show a report first, then save it.", "Sales Reports");
                return;
            }
            RetailReport.SaveToFile(reportRTB.Text, reportName);
        }

        private void chartPB_Paint(object sender, PaintEventArgs e)
        {
            if (chartTitle == "")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawString("The chart of the report appears here.", Font, Brushes.Gray, 10, 10);
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
