namespace RetailShoppingFormProject
{
    public class PurchaseOrder
    {
        private int orderId;
        private int customerId;
        private String orderDate;
        private List<OrderLine> orderLines;
        private String processedBy;

        public PurchaseOrder(int orderId, int customerId, String orderDate)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.orderDate = orderDate;
            this.orderLines = new List<OrderLine>();
            this.processedBy = "";
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public String OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        // new: username of the staff user who processed the sale (audit trail)
        public String ProcessedBy
        {
            get { return processedBy; }
            set { processedBy = value; }
        }

        public List<OrderLine> OrderLines
        {
            get { return orderLines; }
        }

        // updated: a product already in the order gets the added quantity on its line, so each product
        // appears once per order, as the primary key (orderid, productcode) of OrderLines requires
        public void AddLine(OrderLine line)
        {
            foreach (OrderLine existing in orderLines)
            {
                if (existing.ProductCode == line.ProductCode)
                {
                    existing.Quantity = existing.Quantity + line.Quantity;
                    return;
                }
            }
            orderLines.Add(line);
        }

        // Quantity of a product already in the order, used to check stock before adding the same product again
        public int GetQuantityOfProduct(String productCode)
        {
            int total = 0;
            foreach (OrderLine line in orderLines)
            {
                if (line.ProductCode == productCode)
                {
                    total = total + line.Quantity;
                }
            }
            return total;
        }

        public double CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (OrderLine line in orderLines)
            {
                subtotal = subtotal + line.CalculateLineTotal();
            }
            return subtotal;
        }

        // new: sum of the taxable lines only; zero rated lines pay no GST and no QST
        public double CalculateTaxableSubtotal()
        {
            double taxableSubtotal = 0;
            foreach (OrderLine line in orderLines)
            {
                if (line.Taxable)
                {
                    taxableSubtotal = taxableSubtotal + line.CalculateLineTotal();
                }
            }
            return taxableSubtotal;
        }

        // updated: the taxes apply to the taxable subtotal
        public double CalculateGST()
        {
            double gst_Rate = 0.05;
            return gst_Rate * CalculateTaxableSubtotal();
        }

        public double CalculateQST()
        {
            double qst_Rate = 0.09975;
            return qst_Rate * CalculateTaxableSubtotal();
        }

        public double CalculateTotal()
        {
            return CalculateSubtotal() + CalculateGST() + CalculateQST();
        }
    }
}
