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
        public AMTAction()
        {
            this.Frames = new List<AMTFrame>();
        }
    }
}
