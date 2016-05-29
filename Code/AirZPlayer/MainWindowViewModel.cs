using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AirZPlayer
{
    class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<MusicInfo> _musicList = new ObservableCollection<MusicInfo>();
        public ObservableCollection<MusicInfo> MusicList
        {
            set
            {
                if (_musicList != value)
                {
                    _musicList = value;
                    RaisePropertyChanged(nameof(MusicList));
                }
            }
            get
            {
                return _musicList;
            }
        }

        public ICommand Pause { set; get; }
        public ICommand Stop { set; get; }
        public ICommand Play { set; get; }
    }
}
