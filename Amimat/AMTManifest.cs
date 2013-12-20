using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Amimat.Core
{
    public class AMTManifest
    {
        public string AssetName { get; set; }
        public IList<string> ActionFileName { get; set; }
        public string DefaultAction { get; set; }
        public AMTManifest()
        {
            this.ActionFileName = new List<string>();
        }
    }
}
