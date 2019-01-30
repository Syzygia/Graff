using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gra_PH_ine.Classes.Tools
{
    class HandTool:Tool
    {
       
        public override void MouseDown(Point p)
        {
            pressed = true;
            NotArtist.Figures.Add(new Hand(p));
        }

        public override void MouseMove(Point p)
        {
            if (pressed)
            {
                if (pressed)
                {
                    NotArtist.Figures[NotArtist.Figures.Count - 1].AddPoint(p);
                    NotArtist.DistanceToPointX += NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].X - NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].X;
                    NotArtist.DistanceToPointY += NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].Y - NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].Y;
                }            
            }
        }
        public override void MouseUp(Point p)
        {
            NotArtist.Figures.Remove(NotArtist.Figures[NotArtist.Figures.Count - 1]);
        }
    }
}

