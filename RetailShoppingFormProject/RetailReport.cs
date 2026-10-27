/*  Report output of the Retail Shopping System, iteration 3
    Helpers shared by the report forms: report header and footer, column fitting,
    colors of the status words, saving a report to a text file and the bar chart of a report.
*/
namespace RetailShoppingFormProject
{
    public static class RetailReport
    {
        public const int Width = 84;

        // Text cut to the width of a report column so the columns stay aligned
        public static String Fit(String text, int width)
        {
            if (text.Length > width)
            {
                return text.Substring(0, width);
            }
            return text;
        }

        public static String Rule(char symbol)
        {
            return "".PadRight(Width, symbol) + "\n";
        }

        // Report header: store, title, period or subject, date and time, user who produced the report
        public static String Header(String title, String subject, User preparedBy)
        {
            return Rule('=')
                + "RETAIL SHOPPING SYSTEM\n"
                + title + "\n"
                + subject + "\n"
                + "Printed " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " by " + preparedBy.GetDisplayName() + "\n"
                + Rule('=') + "\n";
        }

        public static String Footer()
        {
            return Rule('=') + "*** End of report ***";
        }

        // Writes the report into a text file chosen by the user; returns false when the user cancels
        public static bool SaveToFile(String reportText, String suggestedName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save the report";
            saveDialog.Filter = "Text files (*.txt)|*.txt";
            saveDialog.FileName = suggestedName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            StreamWriter reportWriter = new StreamWriter(
                new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write));
            reportWriter.Write(reportText.Replace("\n", Environment.NewLine));
            reportWriter.Close();
            MessageBox.Show("The report was saved in\n" + saveDialog.FileName, "Save Report");
            return true;
        }

        // Every occurrence of the word gets the color (red = stop, amber = caution, green = go)
        public static void ColorWord(RichTextBox box, String word, Color color)
        {
            int start = box.Find(word, 0, RichTextBoxFinds.MatchCase);
            while (start >= 0)
            {
                box.Select(start, word.Length);
                box.SelectionColor = color;
                if (start + word.Length >= box.TextLength)
                {
                    break;
                }
                start = box.Find(word, start + word.Length, RichTextBoxFinds.MatchCase);
            }
            box.Select(0, 0);
        }

        // Horizontal bar chart: one bar per label, the longest bar in amber, the others in navy
        public static void DrawBarChart(Graphics g, Rectangle area, String title, List<String> labels,
            List<double> values, String valuePrefix)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            Font titleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 8.5F);
            SolidBrush navyBrush = new SolidBrush(RetailTheme.Navy);
            SolidBrush amberBrush = new SolidBrush(RetailTheme.Amber);
            Pen axisPen = new Pen(Color.Gray, 1);

            g.DrawString(title, titleFont, navyBrush, area.Left + 8, area.Top + 8);
            if (values.Count == 0)
            {
                g.DrawString("No data for this report.", textFont, Brushes.Gray, area.Left + 8, area.Top + 40);
            }
            else
            {
                double max = 0;
                int maxIndex = 0;
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] > max)
                    {
                        max = values[i];
                        maxIndex = i;
                    }
                }
                if (max == 0)
                {
                    max = 1;
                }

                int labelWidth = 115;
                int top = area.Top + 42;
                int barLeft = area.Left + labelWidth;
                int barSpace = area.Width - labelWidth - 75;
                int rowHeight = Math.Min(36, (area.Height - 60) / values.Count);
                int barHeight = Math.Max(8, rowHeight * 2 / 3);

                g.DrawLine(axisPen, barLeft, top - 4, barLeft, top + rowHeight * values.Count);
                for (int i = 0; i < values.Count; i++)
                {
                    int y = top + i * rowHeight;
                    int barWidth = (int)(barSpace * values[i] / max);
                    SolidBrush barBrush = navyBrush;
                    if (i == maxIndex)
                    {
                        barBrush = amberBrush;
                    }
                    g.DrawString(Fit(labels[i], 15), textFont, Brushes.Black, area.Left + 6, y + barHeight / 2 - 8);
                    g.FillRectangle(barBrush, barLeft + 1, y, Math.Max(barWidth, 2), barHeight);
                    // amounts in dollars with cents, quantities as whole numbers
                    String valueText = values[i].ToString("N0");
                    if (valuePrefix == "$")
                    {
                        valueText = "$" + values[i].ToString("N2");
                    }
                    g.DrawString(valueText, textFont, Brushes.Black,
                        barLeft + Math.Max(barWidth, 2) + 4, y + barHeight / 2 - 8);
                }
            }

            titleFont.Dispose();
            textFont.Dispose();
            navyBrush.Dispose();
            amberBrush.Dispose();
            axisPen.Dispose();
        }
    }
}
