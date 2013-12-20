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
        AMTActionPlayer CurrentAction = null, Default = null;
        DispatcherTimer Timer = null;
        public MainWindow()
        {
            InitializeComponent();
            Package = new AMTPackage();
            bool result = AMTUtil.OpenProject(Package, AMTUtil.GetAbsPath(Directory.GetCurrentDirectory(), "AMT.amf"));
            //Set current action
            Default = new AMTActionPlayer(Package.Animation, AMTUtil.GetActionFromName(Package.Animation, "test1"));
            CurrentAction = Default;
            if (result)
            {
                Timer = new DispatcherTimer();
                Timer.Interval = TimeSpan.FromMilliseconds(10);
                Timer.Tick += Timer_Tick;
                Timer.Start();
                this.MouseDoubleClick += MainWindow_MouseDoubleClick;
            }
            else
            {
                MessageBox.Show("Do you have project file in same directory?", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                System.Environment.Exit(0);
            }
            this.MouseDown += Window_MouseDown;
        }

        void MainWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Timer.Interval = TimeSpan.FromMilliseconds(10);
            CurrentAction = new AMTActionPlayer(Package.Animation, AMTUtil.GetActionFromName(Package.Animation, "moveRibbon"));
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            AMTFrame f = CurrentAction.GetNextFrameWithRandomness();
            Console.WriteLine("Delay: {0}", f.Delay);
            if (CurrentAction.GetLoopTime() > 1)
                CurrentAction = Default;
            IMainDisplay.Source = AMTUtil.BytesToImageSource(Package.Frames[f.FrameRef]);
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
