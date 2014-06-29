using System;
using System.IO;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

using Amimat.Util;

namespace Amimat.Core
{
    public enum ResourceType
    {
        GIF,
        PNG,
    }
    public class AMTResource
    {
        public ResourceType Type { get; set; }
        public string Name { get; set; }
        public List<byte[]> Frames { get; set; }
        public List<string> FrameUID { get; set; }
        public string UID { get; set; }
        public AMTResource()
        {
            Frames = new List<byte[]>();
            FrameUID = new List<string>();
        }
        public bool LoadResource(ResourceType Type, string ResourcePath)
        {
            switch(Type)
            {
                case ResourceType.GIF:
                    Frames = LoadGIF(ResourcePath);
                    UpdateUID();
                    break;
                case ResourceType.PNG:
                    break;
                default:
                    return false;
            }
            return true;
        }
        public void UpdateUID()
        {
            FrameUID.Clear();
            for(int i = 0; i< Frames.Count; i++)
            {
                using (var md5 = MD5.Create())
                {
                    FrameUID.Add(BitConverter.ToString(md5.ComputeHash(Frames[i])).Replace("-", "").ToLower());
                }
            }
        }
        private List<byte[]> LoadGIF(string imagePath)
        {
            try
            {
                //Make sure the image exists
                if (!File.Exists(imagePath))
                {
                    throw new FileNotFoundException("Unable to locate " + imagePath);
                }

                Dictionary<Guid, ImageFormat> guidToImageFormatMap = new Dictionary<Guid, ImageFormat>()
                {
                    {ImageFormat.Bmp.Guid,  ImageFormat.Bmp},
                    {ImageFormat.Gif.Guid,  ImageFormat.Png},
                    {ImageFormat.Icon.Guid, ImageFormat.Png},
                    {ImageFormat.Jpeg.Guid, ImageFormat.Jpeg},
                    {ImageFormat.Png.Guid,  ImageFormat.Png}
                };

                List<byte[]> tmpFrames = new List<byte[]>() { };

                using (Image img = Image.FromFile(imagePath, true))
                {
                    //Check the image format to determine what
                    //format the image will be saved to the 
                    //memory stream in
                    ImageFormat imageFormat = null;
                    Guid imageGuid = img.RawFormat.Guid;

                    foreach (KeyValuePair<Guid, ImageFormat> pair in guidToImageFormatMap)
                    {
                        if (imageGuid == pair.Key)
                        {
                            imageFormat = pair.Value;
                            break;
                        }
                    }

                    if (imageFormat == null)
                    {
                        throw new NoNullAllowedException("Unable to determine image format");
                    }

                    //Get the frame count
                    FrameDimension dimension = new FrameDimension(img.FrameDimensionsList[0]);
                    int frameCount = img.GetFrameCount(dimension);

                    //Step through each frame
                    for (int i = 0; i < frameCount; i++)
                    {
                        //Set the active frame of the image and then 
                        //write the bytes to the tmpFrames array
                        img.SelectActiveFrame(dimension, i);
                        using (MemoryStream ms = new MemoryStream())
                        {

                            img.Save(ms, imageFormat);
                            tmpFrames.Add(ms.ToArray());
                        }
                    }

                }

                return tmpFrames;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }

            return null;
        }
    }
}
