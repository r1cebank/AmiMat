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

using Amimat.Core;

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
                    AMTAction EmbeddedAction = Animation.Actions[Animation.Manifest.ActionFileName.IndexOf(f.ActionRef)];
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
        public static List<byte[]> LoadAsset(string AssetName)
        {
            List<byte[]> Frames = new List<byte[]>();
            try
            {
                //Try extracting the frames
                Frames = EnumerateFrames(AssetName);
                if (Frames == null || Frames.Count() == 0)
                {
                    throw new NoNullAllowedException("Unable to obtain frames from " + AssetName);
                }
                return Frames;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
                return null;
            }
        }
        /// <summary>
        /// Convert image in memory to Image with transparency channel
        /// </summary>
        /// <param name="imageBytes">bytes to convert</param>
        /// <returns>bitmap with transparency</returns>
        private Bitmap BytesToImage(byte[] imageBytes)
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
        private byte[] ConvertImageToBytes(Image image)
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