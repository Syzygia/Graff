using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
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

         }      
 }

