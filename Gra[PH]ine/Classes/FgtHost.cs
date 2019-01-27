using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Gra_PH_ine.Figures
{
    public class FgtHost: FrameworkElement
    {
        public VisualCollection Children;
        public FgtHost()
        {
            Children = new VisualCollection(this);
        }
        protected override Visual GetVisualChild(int index)
        {
            return base.GetVisualChild(index);
        }
        protected override int VisualChildrenCount => base.VisualChildrenCount;
        public void Clear()
        {
            Children.Clear();
        }

    }
}
