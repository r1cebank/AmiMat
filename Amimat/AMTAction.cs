using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimat.Core
{
    public class AMTAction
    {
        public string Name { get; set; }
        public IList<AMTFrame> Frames { get; set; }
        public List<string> ResourceRequired { get; set; } // Will be put to use when action include cross resource reference
        public AMTAction()
        {
            this.Frames = new List<AMTFrame>();
        }
    }
}
