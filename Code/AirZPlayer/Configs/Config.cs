using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AirZPlayer
{
    [DataContract(Name="Config")]
    class Config
    {
        [DataMember(Name ="Version")]
        public string Version { set; get; } = "0.1";
        [DataMember(Name = "MusicList")]
        public List<MusicDirectoryInfo> MusicList { set; get; } = new List<MusicDirectoryInfo>();
    }

    [DataContract(Name= "MusicDirectoryInfo")]
    class MusicDirectoryInfo
    {
        [DataMember(Name = "IsDefault")]
        public bool IsDefault { set; get; }
        [DataMember(Name = "GroupName")]
        public string GroupName { set; get; }
        [DataMember(Name = "MusicInfos")]
        public List<MusicInfo> MusicInfos { set; get; }
    }

}
