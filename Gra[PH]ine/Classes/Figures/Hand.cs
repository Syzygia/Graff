using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using Gra_PH_ine.Classes;
using Gra_PH_ine.Classes.Figures;

namespace Gra_PH_ine.Figures
{
    public class Hand : Figure
    {

        public Hand()
        {

        }
        public override Figure Clone()
        {
            return new Line
            {
                points = new List<Point>(points),
                Fill = this.Fill,
                Line = this.Line
            };
        }
        public Hand(Point p) : base(p)
        {
            Fill = null;
            Line = null;
        }
        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
        public override void Draw(DrawingContext kt)
        {
            //kt.DrawLine(Line, points[0], points[1]);
        }
        public override string ConvertToSVG()
        {
            return "";
        }
    }
}
