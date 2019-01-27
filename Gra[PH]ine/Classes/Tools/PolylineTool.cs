using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Gra_PH_ine.Classes.Tools
{
    class PolylineTool:Tool
    {
       Polyline myPolyline = new Polyline();

        public override void MouseDown(Point p)
        {
         //   NotArtist.Figures.Add(myPolyline);
        }

        public override void MouseMove(Point p)
        {
            NotArtist.Figures[NotArtist.Figures.Count - 1].AddPoint(p);
        }

        public override void MouseUp(Point p)
        {
            // base.MouseUp(p);
        }
    }
}
