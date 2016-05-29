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
    }
}
