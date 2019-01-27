using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
namespace Gra_PH_ine.Figures
{
    public class Line:Figure
    {
        
        public Line()
        {
           
        }
        public Line(Point p) : base(p)
        {

        }
        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
        public override void Draw (DrawingContext kt)
        {
            kt.DrawLine(new Pen(Brushes.Black, 4), points[0], points[1]);
        }
    }
}
