namespace RetailShoppingFormProject
{
    public class OrderLine
    {
        private String productCode;
        private String productName;
        private int quantity;
        private double unitPrice;

        public OrderLine(String productCode, String productName, int quantity, double unitPrice)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
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

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public double CalculateLineTotal()
        {
            return quantity * unitPrice;
        }
    }
}
