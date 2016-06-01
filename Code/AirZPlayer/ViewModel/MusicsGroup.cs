using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirZPlayer
{
    internal class MusicsGroup : ViewModelBase
    {
        private string _groupName;
        private bool _isDefault;
        private ObservableCollection<MusicInfoViewModel> _musicInfos;

        public string GroupName
        {
            get
            {
                return _groupName;
            }

            set
            {
                if (_groupName != value)
                {
                    _groupName = value;
                    RaisePropertyChanged(nameof(GroupName));
                }
            }
        }

        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }

            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    RaisePropertyChanged(nameof(IsDefault));
                }
            }
        }

        public ObservableCollection<MusicInfoViewModel> MusicInfos
        {
            get
            {
                return _musicInfos ?? (_musicInfos = new ObservableCollection<MusicInfoViewModel>());
            }

            set
            {
                if (_musicInfos != value)
                {
                    _musicInfos = value;
                    if (value == null)
                    {
                        _musicInfos = new ObservableCollection<MusicInfoViewModel>();
                    }
                    RaisePropertyChanged(nameof(MusicInfos));
                }
            }
        }
    }
}
