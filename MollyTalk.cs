using MollyTalk.Commands;
using MollyTalk.Config;
using MollyTalk.Listeners;
using Mono.Addins;
using SharpStar.Lib;
using SharpStar.Lib.Packets;
using SharpStar.Lib.Plugins;
using SharpStar.Lib.Server;

[assembly: Addin("MollyTalk", Version = "0.1")]
[assembly: AddinDescription("Your own personal chatterbox")]
[assembly: AddinProperty("sharpstar", "0.2.3.4")] //minimum SharpStar version
[assembly: AddinDependency("SharpStar.Lib", "1.0")]

namespace MollyTalk
{
    [Extension]
    public class MollyTalk : CSPlugin
    { 
        public static MTConfig MTConfig;

        private readonly MTCommand _mtCommand = new MTCommand();

        public MollyTalk()
        {
            MTConfig = new MTConfig();
        }

        public override string Name
        {
            get { return "MollyTalk"; }
        }

        public override void OnLoad()
        {
            RegisterCommandObject(_mtCommand);

            if (MTConfig.ConfigFile.IsGreet)
            {
                RegisterEventObject(new ConnectionListener());
            }

            RegisterEventObject(new ChatListener());

            if (MTConfig.ConfigFile.IsAnnounce)
            {
                MollyAnnounce announcer = new MollyAnnounce();
                announcer.start();
            }
        }
    }
}