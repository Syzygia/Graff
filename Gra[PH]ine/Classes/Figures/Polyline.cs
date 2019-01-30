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
            var svg_points = string.Empty;

            for (var i = 0; i < points.Count - 1; i++)
                svg_points += points[i].X.ToString(culture) + "," + points[i].Y.ToString(culture) + " ";
            svg_points += points[points.Count - 1].X.ToString(culture) + "," + points[points.Count - 1].Y.ToString(culture);

            var stroke = ((SolidColorBrush)Line.Brush).Color.ToString().Remove(1, 2);

            return "<polyline points=\"" + svg_points + "\" style=\"fill:none;stroke:" + stroke + ";stroke-width:" + Line.Thickness.ToString(culture) + "\"/>";
        }
    }
}