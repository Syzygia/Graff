using Gra_PH_ine.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Gra_PH_ine.Figures

{
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Polyline))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(RoundRect))]
    [XmlInclude(typeof(Star))]
    [XmlInclude(typeof(SolidColorBrush))]
    [XmlInclude(typeof(MatrixTransform))]

    [Serializable]
    public  class Figure// this one is dangerous
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
        public virtual string ConvertToSVG()
        {
            return "";
        }
        public Brush Fill { get; set; }
        public Pen Line;
    }
}
