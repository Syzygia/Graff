using Gra_PH_ine.Classes.Tools;
using Gra_PH_ine.Figures;
using System.Collections.Generic;

namespace Gra_PH_ine.Classes
{
    public static class NotArtist
    {
        public static List<Figure> Figures = new List<Figure>();

        public static List<Tool> Tools = new List<Tool>() { new LineTool() };

        public static Tool SelectedTool = Tools[1];

        public static FgtHost FgtHost = new FgtHost();
        // public static List<Colors> color = new List<Colors>();

    }
}
