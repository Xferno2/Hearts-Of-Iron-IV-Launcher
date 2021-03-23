using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoi4_Launcher.Utility
{
    public static class Utility
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

        public static Image GetImage(string dir, params string[] extensions) {

            try {
                DirectoryInfo dInfo = new DirectoryInfo(@dir);
                var imgDir = dInfo.GetFilesByExtensions(extensions);
                return Image.FromFile(imgDir.First().FullName);
            } catch (Exception ex) { return null; };
        }

        public static void enableDoubleBuff(System.Windows.Forms.Control cont)
        {
            System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }
    }
}
