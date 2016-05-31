using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GongSolutions.Wpf.DragDrop;

namespace AirZPlayer
{
    /// <summary>
    /// MusicListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MusicListWindow
    {
        public MusicListWindow()
        {
            InitializeComponent();
        }
    }

    public class FileDropHandler : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.Effects = DragDropEffects.All;
        }

        public void Drop(IDropInfo dropInfo)
        {
            var dataObjt = dropInfo.Data as IDataObject;
            if (dataObjt != null)
            {
                if (dataObjt.GetDataPresent(DataFormats.FileDrop, true))
                {
                    var files = new List<string>();
                    var filesObj = dataObjt.GetData(DataFormats.FileDrop, true) as string[];
                    if (filesObj != null)
                    {
                        foreach (var path in filesObj)
                        {
                            if (File.Exists(path) && FilterMusicPath(path))
                            {
                                files.Add(path);
                            }
                            if (Directory.Exists(path))
                            {
                                files.AddRange(GetDirectoryFiles(path));
                            }
                        }
                    }

                    MusicListManager.Instance.AddMusicList("aaa", true, files);
#if DEBUG
                    files.ForEach(file=>Debug.WriteLine(file));
#endif
                }
            }
        }

        static List<string> MusicExtensions = new List<string>()
        {
            ".mp3",".acc",".flac",".wav"
        };
        private bool FilterMusicPath(string path)
        {
            return MusicExtensions.Contains(System.IO.Path.GetExtension(path));
        }
        private List<string> GetDirectoryFiles(string dir)
        {
            var files = new List<string>();
            if (Directory.Exists(dir))
            {
                var dirInfo = new DirectoryInfo(dir);
                files.AddRange(dirInfo.GetFiles().Where(fileInfo => FilterMusicPath(fileInfo.FullName)).Select(fileInfo=>fileInfo.FullName));

                foreach (var subDirInfo in dirInfo.GetDirectories())
                {
                    files.AddRange(GetDirectoryFiles(subDirInfo.FullName));
                }
            }
            return files;
        }
    }
}
