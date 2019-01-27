﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Gra_PH_ine.Figures
{
    public abstract class Figure
    {
        protected List<Point> points = new List<Point>();
        public  Figure()
        {
            
        }
        public Figure(Point point)
        {
            points = new List<Point>{point,point};
        }
        public virtual void Draw(DrawingContext kt)
        {

        }
        public virtual void AddPoint(Point p)
        {

        }
    }
}