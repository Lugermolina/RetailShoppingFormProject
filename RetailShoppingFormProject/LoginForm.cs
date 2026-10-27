/*  Staff login of the Retail Shopping System, iteration 2
    Input(s): username and password
    Processing: the username is searched in the Users table and the hash of the typed password
                is compared with the stored hash; after three failed attempts the account is locked
                until an administrator unlocks it in User Management
    Output(s): the main menu with the options of the user's role, or an error message
*/
using Microsoft.Data.SqlClient;

namespace RetailShoppingFormProject
{
    public partial class LoginForm : Form
    {
        private ToolTip tips = new ToolTip();

        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            RetailTheme.Apply(this);
            // new: help text shown when the mouse stays over a control
            tips.SetToolTip(showPasswordPB, "Shows or hides the password");
        }

        private void loginB_Click(object sender, EventArgs e)
        {
            // input
            String username = usernameTB.Text.Trim();
            String password = passwordTB.Text;

            if (username == "")
            {
                MessageBox.Show("Enter the username.", "Login");
                usernameTB.Focus();
                return;
            }
            if (password == "")
            {
                MessageBox.Show("Enter the password.", "Login");
                passwordTB.Focus();
                return;
            }

            // processing
            User user;
            try
            {
                user = RetailDatabase.FindUserByUsername(username);
            }
            catch (SqlException)
            {
                MessageBox.Show("The database is not available. Check that SQL Server is running.", "Login");
                return;
            }

            // The same message for an unknown username and a wrong password
            if (user == null)
            {
                MessageBox.Show("Invalid username or password.", "Login");
                passwordTB.Text = "";
                passwordTB.Focus();
                return;
            }

            // A locked account cannot log in, even with the right password
            if (user.Locked)
            {
                MessageBox.Show("This account is locked. Contact the administrator.", "Login");
                passwordTB.Text = "";
                return;
            }

            // The failed attempt is counted on the account and stored in the Users table
            if (!user.CheckPassword(password))
            {
                user.RegisterFailedAttempt();
                RetailDatabase.UpdateLoginStatus(user);
                if (user.Locked)
                {
                    MessageBox.Show("Invalid username or password.\nThe account is now locked after "
                        + User.MaxFailedAttempts + " failed attempts. Contact the administrator.", "Login");
                }
                else
                {
                    MessageBox.Show("Invalid username or password.\nAttempts left: "
                        + (User.MaxFailedAttempts - user.FailedAttempts), "Login");
                }
                passwordTB.Text = "";
                passwordTB.Focus();
                return;
            }

            // output
            user.ResetFailedAttempts();
            RetailDatabase.UpdateLoginStatus(user);
            Hide();
            MainRetailForm mainForm = new MainRetailForm(user);
            mainForm.ShowDialog();

            // Log Out returns to the login; Exit closes the application
            if (mainForm.LoggedOut)
            {
                usernameTB.Text = "";
                passwordTB.Text = "";
                Show();
                usernameTB.Focus();
            }
            else
            {
                Close();
            }
        }

        // The password is shown or hidden; the eye is crossed out while the password is hidden
        private void showPasswordPB_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            passwordTB.UseSystemPasswordChar = !passwordVisible;
            showPasswordPB.Invalidate();
        }

        // Simple eye drawn with an ellipse and a pupil, plus a diagonal line when the password is hidden
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

        private void exitB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
