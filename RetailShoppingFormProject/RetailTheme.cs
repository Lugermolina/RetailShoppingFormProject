/*  Colors and look of the Retail Shopping System, iteration 3: navy and amber
    Navy for titles, headings, buttons and the bars of the charts, amber for the main action and highlights,
    red, amber and green for the stock and account status (stop, caution, go).
    Apply(form) is called once in the constructor of every form so all the screens look the same.
*/
namespace RetailShoppingFormProject
{
    public static class RetailTheme
    {
        public static readonly Color Navy = Color.FromArgb(31, 58, 95);
        public static readonly Color NavyHover = Color.FromArgb(52, 88, 135);
        public static readonly Color NavyLight = Color.FromArgb(222, 230, 241);
        public static readonly Color Amber = Color.FromArgb(242, 169, 0);
        public static readonly Color AmberHover = Color.FromArgb(255, 193, 51);
        public static readonly Color AmberLight = Color.FromArgb(255, 243, 214);
        public static readonly Color Background = Color.FromArgb(246, 247, 249);
        public static readonly Color StatusRed = Color.FromArgb(192, 0, 0);
        public static readonly Color StatusAmber = Color.FromArgb(191, 120, 0);
        public static readonly Color StatusGreen = Color.FromArgb(0, 128, 64);

        // Main action of a form, in amber
        private static readonly String[] PrimaryButtons = { "loginB", "completePurchaseB" };

        // Buttons that close or clear, in white with a navy border
        private static readonly String[] SecondaryButtons = { "closeB", "clearB", "exitB", "newOrderB" };

        public static void Apply(Form form)
        {
            form.BackColor = Background;
            ApplyToControls(form.Controls);
        }

        // Goes through the controls of the form and the controls inside them (panels)
        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                {
                    StyleButton((Button)control);
                }
                else if (control is Label && (control.Font.Bold || control.Name == "titleL"))
                {
                    control.ForeColor = Navy;
                }
                else if (control is MenuStrip)
                {
                    control.BackColor = NavyLight;
                }
                else if (control is StatusStrip)
                {
                    control.BackColor = Navy;
                    control.ForeColor = Color.White;
                }
                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        private static void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.Cursor = Cursors.Hand;
            if (Array.IndexOf(PrimaryButtons, button.Name) >= 0)
            {
                button.BackColor = Amber;
                button.ForeColor = Navy;
                button.FlatAppearance.BorderColor = Amber;
                button.FlatAppearance.MouseOverBackColor = AmberHover;
                button.Font = new Font(button.Font, FontStyle.Bold);
            }
            else if (Array.IndexOf(SecondaryButtons, button.Name) >= 0)
            {
                button.BackColor = Color.White;
                button.ForeColor = Navy;
                button.FlatAppearance.BorderColor = Navy;
                button.FlatAppearance.MouseOverBackColor = NavyLight;
            }
            else
            {
                button.BackColor = Navy;
                button.ForeColor = Color.White;
                button.FlatAppearance.BorderColor = Navy;
                button.FlatAppearance.MouseOverBackColor = NavyHover;
            }
        }
    }
}
