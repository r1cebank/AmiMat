using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Scripting;
using Amimat.Util;

using Newtonsoft.Json;

namespace Amimat.Core
{
    class AMTPackage
    {
        public AMTUtil.State PackageState { get; set; }
        public AMTAnimation Animation { get; set; }
        public AMTLua LuaScript { get; set; }
        public string WorkingDir { get; set; }
        public AMTPackage()
        {
            Animation = new AMTAnimation();
            LuaScript = new AMTLua();
            PackageState = AMTUtil.State.EMPTY;
        }
        public void Save(string WorkingDir)
        {
            File.WriteAllText(AMTUtil.GetPathOfFile(WorkingDir, "AMT.amf"), JsonConvert.SerializeObject(Animation.Manifest, Formatting.Indented));
            foreach (AMTAction a in Animation.Actions)
            {
                File.WriteAllText(AMTUtil.GetPathOfFile(WorkingDir, a.Name + ".act"), JsonConvert.SerializeObject(a, Formatting.Indented));
            }
        }
    }
}
