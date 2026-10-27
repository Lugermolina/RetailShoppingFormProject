/*  Business process 4: Store manager follow-up on inventory and sales, iteration 3
    Input(s): product code, name, category, unit price, quantity in stock, minimum stock, taxable or zero rated;
    Processing: add, find, update and remove a product in the Products table of SQL Server;
                the category comes from the Categories table, a new category can be added;
                the product code must match its category (P, the category digit, three digits);
                a product that was sold cannot be removed (foreign key of OrderLines);
                stock value, stock status, low-stock shortage
    Output(s): inventory report (detail) and low-stock list (exception), with the status in red, amber or green,
               saved to a text file on request; the sales reports are in SalesReportForm
*/
namespace RetailShoppingFormProject
{
    public partial class ManagerForm : Form
    {
        private ToolTip tips = new ToolTip();

        private User loggedUser;
        private String reportName = "";

        // updated: receives the logged in user, printed in the report header
        public ManagerForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            // new: help text shown when the mouse stays over a control
            tips.SetToolTip(productCodeTB, "P, the category digit and three digits, for example P1007 for Groceries");
            tips.SetToolTip(taxableCB, "Uncheck for the zero rated basic groceries (no GST, no QST)");
            tips.SetToolTip(removeProductB, "A product that was sold cannot be removed: set its stock to 0");
            this.loggedUser = loggedUser;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        // The categories of the Categories table are offered in the list; a new category can still be typed
        private void LoadCategories()
        {
            categoryCB.Items.Clear();
            foreach (Category c in RetailDatabase.ReadCategories())
            {
                categoryCB.Items.Add(c.CategoryName);
            }
        }

