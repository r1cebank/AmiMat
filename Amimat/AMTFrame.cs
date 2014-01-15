using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimat.Core
{
    public class AMTFrame : ICloneable
    {
        public string Resource { get; set; } //Which Resource to load?
        public int FrameRef { get; set; }
        public int Delay { get; set; }
        public double Randomness { get; set; }
        public string MD5 { get; set; }
        public string ActionRef { get; set; }
        public IList<string> Tags { get; set; }
        public IList<KeyValuePair<string, IList<string>>> Functions { get; set; }
        public AMTFrame()
        {
            this.ActionRef = null;
            this.Randomness = 0.0f;
            this.Tags = new List<string>();
            this.Functions = new List<KeyValuePair<string, IList<string>>>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
