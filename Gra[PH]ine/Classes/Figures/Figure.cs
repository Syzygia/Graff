using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Gra_PH_ine.Figures
{
    public  class Figure
    {
        public  List<Point> points { get; set; }
        //watch out
        public Figure()
        {
            
        }
        public Figure(Point point)
        {
            points = new List<Point>{point,point};
        }
        public virtual Figure Clone()
        {
            return new Figure();
            
        }
        public virtual void Draw(DrawingContext kt)
        {

        }
        public virtual void AddPoint(Point p)
        {

        }

        public Brush Fill { get; set; }
        public Pen Line;
    }
}
