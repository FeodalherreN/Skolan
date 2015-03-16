using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MacSnapHack.Helpers
{
    public static class DataHelpers
    {
        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ReadFully(Stream input)
        {
            byte[] data;
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                data = ms.ToArray();
            }

            return data;
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static BitmapImage StreamToBitmapImage(Stream stream)
        {
            var image = new BitmapImage();
            image.StreamSource = stream;
            return image;
        }
    }
}
