using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gra_PH_ine.Classes.Tools
{
    class FakeTool:Tool
    {
        public override void MouseDown(Point p)
        {
           // NotArtist.Figures.Add(new Star(p));
        }

        public override void MouseMove(Point p)
        {
          //  NotArtist.Figures[NotArtist.Figures.Count - 1].AddPoint(p);
        }

        public override void MouseUp(Point p)
        {
            // base.MouseUp(p);
        }
    }
}
