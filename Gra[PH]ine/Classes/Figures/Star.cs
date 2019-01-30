using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using Gra_PH_ine.Figures;
using System.Globalization;

namespace Gra_PH_ine.Classes.Figures
{
    [Serializable]
    public class Star : Figure
    {
        public Star()
        {

        }        
        public override Figure Clone()
        {
            return new Star
            {
                points = new List<Point>(points),
                Fill = this.Fill,
                Line = this.Line
            };
        }
        public Star(Point p) : base(p)
        {
            Fill = NotArtist.SelectedFill.Clone();
            Line = NotArtist.SelectedLine.Clone();
        }
        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
        public override void Draw(DrawingContext kt)
        {
            var n = 10;
            var geometry = new StreamGeometry();
            var size = Point.Subtract(points[0], points[1]);
            size = size / 2;
            var point0 = Point.Subtract(points[0], size);
            var star_pts = new List<Point>
            {
                Point.Add(point0, new Vector(size.X / 5 * 2 * Math.Sin((Math.PI / 180) * (360 / n)), size.Y / 5 * 2 * Math.Cos((Math.PI / 180) * (360 / n))))
            };

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                    star_pts.Add(Point.Add(point0, new Vector(size.X / 5 * 2 * Math.Sin((2 * Math.PI / n) * (i + 1)), size.Y / 5 * 2 * Math.Cos((2 * Math.PI / n) * (i + 1)))));
                else
                    star_pts.Add(Point.Add(point0, new Vector(size.X * Math.Sin((2 * Math.PI / n) * (i + 1)), size.Y * Math.Cos((2 * Math.PI / n) * (i + 1)))));
            }

            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(star_pts[0], true, true);
                for (int i = 1; i < n; i++)
                {
                    ctx.LineTo(star_pts[i], true, false);
                }
            }
            geometry.Freeze();
            kt.DrawGeometry(Fill,Line, geometry);
        }
        public override string ConvertToSVG()
        {
            var n = 10;
            var geometry = new StreamGeometry();
            var size = Point.Subtract(points[0], points[1]);
            size = size / 2;
            var point0 = Point.Subtract(points[0], size);
            var star_pts = new List<Point>
            {
                Point.Add(point0, new Vector(size.X / 5 * 2 * Math.Sin((Math.PI / 180) * (360 / n)), size.Y / 5 * 2 * Math.Cos((Math.PI / 180) * (360 / n))))
            };
            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                    star_pts.Add(Point.Add(point0, new Vector(size.X / 5 * 2 * Math.Sin((2 * Math.PI / n) * (i + 1)), size.Y / 5 * 2 * Math.Cos((2 * Math.PI / n) * (i + 1)))));
                else
                    star_pts.Add(Point.Add(point0, new Vector(size.X * Math.Sin((2 * Math.PI / n) * (i + 1)), size.Y * Math.Cos((2 * Math.PI / n) * (i + 1)))));
            }
            var culture = new CultureInfo("en");
            var svg_points = string.Empty;
            for (var i = 0; i < n - 1; i++)
                svg_points += star_pts[i].X.ToString(culture) + "," + star_pts[i].Y.ToString(culture) + " ";
            svg_points += star_pts[n - 1].X.ToString(culture) + "," + star_pts[n - 1].Y.ToString(culture);
            var fill = ((SolidColorBrush)Fill).Color.ToString().Remove(1, 2);
            var stroke = ((SolidColorBrush)Line.Brush).Color.ToString().Remove(1, 2);
            var alpha = ((SolidColorBrush)Fill).Color.A / 255.0;

            return "<polygon points=\"" + svg_points + "\" fill-opacity=" + alpha.ToString(culture) + " style=\"fill:" + fill + ";stroke:" + stroke + ";stroke-width:" + Line.Thickness.ToString(culture) + "\"/>";
        }
    }
}



