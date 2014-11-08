using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk.Config
{
    [JsonObject]
    public class MTConfigFile
    {
        [JsonProperty]
        public string Sender { get; set; }

        [JsonProperty]
        public bool IsGreet { get; set; }

        [JsonProperty]
        public string Join { get; set; }

        [JsonProperty]
        public string Leave { get; set; }

        [JsonProperty]
        public bool IsAnnounce { get; set; }

        [JsonProperty]
        public int MinsPerAnnounce { get; set; }

        [JsonProperty]
        public List<string> Announcements { get; set; }

        [JsonProperty]
        public Dictionary<string, List<string>> Replies { get; set; }

        public MTConfigFile()
        {
            Sender = "Molly";

            IsGreet = true;
            Join = "Greetings %player% ;D";
            Leave = "%player% is out the hatch!";

            IsAnnounce = true;
            MinsPerAnnounce = 12;
            Announcements = new List<string>();
            Announcements.Add("Hoy! Thanks for playing our server!");
            Announcements.Add("I think %player% is my fav player ;3");

            Replies = new Dictionary<string, List<string>>();
            List<string> keys = new List<string>();
            keys.Add("build");
            keys.Add("a");
            keys.Add("snowman");
            Replies.Add("Come on lets go and play!", keys);

            List<string> keys2 = new List<string>();
            keys2.Add("hello");
            keys2.Add("molly");
            Replies.Add("Hi %player%!", keys2);
        }
    }
}
