using SharpStar.Lib.Attributes;
using SharpStar.Lib.Plugins;
using SharpStar.Lib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk.Commands
{
    class HelpCommand : SubCommand
    {
        public HelpCommand()
            : base("help", "")
        {
        }

        public override void OnCommand(SharpStarClient client, string[] args)
        {
            string sender = MollyTalk.MTConfig.ConfigFile.Sender;

            client.SendChatMessage(sender, "*- MollyTalk Help -*");
            if (client.Server.Player.HasPermission("say"))
            {
                client.SendChatMessage(sender, "/mt say <msg> - Speak as " + sender);
            }
        }
    }
}
