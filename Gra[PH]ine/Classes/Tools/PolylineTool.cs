using Gra_PH_ine.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Gra_PH_ine.Classes.Tools
{
    class PolylineTool:Tool
    {
       

        public override void MouseDown(Point p)
        {
            pressed = true;
            NotArtist.Figures.Add(new Polyline(p));
        }

        public override void MouseMove(Point p)
        {
            if (pressed)
                NotArtist.Figures[NotArtist.Figures.Count - 1].AddPoint(p);
        }

        public override void MouseUp(Point p)
        {
            // base.MouseUp(p);
        }
    }
}
