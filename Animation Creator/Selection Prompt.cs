using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Animation_Creator
{
    class Selection_Prompt <T>
    {
        public static object ShowDialog(string text, string caption, IList<T> list)
        {
            Form prompt = new Form();
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            prompt.Width = 250;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text, AutoSize = true };
            ListBox listBox = new ListBox() { Left = 25, Top = 35, Width = 175 };
            foreach (object o in list)
            {
                listBox.Items.Add(o);
            }
            Button confirmation = new Button() { Text = "Ok", Left = 25, Width = 60, Top = 140 };
            Button cancel = new Button() { Text = "Cancel", Left = 90, Width = 60, Top = 140 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { listBox.SelectedItem = -1; prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(listBox);
            prompt.ShowDialog();
            return listBox.SelectedItem;
            //Bug Cancel not working
        }
    }
}
