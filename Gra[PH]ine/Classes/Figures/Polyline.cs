using Gra_PH_ine.Classes;
using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Gra_PH_ine.Classes.Figures
{
    [Serializable]
   public class Polyline:Figure
    {
        public Polyline()
        {

        }
        public override Figure Clone()
        {
            return new Polyline
            {
                points = new List<Point>(points),
                Fill = this.Fill,
                Line = this.Line
            };
        }
        public Polyline(Point p) : base(p)
        {
                Line = NotArtist.SelectedLine.Clone();
        }
       public override void AddPoint(Point p)
        {
            points.Add(p);
        }
        public override void Draw(DrawingContext dc)
        {
        var geo = new StreamGeometry();
        using (var geoContext = geo.Open())
        {
            geoContext.BeginFigure(points[0], false, false);
            geoContext.PolyLineTo(points, true, false);
        }
        dc.DrawGeometry(null, Line, geo);


        }
        public override string ConvertToSVG()
        {
            var culture = new CultureInfo("en"); ;
            var size = Point.Subtract(points[1], points[0]);
            var point0 = Point.Subtract(points[1], size / 2);
            var opacity = ((SolidColorBrush)Fill).Color.A / 255.0;
            var fill = ((SolidColorBrush)Fill).Color.ToString(culture).Remove(1, 2);
            var stroke = ((SolidColorBrush)Line.Brush).Color.ToString(culture).Remove(1, 2);
            return "<ellipse cx=" + point0.X.ToString(culture) + " cy=" + point0.Y.ToString(culture) + " fill-opacity=" + opacity.ToString(culture) + " rx=" + size.X.ToString(culture) + " ry=" + size.Y.ToString(culture) + " style=\"fill:" + fill + ";stroke:" + stroke + ";stroke-width:\"" + Line.Thickness.ToString(culture) + " />";
        }
    }
}