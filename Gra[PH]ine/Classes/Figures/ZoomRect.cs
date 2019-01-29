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
    class ZoomRect : Figure
    {
        public ZoomRect()
        {

        }
        public ZoomRect(Point p) : base(p)
        {
            
        }
        public override Figure Clone()
        {
            return new ZoomRect
            {
                points = new List<Point>(points),
                Fill = this.Fill,
                Line = this.Line
            };
            
        }

        public override void Draw(DrawingContext drawingContext)
        {
            var diagonal = Point.Subtract(points[0], points[1]);
            drawingContext.DrawRectangle(null, new Pen(Brushes.Black, 2) { DashStyle = DashStyles.Dash }, new Rect(points[1], diagonal));
        }

        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
    }
}
