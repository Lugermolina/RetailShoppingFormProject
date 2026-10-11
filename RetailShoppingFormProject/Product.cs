namespace RetailShoppingFormProject
{
    public class Product
    {
        private String productCode;
        private String productName;
        private String category;
        private double unitPrice;
        private int stockQty;
        private int minStock;

        public Product(String productCode, String productName, String category, double unitPrice, int stockQty, int minStock)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.category = category;
            this.unitPrice = unitPrice;
            this.stockQty = stockQty;
            this.minStock = minStock;
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