        // Validates the fields before the product is built; returns null after showing the problem.
        // A category that does not exist yet is added after a confirmation, with the next category ID.
        private Product ReadProductFields()
        {
            String productCode = productCodeTB.Text.Trim().ToUpper();
            String productName = productNameTB.Text.Trim().Replace("\t", " ");
            String categoryName = categoryCB.Text.Trim().Replace("\t", " ");
            double unitPrice;
            int stockQty;
            int minStock;

            if (productCode == "" || productName == "" || categoryName == "")
            {
                MessageBox.Show("Product code, name and category are required.", "Product Maintenance");
                return null;
            }

            Category category = RetailDatabase.FindCategoryByName(categoryName);
            bool newCategory = false;
            if (category == null)
            {
                int nextCategoryId = RetailDatabase.NextCategoryId();
                if (nextCategoryId > 9)
                {
                    MessageBox.Show("No more categories can be added: the product codes have one digit for the category.",
                        "Product Maintenance");
                    return null;
                }
                category = new Category(nextCategoryId, categoryName);
                newCategory = true;
            }

            if (!Product.IsValidCode(productCode, category.CategoryId))
            {
                MessageBox.Show("The product code must be P, the category digit and three digits.\n"
                    + "For the category " + category.CategoryName + ": " + category.GetCodeBlock()
                    + ", for example P" + category.CategoryId + "001.", "Product Maintenance");
                productCodeTB.Focus();
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

            if (newCategory)
            {
                DialogResult answer = MessageBox.Show("The category " + categoryName + " does not exist.\n"
                    + "Add it as category " + category.CategoryId + " (codes " + category.GetCodeBlock() + ")?",
                    "Product Maintenance", MessageBoxButtons.YesNo);
                if (answer != DialogResult.Yes)
                {
                    return null;
                }
                RetailDatabase.AddCategory(category);
            }

            return new Product(productCode, productName, category.CategoryId, category.CategoryName,
                Math.Round(unitPrice, 2), stockQty, minStock, taxableCB.Checked);
        }

        private void findProductB_Click(object sender, EventArgs e)
        {
            Product product = RetailDatabase.FindProduct(productCodeTB.Text.Trim());
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
            if (RetailDatabase.FindProduct(productCodeTB.Text.Trim()) != null)
            {
                MessageBox.Show("A product with the code " + productCodeTB.Text.Trim().ToUpper() + " already exists.",
                    "Product Maintenance");
                return;
            }
            Product newProduct = ReadProductFields();
            if (newProduct == null)
            {
                return;
            }
            RetailDatabase.AddProduct(newProduct);
            LoadCategories();
            MessageBox.Show("Product " + newProduct.ProductCode + " added.", "Product Maintenance");
        }

        private void updateProductB_Click(object sender, EventArgs e)
        {
            if (RetailDatabase.FindProduct(productCodeTB.Text.Trim()) == null)
            {
                MessageBox.Show("No product has the code " + productCodeTB.Text.Trim().ToUpper() + ".", "Product Maintenance");
                return;
            }
            Product changedProduct = ReadProductFields();
            if (changedProduct == null)
            {
                return;
            }
            RetailDatabase.UpdateProduct(changedProduct);
            LoadCategories();
            MessageBox.Show("Product " + changedProduct.ProductCode + " updated.", "Product Maintenance");
        }

        private void removeProductB_Click(object sender, EventArgs e)
        {
            String productCode = productCodeTB.Text.Trim().ToUpper();
            Product product = RetailDatabase.FindProduct(productCode);
            if (product == null)
            {
                MessageBox.Show("No product has the code " + productCode + ".", "Product Maintenance");
                return;
            }

            // new: the order lines keep the products sold (foreign key of OrderLines)
            int salesCount = RetailDatabase.CountSalesOfProduct(productCode);
            if (salesCount > 0)
            {
                MessageBox.Show(product.ProductName + " appears in " + salesCount + " order line(s) and cannot be removed:\n"
                    + "the order history must stay complete. Set its stock to 0 to stop selling it.", "Product Maintenance");
                return;
            }

            DialogResult answer = MessageBox.Show("Remove " + product.ProductName + " from the catalog?",
                "Product Maintenance", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }
            RetailDatabase.DeleteProduct(productCode);
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

        // Detail report: one line per product with its stock value and status
        private void inventoryReportB_Click(object sender, EventArgs e)
        {
            List<Product> products = RetailDatabase.ReadProducts();
            double totalValue = 0;
            int lowCount = 0;
            int outCount = 0;
            String text = RetailReport.Header("INVENTORY REPORT (DETAIL REPORT)", "All the products of the catalog", loggedUser);
            text = text + "Code".PadRight(7) + "Name".PadRight(25) + "Price".PadLeft(8)
                + "Stock".PadLeft(6) + "Min".PadLeft(5) + "Value".PadLeft(10) + " T " + "Status\n" + RetailReport.Rule('-');
            foreach (Product p in products)
            {
                text = text + p.ProductCode.PadRight(7) + RetailReport.Fit(p.ProductName, 24).PadRight(25)
                    + p.UnitPrice.ToString("N2").PadLeft(8)
                    + p.StockQty.ToString().PadLeft(6) + p.MinStock.ToString().PadLeft(5)
                    + p.CalculateStockValue().ToString("N2").PadLeft(10) + " " + p.GetTaxLabel().Substring(0, 1) + " "
                    + p.GetStockStatus() + "\n";
                totalValue = totalValue + p.CalculateStockValue();
                if (p.StockQty == 0)
                {
                    outCount = outCount + 1;
                }
                else if (p.IsBelowMinimum())
                {
                    lowCount = lowCount + 1;
                }
            }
            text = text + RetailReport.Rule('-')
                + "Products: " + products.Count + " (low stock: " + lowCount + ", out of stock: " + outCount + ")\n"
                + "Total stock value: $" + totalValue.ToString("N2") + "\n"
                + "T: T = taxable, Z = zero rated\n" + RetailReport.Footer();
            reportRTB.Text = text;
            ColorStatus();
            reportName = "Inventory";
        }

        // Exception report: only the products below their minimum stock
        private void lowStockB_Click(object sender, EventArgs e)
        {
            List<Product> products = RetailDatabase.ReadProducts();
            int count = 0;
            int unitsToOrder = 0;
            String text = RetailReport.Header("PRODUCTS BELOW THE MINIMUM STOCK (EXCEPTION REPORT)", "Products to reorder", loggedUser);
            text = text + "Code".PadRight(7) + "Name".PadRight(25) + "Category".PadRight(15)
                + "Stock".PadLeft(7) + "Min".PadLeft(5) + "Short".PadLeft(7) + "  Status\n" + RetailReport.Rule('-');
            foreach (Product p in products)
            {
                if (p.IsBelowMinimum())
                {
                    text = text + p.ProductCode.PadRight(7) + RetailReport.Fit(p.ProductName, 24).PadRight(25)
                        + RetailReport.Fit(p.Category, 14).PadRight(15) + p.StockQty.ToString().PadLeft(7)
                        + p.MinStock.ToString().PadLeft(5) + (p.MinStock - p.StockQty).ToString().PadLeft(7)
                        + "  " + p.GetStockStatus() + "\n";
                    count = count + 1;
                    unitsToOrder = unitsToOrder + p.MinStock - p.StockQty;
                }
            }
            if (count == 0)
            {
                text = text + "Every product is at or above its minimum stock.\n";
            }
            text = text + RetailReport.Rule('-') + "Products to reorder: " + count + "\n"
                + "Units missing to reach the minimum: " + unitsToOrder + "\n" + RetailReport.Footer();
            reportRTB.Text = text;
            ColorStatus();
            reportName = "LowStock";
        }

        // Red = out of stock (stop), amber = low stock (caution), green = in stock (go)
        private void ColorStatus()
        {
            RetailReport.ColorWord(reportRTB, "Out of stock", RetailTheme.StatusRed);
            RetailReport.ColorWord(reportRTB, "Low stock", RetailTheme.StatusAmber);
            RetailReport.ColorWord(reportRTB, "In stock", RetailTheme.StatusGreen);
        }

        private void saveReportB_Click(object sender, EventArgs e)
        {
            if (reportRTB.Text == "")
            {
                MessageBox.Show("Show a report first, then save it.", "Products and Inventory");
                return;
            }
            RetailReport.SaveToFile(reportRTB.Text, reportName);
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
