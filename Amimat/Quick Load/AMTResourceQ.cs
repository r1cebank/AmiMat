using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimat.Core
{
    public class AMTResourceQ
    {
        public ResourceType Type { get; set; }
        public string Name
        {
            get
            {
                return UID.Split('-')[1];
            }
        }
        public List<string> FrameUID { get; set; }
        public string UID { get; set; }
    }
}
