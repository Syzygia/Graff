using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gra_PH_ine.Classes
{
  public static  class Converter
    {
        public static void ConvertToSVG(string fileName)
        {
            var culture = new CultureInfo("en");
            var svg = "<svg width=" + NotArtist.CanvasWidth.ToString(culture) + " height=" + NotArtist.CanvasHeigth.ToString(culture) + ">\n" + Environment.NewLine;
            foreach (var figure in NotArtist.Figures)
            {
                svg += " " + figure.ConvertToSVG() + Environment.NewLine;
            }
            svg += "</svg>";
            File.WriteAllText(fileName, svg);
        }

        public static void ConvertToPNG(string fileName)
        {
            MemoryStream ms = SaveCanvasAsStream();
            File.WriteAllBytes(fileName, ms.ToArray());
        }

        public static MemoryStream SaveCanvasAsStream()
        {
            Rect rect = new Rect(MainWindow.appWindow.MainCanvas.RenderSize);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
              (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(MainWindow.appWindow.MainCanvas);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            MemoryStream ms = new MemoryStream();
            pngEncoder.Save(ms);
            ms.Close();
            return ms;
        }
    }
}
