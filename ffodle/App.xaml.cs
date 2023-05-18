using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Interop;

namespace ffodle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create and show the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }

}
