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
using System.Windows.Media.Animation;
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
            bool result = AMTUtil.OpenPackage(Package, AMTUtil.GetAbsPath(Directory.GetCurrentDirectory(), "AMT.apkg"));
            //Set current action
            Default = new AMTActionPlayer(Package.Animation, AMTUtil.GetDefaultAction(Package.Animation));
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
            CMainDisplay.Background = new ImageBrush(AMTUtil.BytesToImageSource(Package.Frames[f.FrameRef]));
            //Text(CTopLeft, 10, 100, "Timer Triggered", Color.FromRgb(0, 100, 100));
            Timer.Interval = TimeSpan.FromMilliseconds(f.Delay);
        }

        private void Text(Canvas canvas, double x, double y, string text, Color color)
        {

            TextBlock textBlock = new TextBlock();
            textBlock.Name = "Text";
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
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
