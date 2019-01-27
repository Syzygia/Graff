using System.Windows;
using System.Windows.Media;

namespace Gra_PH_ine.Classes
{
    public class FgtHost : FrameworkElement
    {
        public VisualCollection Children;

        public FgtHost()
        {
            Children = new VisualCollection(this);
        }

        protected override Visual GetVisualChild(int index)
        {
            return Children[index];
        }

        protected override int VisualChildrenCount => Children.Count;

        public void Clear()
        {
            Children.Clear();
        }
    }
}
