using Gra_PH_ine.Classes;
using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra_PH_ine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainCanvas.Children.Add(NotArtist.FgtHost);
        }

        private void MainCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            NotArtist.SelectedTool.MouseDown(e.GetPosition(MainCanvas));
            Invalidate();
        }
       
        private void Invalidate()
        {
            NotArtist.FgtHost.Clear();
            var dv = new DrawingVisual();
            var dc = dv.RenderOpen();
            foreach (Figure f in NotArtist.Figures)
            {
                f.Draw(dc);
            }
            dc.Close();
            NotArtist.FgtHost.Children.Add(dv);
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                NotArtist.SelectedTool.MouseMove(e.GetPosition(MainCanvas));
                Invalidate();
            }
        }
    }
}
