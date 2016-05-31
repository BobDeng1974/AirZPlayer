using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libZPlay;

namespace AirZPlayer
{
    internal class MusicPlayer
    {
        //private static Lazy<MusicListManager> _instance = new Lazy<MusicListManager>(() => new MusicListManager());
        //public static MusicListManager Instance => _instance.Value;

        private static Lazy<ZPlay> _playerInstance = new Lazy<ZPlay>(()=>new ZPlay());
        public static ZPlay Player => _playerInstance.Value;

        private MusicPlayer() { }

        public static MusicInfo GetMusicInfo(string path)
        {
            //读取音乐信息
            TID3Info info = new TID3Info();

            if (Player.LoadFileID3(path, TStreamFormat.sfAutodetect, TID3Version.id3Version2, ref info))
            {
                return new MusicInfo()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Title = info.Title,
                    Path = path,
                };
            }

            return null;
        }

        public static void Play(MusicInfo musicInfo)
        {
            if (Player.OpenFile(musicInfo.Path, TStreamFormat.sfAutodetect))
            {
                Player.StartPlayback();
            }
            else
            {
                throw new MusicPlayException();
            }
        }
            
    }
}
