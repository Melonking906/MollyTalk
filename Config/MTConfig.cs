using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk.Config
{
    public class MTConfig
    {
        public MTConfigFile ConfigFile { get; set; }

        private const string FileName = "mollytalk.json";

        public MTConfig()
        {
            Reload();
        }

        private void SetDefaults()
        {
            Save();
        }

        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(ConfigFile, Formatting.Indented));
        }

        public void Reload()
        {
            if (File.Exists(FileName))
            {
                ConfigFile = JsonConvert.DeserializeObject<MTConfigFile>(File.ReadAllText(FileName));
            }
            else
            {
                ConfigFile = new MTConfigFile();
                SetDefaults();
            }

        }
    }
}
