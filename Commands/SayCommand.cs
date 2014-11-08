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
    class SayCommand : SubCommand
    {
        public SayCommand() : base("say", "mollytalk.say")
        {
        }

        public override void OnCommand(SharpStarClient client, string[] args)
        {
            if (args.Length < 1)
            {
                client.SendChatMessage(MollyTalk.MTConfig.ConfigFile.Sender, "Usage: /mt say <msg>");
                return;
            }

            string msg = "";
            foreach (string word in args) // Put all the args together.
            {
                msg = msg + word + " ";
            }

            msg = msg.Replace("say ", ""); // Remove the subcommand from the say.

            MTChat.send(msg);
        }
    }
}
