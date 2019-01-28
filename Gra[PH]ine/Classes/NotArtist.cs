
using System.Collections.Generic;
using System.Windows.Media;
using Gra_PH_ine.Classes.Tools;
using Gra_PH_ine.Figures;

namespace Gra_PH_ine.Classes
{
    public static class NotArtist
    {
        public static List<Figure> Figures = new List<Figure>();

        public static List<Gra_PH_ine.Classes.Tools.Tool> Tools = new List<Tool>() { new LineTool(),new RectTool(),new EllipseTool(),new RoundRectTool(),new StarTool(),new PolylineTool(), new FakeTool()};

        public static Tool SelectedTool = Tools[5];

        public static FgtHost FgtHost = new FgtHost();
        public static Brush SelectedFill = Brushes.White;
        public static Pen SelectedLine = new Pen(Brushes.Black, 4);
    }
}
