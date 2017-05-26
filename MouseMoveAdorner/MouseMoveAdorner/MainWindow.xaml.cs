using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.JoshSmith.Controls.Utilities;

namespace MouseMoveAdorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SampleAdorner adorner;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (adorner == null)
            {
                adorner = new SampleAdorner(grid);
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(grid);
                layer.Add(adorner);
            }
            var pos = MouseUtilities.GetMousePosition(grid);
            adorner.SetOffsets(pos.X, pos.Y);
        }
    }
}
