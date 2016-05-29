using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirZPlayer
{
    class MusicListManager
    {
        private static Lazy<MusicListManager> _instance = new Lazy<MusicListManager>(()=>new MusicListManager());
        public static MusicListManager Instance => _instance.Value;

        public List<MusicInfo> LoadMusicList()
        {
            //TODO: 读取配置文件中歌曲列表信息
            return new List<MusicInfo>()
            {
                new MusicInfo()
                {
                    Name="aaa",
                    Path=@"G:\download\T. Swift.1989 Deluxe-2014\01 Welcome To New York.flac"
                },
                new MusicInfo()
                {
                    Name = "bbb",
                    Path = @"G:\download\T. Swift.1989 Deluxe-2014\02 Blank Space.flac",
                }
            };
        }
        public string CurrentPlayingMusicId { set; get; }

    }
}
