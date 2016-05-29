using libZPlay;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var musics = MusicListManager.Instance.LoadMusicList();

                musics.ForEach(musicItem =>
                {
                    Dispatcher.BeginInvoke(new Action(()=>
                    {
                        _vm.MusicList.Add(musicItem);

                        if (!string.IsNullOrWhiteSpace(musicItem.Id) && MusicListManager.Instance.CurrentPlayingMusicId == musicItem.Id)
                        {
                            //TODO: Play current music

                        }
                    }));
                });
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
                if (Player.OpenFile(musicItem.Path, TStreamFormat.sfAutodetect))
                {
                    Player.StartPlayback();
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
        public ZPlay Player => _player.Value;
        MainWindowViewModel _vm = new MainWindowViewModel();
        Lazy<ZPlay> _player = new Lazy<ZPlay>(()=>new ZPlay());
        Lazy<MusicListWindow> _musicListWindow = new Lazy<MusicListWindow>(()=>new MusicListWindow());
    }
}
