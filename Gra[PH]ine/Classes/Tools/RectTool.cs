using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Gra_PH_ine.Classes.Figures;
using Gra_PH_ine.Classes.Tools;

namespace Gra_PH_ine.Classes.Tools
{
    class RectTool:Tool
    {
        public override void MouseDown(Point p)
        {
            pressed = true;
            NotArtist.Figures.Add(new Rectangle(p));
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
