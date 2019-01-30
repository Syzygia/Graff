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
    public class Ellipse : Figure
        {
            public Ellipse()
            {

            }
            public Ellipse(Point p) : base(p)
            {
            Fill = NotArtist.SelectedFill.Clone();
            Line = NotArtist.SelectedLine.Clone();
        }
            public override void AddPoint(Point p)
            {
                points[1] = p;
            }
            public override void Draw(DrawingContext dc)
            {
                var space = Vector.Divide(Point.Subtract(points[0], points[1]), 2.0);
                var center = Point.Add(points[1], space);

                dc.DrawEllipse(Fill, Line, center, space.X, space.Y);
            }
            public override Figure Clone()
            {
                return new Ellipse
                {
                    points = new List<Point>(points),
                    Fill = this.Fill,
                    Line = this.Line
                };
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

