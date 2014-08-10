using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Amimat.Util;
using Amimat.Config;

using Newtonsoft.Json;
using SevenZip;

namespace Amimat.Core
{
    public class AMTPackage : ICloneable
    {
        public AMTUtil.State PackageState { get; set; }
        public AMTAnimation Animation { get; set; }
        public string WorkingDir { get; set; }
        public string Name { get; set; }
        public AMTResource CurrentResource { get; set; }
        public List<KeyValuePair<string, string>> Resources { get; set; }
        public AMTPackage()
        {
            Animation = new AMTAnimation();
            CurrentResource = null;
            Resources = new List<KeyValuePair<string, string>>();
            PackageState = AMTUtil.State.EMPTY;
        }
        public bool SwitchResource(string ResourceName)
        {
            if (CurrentResource != null)
            {
                if (ResourceName == CurrentResource.Name)
                    return true;
            }
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
            //check existing
            if (Resources.Exists(delegate(KeyValuePair<string, string> match)
            {
                return match.Value == ResourceName;
            }))
                return false;
            CurrentResource = new AMTResource();
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(ResourcePath))
                {
                    CurrentResource.UID = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower() + "-" + ResourceName;
                }
            }
            if (CurrentResource.LoadResource(Type, ResourcePath))
            {
                Resources.Add(new KeyValuePair<string, string> (CurrentResource.UID, ResourceName));
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
                ArcPostProcessor(AMTUtil.GetAbsPath(WorkingDir, CurrentResource.Name + AMTConfig.ResourceExtension));
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool AddExistingResource(string ResourcePath)
        {
            string PrePath = ArcPreProcessor(ResourcePath);
            try
            {
                //Check for existing using UID
                CurrentResource = (AMTResource)JsonConvert.DeserializeObject<AMTResource>(File.ReadAllText(PrePath));
                Resources.Add(new KeyValuePair<string, string>(CurrentResource.UID, CurrentResource.Name));
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
            AMTResource resourceBk = this.CurrentResource;
            try
            {
                this.CurrentResource = null;
                File.WriteAllText(AMTUtil.GetAbsPath(WorkingDir, "AMT.apkg"), JsonConvert.SerializeObject(this));
            }
            catch
            {
                return false;
            }
            this.CurrentResource = resourceBk;
            return true;
        }

        public string GetVersion() { return AMTConfig.Version; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private string ArcPreProcessor(string FilePath)
        {
            SevenZipExtractor.SetLibraryPath(@"C:\Program Files (x86)\7-Zip\7z.dll");
            var tmp = new SevenZipExtractor(FilePath);
            tmp.ExtractArchive(WorkingDir);
            return AMTUtil.GetAbsPath(WorkingDir, Path.GetFileNameWithoutExtension(FilePath) + AMTConfig.ResourceExtension);
        }

        private void ArcPreClean(string FilePath)
        {
            File.Delete(FilePath);
        }

        private void ArcPostProcessor(string FilePath)
        {
            SevenZipExtractor.SetLibraryPath(@"C:\Program Files (x86)\7-Zip\7z.dll");
            var tmp = new SevenZipCompressor();
            string PostFile = AMTUtil.GetAbsPath(WorkingDir, CurrentResource.Name + AMTConfig.ResourcePostExtension);
            tmp.CompressFiles(PostFile, FilePath);
            File.Delete(FilePath);     
        }
    }
}
