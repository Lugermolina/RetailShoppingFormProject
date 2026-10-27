/*  SQL Server storage of the Retail Shopping System, iteration 3
    Database RetailShoppingdb on localhost, seven tables in third normal form:
    Users      : userid, username, passwordhash, firstname, lastname, role, failedattempts, locked
    Categories : categoryid, categoryname
    Products   : productcode, productname, categoryid, unitprice, stockqty, minstock, taxable
    Customers  : customerid, firstname, lastname, address, phone, email (customer 0 = walk in customer)
    Orders     : orderid, orderdate, customerid, userid, subtotal, gst, qst, total
    Payments   : orderid, method, amountpaid, changegiven (one payment per order)
    OrderLines : orderid, productcode, quantity, unitprice, taxable
    The text files of iteration 2 were converted into these tables by RetailShoppingdb.sql.
*/
using Microsoft.Data.SqlClient;

namespace RetailShoppingFormProject
{
    public static class RetailDatabase
    {
        public const String ConnectionString = "Data Source=localhost;Initial Catalog=RetailShoppingdb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        private const String UserColumns = "userid, username, passwordhash, firstname, lastname, role, failedattempts, locked";

        private const String ProductSelect = "SELECT p.productcode, p.productname, p.categoryid, c.categoryname, p.unitprice, "
            + "p.stockqty, p.minstock, p.taxable FROM Products p JOIN Categories c ON p.categoryid = c.categoryid ";

        private const String CustomerSelect = "SELECT customerid, firstname, lastname, address, phone, email FROM Customers ";

        // The customer name, the payment and the username come from their own tables (3NF)
        private const String OrderSelect = "SELECT o.orderid, o.orderdate, o.customerid, c.firstname + ' ' + c.lastname, "
            + "o.subtotal, o.gst, o.qst, o.total, p.method, p.amountpaid, p.changegiven, ISNULL(u.username, 'n/a') "
            + "FROM Orders o JOIN Customers c ON o.customerid = c.customerid "
            + "JOIN Payments p ON o.orderid = p.orderid "
            + "LEFT JOIN Users u ON o.userid = u.userid ";

        // ---------- Users ----------

        // Builds a User object from the current row of the reader
        private static User ReadUserRow(SqlDataReader reader)
        {
            return new User((int)reader.GetValue(0), (String)reader.GetValue(1), (String)reader.GetValue(2),
                (String)reader.GetValue(3), (String)reader.GetValue(4), (String)reader.GetValue(5), (int)reader.GetValue(6),
                (bool)reader.GetValue(7));
        }

        public static User FindUserByUsername(String username)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT " + UserColumns + " FROM Users WHERE username = @ParamUsername";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUsername", username);
            SqlDataReader reader = command.ExecuteReader();

            User user = null;
            while (reader.Read())
            {
                user = ReadUserRow(reader);
            }

