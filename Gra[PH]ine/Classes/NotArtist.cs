
using System.Collections.Generic;
using System.Windows.Media;
using Gra_PH_ine.Classes.Tools;
using Gra_PH_ine.Figures;

namespace Gra_PH_ine.Classes
{
    public static class NotArtist
    {
        public static List<Figure> Figures = new List<Figure>();

        public static List<Gra_PH_ine.Classes.Tools.Tool> Tools = new List<Tool>() { new LineTool(),new RectTool(),new EllipseTool(),new RoundRectTool(),new StarTool(),new PolylineTool(),
            new ZoomTool(), new FakeTool()};

        public static Tool SelectedTool = Tools[5];

        public static FgtHost FgtHost = new FgtHost();
        public static Brush SelectedFill = Brushes.White;
        public static Pen SelectedLine = new Pen(Brushes.Black, 4);
        public static double ScaleRateX = 1;
        public static double ScaleRateY = 1;
        public static double DistanceToPointX;
        public static double DistanceToPointY;
        public static double HandScrollX;
        public static double HandScrollY;
        public static double CanvasWidth;
        public static double CanvasHeigth;
        public static List<List<Figure>> ConditionsCanvas = new List<List<Figure>>();
        public static int ConditionNumber = 0;

        public static void AddCondition()
        {
            List<Figure> figuresNow = new List<Figure>(Figures);
            foreach (Figure figure in Figures)
            {
                figuresNow.Add(figure.Clone());
            }
            ConditionsCanvas.Add(figuresNow);
            ConditionNumber++;
            if (ConditionNumber != ConditionsCanvas.Count)
            {
                ConditionsCanvas.RemoveRange(ConditionNumber - 1, ConditionsCanvas.Count - ConditionNumber);
            }
            Figures.Clear();
            foreach (Figure figure in figuresNow)
            {
                Figures.Add(figure.Clone());
            }
            //  Figures =new List<Figure>(figuresNow);
            //foreach (Figure figure in ConditionsCanvas[ConditionNumber - 1])
            //{
            //    figure.Select = false;
            //    figure.SelectRect = null;
            //}
            //if (ConditionsCanvas.Count > 1)
            //{
            //    foreach (Figure figure in ConditionsCanvas[ConditionNumber - 2])
            //    {
            //        figure.Select = false;
            //        figure.SelectRect = null;
            //    }
            //}
        }
        public static void GotoPastCondition()
        {
            if (ConditionNumber != 1)
            {
                ConditionNumber--;
                Figures.Clear();
                foreach (Figure figure in ConditionsCanvas[ConditionNumber - 1])
                {
                    Figures.Add(figure.Clone());
                }
            }
        }

        public static void GotoSecondCondition()
        {
            if (ConditionNumber != ConditionsCanvas.Count)
            {
                ConditionNumber++;
                Figures.Clear();
                foreach (Figure figure in ConditionsCanvas[ConditionNumber - 1])
                {
                    Figures.Add(figure.Clone());
                }
            }
        }
    }
}
