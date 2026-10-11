/*  Staff user of the Retail Shopping System, iteration 2
    Each user logs in with a username and a password and has one role:
    Cashier : sales, product search, order search and customer management
    Manager : Cashier access plus inventory and the manager reports
    Admin   : full access, including user management and the admin reports
    Users are stored in the Users table of the SQL Server database RetailShoppingdb.
    After three failed login attempts the account is locked until an administrator unlocks it.
*/
using System.Security.Cryptography;
using System.Text;

namespace RetailShoppingFormProject
{
    public class User
    {
        private int userId;
        private String username;
        private String passwordHash;
        private String firstName;
        private String lastName;
        private String role;
        private int failedAttempts;
        private bool locked;

        public const int MaxFailedAttempts = 3;

        public User(int userId, String username, String passwordHash, String firstName, String lastName, String role,
            int failedAttempts, bool locked)
        {
            this.userId = userId;
            this.username = username;
            this.passwordHash = passwordHash;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.failedAttempts = failedAttempts;
            this.locked = locked;
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String Role
        {
            get { return role; }
            set { role = value; }
        }

        public int FailedAttempts
        {
            get { return failedAttempts; }
            set { failedAttempts = value; }
        }

        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        // SHA-256 hash in hexadecimal; only the hash is stored, never the password itself
        public static String HashPassword(String password)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hashBytes);
        }

        // The typed password is hashed and compared with the stored hash
        public bool CheckPassword(String typedPassword)
        {
            return HashPassword(typedPassword) == passwordHash;
        }

        // One more failed attempt; the account is locked when it reaches the maximum
        public void RegisterFailedAttempt()
        {
            failedAttempts = failedAttempts + 1;
            if (failedAttempts >= MaxFailedAttempts)
            {
                locked = true;
            }
        }

        public void ResetFailedAttempts()
        {
            failedAttempts = 0;
        }

        public String GetStatus()
        {
            if (locked)
            {
                return "Locked";
            }
            return "Active";
        }

        public bool CanManageInventory()
        {
            return role == "Manager" || role == "Admin";
        }

        public bool IsAdmin()
        {
            return role == "Admin";
        }

        public String GetFullName()
        {
            return firstName + " " + lastName;
        }

        public String GetDisplayName()
        {
            return GetFullName() + " (" + role + ")";
        }
    }
}
