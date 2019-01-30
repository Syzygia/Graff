using Gra_PH_ine.Classes.Figures;
using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gra_PH_ine.Classes.Tools
{
    class ZoomTool:Tool
    {
        public override void MouseDown(Point point)
        {
            pressed = true;
            NotArtist.Figures.Add(new ZoomRect(point));
        }

        public override void MouseMove(Point p)
        {
            if (pressed)
                NotArtist.Figures[NotArtist.Figures.Count - 1].AddPoint(p);
        }
        public override void MouseStop()
        {
            if (pressed)
            {
                pressed = false;
                if(NotArtist.Figures.Count!=0)
                    NotArtist.Figures.Remove(NotArtist.Figures[NotArtist.Figures.Count - 1]);
            }

        }

        public override void MouseUp(Point point)
        {            
            pressed = false;
            if (Point.Subtract(NotArtist.Figures[NotArtist.Figures.Count - 1].points[0], NotArtist.Figures[NotArtist.Figures.Count - 1].points[1]).Length > 50)
            {               
               Double ScaleRateX = NotArtist.CanvasWidth / Math.Abs(NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].X - NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].X);
               Double ScaleRateY = NotArtist.CanvasHeigth / (Math.Abs(NotArtist.Figures[NotArtist.Figures.Count - 1].points[1].Y - NotArtist.Figures[NotArtist.Figures.Count - 1].points[0].Y));              

                if (ScaleRateX > ScaleRateY)
                {
                    NotArtist.ScaleRate = ScaleRateX;
                }
                else
                {
                    NotArtist.ScaleRate = ScaleRateY;
                }

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
                }
            }
            else
            {
                NotArtist.ScaleRate = 1;
                NotArtist.DistanceToPointY = 0;
                NotArtist.DistanceToPointX = 0;
            }
            NotArtist.Figures.Remove(NotArtist.Figures[NotArtist.Figures.Count - 1]);
        }
            
            
            
        }
    }

