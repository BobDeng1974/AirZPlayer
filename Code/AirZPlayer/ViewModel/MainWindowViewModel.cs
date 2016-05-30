﻿using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AirZPlayer.ViewModel
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