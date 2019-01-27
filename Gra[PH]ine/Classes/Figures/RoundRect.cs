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
    class RoundRect:Figure
    {
        public RoundRect(Point p) : base(p)
        {

        }
        public override void AddPoint(Point p)
        {
            points[1] = p;
        }
        public override void Draw(DrawingContext dc)
        {           
            dc.DrawRoundedRectangle(new SolidColorBrush(Colors.Transparent), new Pen(Brushes.Black, 4),new Rect (points[0],points[1]),30,30 );
        }
    }
}
