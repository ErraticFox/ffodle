
using System;
using System.Windows;
using System.Windows.Input;
using ffodle.Hotkeys;
using System.IO;
using Microsoft.Toolkit.Uwp.Notifications;
using Application = System.Windows.Application;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using System.Threading;
using System.Text.RegularExpressions;
using Forms = System.Windows.Forms;
using System.Threading.Tasks;

namespace ffodle
{

    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly TrayIcon _trayIcon;
        private string outputFolder;
        private StringBuilder sb = new();
        private string progressPercent;
        private Process downloadProcess;

        public MainWindow()
        {
            InitializeComponent();

            GetDownloadFolder();

            DataContext = this;

            _trayIcon = new TrayIcon();

            HotkeysManager.SetupSystemHook();
            GlobalHotKey downloadHotkey = new GlobalHotKey(Forms.Keys.Control | Forms.Keys.Shift, Key.Z, HotkeyDownload);
            GlobalHotKey cancelHotkey = new GlobalHotKey(Forms.Keys.Control | Forms.Keys.Shift, Key.X, CancelDownload);
            HotkeysManager.AddHotkey(downloadHotkey);
            HotkeysManager.AddHotkey(cancelHotkey);
        }
        public string StreamText
        {
            get { return sb.ToString(); }
        }

        public string ProgressPercent
        {
            get { return progressPercent; }
        }

        private void GetDownloadFolder()
        {
            if (Properties.Settings.Default.Output == "")
            {
                outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), Forms.Application.ProductName);
            }
            else
            {
                outputFolder = Properties.Settings.Default.Output;
            }
        }

        private void HotkeyDownload()
        {
            DownloadVideo(true);
        }


        private void CancelDownload()
        {
            GenerateToast("Canceled Download");
            downloadProcess.Kill(true);
        }

        private void ButtonDownload(object sender, RoutedEventArgs e)
        {
            DownloadVideo();
        }

        private void DownloadVideo(bool clipboard = false)
        {
            sb.Clear();
            sb.Append("Starting Download...");
            OnPropertyChanged("StreamText");

            var ytdlp = Path.Combine(Forms.Application.StartupPath, "yt-dlp.exe");
            var fileName = "%(webpage_url_domain)s-%(uploader)s-%(id)s.%(ext)s";

            var url = clipboard ? Clipboard.GetText() : urlTextBox.Text;

            string[] argumentList = {
                "-f \"best[ext=mp4]\"",
                "--windows-filenames --print after_move:filepath",
                "--force-overwrites --progress",
                $"-o {Path.Join(outputFolder, fileName)} {url}"
            };


            downloadProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ytdlp,
                    Arguments = string.Join(" ", argumentList),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            downloadProcess.OutputDataReceived += (s, e) =>
            {

                var data = e.Data;
                var progressPattern = DownloadPercent();


                if (data != null)
                {
                    Match match = progressPattern.Match(data);

                    if (match.Success)
                    {
                        progressPercent = match.Groups[0].ToString();
                        OnPropertyChanged("ProgressPercent");

                    }
                }


                if (Path.Exists(data))
                {
                    GenerateToast("Video copied to clipboard");

                    Thread t = new Thread((ThreadStart)(() =>
                    {
                        StringCollection strColl = new()
                        {
                            data
                        };
                        Clipboard.SetFileDropList(strColl);
                    }));
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();

                    return;
                }

                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    sb.AppendLine(e.Data);
                    OnPropertyChanged("StreamText");
                }


            };
            downloadProcess.ErrorDataReceived += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    sb.AppendLine(e.Data);
                    OnPropertyChanged("StreamText");
                }
            };

            GenerateToast("Downloading video");
            downloadProcess.Start();
            downloadProcess.BeginErrorReadLine();
            downloadProcess.BeginOutputReadLine();

        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _trayIcon.notifyIcon.Dispose();
            HotkeysManager.ShutdownSystemHook();
        }


        private void DragBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).WindowState = WindowState.Minimized;
            GetWindow(this).ShowInTaskbar = false;
            GenerateToast("FFodle was minimized to the system tray.");
        }

        private void GenerateToast(string text)
        {
            Task.Run(() =>
            {
                new ToastContentBuilder().AddText(text).Show();
            });
        }

        public void Minimize_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void TextBlockStream_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            textBlockStream.Focus();
            textBlockStream.CaretIndex = textBlockStream.Text.Length;
            textBlockStream.ScrollToEnd();
        }

        private void SetDownloadFolder(object sender, RoutedEventArgs e)
        {
            var dialog = new Forms.FolderBrowserDialog();
            Forms.DialogResult result = dialog.ShowDialog();

            if (result == Forms.DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                Properties.Settings.Default.Output = selectedPath;
                Properties.Settings.Default.Save();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [GeneratedRegex("\\d+(?=\\.\\d+\\%)")]
        private static partial Regex DownloadPercent();

    }

}
