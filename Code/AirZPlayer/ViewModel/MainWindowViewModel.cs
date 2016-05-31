using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AirZPlayer.ViewModel
{
    class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<MusicInfoViewModel> _musicList = new ObservableCollection<MusicInfoViewModel>();
        public ObservableCollection<MusicInfoViewModel> MusicList
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
        public FileDropHandler CustomDropHandler { get; set; }

    }
}
