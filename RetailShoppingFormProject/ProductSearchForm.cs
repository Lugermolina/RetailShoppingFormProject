/*  Business process 2: Search for a product
    Input(s): part of the product name, category, minimum price, maximum price (each one optional)
    Processing: SQL Server selects the products that match the filters that are filled in;
                the prices are validated first (data type and range checks)
    Output(s): the list of matching products with price, stock and stock status
*/
namespace RetailShoppingFormProject
{
    public partial class ProductSearchForm : Form
    {
        public ProductSearchForm()
        {
            InitializeComponent();
            RetailTheme.Apply(this);
        }

        private void ProductSearchForm_Load(object sender, EventArgs e)
        {
            categoryCB.Items.Add("All");
            foreach (Category c in RetailDatabase.ReadCategories())
            {
                categoryCB.Items.Add(c.CategoryName);
            }
            categoryCB.SelectedIndex = 0;
            ShowProducts(RetailDatabase.ReadProducts());
        }

        private void searchB_Click(object sender, EventArgs e)
        {
            // input
            String nameFilter = productNameTB.Text.Trim();
            String categoryFilter = categoryCB.Text;
            double minPrice = 0;
            double maxPrice = 99999999.99;
            if (minPriceTB.Text.Trim() != "")
            {
                if (!double.TryParse(minPriceTB.Text.Trim(), out minPrice) || minPrice < 0)
                {
                    MessageBox.Show("The minimum price must be a number, zero or more, for example 5 or 4.99.", "Product Search");
                    minPriceTB.Focus();
                    return;
                }
            }
            if (maxPriceTB.Text.Trim() != "")
            {
                if (!double.TryParse(maxPriceTB.Text.Trim(), out maxPrice) || maxPrice < 0)
                {
                    MessageBox.Show("The maximum price must be a number, zero or more, for example 10.", "Product Search");
                    maxPriceTB.Focus();
                    return;
                }
            }
            if (minPrice > maxPrice)
            {
                MessageBox.Show("The minimum price cannot be higher than the maximum price.", "Product Search");
                minPriceTB.Focus();
                return;
            }

            // processing
            List<Product> matches = RetailDatabase.SearchProducts(nameFilter, categoryFilter, minPrice, maxPrice);

            // output
            ShowProducts(matches);
        }

        private void showAllB_Click(object sender, EventArgs e)
        {
            ShowProducts(RetailDatabase.ReadProducts());
        }

        private void ShowProducts(List<Product> products)
        {
            productsRTB.Text = "";
            productsRTB.AppendText("Code".PadRight(8) + "Name".PadRight(28) + "Category".PadRight(16)
                + "Price".PadLeft(10) + "Stock".PadLeft(8) + "   " + "Status".PadRight(14) + "Tax\n");
            foreach (Product p in products)
            {
                productsRTB.AppendText(p.ProductCode.PadRight(8) + p.ProductName.PadRight(28) + p.Category.PadRight(16)
                    + ("$" + p.UnitPrice.ToString("N2")).PadLeft(10) + p.StockQty.ToString().PadLeft(8)
                    + "   " + p.GetStockStatus().PadRight(14) + p.GetTaxLabel() + "\n");
            }
            resultCountL.Text = products.Count + " product(s) found";
            RetailReport.ColorWord(productsRTB, "Out of stock", RetailTheme.StatusRed);
            RetailReport.ColorWord(productsRTB, "Low stock", RetailTheme.StatusAmber);
            RetailReport.ColorWord(productsRTB, "In stock", RetailTheme.StatusGreen);
            productsRTB.SelectionStart = 0;
            productsRTB.ScrollToCaret();
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            productNameTB.Text = "";
            minPriceTB.Text = "";
            maxPriceTB.Text = "";
            categoryCB.SelectedIndex = 0;
            productsRTB.Text = "";
            resultCountL.Text = "";
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
