/*  Text file storage, iteration 2 (the users are in SQL Server, see RetailDatabase)
    Records are stored one per line, fields separated by tabs, in the folder of the executable.
    customers.txt : customerId, firstName, lastName, address, phone, email
    products.txt  : productCode, productName, category, unitPrice, stockQty, minStock, taxable
    orders.txt    : orderId, orderDate, customerId, customerName, subtotal, gst, qst, total, method, amountPaid, change, processedBy
    orderlines.txt: orderId, productCode, productName, quantity, unitPrice, lineTotal, taxable
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
        // updated: basic groceries (milk, eggs, bread, coffee, fruit juice) are zero rated
        public static void CreateSampleProducts()
        {
            if (File.Exists(ProductsFile))
            {
                return;
            }
            List<Product> products = new List<Product>();
            products.Add(new Product("P1001", "Whole Milk 2L", "Groceries", 5.49, 40, 15, false));
            products.Add(new Product("P1002", "Brown Eggs 12", "Groceries", 4.99, 30, 10, false));
            products.Add(new Product("P1003", "Sliced Bread", "Groceries", 3.79, 8, 12, false));
            products.Add(new Product("P2001", "Orange Juice 1.75L", "Beverages", 6.29, 25, 10, false));
            products.Add(new Product("P2002", "Sparkling Water 12x355ml", "Beverages", 7.99, 18, 8, true));
            products.Add(new Product("P2003", "Ground Coffee 340g", "Beverages", 11.49, 5, 6, false));
            products.Add(new Product("P3001", "Dish Soap 740ml", "Household", 3.99, 22, 10, true));
            products.Add(new Product("P3002", "Paper Towels 6 Rolls", "Household", 9.99, 0, 5, true));
            products.Add(new Product("P4001", "Toothpaste 100ml", "Personal Care", 2.99, 35, 10, true));
            products.Add(new Product("P4002", "Shampoo 400ml", "Personal Care", 8.49, 14, 6, true));
            products.Add(new Product("P5001", "AA Batteries 8 Pack", "Electronics", 12.99, 12, 5, true));
            products.Add(new Product("P5002", "USB-C Cable 1m", "Electronics", 14.99, 3, 4, true));
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
                if (productRecord.Trim() != "")
                {
                    productFields = productRecord.Split("\t");

                    // updated: a record without the seventh field comes from iteration 1, when every product was taxable
                    bool taxable = true;
                    if (productFields.Length >= 7)
                    {
                        taxable = bool.Parse(productFields[6]);
                    }
                    products.Add(new Product(productFields[0], productFields[1], productFields[2],
                        double.Parse(productFields[3]), int.Parse(productFields[4]), int.Parse(productFields[5]), taxable));
                }
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
                    + p.UnitPrice.ToString("F2") + "\t" + p.StockQty + "\t" + p.MinStock + "\t" + p.Taxable);
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
                // updated: an empty line in the file is skipped instead of stopping the program
                if (customerRecord.Trim() != "")
                {
                    customerFields = customerRecord.Split("\t");
                    customers.Add(new Customer(int.Parse(customerFields[0]), customerFields[1], customerFields[2],
                        customerFields[3], customerFields[4], customerFields[5]));
                }
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

        // updated: highest ID plus one, so an ID is never reused after a deletion
        public static int NextCustomerId()
        {
            int nextId = 1;
            foreach (Customer c in ReadCustomers())
            {
                if (c.CustomerId >= nextId)
                {
                    nextId = c.CustomerId + 1;
                }
            }
            return nextId;
        }

        public static void AppendCustomer(Customer c)
        {
            StreamWriter customerWriter = new StreamWriter(
                new FileStream(CustomersFile, FileMode.Append, FileAccess.Write));
            customerWriter.WriteLine(c.CustomerId + "\t" + c.FirstName + "\t" + c.LastName + "\t"
                + c.Address + "\t" + c.Phone + "\t" + c.Email);
            customerWriter.Close();
        }

        // new: rewrites the whole file, used after an update or a deletion of a customer
        public static void SaveCustomers(List<Customer> customers)
        {
            StreamWriter customerWriter = new StreamWriter(
                new FileStream(CustomersFile, FileMode.Create, FileAccess.Write));
            foreach (Customer c in customers)
            {
                customerWriter.WriteLine(c.CustomerId + "\t" + c.FirstName + "\t" + c.LastName + "\t"
                    + c.Address + "\t" + c.Phone + "\t" + c.Email);
            }
            customerWriter.Close();
        }

        // new: number of orders of a customer; a customer with orders is kept for the order history
        public static int CountOrdersOfCustomer(int customerId)
        {
            int count = 0;
            if (File.Exists(OrdersFile))
            {
                StreamReader orderReader = new StreamReader(
                    new FileStream(OrdersFile, FileMode.Open, FileAccess.Read));
                String orderRecord = orderReader.ReadLine();
                String[] orderFields;
                while (orderRecord != null)
                {
                    if (orderRecord.Trim() != "")
                    {
                        orderFields = orderRecord.Split("\t");
                        if (orderFields[2] == customerId.ToString())
                        {
                            count = count + 1;
                        }
                    }
                    orderRecord = orderReader.ReadLine();
                }
                orderReader.Close();
            }
            return count;
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

        // new: text cut to the width of a report column so the columns stay aligned
        public static String Fit(String text, int width)
        {
            if (text.Length > width)
            {
                return text.Substring(0, width);
            }
            return text;
        }

        // new: every record of orders.txt as 12 fields; a record from before the processedBy field gets "n/a"
        public static List<String[]> ReadOrderRecords()
        {
            List<String[]> records = new List<String[]>();
            if (!File.Exists(OrdersFile))
            {
                return records;
            }
            StreamReader orderReader = new StreamReader(
                new FileStream(OrdersFile, FileMode.Open, FileAccess.Read));
            String orderRecord = orderReader.ReadLine();
            String[] orderFields;
            while (orderRecord != null)
            {
                if (orderRecord.Trim() != "")
                {
                    orderFields = orderRecord.Split("\t");
                    String[] record = new String[12];
                    for (int i = 0; i < 12; i++)
                    {
                        if (i < orderFields.Length)
                        {
                            record[i] = orderFields[i];
                        }
                        else
                        {
                            record[i] = "";
                        }
                    }
                    if (record[11] == "")
                    {
                        record[11] = "n/a";
                    }
                    records.Add(record);
                }
                orderRecord = orderReader.ReadLine();
            }
            orderReader.Close();
            return records;
        }

        // new: the lines of one order as 7 fields; a line without the taxable field was taxable in iteration 1
        public static List<String[]> ReadOrderLineRecords(int orderId)
        {
            List<String[]> records = new List<String[]>();
            if (!File.Exists(OrderLinesFile))
            {
                return records;
            }
            StreamReader lineReader = new StreamReader(
                new FileStream(OrderLinesFile, FileMode.Open, FileAccess.Read));
            String lineRecord = lineReader.ReadLine();
            String[] lineFields;
            while (lineRecord != null)
            {
                if (lineRecord.Trim() != "")
                {
                    lineFields = lineRecord.Split("\t");
                    if (lineFields[0] == orderId.ToString())
                    {
                        String[] record = new String[7];
                        for (int i = 0; i < 7; i++)
                        {
                            if (i < lineFields.Length)
                            {
                                record[i] = lineFields[i];
                            }
                            else
                            {
                                record[i] = "";
                            }
                        }
                        if (record[6] == "")
                        {
                            record[6] = "True";
                        }
                        records.Add(record);
                    }
                }
                lineRecord = lineReader.ReadLine();
            }
            lineReader.Close();
            return records;
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
                + payment.CalculateChange(total).ToString("F2") + "\t" + order.ProcessedBy);
            orderWriter.Close();

            StreamWriter lineWriter = new StreamWriter(
                new FileStream(OrderLinesFile, FileMode.Append, FileAccess.Write));
            foreach (OrderLine line in order.OrderLines)
            {
                lineWriter.WriteLine(order.OrderId + "\t" + line.ProductCode + "\t" + line.ProductName + "\t"
                    + line.Quantity + "\t" + line.UnitPrice.ToString("F2") + "\t"
                    + line.CalculateLineTotal().ToString("F2") + "\t" + line.Taxable);
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
