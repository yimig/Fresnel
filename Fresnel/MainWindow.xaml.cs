using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using System.Windows.Interop;

namespace Fresnel
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool moveMode = false;
        private Point mousePoint = new Point(0, 0);

        public MainWindow()
        {
            InitializeComponent();
            mybrower.Address = AppDomain.CurrentDomain.BaseDirectory + @"UI\index.html";

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void GdTitle_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveMode = true;
            mousePoint = e.GetPosition(this);
        }

        private void GdTitle_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (moveMode)
            {
                this.Left = this.Left + (e.GetPosition(this).X - mousePoint.X);
                this.Top = this.Top + (e.GetPosition(this).Y - mousePoint.Y);
            }
        }

        private void GdTitle_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            moveMode = false;
        }

        private void GdTitle_OnMouseLeave(object sender, MouseEventArgs e)
        {
            moveMode = false;
        }

        private void BtnMenu_OnInitialized(object sender, EventArgs e)
        {
            this.btnMenu.ContextMenu = null;
        }

        private void BtnMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.contextMenu.PlacementTarget = this.btnMenu;
            this.contextMenu.IsOpen = true;
        }

        private void BtnMinisize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MiRefurbish_OnClick(object sender, RoutedEventArgs e)
        {
            mybrower.Reload(false);
        }

        private void MiConsole_OnClick(object sender, RoutedEventArgs e)
        {
            var wininfo = new WindowInfo();
            wininfo.SetAsPopup(new WindowInteropHelper(this).Handle, "DevTools");
            mybrower.ShowDevTools(wininfo);
        }

        private void MiLog_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MiAbout_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
