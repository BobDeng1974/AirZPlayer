//   *********  请勿修改此文件   *********
//   此文件由设计工具再生成。更改
//   此文件可能会导致错误。
namespace Expression.Blend.SampleData.MainWindowViewModelSampleDataSource
{
    using System; 
    using System.ComponentModel;

// 若要在生产应用程序中显著减小示例数据涉及面，则可以设置
// DISABLE_SAMPLE_DATA 条件编译常量并在运行时禁用示例数据。
#if DISABLE_SAMPLE_DATA
    internal class MainWindowViewModelSampleDataSource { }
#else

    public class MainWindowViewModelSampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModelSampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("/AirZPlayer;component/SampleData/MainWindowViewModelSampleDataSource/MainWindowViewModelSampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private MusicList _MusicList = new MusicList();

        public MusicList MusicList
        {
            get
            {
                return this._MusicList;
            }
        }
    }

    public class MusicListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private MusicGroup _MusicGroup = new MusicGroup();

        public MusicGroup MusicGroup
        {
            get
            {
                return this._MusicGroup;
            }

            set
            {
                if (this._MusicGroup != value)
                {
                    this._MusicGroup = value;
                    this.OnPropertyChanged("MusicGroup");
                }
            }
        }
    }

    public class MusicList : System.Collections.ObjectModel.ObservableCollection<MusicListItem>
    { 
    }

    public class MusicGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private MusicInfos _MusicInfos = new MusicInfos();

        public MusicInfos MusicInfos
        {
            get
            {
                return this._MusicInfos;
            }
        }
    }

    public class MusicInfosItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MusicInfos : System.Collections.ObjectModel.ObservableCollection<MusicInfosItem>
    { 
    }
#endif
}
