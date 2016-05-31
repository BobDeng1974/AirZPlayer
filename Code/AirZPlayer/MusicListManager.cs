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
        private MusicListManager()
        { }

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
                        MusicInfos = new ObservableCollection<MusicInfoViewModel>()
                    };
                    musicLists.MusicInfos.ForEach(musicInfo => 
                    {
                        musicGroup.MusicInfos.Add(musicInfo.ToVM());
                    });
                    musicGroups.Add(musicGroup);
                }
            });

            return musicGroups;
        }

        public void AddMusicList(string strGroupName, bool isDefault, List<string> pathList)
        {

        }
        public string CurrentPlayingMusicId { set; get; }

    }
}
