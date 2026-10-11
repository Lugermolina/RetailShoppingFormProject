/*  Business process 2: Search for a product
    Input(s): part of the product name, category, minimum price, maximum price (each one optional)
    Processing: every product of products.txt is compared with the filters that are filled in
    Output(s): the list of matching products with price, stock and stock status
*/
namespace RetailShoppingFormProject
{
    public partial class ProductSearchForm : Form
    {
        public ProductSearchForm()
        {
            InitializeComponent();
        }

        private void ProductSearchForm_Load(object sender, EventArgs e)
        {
            categoryCB.Items.Add("All");
            List<Product> products = RetailDataFile.ReadProducts();
            foreach (Product p in products)
            {
                if (!categoryCB.Items.Contains(p.Category))
                {
                    categoryCB.Items.Add(p.Category);
                }
            }
            categoryCB.SelectedIndex = 0;
            ShowProducts(products);
        }

        private void searchB_Click(object sender, EventArgs e)
        {
            // input
            String nameFilter = productNameTB.Text.Trim().ToLower();
            String categoryFilter = categoryCB.Text;
            double minPrice = 0;
            double maxPrice = double.MaxValue;
            if (minPriceTB.Text.Trim() != "")
            {
                minPrice = double.Parse(minPriceTB.Text);
            }
            if (maxPriceTB.Text.Trim() != "")
            {
                maxPrice = double.Parse(maxPriceTB.Text);
            }

            // processing
            List<Product> matches = new List<Product>();
            foreach (Product p in RetailDataFile.ReadProducts())
            {
                bool nameMatches = nameFilter == "" || p.ProductName.ToLower().Contains(nameFilter);
                bool categoryMatches = categoryFilter == "All" || p.Category == categoryFilter;
                bool priceMatches = p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice;
                if (nameMatches && categoryMatches && priceMatches)
                {
                    matches.Add(p);
                }
            }

            // output
            ShowProducts(matches);
        }

        private void showAllB_Click(object sender, EventArgs e)
        {
            ShowProducts(RetailDataFile.ReadProducts());
        }

        private void ShowProducts(List<Product> products)
        {
            productsRTB.Text = "";
            productsRTB.AppendText("Code".PadRight(8) + "Name".PadRight(28) + "Category".PadRight(16)
                + "Price".PadLeft(10) + "Stock".PadLeft(8) + "   Status\n");
            foreach (Product p in products)
            {
                productsRTB.AppendText(p.ProductCode.PadRight(8) + p.ProductName.PadRight(28) + p.Category.PadRight(16)
                    + ("$" + p.UnitPrice.ToString("N2")).PadLeft(10) + p.StockQty.ToString().PadLeft(8)
                    + "   " + p.GetStockStatus() + "\n");
            }
            resultCountL.Text = products.Count + " product(s) found";
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
