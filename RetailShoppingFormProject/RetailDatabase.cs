/*  SQL Server storage of iteration 2
    Database RetailShoppingdb, table Users: userid, username, passwordhash, firstname, lastname, role, failedattempts, locked
    The other tables of the system are still text files (see RetailDataFile).
*/
using Microsoft.Data.SqlClient;

namespace RetailShoppingFormProject
{
    public static class RetailDatabase
    {
        public const String ConnectionString = "Data Source=localhost;Initial Catalog=RetailShoppingdb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        private const String UserColumns = "userid, username, passwordhash, firstname, lastname, role, failedattempts, locked";

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
    }
}
