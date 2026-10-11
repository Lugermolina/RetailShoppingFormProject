/*  Text file storage of iteration 1
    Records are stored one per line, fields separated by tabs, in the folder of the executable.
    customers.txt : customerId, firstName, lastName, address, phone, email
    products.txt  : productCode, productName, category, unitPrice, stockQty, minStock
    orders.txt    : orderId, orderDate, customerId, customerName, subtotal, gst, qst, total, method, amountPaid, change
    orderlines.txt: orderId, productCode, productName, quantity, unitPrice, lineTotal
*/
namespace RetailShoppingFormProject
{
    public static class RetailDataFile
    {
        public const String CustomersFile = "customers.txt";
        public const String ProductsFile = "products.txt";
        public const String OrdersFile = "orders.txt";
        public const String OrderLinesFile = "orderlines.txt";

        // Creates a starting catalog the first time the application runs
        public static void CreateSampleProducts()
        {
            if (File.Exists(ProductsFile))
            {
                return;
            }
            List<Product> products = new List<Product>();
            products.Add(new Product("P1001", "Whole Milk 2L", "Groceries", 5.49, 40, 15));
            products.Add(new Product("P1002", "Brown Eggs 12", "Groceries", 4.99, 30, 10));
            products.Add(new Product("P1003", "Sliced Bread", "Groceries", 3.79, 8, 12));
            products.Add(new Product("P2001", "Orange Juice 1.75L", "Beverages", 6.29, 25, 10));
            products.Add(new Product("P2002", "Sparkling Water 12x355ml", "Beverages", 7.99, 18, 8));
            products.Add(new Product("P2003", "Ground Coffee 340g", "Beverages", 11.49, 5, 6));
            products.Add(new Product("P3001", "Dish Soap 740ml", "Household", 3.99, 22, 10));
            products.Add(new Product("P3002", "Paper Towels 6 Rolls", "Household", 9.99, 0, 5));
            products.Add(new Product("P4001", "Toothpaste 100ml", "Personal Care", 2.99, 35, 10));
            products.Add(new Product("P4002", "Shampoo 400ml", "Personal Care", 8.49, 14, 6));
            products.Add(new Product("P5001", "AA Batteries 8 Pack", "Electronics", 12.99, 12, 5));
            products.Add(new Product("P5002", "USB-C Cable 1m", "Electronics", 14.99, 3, 4));
            SaveProducts(products);
        }

        public static List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();
            if (!File.Exists(ProductsFile))
            {
                return products;
            }
            StreamReader productReader = new StreamReader(
                new FileStream(ProductsFile, FileMode.Open, FileAccess.Read));
            String productRecord = productReader.ReadLine();
            String[] productFields;
            while (productRecord != null)
            {
                productFields = productRecord.Split("\t");
                products.Add(new Product(productFields[0], productFields[1], productFields[2],
                    double.Parse(productFields[3]), int.Parse(productFields[4]), int.Parse(productFields[5])));
                productRecord = productReader.ReadLine();
            }
            productReader.Close();
            return products;
        }

        // Rewrites the whole file, used after an update, a removal or a stock change
        public static void SaveProducts(List<Product> products)
        {
            StreamWriter productWriter = new StreamWriter(
                new FileStream(ProductsFile, FileMode.Create, FileAccess.Write));
            foreach (Product p in products)
            {
                productWriter.WriteLine(p.ProductCode + "\t" + p.ProductName + "\t" + p.Category + "\t"
                    + p.UnitPrice.ToString("F2") + "\t" + p.StockQty + "\t" + p.MinStock);
            }
            productWriter.Close();
        }

        public static Product FindProduct(String productCode)
        {
            List<Product> products = ReadProducts();
            foreach (Product p in products)
            {
                if (p.ProductCode.ToUpper() == productCode.ToUpper())
                {
                    return p;
                }
            }
            return null;
        }

        public static List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();
            if (!File.Exists(CustomersFile))
            {
                return customers;
            }
            StreamReader customerReader = new StreamReader(
                new FileStream(CustomersFile, FileMode.Open, FileAccess.Read));
            String customerRecord = customerReader.ReadLine();
            String[] customerFields;
            while (customerRecord != null)
            {
                customerFields = customerRecord.Split("\t");
                customers.Add(new Customer(int.Parse(customerFields[0]), customerFields[1], customerFields[2],
                    customerFields[3], customerFields[4], customerFields[5]));
                customerRecord = customerReader.ReadLine();
            }
            customerReader.Close();
            return customers;
        }

        public static Customer FindCustomer(int customerId)
        {
            List<Customer> customers = ReadCustomers();
            foreach (Customer c in customers)
            {
                if (c.CustomerId == customerId)
                {
                    return c;
                }
            }
            return null;
        }

        public static int NextCustomerId()
        {
            return ReadCustomers().Count + 1;
        }

        public static void AppendCustomer(Customer c)
        {
            StreamWriter customerWriter = new StreamWriter(
                new FileStream(CustomersFile, FileMode.Append, FileAccess.Write));
            customerWriter.WriteLine(c.CustomerId + "\t" + c.FirstName + "\t" + c.LastName + "\t"
                + c.Address + "\t" + c.Phone + "\t" + c.Email);
            customerWriter.Close();
        }

        public static int NextOrderId()
        {
            int count = 0;
            if (File.Exists(OrdersFile))
            {
                StreamReader orderReader = new StreamReader(
                    new FileStream(OrdersFile, FileMode.Open, FileAccess.Read));
                while (orderReader.ReadLine() != null)
                {
                    count = count + 1;
                }
                orderReader.Close();
            }
            return count + 1;
        }

        // Stores the order header, its lines, and reduces the stock of each product sold
        public static void SaveOrder(PurchaseOrder order, Customer customer, Payment payment)
        {
            double total = Math.Round(order.CalculateTotal(), 2);
            StreamWriter orderWriter = new StreamWriter(
                new FileStream(OrdersFile, FileMode.Append, FileAccess.Write));
            orderWriter.WriteLine(order.OrderId + "\t" + order.OrderDate + "\t" + customer.CustomerId + "\t"
                + customer.GetFullName() + "\t" + order.CalculateSubtotal().ToString("F2") + "\t"
                + order.CalculateGST().ToString("F2") + "\t" + order.CalculateQST().ToString("F2") + "\t"
                + total.ToString("F2") + "\t" + payment.Method + "\t" + payment.AmountPaid.ToString("F2") + "\t"
                + payment.CalculateChange(total).ToString("F2"));
            orderWriter.Close();

            StreamWriter lineWriter = new StreamWriter(
                new FileStream(OrderLinesFile, FileMode.Append, FileAccess.Write));
            foreach (OrderLine line in order.OrderLines)
            {
                lineWriter.WriteLine(order.OrderId + "\t" + line.ProductCode + "\t" + line.ProductName + "\t"
                    + line.Quantity + "\t" + line.UnitPrice.ToString("F2") + "\t"
                    + line.CalculateLineTotal().ToString("F2"));
            }
            lineWriter.Close();

            List<Product> products = ReadProducts();
            foreach (OrderLine line in order.OrderLines)
            {
                foreach (Product p in products)
                {
                    if (p.ProductCode == line.ProductCode)
                    {
                        p.StockQty = p.StockQty - line.Quantity;
                    }
                }
            }
            SaveProducts(products);
        }
    }
}
