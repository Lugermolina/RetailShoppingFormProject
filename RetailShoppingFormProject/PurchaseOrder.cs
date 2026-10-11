namespace RetailShoppingFormProject
{
    public class PurchaseOrder
    {
        private int orderId;
        private int customerId;
        private String orderDate;
        private List<OrderLine> orderLines;

        public PurchaseOrder(int orderId, int customerId, String orderDate)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.orderDate = orderDate;
            this.orderLines = new List<OrderLine>();
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

        public List<OrderLine> OrderLines
        {
            get { return orderLines; }
        }

        public void AddLine(OrderLine line)
        {
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

        public double CalculateGST()
        {
            double gst_Rate = 0.05;
            return gst_Rate * CalculateSubtotal();
        }

        public double CalculateQST()
        {
            double qst_Rate = 0.09975;
            return qst_Rate * CalculateSubtotal();
        }

        public double CalculateTotal()
        {
            return CalculateSubtotal() + CalculateGST() + CalculateQST();
        }
    }
}
