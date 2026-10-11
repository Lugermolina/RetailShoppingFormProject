namespace RetailShoppingFormProject
{
    public class Payment
    {
        private int orderId;
        private String method;
        private double amountPaid;

        public Payment(int orderId, String method, double amountPaid)
        {
            this.orderId = orderId;
            this.method = method;
            this.amountPaid = amountPaid;
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public String Method
        {
            get { return method; }
            set { method = value; }
        }

        public double AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }

        public double CalculateChange(double totalDue)
        {
            return amountPaid - totalDue;
        }
    }
}
