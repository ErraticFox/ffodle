using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace ffodle
{
    internal class TrayIcon
    {
        public NotifyIcon notifyIcon;

        public TrayIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Resources/windows.ico");
            notifyIcon.Visible = true;
            notifyIcon.MouseDown += notifyIcon_MouseDown;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Close", null, OnCloseClick);
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Application.Current.MainWindow.ShowInTaskbar = true;
                Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                Application.Current.MainWindow.Activate();
            }
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
