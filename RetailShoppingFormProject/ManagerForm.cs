/*  Business process 4: Store manager follow-up on inventory and sales
    Input(s): product code, name, category, unit price, quantity in stock, minimum stock, taxable or zero rated;
              period of the sales report (from date, to date)
    Processing: add, find, update and remove a product in products.txt;
                stock value, stock status, low-stock shortage, sales totals of the period
    Output(s): inventory report, low-stock list, sales report by period
*/
namespace RetailShoppingFormProject
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            fromDateTB.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
            toDateTB.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        // updated: the fields are validated before the product is built; returns null after showing the problem
        // new: the existing categories are offered in the list; a new category can still be typed
        private void LoadCategories()
        {
            categoryCB.Items.Clear();
            foreach (Product p in RetailDataFile.ReadProducts())
            {
                if (!categoryCB.Items.Contains(p.Category))
                {
                    categoryCB.Items.Add(p.Category);
                }
            }
        }

        private Product ReadProductFields()
        {
            String productCode = productCodeTB.Text.Trim().ToUpper();
            String productName = productNameTB.Text.Trim().Replace("\t", " ");
            String category = categoryCB.Text.Trim().Replace("\t", " ");
            double unitPrice;
            int stockQty;
            int minStock;

            if (productCode == "" || productName == "" || category == "")
            {
                MessageBox.Show("Product code, name and category are required.", "Product Maintenance");
                return null;
            }
            if (!double.TryParse(unitPriceTB.Text.Trim(), out unitPrice) || unitPrice <= 0)
            {
                MessageBox.Show("The unit price must be a number greater than zero, for example 4.99.", "Product Maintenance");
                unitPriceTB.Focus();
                return null;
            }
            if (!int.TryParse(stockQtyTB.Text.Trim(), out stockQty) || stockQty < 0)
            {
                MessageBox.Show("The quantity in stock must be a whole number, zero or more.", "Product Maintenance");
                stockQtyTB.Focus();
                return null;
            }
            if (!int.TryParse(minStockTB.Text.Trim(), out minStock) || minStock < 0)
            {
                MessageBox.Show("The minimum stock must be a whole number, zero or more.", "Product Maintenance");
                minStockTB.Focus();
                return null;
            }
            return new Product(productCode, productName, category, Math.Round(unitPrice, 2), stockQty, minStock,
                taxableCB.Checked);
        }

        private void findProductB_Click(object sender, EventArgs e)
        {
            Product product = RetailDataFile.FindProduct(productCodeTB.Text.Trim());
            if (product == null)
            {
                MessageBox.Show("No product has the code " + productCodeTB.Text + ".", "Product Maintenance");
                return;
            }
            productCodeTB.Text = product.ProductCode;
            productNameTB.Text = product.ProductName;
            categoryCB.Text = product.Category;
            unitPriceTB.Text = product.UnitPrice.ToString("F2");
            stockQtyTB.Text = product.StockQty.ToString();
            minStockTB.Text = product.MinStock.ToString();
            taxableCB.Checked = product.Taxable;
        }

        private void addProductB_Click(object sender, EventArgs e)
        {
            Product newProduct = ReadProductFields();
            if (newProduct == null)
            {
                return;
            }
            if (RetailDataFile.FindProduct(newProduct.ProductCode) != null)
            {
                MessageBox.Show("A product with the code " + newProduct.ProductCode + " already exists.", "Product Maintenance");
                return;
            }
            List<Product> products = RetailDataFile.ReadProducts();
            products.Add(newProduct);
            RetailDataFile.SaveProducts(products);
            LoadCategories();
            MessageBox.Show("Product " + newProduct.ProductCode + " added.", "Product Maintenance");
        }

        private void updateProductB_Click(object sender, EventArgs e)
        {
            Product changedProduct = ReadProductFields();
            if (changedProduct == null)
            {
                return;
            }
            List<Product> products = RetailDataFile.ReadProducts();
            bool found = false;
            foreach (Product p in products)
            {
                if (p.ProductCode == changedProduct.ProductCode)
                {
                    p.ProductName = changedProduct.ProductName;
                    p.Category = changedProduct.Category;
                    p.UnitPrice = changedProduct.UnitPrice;
                    p.StockQty = changedProduct.StockQty;
                    p.MinStock = changedProduct.MinStock;
                    p.Taxable = changedProduct.Taxable;
                    found = true;
                }
            }
            if (!found)
            {
                MessageBox.Show("No product has the code " + changedProduct.ProductCode + ".", "Product Maintenance");
                return;
            }
            RetailDataFile.SaveProducts(products);
            LoadCategories();
            MessageBox.Show("Product " + changedProduct.ProductCode + " updated.", "Product Maintenance");
        }

        private void removeProductB_Click(object sender, EventArgs e)
        {
            String productCode = productCodeTB.Text.Trim().ToUpper();
            Product product = RetailDataFile.FindProduct(productCode);
            if (product == null)
            {
                MessageBox.Show("No product has the code " + productCode + ".", "Product Maintenance");
                return;
            }
            DialogResult answer = MessageBox.Show("Remove " + product.ProductName + " from the catalog?",
                "Product Maintenance", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }
            List<Product> products = RetailDataFile.ReadProducts();
            List<Product> remaining = new List<Product>();
            foreach (Product p in products)
            {
                if (p.ProductCode != product.ProductCode)
                {
                    remaining.Add(p);
                }
            }
            RetailDataFile.SaveProducts(remaining);
            ClearFields();
            MessageBox.Show("Product " + productCode + " removed.", "Product Maintenance");
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            productCodeTB.Text = "";
            productNameTB.Text = "";
            categoryCB.Text = "";
            unitPriceTB.Text = "";
            stockQtyTB.Text = "";
            minStockTB.Text = "";
            taxableCB.Checked = true;
            productCodeTB.Focus();
        }

        private void inventoryReportB_Click(object sender, EventArgs e)
        {
            List<Product> products = RetailDataFile.ReadProducts();
            double totalValue = 0;
            reportRTB.Text = "";
            reportRTB.AppendText("INVENTORY REPORT      " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\n\n");
            reportRTB.AppendText("Code".PadRight(7) + "Name".PadRight(25) + "Price".PadLeft(8) + "Stock".PadLeft(7)
                + "Min".PadLeft(5) + "Value".PadLeft(11) + "  Tax" + "  Status\n");
            foreach (Product p in products)
            {
                reportRTB.AppendText(p.ProductCode.PadRight(7) + p.ProductName.PadRight(25)
                    + p.UnitPrice.ToString("N2").PadLeft(8) + p.StockQty.ToString().PadLeft(7)
                    + p.MinStock.ToString().PadLeft(5) + p.CalculateStockValue().ToString("N2").PadLeft(11)
                    + "  " + p.GetTaxLabel().Substring(0, 1) + "    " + p.GetStockStatus() + "\n");
                totalValue = totalValue + p.CalculateStockValue();
            }
            reportRTB.AppendText("\nProducts: " + products.Count + "\n");
            reportRTB.AppendText("Total stock value: $" + totalValue.ToString("N2") + "\n");
            reportRTB.AppendText("Tax: T = taxable, Z = zero rated");
        }

        private void lowStockB_Click(object sender, EventArgs e)
        {
            List<Product> products = RetailDataFile.ReadProducts();
            int count = 0;
            reportRTB.Text = "";
            reportRTB.AppendText("PRODUCTS BELOW THE MINIMUM STOCK LEVEL      " + DateTime.Now.ToString("yyyy-MM-dd") + "\n\n");
            reportRTB.AppendText("Code".PadRight(7) + "Name".PadRight(25) + "Category".PadRight(15)
                + "Stock".PadLeft(7) + "Min".PadLeft(5) + "Short".PadLeft(7) + "\n");
            foreach (Product p in products)
            {
                if (p.IsBelowMinimum())
                {
                    reportRTB.AppendText(p.ProductCode.PadRight(7) + p.ProductName.PadRight(25) + p.Category.PadRight(15)
                        + p.StockQty.ToString().PadLeft(7) + p.MinStock.ToString().PadLeft(5)
                        + (p.MinStock - p.StockQty).ToString().PadLeft(7) + "\n");
                    count = count + 1;
                }
            }
            reportRTB.AppendText("\nProducts to reorder: " + count);
        }

        private void salesReportB_Click(object sender, EventArgs e)
        {
            // input
            String fromDate = fromDateTB.Text.Trim();
            String toDate = toDateTB.Text.Trim();

            reportRTB.Text = "";
            reportRTB.AppendText("SALES REPORT FROM " + fromDate + " TO " + toDate + "\n\n");
            if (!File.Exists(RetailDataFile.OrdersFile))
            {
                reportRTB.AppendText("No sales have been recorded yet.");
                return;
            }

            // processing: dates are stored as yyyy-MM-dd, so text comparison follows calendar order
            StreamReader orderReader = new StreamReader(
                new FileStream(RetailDataFile.OrdersFile, FileMode.Open, FileAccess.Read));
            String orderRecord = orderReader.ReadLine();
            String[] orderFields;
            int orderCount = 0;
            double subtotalSum = 0;
            double taxSum = 0;
            double totalSum = 0;
            // updated: the By column shows the user who processed the sale (n/a for the orders of iteration 1)
            reportRTB.AppendText("Order".PadRight(7) + "Date".PadRight(12) + "Customer".PadRight(22)
                + "Payment".PadRight(13) + "Total".PadLeft(11) + "  By\n");
            int walkInCount = 0;
            while (orderRecord != null)
            {
                if (orderRecord.Trim() == "")
                {
                    orderRecord = orderReader.ReadLine();
                    continue;
                }
                orderFields = orderRecord.Split("\t");
                String processedBy = "n/a";
                if (orderFields.Length >= 12 && orderFields[11] != "")
                {
                    processedBy = orderFields[11];
                }
                String orderDate = orderFields[1];
                if (String.Compare(orderDate, fromDate) >= 0 && String.Compare(orderDate, toDate) <= 0)
                {
                    reportRTB.AppendText(orderFields[0].PadRight(7) + orderDate.PadRight(12) + orderFields[3].PadRight(22)
                        + orderFields[8].PadRight(13) + double.Parse(orderFields[7]).ToString("N2").PadLeft(11)
                        + "  " + processedBy + "\n");
                    orderCount = orderCount + 1;
                    if (orderFields[2] == Customer.WalkInId.ToString())
                    {
                        walkInCount = walkInCount + 1;
                    }
                    subtotalSum = subtotalSum + double.Parse(orderFields[4]);
                    taxSum = taxSum + double.Parse(orderFields[5]) + double.Parse(orderFields[6]);
                    totalSum = totalSum + double.Parse(orderFields[7]);
                }
                orderRecord = orderReader.ReadLine();
            }
            orderReader.Close();

            // output
            reportRTB.AppendText("\nNumber of orders: " + orderCount + " (walk in customers: " + walkInCount + ")\n");
            reportRTB.AppendText("Sales before taxes: $" + subtotalSum.ToString("N2") + "\n");
            reportRTB.AppendText("Taxes collected (GST + QST): $" + taxSum.ToString("N2") + "\n");
            reportRTB.AppendText("Total sales: $" + totalSum.ToString("N2"));
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
