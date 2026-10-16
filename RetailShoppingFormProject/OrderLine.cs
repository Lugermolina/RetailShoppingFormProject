namespace RetailShoppingFormProject
{
    public class OrderLine
    {
        private String productCode;
        private String productName;
        private int quantity;
        private double unitPrice;
        private bool taxable;

        public OrderLine(String productCode, String productName, int quantity, double unitPrice, bool taxable)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
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

        // new: tax status of the product at the moment of the sale
        public bool Taxable
        {
            get { return taxable; }
            set { taxable = value; }
        }

        // new: "T" marks a taxable line on the cart and the receipt
        public String GetTaxMark()
        {
            if (taxable)
            {
                return "T";
            }
            return "";
        }

        public double CalculateLineTotal()
        {
            return quantity * unitPrice;
        }
    }
}
