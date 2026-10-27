/*  User management, iteration 3 (Admin only)
    Input(s): user ID or username, first name, last name, role, password, account locked
    Processing: Add, Search, Update and Delete on the Users table of the SQL Server database;
                the password is stored as a hash; unlocking an account resets its failed attempts
    Output(s): the details of the user on the form and the list of all the users
    Rules: the username is unique; the password has at least 6 characters; the logged in administrator
           cannot lock, delete or change the role of their own account, so one administrator always remains;
           a user who processed orders cannot be deleted (audit trail), the account is locked instead
*/
namespace RetailShoppingFormProject
{
    public partial class UserForm : Form
    {
        private ToolTip tips = new ToolTip();

        private User loggedUser;
        private bool passwordVisible = false;

        public UserForm(User loggedUser)
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            // new: help text shown when the mouse stays over a control
            tips.SetToolTip(lockedCB, "Uncheck to unlock the account; its failed attempts go back to 0");
            tips.SetToolTip(showPasswordPB, "Shows or hides the password");
            this.loggedUser = loggedUser;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            ClearFields();
            ShowUsers();
        }

        private void addUserB_Click(object sender, EventArgs e)
        {
            // input
            String username = usernameTB.Text.Trim();
            String firstName = firstNameTB.Text.Trim();
            String lastName = lastNameTB.Text.Trim();
            String role = roleCB.Text;
            String password = passwordTB.Text;

            if (username == "" || firstName == "" || lastName == "" || password == "")
            {
                MessageBox.Show("Username, first name, last name and password are required.", "User Management");
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("The password must have at least 6 characters.", "User Management");
                return;
            }
            if (RetailDatabase.FindUserByUsername(username) != null)
            {
                MessageBox.Show("The username " + username + " is already used.", "User Management");
                return;
            }

            // processing
            int userId = RetailDatabase.NextUserId();
            User user = new User(userId, username, User.HashPassword(password), firstName, lastName, role, 0, false);
            RetailDatabase.AddUser(user);

            // output
            ShowUserDetails(user);
            ShowUsers();
            MessageBox.Show("User " + username + " added with ID " + userId + ".", "User Management");
        }

        private void searchUserB_Click(object sender, EventArgs e)
        {
            String idText = userIdTB.Text.Trim();
            String username = usernameTB.Text.Trim();
            User user;

            if (idText == "" && username == "")
            {
                MessageBox.Show("Enter the user ID or the username.", "User Management");
                return;
            }

            // The user ID is used first; the username only when the ID is empty
            if (idText != "")
            {
                int userId;
                if (!int.TryParse(idText, out userId))
                {
                    MessageBox.Show("The user ID must be a number.", "User Management");
                    return;
                }
                user = RetailDatabase.FindUser(userId);
            }
            else
            {
                user = RetailDatabase.FindUserByUsername(username);
            }

            if (user == null)
            {
                MessageBox.Show("No user was found.", "User Management");
                return;
            }
            ShowUserDetails(user);
        }

        private void updateUserB_Click(object sender, EventArgs e)
        {
            User existing = FindUserOnForm();
            if (existing == null)
            {
                return;
            }

            // input
            String username = usernameTB.Text.Trim();
            String firstName = firstNameTB.Text.Trim();
            String lastName = lastNameTB.Text.Trim();
            String role = roleCB.Text;
            String password = passwordTB.Text;
            bool locked = lockedCB.Checked;

            if (username == "" || firstName == "" || lastName == "")
            {
                MessageBox.Show("Username, first name and last name are required.", "User Management");
                return;
            }
            User sameUsername = RetailDatabase.FindUserByUsername(username);
            if (sameUsername != null && sameUsername.UserId != existing.UserId)
            {
                MessageBox.Show("The username " + username + " is already used.", "User Management");
                return;
            }
            if (existing.UserId == loggedUser.UserId && (locked || role != loggedUser.Role))
            {
                MessageBox.Show("You cannot lock your own account or change your own role.", "User Management");
                return;
            }

            // processing
            // An empty password keeps the current one
            String passwordHash = existing.PasswordHash;
            if (password != "")
            {
                if (password.Length < 6)
                {
                    MessageBox.Show("The password must have at least 6 characters.", "User Management");
                    return;
                }
                passwordHash = User.HashPassword(password);
            }

            // Unlocking an account starts its failed attempts again from zero
            int failedAttempts = existing.FailedAttempts;
            if (!locked)
            {
                failedAttempts = 0;
            }

            User updated = new User(existing.UserId, username, passwordHash, firstName, lastName, role,
                failedAttempts, locked);
            RetailDatabase.UpdateUser(updated);

            // output
            ShowUserDetails(updated);
            String message = "User " + username + " updated.";
            if (existing.Locked && !locked)
            {
                message = message + "\nThe account is unlocked.";
            }
            ShowUsers();
            MessageBox.Show(message, "User Management");
        }

