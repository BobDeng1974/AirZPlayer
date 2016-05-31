using System;
using System.Collections.Generic;
using AirZPlayer.ViewModel;
using System.Collections.ObjectModel;
using libZPlay;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace AirZPlayer
{
    class MusicListManager: ViewModelBase
    {
        private static Lazy<MusicListManager> _instance = new Lazy<MusicListManager>(()=>new MusicListManager());
        public static MusicListManager Instance => _instance.Value;

        static MusicListManager()
        {
        }
        private MusicListManager()
        {
            _realonlyMusicList = new ReadOnlyObservableCollection<MusicsGroup>(_musicList);
        }

        public ReadOnlyObservableCollection<MusicsGroup> _realonlyMusicList;

        private ObservableCollection<MusicsGroup> _musicList = new ObservableCollection<MusicsGroup>();
        public ReadOnlyObservableCollection<MusicsGroup> MusicList => _realonlyMusicList;

        public Task LoadMusicList()
        {
            return Task.Run(()=>
            {
                //List<MusicsGroup> musicGroups = new List<MusicsGroup>();
                //读取配置文件中歌曲列表信息
                ConfigManager.Instance.Load();
                ConfigManager.Instance.Config?.MusicList?.ForEach(musicLists =>
                {
                    if(musicLists != null)
                    {
                        var musicGroup = new MusicsGroup()
                        {
                            IsDefault = musicLists.IsDefault,
                            Name = musicLists.GroupName,
                            MusicInfos = new ObservableCollection<MusicInfoViewModel>()
                        };
                        musicLists.MusicInfos.ForEach(musicInfo => 
                        {
                            musicGroup.MusicInfos.Add(musicInfo.ToVM());
                        });

                        App.Current.Dispatcher.BeginInvoke(new Action(()=> 
                        {
                            _musicList.Add(musicGroup);
                        }));
                    }
                });
            });
        }

        public Task AddMusicList(string strGroupName, bool isDefault, List<string> pathList)
        {
            return Task.Run(() => 
            {
                if (ConfigManager.Instance.Config?.MusicList == null)
                {
                    return;
                }
                var vmGroup = _musicList.ToList().Where(g => isDefault ? g.IsDefault : g.Name.Equals(strGroupName)).FirstOrDefault();
                var group = ConfigManager.Instance.Config?.MusicList?.Where(g => isDefault ? g.IsDefault : g.GroupName.Equals(strGroupName)).FirstOrDefault();

                Debug.Assert((group == null && vmGroup == null) || (group != null && vmGroup != null));
                if (vmGroup == null)
                {
                    vmGroup = new MusicsGroup()
                    {
                        Name = strGroupName,
                        IsDefault = isDefault,
                    };
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        _musicList.Add(vmGroup);
                    });
                }

                if (group != null)
                {
                    //在现有组上增加
                    if (group.MusicInfos == null)
                    {
                        group.MusicInfos = new List<MusicInfo>();
                    }
                }
                else
                {
                    //新增分组
                    group = new MusicDirectoryInfo()
                    {
                        GroupName = strGroupName,
                        IsDefault = isDefault,
                        MusicInfos = new List<MusicInfo>()
                    };
                    ConfigManager.Instance.Config.MusicList.Add(group);
                }

                pathList.ForEach(path =>
                {
                    var musicInfo = MusicPlayer.GetMusicInfo(path);
                    if (musicInfo != null)
                    {
                        group.MusicInfos.Add(musicInfo);

                        //增加到viewmodel
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            vmGroup.MusicInfos.Add(musicInfo.ToVM());
                        }));
                    }
                });
            });
            
        }
        public string CurrentPlayingMusicId { set; get; }

    }
}
