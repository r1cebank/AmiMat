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

//WPF
using System.Windows.Media;
using System.Windows.Media.Imaging;

using System.Security.Cryptography;
using Newtonsoft.Json;

using Amimat.Core;
using Amimat.Config;

namespace Amimat.Util
{
    public class AMTUtil
    {
        public enum State
        {
            EMPTY,
            LOADED,
            READY
        }
        /// <summary>
        /// Expand Current action with action reference frames into Action with frame reference frames
        /// </summary>
        /// <param name="Animation">Current Animation</param>
        /// <param name="Action">Action to Expand</param>
        /// <returns>New expanded action</returns>
        public static AMTAction ExpandFrame(AMTAnimation Animation, AMTAction Action)
        {
            AMTAction ExpandedAction = new AMTAction();
            ExpandedAction.Name = Action.Name;
            ExpandedAction.Frames.Clear();
            foreach (AMTFrame f in Action.Frames)
            {
                if (f.ActionRef != null)
                {
                    AMTAction EmbeddedAction = AMTUtil.GetActionFromName(Animation, f.ActionRef);
                    AMTAction ExpandedEmbeddedAction = ExpandFrame(Animation, EmbeddedAction);
                    foreach (AMTFrame fe in ExpandedEmbeddedAction.Frames)
                    {
                        ExpandedAction.Frames.Add(fe);
                    }
                }
                else
                {
                    ExpandedAction.Frames.Add(f);
                }

            }
            return ExpandedAction;
        }
        /// <summary>
        /// Load Current Selected Asset into Memory
        /// </summary>
        /// <param name="AssetName">path of the asset</param>
        /// <returns>loaded asset list</returns>
        public static void LoadAsset(AMTPackage Package, string AssetName)
        {
            Package.CurrentResource.Frames.Clear();
            try
            {
                //Try extracting the frames
                Package.CurrentResource.Frames = EnumerateFrames(AssetName);
                if (Package.CurrentResource.Frames == null || Package.CurrentResource.Frames.Count() == 0)
                {
                    throw new NoNullAllowedException("Unable to obtain frames from " + AssetName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }
        }
        /// <summary>
        /// Convert image in memory to Image with transparency channel
        /// </summary>
        /// <param name="imageBytes">bytes to convert</param>
        /// <returns>bitmap with transparency</returns>
        public static Bitmap BytesToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            try
            {
                //Read bytes into a MemoryStream
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    //Recreate the frame from the MemoryStream
                    using (Bitmap bmp = new Bitmap(ms))
                    {
                        bmp.MakeTransparent();
                        return (Bitmap)bmp.Clone();
                    }
                }
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
        /// <summary>
        /// Convert Selected Images to bytes
        /// </summary>
        /// <param name="image">Image to convert</param>
        /// <returns>bytes</returns>
        public static byte[] ImageToBytes(Image image)
        {
            if (image == null)
            {
                return null;
            }

            try
            {
                //Read bytes into a MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    return ms.ToArray();
                }
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
        /// <summary>
        /// Calculate Image MD5
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns>MD5 string</returns>
        public static string ImageMD5(Image image)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] md5Hash = MD5.ComputeHash(ImageToBytes(image));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Swap two Elements
        /// </summary>
        /// <typeparam name="T">datatype</typeparam>
        /// <param name="list">list to do operations on</param>
        /// <param name="indexA">object 1</param>
        /// <param name="indexB">object 2</param>
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <param name="Frames"></param>
        /// <param name="DefaultDelay"></param>
        public static void InitAnimation(AMTPackage Package, int DefaultDelay = 100)
        {
            Package.PackageState = State.LOADED;
            Package.Animation = new AMTAnimation();
            Package.Animation.Manifest.AssetName = "asset.gif";
            Package.Animation.Manifest.ActionFileName.Add("null");
            Package.Animation.Manifest.DefaultAction = "null";
            Package.Animation.Actions.Add(new AMTAction());
            Package.Animation.Actions[0].Name = "null";
            Package.Animation.Actions[0].Frames.Add(new AMTFrame());
            Package.Animation.Actions[0].Frames[0].Delay = DefaultDelay;
            Package.Animation.Actions[0].Frames[0].FrameRef = 0;
            Package.Animation.Actions[0].Frames[0].Tags.Add("null");
            Package.Animation.Actions[0].Frames[0].MD5 = ImageMD5(BytesToImage(Package.CurrentResource.Frames[0]));
            //Package.Save();
            //
            //
            //
            //
            //
            //
            //

            Package.PackageState = State.READY;
        }
        public static AMTAction GetDefaultAction(AMTAnimation Animation)
        {
            return GetActionFromName(Animation, Animation.Manifest.DefaultAction);
        }
        /// <summary>
        /// Visualize Frame
        /// </summary>
        /// <param name="frame">frame to viualize</param>
        /// <returns>current frame</returns>
        public static string FrameToString(AMTFrame frame)
        {
            string str = "";
            if (frame.ActionRef == null)
            {
                str = "Frame Reference:[" + frame.FrameRef + "]" + "Frame Delay:" + "[" + frame.Delay + "ms" + "]";
                str += "Randomness:[" + frame.Randomness + "]";
                str += "Tags:[";
                foreach (string s in frame.Tags)
                {
                    str += "(";
                    str += s;
                    str += ")";
                }
                str += "]";
            }
            else
            {
                str = "Action Reference: [" + frame.ActionRef + "]";
            }
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkingDir"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetAbsPath(string WorkingDir, string fileName)
        {
            return Path.Combine(WorkingDir, fileName);
        }

        public static bool OpenPackage(AMTPackage Package, string FileName)
        {
            AMTPackage ClonedPackage;
            try
            {
                ClonedPackage = (AMTPackage)JsonConvert.DeserializeObject<AMTPackage>(File.ReadAllText(FileName)).Clone();
            }
            catch
            {
                return false;
            }
            if (!ClonedPackage.Animation.Manifest.Version.Equals(AMTConfig.Version))
            {
                MessageBox.Show("AMT file version does not match!", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Setting Variables
            Package.Animation = ClonedPackage.Animation;
            Package.CurrentResource.Frames = ClonedPackage.CurrentResource.Frames;
            Package.Name = ClonedPackage.Name;
            Package.WorkingDir = Path.GetDirectoryName(FileName);
            Package.PackageState = AMTUtil.State.READY;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
        public static string GetDouble(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.').ToArray());
        }
        /// <summary>
        /// Convert byte to WPF image
        /// </summary>
        /// <param name="imageData">image in bytes</param>
        /// <returns>ImageSource for WPF</returns>
        public static ImageSource BytesToImageSource(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
        /// <summary>
        /// Get action from its name
        /// </summary>
        /// <param name="Animation">Animation to look at</param>
        /// <param name="ActionName">Name of the action</param>
        /// <returns>AMTAction if found, null if not found</returns>
        public static AMTAction GetActionFromName(AMTAnimation Animation, string ActionName)
        {
            foreach (AMTAction a in Animation.Actions)
            {
                if (a.Name.Equals(ActionName))
                    return a;
            }
            return null;
        }
        public static string CheckReference(AMTAnimation Animation, AMTAction CurrentAction, AMTAction ActionToAdd)
        {
            foreach (AMTFrame f in ActionToAdd.Frames)
            {
                if (f.ActionRef != null)
                {
                    if (f.ActionRef == CurrentAction.Name)
                    {
                        return ActionToAdd.Name;
                    }
                    else
                    {
                        return CheckReference(Animation, CurrentAction, GetActionFromName(Animation, f.ActionRef));
                    }
                }
            }
            return null;
        }
        private static List<byte[]> EnumerateFrames(string imagePath)
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