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

        private ConfigManager()
        { }

        public void Load()
        {
            try
            {
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
                Config = new Config();
                Debug.WriteLine(ex);
            }
        }

        public void Save()
        {
            var strConfigPath = ConfigName;
            try
            {
                File.WriteAllText(strConfigPath, JsonConvert.SerializeObject(Config));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public Config Config
        {
            get
            {
                return _config??(_config = new Config());
            }
            private set
            {
                _config = value;
                if (value == null)
                {
                    _config = new Config();
                }
            }
        } 
        private Config _config;
    }
}
