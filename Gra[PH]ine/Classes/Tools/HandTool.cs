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
        private Point lastPos;
        public override void MouseDown(Point p)
        {
            pressed = true;
            lastPos = p;
            NotArtist.delta = Point.Subtract(lastPos, p);
        }

        public override void MouseMove(Point p)
        {
            if (pressed)
            {
               NotArtist.HandScrollX = p.X;
                NotArtist.HandScrollY = p.Y;
                MainWindow.appWindow.ScrollViewerCanvas.ScrollToVerticalOffset(NotArtist.HandScrollX);
                MainWindow.appWindow.ScrollViewerCanvas.ScrollToHorizontalOffset(NotArtist.HandScrollY);
                // NotArtist.delta = Point.Subtract(lastPos, p);
                //   MainWindow.appWindow.Set_Offset(NotArtist.delta.X / 500, NotArtist.delta.Y / 500);
                lastPos = p;
            }
        }

        public override void MouseUp(Point p)
        {
            // base.MouseUp(p);
        }
    }
}

