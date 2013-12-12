using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation_Creator
{
    public partial class FramePreview : Form
    {
        public FramePreview(Image image)
        {
            InitializeComponent();
            pbPreview.Image = image;
        }
    }
}
