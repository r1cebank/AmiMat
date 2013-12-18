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
using System.Windows.Threading;
using System.Drawing;
using System.IO;

using Amimat.Core;
using Amimat.Player;
using Amimat.Util;

namespace Overlay_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AMTPackage Package = null;
        AMTActionPlayer CurrentAction = null;
        DispatcherTimer Timer = null;
        public MainWindow()
        {
            InitializeComponent();
            Package = new AMTPackage();
            AMTUtil.OpenProject(Package, AMTUtil.GetAbsPath(Directory.GetCurrentDirectory(), "AMT.amf"));
            //Set current action
            CurrentAction = new AMTActionPlayer(AMTUtil.GetActionFromName(Package.Animation, "null"));
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(30);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            this.MouseDown += Window_MouseDown;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            AMTFrame f = CurrentAction.GetNextFrame();
            Idisplay.Source = AMTUtil.BytesToImageSource(Package.Frames[f.FrameRef]);
            Timer.Interval = TimeSpan.FromMilliseconds(f.Delay);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
