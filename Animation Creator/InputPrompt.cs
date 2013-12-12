using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation_Creator
{
    class InputPrompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            prompt.Width = 250;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 35, Width = 210 };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 60, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}
