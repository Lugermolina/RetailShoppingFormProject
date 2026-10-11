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

        public String GetFullName()
        {
            return firstName + " " + lastName;
        }
    }
}
