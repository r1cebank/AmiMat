using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimat.Core
{
    public class AMTFrame
    {
        public int FrameRef { get; set; }
        public int Delay { get; set; }
        public string MD5 { get; set; }
        public string ActionRef { get; set; }
        public IList<string> Tags { get; set; }
        public IList<KeyValuePair<string, IList<string>>> Functions { get; set; }
        public AMTFrame()
        {
            this.Tags = new List<string>();
            this.Functions = new List<KeyValuePair<string, IList<string>>>();
        }
    }
}
