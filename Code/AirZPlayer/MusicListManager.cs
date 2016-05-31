using System;
using System.Collections.Generic;
using AirZPlayer.ViewModel;
using System.Collections.ObjectModel;
using libZPlay;

namespace AirZPlayer
{
    class MusicListManager
    {
        private static Lazy<MusicListManager> _instance = new Lazy<MusicListManager>(()=>new MusicListManager());
        public static MusicListManager Instance => _instance.Value;

        static MusicListManager()
        {
        }

        public List<MusicsGroup> LoadMusicList()
        {
            List<MusicsGroup> musicGroups = new List<MusicsGroup>();
            //TODO: 读取配置文件中歌曲列表信息
            ConfigManager.Instance.Load();
            ConfigManager.Instance.Config?.MusicList?.ForEach(musicLists =>
            {
                if(musicLists != null)
                {
                    var musicGroup = new MusicsGroup()
                    {
                        IsDefault = musicLists.IsDefault,
                        Name = musicLists.GroupName,
                        MusicInfos = new ObservableCollection<MusicInfo>()
                    };
                    musicLists.PathList.ForEach(path => 
                    {
                        //读取音乐信息
                        TID3Info info = new TID3Info();

                        if(MusicPlayer.Player.LoadFileID3(path, TStreamFormat.sfAutodetect, TID3Version.id3Version2, ref info))
                        {
                            musicGroup.MusicInfos.Add(new MusicInfo()
                            {
                                Id = Guid.NewGuid().ToString("N"),
                                Title = info.Title,
                                Path = path,
                            });
                        }
                    });
                    musicGroups.Add(musicGroup);
                }
            });

            return musicGroups;
        }
        public string CurrentPlayingMusicId { set; get; }

    }
}
