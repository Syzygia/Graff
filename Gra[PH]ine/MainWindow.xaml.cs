using Gra_PH_ine.Classes;
using Gra_PH_ine.Classes.Tools;
using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public static MainWindow appWindow;
        public MainWindow()
        {
            appWindow = this;
            InitializeComponent();
            NotArtist.AddCondition();
            MainCanvas.Children.Add(NotArtist.FgtHost);
            for (int i = 0; i < NotArtist.Tools.Count-1; i++)//Creating Tool button
            {
                string st = "../icons/" + NotArtist.Tools[i].GetType().Name + ".png";
                ImageBrush img = new ImageBrush();
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(st, UriKind.Relative);
                bi3.EndInit();
                img.ImageSource = bi3;
                Button btn = new Button();
                Panel.Children.Add(btn);
                btn.BorderBrush = Brushes.Black;
                btn.Name = "btn" + i;
                btn.Height = 30;
                btn.Width = 40;
                btn.SetValue(Grid.RowProperty, 1);
                btn.SetValue(Grid.ColumnProperty, i);
                btn.Background = img;
                btn.Content = "";
                btn.Tag = i;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.Click += new RoutedEventHandler(Tool_Click);
            }
            Brush[] colors =                //palitte
            {
                Brushes.Crimson,Brushes.Maroon,Brushes.DeepPink,Brushes.DarkOrange,Brushes.Yellow,Brushes.Fuchsia,Brushes.BlueViolet,Brushes.Indigo,Brushes.Lime,Brushes.Teal,
                Brushes.Aqua,Brushes.LightCyan,Brushes.Blue,Brushes.Navy,Brushes.Ivory,Brushes.Black,

            };
            int j = 0;
            foreach (var brush in colors)    //button of palette (fill color)
            {
                Button newButton = new Button()
                {
                    Width = 20,
                    Height = 20,
                    Background = brush,
                    Tag = brush
                };
                newButton.SetValue(Grid.RowProperty, j);
                newButton.SetValue(Grid.ColumnProperty, 1);
                j++;
                 newButton.Click += new RoutedEventHandler(ButtonFill_Click);
                Palette.Children.Add(newButton);

            }
            j = 0;
            foreach (var brush in colors)     //button of palette (line collor)
            {
                Button newButton = new Button()
                {
                    Width = 20,
                    Height = 20,
                    Background = brush,
                    Tag = brush
                };
                newButton.SetValue(Grid.ColumnProperty, 0);
                newButton.SetValue(Grid.RowProperty, j);
                j++;
                 newButton.Click += new RoutedEventHandler(ButtonLine_Click);
                Palette.Children.Add(newButton);

            }
        }
        private void ButtonFill_Click(object sender, RoutedEventArgs e)
        {
            NotArtist.SelectedFill = (sender as Button).Tag as Brush;
        }
        private void ButtonLine_Click(object sender, RoutedEventArgs e)  
        {
            NotArtist.SelectedLine = new Pen((sender as Button).Background, 2.0);           
        }
        private void Tool_Click(object sender, RoutedEventArgs e) 
        {
            NotArtist.SelectedTool = NotArtist.Tools[Convert.ToInt32((sender as Button).Tag)];
            
        }

        private void MainCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            NotArtist.SelectedTool.MouseDown(e.GetPosition(MainCanvas));
            Invalidate();
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                NotArtist.SelectedTool.MouseMove(e.GetPosition(MainCanvas));
                if (NotArtist.SelectedTool == NotArtist.Tools[7])
                {
                 //   ScrollViewerCanvas.ScrollToVerticalOffset(NotArtist.HandScrollX);
                  //  ScrollViewerCanvas.ScrollToHorizontalOffset(NotArtist.HandScrollY);
                }

                    Invalidate();
            }
        }
        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
           // NotArtist.AddCondition();
            NotArtist.SelectedTool.MouseStop();          
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
        private void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            NotArtist.CanvasHeigth = MainCanvas.ActualHeight;
            NotArtist.CanvasWidth = MainCanvas.ActualWidth;
        }

        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            NotArtist.CanvasHeigth = MainCanvas.ActualHeight;
            NotArtist.CanvasWidth = MainCanvas.ActualWidth;
        }

        private void MainCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            NotArtist.AddCondition();
            NotArtist.SelectedTool.MouseUp(e.GetPosition(MainCanvas));
            if (NotArtist.SelectedTool==NotArtist.Tools[6])
            {
                MainCanvas.LayoutTransform = new ScaleTransform(NotArtist.ScaleRateX, NotArtist.ScaleRateY);
                ScrollViewerCanvas.ScrollToVerticalOffset(NotArtist.DistanceToPointY * NotArtist.ScaleRateY);
                ScrollViewerCanvas.ScrollToHorizontalOffset(NotArtist.DistanceToPointX * NotArtist.ScaleRateX);
            }
            Invalidate();
        }

        private void Goto_Past(object sender, RoutedEventArgs e)
        {
            NotArtist.GotoPastCondition();
            
            Invalidate();
        }

        private void GotoFuture(object sender, RoutedEventArgs e)
        {
            NotArtist.GotoSecondCondition();
            Invalidate();
        }
        public void Set_Offset(double X, double Y)
        {
            ScrollViewerCanvas.ScrollToVerticalOffset(NotArtist.DistanceToPointY * NotArtist.ScaleRateY);
            ScrollViewerCanvas.ScrollToHorizontalOffset(NotArtist.DistanceToPointX * NotArtist.ScaleRateX);
            // appWindow.ScrollViewerCanvas.InvalidateScrollInfo(X).VisualOffset += X;
            // ScrollBarY.Value += Y;
        }
    }
}
