using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Config;

namespace Amimat.Core
{
    public class AMTManifest
    {
        public string AssetName { get; set; }
        public IList<string> ActionFileName { get; set; }
        public string DefaultAction { get; set; }
        public string Version { get; set; }
        public AMTManifest()
        {
            Version = AMTConfig.Version;
            this.ActionFileName = new List<string>();
        }
    }
}
