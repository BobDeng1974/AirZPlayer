using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AirZPlayer
{
    class ConfigManager
    {
        public const string ConfigName = "config.json";
        private static Lazy<ConfigManager> _instance = new Lazy<ConfigManager>(() => new ConfigManager());
        public static ConfigManager Instance => _instance.Value;

        public void Load()
        {
            try
            {
                //test
                //var a = new Config() {
                //    Version = "0.4",
                //    MusicList = new List<MusicDirectoryInfo>()
                //    {
                //        new MusicDirectoryInfo()
                //        {
                //            IsDefault = true,
                //            GroupName = "aaaaa",
                //            PathList = new List<string>()
                //            {
                //                "p11111111",
                //                "p22222222222",
                //                "p333333333333333"
                //            }
                //        }
                //    }
                //};
                //var ss = JsonConvert.SerializeObject(a);
                //File.WriteAllText("ccc.json", ss);

                var strConfigPath = ConfigName;
                if (File.Exists(strConfigPath))
                {
                    string strFileContent = File.ReadAllText(strConfigPath);
                    if (!string.IsNullOrWhiteSpace(strFileContent))
                    {
                        //反序列化为对象
                        Config = JsonConvert.DeserializeObject<Config>(strFileContent)??new Config();
                    }
                }
            }
            catch(Exception ex)
            {
                Config = default(Config);
                Debug.WriteLine(ex);
            }
        }

        public Config Config
        {
            get
            {
                return _config;
            }
            private set
            {
                _config = value;
            }
        }
        private Config _config;
    }
}
