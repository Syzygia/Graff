using Gra_PH_ine.Classes;
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
    class Polyline:Figure
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
}
}