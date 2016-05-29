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
            Task.Run(() =>
            {
                var musicGroups = MusicListManager.Instance.LoadMusicList();
                var musics = (musicGroups.FirstOrDefault()??new MusicsGroup()).MusicInfos;
                if (musics != null)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _vm.MusicList = musics;
                    }));
                }

            });
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _musicListWindow.Value.Owner = this;
            _musicListWindow.Value.DataContext = _vm;
            _musicListWindow.Value.Show();
        }

        private void InitCommand()
        {
            _vm.Play = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<MusicInfo>(musicItem => 
            {
                if (MusicPlayer.Player.OpenFile(musicItem.Path, TStreamFormat.sfAutodetect))
                {
                    MusicPlayer.Player.StartPlayback();
                }
                else
                {
                    Message($"无法打开:{musicItem.Path}");
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
