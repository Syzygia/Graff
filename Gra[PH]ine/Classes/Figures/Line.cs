using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using Gra_PH_ine.Classes;
using Gra_PH_ine.Classes.Figures;
using System.Globalization;

namespace Gra_PH_ine.Figures
{
    [Serializable]
    public class Line:Figure
    {
        
        public Line()
        {
           
        }
        public override Figure Clone()
        {
            return new Line
            {
                points = new List<Point>(points),
                Fill= this.Fill,
                Line = this.Line
             };
        }
        public Line(Point p) : base(p)
        {
            Fill = NotArtist.SelectedFill.Clone();
            Line = NotArtist.SelectedLine.Clone();
        }
        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
        public override void Draw (DrawingContext kt)
        {
            kt.DrawLine(Line, points[0], points[1]);
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
