using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace AirZPlayer.ViewModel
{
    class MusicInfo: ViewModelBase
    {
        private string _path;
        private string _name;
        private string _id;

        public string Path
        {
            set
            {
                if (_path != value)
                {
                    _path = value;
                    RaisePropertyChanged(nameof(Path));
                }
            }
            get
            {
                return _path;
            }
        }

        public string Title
        {
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
            get
            {
                return _name;
            }
        }

        public string Id
        {
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
            get
            {
                return _id;
            }
        }

    }
}
