using libZPlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirZPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            if (player.OpenFile(@"C:\Users\zhangxin\Downloads\邓紫棋 - 泡沫.flac", TStreamFormat.sfAutodetect) == false)
            {
                // error
            }
            player.StartPlayback();
        }
        ZPlay player = new ZPlay();
    }
}
