using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Amimat.Core;
using Newtonsoft.Json;

namespace Animation_Creator
{
    public partial class FrameInfo : Form
    {
        public FrameInfo(AMTFrame frame)
        {
            InitializeComponent();
            tbFrameInfo.Text = JsonConvert.SerializeObject(frame, Formatting.Indented);
        }
    }
}
