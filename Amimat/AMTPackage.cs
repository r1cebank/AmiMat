using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Util;
using Amimat.Config;

using Newtonsoft.Json;

namespace Amimat.Core
{
    public class AMTPackage : ICloneable
    {
        public AMTUtil.State PackageState { get; set; }
        public AMTAnimation Animation { get; set; }
        public string WorkingDir { get; set; }
        public string Name { get; set; }
        public List<byte[]> Frames { get; set; }
        public AMTPackage()
        {
            Animation = new AMTAnimation();
            Frames = new List<byte[]>();
            PackageState = AMTUtil.State.EMPTY;
        }
        public bool Save()
        {
            try
            {
                File.WriteAllText(AMTUtil.GetAbsPath(WorkingDir, AMTConfig.MainfestFileName + AMTConfig.MainfestExtension), JsonConvert.SerializeObject(Animation.Manifest, Formatting.Indented));
                foreach (AMTAction a in Animation.Actions)
                {
                    File.WriteAllText(AMTUtil.GetAbsPath(WorkingDir, a.Name + AMTConfig.ActionExtension), JsonConvert.SerializeObject(a, Formatting.Indented));
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool SavePackage()
        {
            try
            {
                File.WriteAllText(AMTUtil.GetAbsPath(WorkingDir, "AMT.apkg"), JsonConvert.SerializeObject(this));
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string GetVersion() { return AMTConfig.Version; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