            connection.Close();
            return user;
        }

        public static User FindUser(int userId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT " + UserColumns + " FROM Users WHERE userid = @ParamUserId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUserId", userId);
            SqlDataReader reader = command.ExecuteReader();

            User user = null;
            while (reader.Read())
            {
                user = ReadUserRow(reader);
            }

            connection.Close();
            return user;
        }

        public static List<User> ReadUsers()
        {
            List<User> users = new List<User>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT " + UserColumns + " FROM Users ORDER BY userid";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(ReadUserRow(reader));
            }

            connection.Close();
            return users;
        }

        public static int NextUserId()
        {
            int nextId = 1;
            foreach (User u in ReadUsers())
            {
                if (u.UserId >= nextId)
                {
                    nextId = u.UserId + 1;
                }
            }
            return nextId;
        }

        public static void AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "INSERT INTO Users (" + UserColumns + ") " +
                         "VALUES (@ParamUserId, @ParamUsername, @ParamPasswordHash, @ParamFirstName, @ParamLastName, @ParamRole, " +
                         "@ParamFailedAttempts, @ParamLocked)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUserId", user.UserId);
            command.Parameters.AddWithValue("@ParamUsername", user.Username);
            command.Parameters.AddWithValue("@ParamPasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@ParamFirstName", user.FirstName);
            command.Parameters.AddWithValue("@ParamLastName", user.LastName);
            command.Parameters.AddWithValue("@ParamRole", user.Role);
            command.Parameters.AddWithValue("@ParamFailedAttempts", user.FailedAttempts);
            command.Parameters.AddWithValue("@ParamLocked", user.Locked);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdateUser(User user)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "UPDATE Users SET username = @ParamUsername, passwordhash = @ParamPasswordHash, " +
                         "firstname = @ParamFirstName, lastname = @ParamLastName, role = @ParamRole, failedattempts = @ParamFailedAttempts, " +
                         "locked = @ParamLocked WHERE userid = @ParamUserId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUsername", user.Username);
            command.Parameters.AddWithValue("@ParamPasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@ParamFirstName", user.FirstName);
            command.Parameters.AddWithValue("@ParamLastName", user.LastName);
            command.Parameters.AddWithValue("@ParamRole", user.Role);
            command.Parameters.AddWithValue("@ParamFailedAttempts", user.FailedAttempts);
            command.Parameters.AddWithValue("@ParamLocked", user.Locked);
            command.Parameters.AddWithValue("@ParamUserId", user.UserId);
            command.ExecuteNonQuery();

            connection.Close();
        }

        // Stores only the login counters, after a failed or a successful login
        public static void UpdateLoginStatus(User user)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "UPDATE Users SET failedattempts = @ParamFailedAttempts, locked = @ParamLocked " +
                         "WHERE userid = @ParamUserId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamFailedAttempts", user.FailedAttempts);
            command.Parameters.AddWithValue("@ParamLocked", user.Locked);
            command.Parameters.AddWithValue("@ParamUserId", user.UserId);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteUser(int userId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "DELETE FROM Users WHERE userid = @ParamUserId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUserId", userId);
            command.ExecuteNonQuery();

            connection.Close();
        }

        // new: a user who processed orders is kept for the audit trail (foreign key of Orders)
        public static int CountOrdersOfUser(int userId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT COUNT(*) FROM Orders WHERE userid = @ParamUserId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamUserId", userId);
            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = (int)reader.GetValue(0);
            }

            connection.Close();
            return count;
        }

        // ---------- Categories ----------

        public static List<Category> ReadCategories()
        {
            List<Category> categories = new List<Category>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT categoryid, categoryname FROM Categories ORDER BY categoryid";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Category((int)reader.GetValue(0), reader.GetValue(1).ToString()));
            }

            connection.Close();
            return categories;
        }

        public static Category FindCategoryByName(String categoryName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT categoryid, categoryname FROM Categories WHERE categoryname = @ParamName";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamName", categoryName);
            SqlDataReader reader = command.ExecuteReader();

            Category category = null;
            while (reader.Read())
            {
                category = new Category((int)reader.GetValue(0), reader.GetValue(1).ToString());
            }

            connection.Close();
            return category;
        }

        public static int NextCategoryId()
        {
            int nextId = 1;
            foreach (Category c in ReadCategories())
            {
                if (c.CategoryId >= nextId)
                {
                    nextId = c.CategoryId + 1;
                }
            }
            return nextId;
        }

        public static void AddCategory(Category category)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "INSERT INTO Categories (categoryid, categoryname) VALUES (@ParamId, @ParamName)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", category.CategoryId);
            command.Parameters.AddWithValue("@ParamName", category.CategoryName);
            command.ExecuteNonQuery();

            connection.Close();
        }

        // ---------- Products ----------

        private static Product ReadProductRow(SqlDataReader reader)
        {
            return new Product(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), (int)reader.GetValue(2),
                reader.GetValue(3).ToString(), double.Parse(reader.GetValue(4).ToString()), (int)reader.GetValue(5),
                (int)reader.GetValue(6), (bool)reader.GetValue(7));
        }

        public static List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = ProductSelect + "ORDER BY p.productcode";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(ReadProductRow(reader));
            }

            connection.Close();
            return products;
        }

        public static Product FindProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = ProductSelect + "WHERE p.productcode = @ParamCode";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamCode", productCode.Trim().ToUpper());
            SqlDataReader reader = command.ExecuteReader();

            Product product = null;
            while (reader.Read())
            {
                product = ReadProductRow(reader);
            }

            connection.Close();
            return product;
        }

        // new: the filters are applied by SQL Server; an empty name matches every product, "All" every category
        public static List<Product> SearchProducts(String namePart, String categoryName, double minPrice, double maxPrice)
        {
            List<Product> products = new List<Product>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = ProductSelect + "WHERE p.productname LIKE @ParamName "
                + "AND (@ParamCategory = 'All' OR c.categoryname = @ParamCategory) "
                + "AND p.unitprice BETWEEN @ParamMin AND @ParamMax ORDER BY p.productcode";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamName", "%" + namePart + "%");
            command.Parameters.AddWithValue("@ParamCategory", categoryName);
            command.Parameters.AddWithValue("@ParamMin", minPrice);
            command.Parameters.AddWithValue("@ParamMax", maxPrice);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(ReadProductRow(reader));
            }

            connection.Close();
            return products;
        }

        public static void AddProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "INSERT INTO Products (productcode, productname, categoryid, unitprice, stockqty, minstock, taxable) "
                + "VALUES (@ParamCode, @ParamName, @ParamCategoryId, @ParamPrice, @ParamStock, @ParamMinStock, @ParamTaxable)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamCode", product.ProductCode);
            command.Parameters.AddWithValue("@ParamName", product.ProductName);
            command.Parameters.AddWithValue("@ParamCategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@ParamPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@ParamStock", product.StockQty);
            command.Parameters.AddWithValue("@ParamMinStock", product.MinStock);
            command.Parameters.AddWithValue("@ParamTaxable", product.Taxable);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdateProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "UPDATE Products SET productname = @ParamName, categoryid = @ParamCategoryId, unitprice = @ParamPrice, "
                + "stockqty = @ParamStock, minstock = @ParamMinStock, taxable = @ParamTaxable WHERE productcode = @ParamCode";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamName", product.ProductName);
            command.Parameters.AddWithValue("@ParamCategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@ParamPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@ParamStock", product.StockQty);
            command.Parameters.AddWithValue("@ParamMinStock", product.MinStock);
            command.Parameters.AddWithValue("@ParamTaxable", product.Taxable);
            command.Parameters.AddWithValue("@ParamCode", product.ProductCode);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "DELETE FROM Products WHERE productcode = @ParamCode";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamCode", productCode);
            command.ExecuteNonQuery();

            connection.Close();
        }

        // new: a product that appears in order lines is kept so the order history stays complete
        public static int CountSalesOfProduct(String productCode)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT COUNT(*) FROM OrderLines WHERE productcode = @ParamCode";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamCode", productCode);
            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = (int)reader.GetValue(0);
            }

            connection.Close();
            return count;
        }

        // ---------- Customers ----------

        private static Customer ReadCustomerRow(SqlDataReader reader)
        {
            return new Customer((int)reader.GetValue(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),
                reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());
        }

        // Registered customers only: customer 0 (walk in) is not listed
        public static List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = CustomerSelect + "WHERE customerid > 0 ORDER BY customerid";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(ReadCustomerRow(reader));
            }

            connection.Close();
            return customers;
        }

        public static Customer FindCustomer(int customerId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = CustomerSelect + "WHERE customerid = @ParamId AND customerid > 0";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", customerId);
            SqlDataReader reader = command.ExecuteReader();

            Customer customer = null;
            while (reader.Read())
            {
                customer = ReadCustomerRow(reader);
            }

            connection.Close();
            return customer;
        }

        // A phone can be shared by a household, so the search can return several customers
        public static List<Customer> FindCustomersByPhone(String phone)
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = CustomerSelect + "WHERE phone = @ParamPhone AND customerid > 0 ORDER BY customerid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamPhone", phone);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(ReadCustomerRow(reader));
            }

            connection.Close();
            return customers;
        }

        public static List<Customer> FindCustomersByLastName(String lastName)
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = CustomerSelect + "WHERE lastname = @ParamLastName AND customerid > 0 ORDER BY customerid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamLastName", lastName);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(ReadCustomerRow(reader));
            }

            connection.Close();
            return customers;
        }

        // Highest ID plus one, so an ID is never reused after a deletion
        public static int NextCustomerId()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT MAX(customerid) FROM Customers";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            int nextId = 1;
            while (reader.Read())
            {
                nextId = (int)reader.GetValue(0) + 1;
            }

            connection.Close();
            return nextId;
        }

        public static void AddCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "INSERT INTO Customers (customerid, firstname, lastname, address, phone, email) "
                + "VALUES (@ParamId, @ParamFirstName, @ParamLastName, @ParamAddress, @ParamPhone, @ParamEmail)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", customer.CustomerId);
            command.Parameters.AddWithValue("@ParamFirstName", customer.FirstName);
            command.Parameters.AddWithValue("@ParamLastName", customer.LastName);
            command.Parameters.AddWithValue("@ParamAddress", customer.Address);
            command.Parameters.AddWithValue("@ParamPhone", customer.Phone);
            command.Parameters.AddWithValue("@ParamEmail", customer.Email);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdateCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "UPDATE Customers SET firstname = @ParamFirstName, lastname = @ParamLastName, address = @ParamAddress, "
                + "phone = @ParamPhone, email = @ParamEmail WHERE customerid = @ParamId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamFirstName", customer.FirstName);
            command.Parameters.AddWithValue("@ParamLastName", customer.LastName);
            command.Parameters.AddWithValue("@ParamAddress", customer.Address);
            command.Parameters.AddWithValue("@ParamPhone", customer.Phone);
            command.Parameters.AddWithValue("@ParamEmail", customer.Email);
            command.Parameters.AddWithValue("@ParamId", customer.CustomerId);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteCustomer(int customerId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "DELETE FROM Customers WHERE customerid = @ParamId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", customerId);
            command.ExecuteNonQuery();

            connection.Close();
        }

        // A customer with orders is kept for the order history (foreign key of Orders)
        public static int CountOrdersOfCustomer(int customerId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT COUNT(*) FROM Orders WHERE customerid = @ParamId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", customerId);
            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = (int)reader.GetValue(0);
            }

            connection.Close();
            return count;
        }

        // ---------- Orders, payments and order lines ----------

        public static int NextOrderId()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT ISNULL(MAX(orderid), 0) + 1 FROM Orders";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            int nextId = 1;
            while (reader.Read())
            {
                nextId = (int)reader.GetValue(0);
            }

            connection.Close();
            return nextId;
        }

        // Stores the order, its payment and its lines, and reduces the stock of each product sold.
        // All the statements run in one transaction: if one fails (for example the stock was sold meanwhile
        // at another register), none is kept. The order number is taken again inside the transaction
        // because another register can save an order between the start and the end of this sale.
        public static void SaveOrder(PurchaseOrder order, Customer customer, Payment payment, int userId)
        {
            double total = Math.Round(order.CalculateTotal(), 2);

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                String sql = "SELECT ISNULL(MAX(orderid), 0) + 1 FROM Orders WITH (UPDLOCK, HOLDLOCK)";
                SqlCommand command = new SqlCommand(sql, connection, transaction);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order.OrderId = (int)reader.GetValue(0);
                }
                reader.Close();
                payment.OrderId = order.OrderId;

                sql = "INSERT INTO Orders (orderid, orderdate, customerid, userid, subtotal, gst, qst, total) "
                    + "VALUES (@ParamId, @ParamDate, @ParamCustomerId, @ParamUserId, @ParamSubtotal, @ParamGst, @ParamQst, @ParamTotal)";
                command = new SqlCommand(sql, connection, transaction);
                command.Parameters.AddWithValue("@ParamId", order.OrderId);
                command.Parameters.AddWithValue("@ParamDate", DateTime.Parse(order.OrderDate));
                command.Parameters.AddWithValue("@ParamCustomerId", customer.CustomerId);
                command.Parameters.AddWithValue("@ParamUserId", userId);
                command.Parameters.AddWithValue("@ParamSubtotal", Math.Round(order.CalculateSubtotal(), 2));
                command.Parameters.AddWithValue("@ParamGst", Math.Round(order.CalculateGST(), 2));
                command.Parameters.AddWithValue("@ParamQst", Math.Round(order.CalculateQST(), 2));
                command.Parameters.AddWithValue("@ParamTotal", total);
                command.ExecuteNonQuery();

                sql = "INSERT INTO Payments (orderid, method, amountpaid, changegiven) "
                    + "VALUES (@ParamId, @ParamMethod, @ParamPaid, @ParamChange)";
                command = new SqlCommand(sql, connection, transaction);
                command.Parameters.AddWithValue("@ParamId", order.OrderId);
                command.Parameters.AddWithValue("@ParamMethod", payment.Method);
                command.Parameters.AddWithValue("@ParamPaid", Math.Round(payment.AmountPaid, 2));
                command.Parameters.AddWithValue("@ParamChange", Math.Round(payment.CalculateChange(total), 2));
                command.ExecuteNonQuery();

                foreach (OrderLine line in order.OrderLines)
                {
                    sql = "INSERT INTO OrderLines (orderid, productcode, quantity, unitprice, taxable) "
                        + "VALUES (@ParamId, @ParamCode, @ParamQty, @ParamPrice, @ParamTaxable)";
                    command = new SqlCommand(sql, connection, transaction);
                    command.Parameters.AddWithValue("@ParamId", order.OrderId);
                    command.Parameters.AddWithValue("@ParamCode", line.ProductCode);
                    command.Parameters.AddWithValue("@ParamQty", line.Quantity);
                    command.Parameters.AddWithValue("@ParamPrice", line.UnitPrice);
                    command.Parameters.AddWithValue("@ParamTaxable", line.Taxable);
                    command.ExecuteNonQuery();

                    // The stock is reduced only when enough units are left
                    sql = "UPDATE Products SET stockqty = stockqty - @ParamQty "
                        + "WHERE productcode = @ParamCode AND stockqty >= @ParamQty";
                    command = new SqlCommand(sql, connection, transaction);
                    command.Parameters.AddWithValue("@ParamQty", line.Quantity);
                    command.Parameters.AddWithValue("@ParamCode", line.ProductCode);
                    int rowsChanged = command.ExecuteNonQuery();
                    if (rowsChanged == 0)
                    {
                        throw new InvalidOperationException("Insufficient stock for " + line.ProductName
                            + ". The stock changed since the product was added to the order.");
                    }
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
                throw;
            }

            connection.Close();
        }

        // Order record as 12 texts: orderId, orderDate, customerId, customerName, subtotal, gst, qst, total,
        // method, amountPaid, change, processedBy (n/a for the orders recorded before the login existed)
        private static String[] ReadOrderRow(SqlDataReader reader)
        {
            String[] record = new String[12];
            for (int i = 0; i < 12; i++)
            {
                record[i] = reader.GetValue(i).ToString();
            }
            record[1] = ((DateTime)reader.GetValue(1)).ToString("yyyy-MM-dd");
            return record;
        }

        public static List<String[]> ReadOrderRecords()
        {
            List<String[]> records = new List<String[]>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = OrderSelect + "ORDER BY o.orderid";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                records.Add(ReadOrderRow(reader));
            }

            connection.Close();
            return records;
        }

        public static String[] FindOrderRecord(int orderId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = OrderSelect + "WHERE o.orderid = @ParamId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", orderId);
            SqlDataReader reader = command.ExecuteReader();

            String[] record = null;
            while (reader.Read())
            {
                record = ReadOrderRow(reader);
            }

            connection.Close();
            return record;
        }

        public static List<String[]> FindOrdersOfCustomer(int customerId)
        {
            List<String[]> records = new List<String[]>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = OrderSelect + "WHERE o.customerid = @ParamId ORDER BY o.orderid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", customerId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                records.Add(ReadOrderRow(reader));
            }

            connection.Close();
            return records;
        }

        // Orders of a period, sorted by date then order number (used by the reports with a control break per day)
        public static List<String[]> FindOrdersBetween(DateTime fromDate, DateTime toDate)
        {
            List<String[]> records = new List<String[]>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = OrderSelect + "WHERE o.orderdate BETWEEN @ParamFrom AND @ParamTo ORDER BY o.orderdate, o.orderid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamFrom", fromDate.Date);
            command.Parameters.AddWithValue("@ParamTo", toDate.Date);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                records.Add(ReadOrderRow(reader));
            }

            connection.Close();
            return records;
        }

        // Lines of one order as 7 texts: orderId, productCode, productName, quantity, unitPrice, lineTotal, taxable
        public static List<String[]> ReadOrderLineRecords(int orderId)
        {
            List<String[]> records = new List<String[]>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT l.orderid, l.productcode, p.productname, l.quantity, l.unitprice, "
                + "l.quantity * l.unitprice, l.taxable FROM OrderLines l "
                + "JOIN Products p ON l.productcode = p.productcode WHERE l.orderid = @ParamId ORDER BY p.productname";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamId", orderId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String[] record = new String[7];
                for (int i = 0; i < 7; i++)
                {
                    record[i] = reader.GetValue(i).ToString();
                }
                records.Add(record);
            }

            connection.Close();
            return records;
        }

        // ---------- Report queries (grouping and totals computed by SQL Server) ----------

        // Every row of the query as texts, one per column; the caller opens and closes the connection
        private static List<String[]> ReadRows(SqlCommand command, int columnCount)
        {
            List<String[]> rows = new List<String[]>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                String[] row = new String[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    row[i] = reader.GetValue(i).ToString();
                }
                rows.Add(row);
            }
            reader.Close();
            return rows;
        }

        // category, orders, units sold, sales before taxes
        public static List<String[]> SalesByCategory(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT c.categoryname, COUNT(DISTINCT o.orderid), SUM(l.quantity), SUM(l.quantity * l.unitprice) "
                + "FROM OrderLines l JOIN Orders o ON l.orderid = o.orderid "
                + "JOIN Products p ON l.productcode = p.productcode "
                + "JOIN Categories c ON p.categoryid = c.categoryid "
                + "WHERE o.orderdate BETWEEN @ParamFrom AND @ParamTo "
                + "GROUP BY c.categoryname ORDER BY SUM(l.quantity * l.unitprice) DESC";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamFrom", fromDate.Date);
            command.Parameters.AddWithValue("@ParamTo", toDate.Date);
            List<String[]> rows = ReadRows(command, 4);

            connection.Close();
            return rows;
        }

        // product code, name, category, units sold, sales before taxes, for the best sellers of the period
        public static List<String[]> BestSellers(DateTime fromDate, DateTime toDate, int howMany)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT TOP (@ParamTop) p.productcode, p.productname, c.categoryname, SUM(l.quantity), "
                + "SUM(l.quantity * l.unitprice) FROM OrderLines l JOIN Orders o ON l.orderid = o.orderid "
                + "JOIN Products p ON l.productcode = p.productcode "
                + "JOIN Categories c ON p.categoryid = c.categoryid "
                + "WHERE o.orderdate BETWEEN @ParamFrom AND @ParamTo "
                + "GROUP BY p.productcode, p.productname, c.categoryname "
                + "ORDER BY SUM(l.quantity) DESC, SUM(l.quantity * l.unitprice) DESC";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamTop", howMany);
            command.Parameters.AddWithValue("@ParamFrom", fromDate.Date);
            command.Parameters.AddWithValue("@ParamTo", toDate.Date);
            List<String[]> rows = ReadRows(command, 5);

            connection.Close();
            return rows;
        }

        // payment method, orders, total sales, amount received, change given, for the closing of one day
        public static List<String[]> SalesByPaymentMethod(DateTime day)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT p.method, COUNT(*), SUM(o.total), SUM(p.amountpaid), SUM(p.changegiven) "
                + "FROM Orders o JOIN Payments p ON o.orderid = p.orderid WHERE o.orderdate = @ParamDay "
                + "GROUP BY p.method ORDER BY p.method";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ParamDay", day.Date);
            List<String[]> rows = ReadRows(command, 5);

            connection.Close();
            return rows;
        }

        // username, full name, role, orders, total sales; every user is listed, even without sales
        public static List<String[]> SalesByUser()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT u.username, u.firstname + ' ' + u.lastname, u.role, COUNT(o.orderid), ISNULL(SUM(o.total), 0) "
                + "FROM Users u LEFT JOIN Orders o ON o.userid = u.userid "
                + "GROUP BY u.username, u.firstname, u.lastname, u.role ORDER BY ISNULL(SUM(o.total), 0) DESC, u.username";
            SqlCommand command = new SqlCommand(sql, connection);
            List<String[]> rows = ReadRows(command, 5);

            connection.Close();
            return rows;
        }

        // orders and total sales recorded before the login existed (no user)
        public static String[] SalesWithoutUser()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = "SELECT COUNT(*), ISNULL(SUM(total), 0) FROM Orders WHERE userid IS NULL";
            SqlCommand command = new SqlCommand(sql, connection);
            List<String[]> rows = ReadRows(command, 2);

            connection.Close();
            return rows[0];
        }

        // month (yyyy-MM), orders, sales before taxes, taxable sales, GST, QST, total
        public static List<String[]> TaxesByMonth()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            // t holds the taxable amount of each order, the sum of its taxable lines
            String sql = "SELECT CONVERT(CHAR(7), o.orderdate, 120), COUNT(*), SUM(o.subtotal), SUM(t.taxablesales), "
                + "SUM(o.gst), SUM(o.qst), SUM(o.total) FROM Orders o "
                + "JOIN (SELECT orderid, SUM(CASE WHEN taxable = 1 THEN quantity * unitprice ELSE 0 END) AS taxablesales "
                + "FROM OrderLines GROUP BY orderid) t ON o.orderid = t.orderid "
                + "GROUP BY CONVERT(CHAR(7), o.orderdate, 120) ORDER BY CONVERT(CHAR(7), o.orderdate, 120)";
            SqlCommand command = new SqlCommand(sql, connection);
            List<String[]> rows = ReadRows(command, 7);

            connection.Close();
            return rows;
        }

        // exception report: registered customers who never placed an order
        public static List<Customer> CustomersWithoutOrders()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String sql = CustomerSelect + "WHERE customerid > 0 AND customerid NOT IN (SELECT customerid FROM Orders) "
                + "ORDER BY lastname, firstname";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(ReadCustomerRow(reader));
            }

            connection.Close();
            return customers;
        }
    }
}
