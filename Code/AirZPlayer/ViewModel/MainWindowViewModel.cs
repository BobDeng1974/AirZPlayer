using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AirZPlayer
{
    internal class MainWindowViewModel: ViewModelBase
    {
        public ReadOnlyObservableCollection<MusicsGroup> MusicList => MusicListManager.Instance.MusicList;
        public ObservableCollection<MusicsGroup> CurrentMusicList
        {
            get
            {
                return _currentMusicList;
            }
            set
            {
                _currentMusicList = value;
                RaisePropertyChanged(nameof(CurrentMusicList));
            }
        }
        ObservableCollection<MusicsGroup> _currentMusicList;

        public FileDropHandler CustomDropHandler { get; set; }

    }
}