        private void deleteUserB_Click(object sender, EventArgs e)
        {
            User existing = FindUserOnForm();
            if (existing == null)
            {
                return;
            }
            if (existing.UserId == loggedUser.UserId)
            {
                MessageBox.Show("You cannot delete the account you are logged in with.", "User Management");
                return;
            }

            // new: the orders keep the user who processed them (foreign key of the Orders table)
            int orderCount = RetailDatabase.CountOrdersOfUser(existing.UserId);
            if (orderCount > 0)
            {
                MessageBox.Show(existing.Username + " processed " + orderCount + " order(s) and cannot be deleted:\n"
                    + "the audit trail of the sales must stay complete. Lock the account instead.", "User Management");
                return;
            }

            DialogResult answer = MessageBox.Show("Delete the user " + existing.Username + " ("
                + existing.GetFullName() + ")?", "User Management", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            RetailDatabase.DeleteUser(existing.UserId);
            ClearFields();
            ShowUsers();
            MessageBox.Show("User " + existing.Username + " deleted.", "User Management");
        }

        // Update and Delete work on the user whose ID is on the form
        private User FindUserOnForm()
        {
            int userId;
            if (userIdTB.Text.Trim() == "")
            {
                MessageBox.Show("Search the user first.", "User Management");
                return null;
            }
            if (!int.TryParse(userIdTB.Text.Trim(), out userId))
            {
                MessageBox.Show("The user ID must be a number.", "User Management");
                return null;
            }
            User user = RetailDatabase.FindUser(userId);
            if (user == null)
            {
                MessageBox.Show("No user has the ID " + userId + ".", "User Management");
            }
            return user;
        }

        private void ShowUserDetails(User user)
        {
            userIdTB.Text = user.UserId.ToString();
            usernameTB.Text = user.Username;
            firstNameTB.Text = user.FirstName;
            lastNameTB.Text = user.LastName;
            roleCB.SelectedItem = user.Role;
            passwordTB.Text = "";
            lockedCB.Checked = user.Locked;
            failedAttemptsL.Text = "Failed attempts: " + user.FailedAttempts;

            // The lock status belongs to a loaded user; the logged in administrator cannot lock their own account
            lockedCB.Enabled = user.UserId != loggedUser.UserId;
        }

        private void ShowUsers()
        {
            List<User> users = RetailDatabase.ReadUsers();
            usersRTB.Text = "";
            usersRTB.AppendText("ID".PadRight(5) + "Username".PadRight(16) + "Last name".PadRight(18)
                + "First name".PadRight(16) + "Role".PadRight(10) + "Status".PadRight(9) + "Failed\n");
            foreach (User u in users)
            {
                usersRTB.AppendText(u.UserId.ToString().PadRight(5) + u.Username.PadRight(16)
                    + u.LastName.PadRight(18) + u.FirstName.PadRight(16) + u.Role.PadRight(10) + u.GetStatus().PadRight(9)
                    + u.FailedAttempts + "\n");
            }
            usersRTB.AppendText("\nTotal users: " + users.Count);
            RetailReport.ColorWord(usersRTB, "Locked", RetailTheme.StatusRed);
        }

        private void ClearFields()
        {
            userIdTB.Text = "";
            usernameTB.Text = "";
            firstNameTB.Text = "";
            lastNameTB.Text = "";
            roleCB.SelectedIndex = 0;
            passwordTB.Text = "";
            lockedCB.Checked = false;
            lockedCB.Enabled = false;
            failedAttemptsL.Text = "";
            userIdTB.Focus();
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void showPasswordPB_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            passwordTB.UseSystemPasswordChar = !passwordVisible;
            showPasswordPB.Invalidate();
        }

        // Same eye as LoginForm: crossed out while the password is hidden
        private void showPasswordPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            int w = showPasswordPB.Width;
            int h = showPasswordPB.Height;

            g.DrawEllipse(pen, 4, h / 2 - 7, w - 9, 14);
            g.FillEllipse(Brushes.Black, w / 2 - 4, h / 2 - 4, 8, 8);
            if (!passwordVisible)
            {
                g.DrawLine(pen, 5, h - 4, w - 5, 3);
            }
            pen.Dispose();
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
