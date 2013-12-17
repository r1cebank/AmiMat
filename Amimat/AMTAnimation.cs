using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Util;

namespace Amimat.Core
{
    public class AMTAnimation
    {
        public IList<AMTAction> Actions { get; set; }
        public AMTManifest Manifest { get; set; }
        public AMTAnimation()
        {
            this.Actions = new List<AMTAction>();
            this.Manifest = new AMTManifest();
        }
    }
}
