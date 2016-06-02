using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirZPlayer
{
    internal static class Commands
    {
        public static ICommand Pause { set; get; }
        public static ICommand Stop { set; get; }
        public static ICommand Play { set; get; }
        public static ICommand Next { set; get; }
        public static ICommand Previous { set; get; }
    }
}
