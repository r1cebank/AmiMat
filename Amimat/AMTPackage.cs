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
        public AMTResource CurrentResource { get; set; }
        public List<string> Resources { get; set; }
        public AMTPackage()
        {
            Animation = new AMTAnimation();
            CurrentResource = null;
            Resources = new List<string>();
            PackageState = AMTUtil.State.EMPTY;
        }
        public bool SwitchResource(string ResourceName)
        {
            ResourceName = AMTUtil.GetAbsPath(WorkingDir, ResourceName + AMTConfig.ResourceExtension);
            try
            {
                CurrentResource = (AMTResource)JsonConvert.DeserializeObject<AMTResource>(File.ReadAllText(ResourceName));
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool AddResource(string ResourceName, string ResourcePath, ResourceType Type)
        {
            if (Resources.Exists(delegate(string match)
            {
                return match == ResourceName;
            }))
                return false;
            CurrentResource = new AMTResource();
            CurrentResource.Name = ResourceName;
            if (CurrentResource.LoadResource(Type, ResourcePath))
            {
                Resources.Add(ResourceName);
                if (!SaveCurrentResource())
                    return false;
                return true;
            }
            else
                return false;
        }
        private bool SaveCurrentResource()
        {
            try
            {
                File.WriteAllText(AMTUtil.GetAbsPath(WorkingDir, CurrentResource.Name + AMTConfig.ResourceExtension), JsonConvert.SerializeObject(CurrentResource));
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool AddResource(string ResourcePath)
        {
            try
            {
                CurrentResource = (AMTResource)JsonConvert.DeserializeObject<AMTResource>(File.ReadAllText(ResourcePath));
                Resources.Add(CurrentResource.Name);
                if (!SaveCurrentResource())
                    return false;
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
