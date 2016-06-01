using libZPlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirZPlayer
{
    internal class MusicInfoViewModel : MusicInfo
    {
        bool _isLost;
        bool _isSelected;

        public MusicInfoViewModel() : base() { }
        public MusicInfoViewModel(TID3Info info) : base(info) { }

        public bool IsLost
        {
            get
            {
                return _isLost;
            }

            set
            {
                _isLost = value;
                RaisePropertyChanged(nameof(IsLost));
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
    }
}
