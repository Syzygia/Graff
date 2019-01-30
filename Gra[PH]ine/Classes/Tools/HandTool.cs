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
                    
                        //Double ScaleRateX = NotArtist.CanvasWidth / Math.Abs(NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].X - NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].X);
                        //Double ScaleRateY = NotArtist.CanvasHeigth / (Math.Abs(NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].Y - NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].Y));

                        //if (ScaleRateX > ScaleRateY)
                        //{
                        //    NotArtist.ScaleRate = ScaleRateX;
                        //}
                        //else
                        //{
                        //    NotArtist.ScaleRate = ScaleRateY;
                        //}

                        if (NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].X > NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].X)
                        {
                            NotArtist.DistanceToPointX = NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].X;
                        }
                        else
                        {
                            NotArtist.DistanceToPointX = NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].X;
                        }

                        if (NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].Y > NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].Y)
                        {
                            NotArtist.DistanceToPointY = NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].Y;
                        }
                        else
                        {
                            NotArtist.DistanceToPointY = NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].Y;
                            //}
                            //NotArtist.DistanceToPointY = (lastPos.Y - p.Y);
                            //NotArtist.DistanceToPointX = (lastPos.X - p.X);
                        }
                    }
                    
                    //MainWindow.appWindow.ScrollViewerCanvas.ScrollToVerticalOffset(NotArtist.HandScrollX);
                    //MainWindow.appWindow.ScrollViewerCanvas.ScrollToHorizontalOffset(NotArtist.HandScrollY);
                    // NotArtist.delta = Point.Subtract(lastPos, p);
                    //   MainWindow.appWindow.Set_Offset(NotArtist.delta.X / 500, NotArtist.delta.Y / 500);
                    //lastPos = p;


            
            }
        }
        public override void MouseUp(Point p)
        {
            NotArtist.Figures.Remove(NotArtist.Figures[NotArtist.Figures.Count - 1]);
        }
    }
}

