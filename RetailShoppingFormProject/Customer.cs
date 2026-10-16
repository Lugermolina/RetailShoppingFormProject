namespace RetailShoppingFormProject
{
    public class Customer
    {
        private int customerId;
        private String firstName;
        private String lastName;
        private String address;
        private String phone;
        private String email;

        public Customer(int customerId, String firstName, String lastName, String address, String phone, String email)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
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

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        // new: an unregistered buyer is stored with the customer ID 0
        public const int WalkInId = 0;

        public static Customer CreateWalkIn()
        {
            return new Customer(WalkInId, "Walk in", "customer", "", "", "");
        }

        public String GetFullName()
        {
            return firstName + " " + lastName;
        }

        // new: a name has letters, spaces, hyphens and apostrophes only (for example Marie-Pier, O'Neil)
        public static bool IsValidName(String name)
        {
            foreach (char ch in name)
            {
                if (!char.IsLetter(ch) && ch != ' ' && ch != '-' && ch != '\'')
                {
                    return false;
                }
            }
            return true;
        }

        // new: keeps the digits of a phone typed with spaces, dashes, dots or parentheses;
        // 10 digits (or 11 starting with 1) are returned as 514-555-0123, anything else returns ""
        public static String FormatPhone(String phone)
        {
            String digits = "";
            foreach (char ch in phone)
            {
                if (char.IsDigit(ch))
                {
                    digits = digits + ch;
                }
                else if (ch != ' ' && ch != '-' && ch != '.' && ch != '(' && ch != ')' && ch != '+')
                {
                    return "";
                }
            }
            if (digits.Length == 11 && digits[0] == '1')
            {
                digits = digits.Substring(1);
            }
            if (digits.Length != 10 || digits[0] == '0' || digits[0] == '1')
            {
                return "";
            }
            return digits.Substring(0, 3) + "-" + digits.Substring(3, 3) + "-" + digits.Substring(6);
        }

        // new: one @ with a name before it, a domain with a dot after it, and no spaces
        public static bool IsValidEmail(String email)
        {
            int at = email.IndexOf('@');
            if (at <= 0 || at != email.LastIndexOf('@') || email.Contains(' '))
            {
                return false;
            }
            String domain = email.Substring(at + 1);
            int dot = domain.LastIndexOf('.');
            return dot > 0 && dot < domain.Length - 2;
        }
    }
}
