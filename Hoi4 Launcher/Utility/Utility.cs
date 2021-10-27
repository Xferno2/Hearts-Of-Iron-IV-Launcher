using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoi4_Launcher.Utility
{

    public static class UtilityExtension
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            try
            {
                if (extensions == null)
                    throw new ArgumentNullException("extensions");
                IEnumerable<FileInfo> files = dir.EnumerateFiles();
                return files.Where(f => extensions.Contains(f.Extension));
            }
            catch (Exception ex) { return null; }
        }
    }

    public class Util {
        public static Image GetImage(string dir, params string[] extensions)
        {

            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(@dir);
                var imgDir = dInfo.GetFilesByExtensions(extensions);
                return Image.FromFile(imgDir.First().FullName);
            }
            catch (Exception ex) { return null; };
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            if (image != null)
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }
            else { return null; }
        }
        public static Image parseImage(string path, string file)
        {
            try
            {
                string extension = null;
                try
                {
                    var split = path.Split('.')[1];
                    if (split != null)
                        extension = split;
                }
                catch (Exception ex) { return null; }
                if (extension == "zip" || extension == "rar" || extension == "7z")
                {
                    var archivePath = path.Replace(@"\\", @"\").Replace(@"/", @"\");
                    using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                    {
                        ZipArchiveEntry picture = archive.GetEntry(file);
                        if (picture != null)
                            return Image.FromStream(picture.Open());
                        return null;
                    }
                }
                else if (extension == null)
                {
                    return null;
                }
                else
                {
                    return GetImage(path + "/" + file, new string[] { "png", "jpg", "jpeg" });
                }
            }
            catch (Exception ex) { return null; }
        }

        public static void enableDoubleBuff(System.Windows.Forms.Control cont)
        {
            System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }
    }
}
