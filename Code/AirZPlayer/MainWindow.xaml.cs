using libZPlay;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using AirZPlayer.ViewModel;
using System.Linq;
using System.Collections.Generic;

namespace AirZPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitCommand();
            DataContext = _vm;

            Loaded += MainWindow_Loaded;
            UpdateMusicInfo();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _musicListWindow.Value.Owner = this;
            _musicListWindow.Value.DataContext = _vm;
            _musicListWindow.Value.Show();
        }

        private void InitCommand()
        {
            _vm.Play = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<MusicInfoViewModel>(musicItem => 
            {
                try
                {
                    MusicPlayer.Play(musicItem);
                }
                catch (MusicPlayException)
                {
                    musicItem.IsLost = true;
                    Message($"无法播放{musicItem?.Path}");
                }
            });
            _vm.CustomDropHandler = new FileDropHandler();
        }

        public void UpdateMusicInfo()
        {
             MusicListManager.Instance.LoadMusicList().ContinueWith(t=> 
             {
                 if (t.IsFaulted)
                 {
                     Message($"加载音乐列表错误：{t.Exception.HResult:X}");
                 }
             });
        }
        

        private void Message(string msg)
        {
            Debug.WriteLine(msg);
        }
        MainWindowViewModel _vm = new MainWindowViewModel();
        Lazy<MusicListWindow> _musicListWindow = new Lazy<MusicListWindow>(()=>new MusicListWindow());
    }
}
