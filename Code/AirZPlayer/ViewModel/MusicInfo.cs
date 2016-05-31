using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Runtime.Serialization;
using libZPlay;

namespace AirZPlayer
{
    [DataContract]
    class MusicInfo: ViewModelBase
    {
        private string _id;
        private string _path;
        private string _title;
        private string _argist;
        private string _album;
        private string _year;
        private string _comment;
        private string _track;
        private string _genre;

        public MusicInfo() { }
        public MusicInfo(TID3Info info)
        {
            _id = Guid.NewGuid().ToString("N");
            _path = "";
            _title = info.Title;
            _argist = info.Artist;
            _album = info.Album;
            _year = info.Year;
            _comment = info.Comment;
            _track = info.Track;
            _genre = info.Genre;
        }


        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public string Title
        {
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
            get
            {
                return _title;
            }
        }

        [DataMember]
        public string Argist
        {
            get
            {
                return _argist;
            }

            set
            {
                _argist = value;
                RaisePropertyChanged(nameof(Argist));
            }
        }

        [DataMember]
        public string Album
        {
            get
            {
                return _album;
            }

            set
            {
                _album = value;
                RaisePropertyChanged(nameof(Album));
            }
        }

        [DataMember]
        public string Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
                RaisePropertyChanged(nameof(Year));
            }
        }

        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }

            set
            {
                _comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        [DataMember]
        public string Track
        {
            get
            {
                return _track;
            }

            set
            {
                _track = value;
                RaisePropertyChanged(nameof(Track));
            }
        }

        [DataMember]
        public string Genre
        {
            get
            {
                return _genre;
            }

            set
            {
                _genre = value;
                RaisePropertyChanged(nameof(Genre));
            }
        }
    }
}
