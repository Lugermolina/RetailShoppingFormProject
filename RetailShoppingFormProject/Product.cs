/*  Product of the catalog, iteration 3: stored in the Products table of RetailShoppingdb,
    linked to its category by categoryId (the category name comes from the Categories table)
*/
namespace RetailShoppingFormProject
{
    public class Product
    {
        private String productCode;
        private String productName;
        private int categoryId;
        private String category;
        private double unitPrice;
        private int stockQty;
        private int minStock;
        private bool taxable;

        // updated: the category ID is stored in the Products table, the category name is read with it
        public Product(String productCode, String productName, int categoryId, String category, double unitPrice,
            int stockQty, int minStock, bool taxable)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.categoryId = categoryId;
            this.category = category;
            this.unitPrice = unitPrice;
            this.stockQty = stockQty;
            this.minStock = minStock;
            this.taxable = taxable;
        }

        public String ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int StockQty
        {
            get { return stockQty; }
            set { stockQty = value; }
        }

        public int MinStock
        {
            get { return minStock; }
            set { minStock = value; }
        }

        // new: false for zero rated products (basic groceries), which pay neither GST nor QST
        public bool Taxable
        {
            get { return taxable; }
            set { taxable = value; }
        }

        public String GetTaxLabel()
        {
            if (taxable)
            {
                return "Taxable";
            }
            return "Zero rated";
        }

        // new: combination check of the code and the category, the code is P, the category digit and three digits
        public static bool IsValidCode(String code, int categoryId)
        {
            if (code.Length != 5 || code[0] != 'P')
            {
                return false;
            }
            for (int i = 1; i < 5; i++)
            {
                if (!char.IsDigit(code[i]))
                {
                    return false;
                }
            }
            return code[1].ToString() == categoryId.ToString();
        }

        public bool IsBelowMinimum()
        {
            return stockQty < minStock;
        }

        public double CalculateStockValue()
        {
            return unitPrice * stockQty;
        }

        public String GetStockStatus()
        {
            if (stockQty == 0)
            {
                return "Out of stock";
            }
            else if (IsBelowMinimum())
            {
                return "Low stock";
            }
            else
            {
                return "In stock";
            }
        }
    }
}
