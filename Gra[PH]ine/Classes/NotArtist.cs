
using System.Collections.Generic;
using Gra_PH_ine.Classes.Tools;
using Gra_PH_ine.Figures;

namespace Gra_PH_ine.Classes
{
    public static class NotArtist
    {
        public static List<Figure> Figures = new List<Figure>();

        public static List<Gra_PH_ine.Classes.Tools.Tool> Tools = new List<Tool>() { new LineTool(),new RectTool(),new EllipseTool(),new RoundRectTool(),new StarTool(),new PolylineTool()};

        public static Tool SelectedTool = Tools[5];

        public static FgtHost FgtHost = new FgtHost();
    }
}
