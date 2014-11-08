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
    class MTCommand
    {
        private List<SubCommand> commands;

        public MTCommand()
        {
            commands = new List<SubCommand>();

            commands.Add(new HelpCommand());
            commands.Add(new SayCommand());
        }

        [Command("mt", "MollyTalk Commands!")]
        public void OnCommand(SharpStarClient client, string[] args)
        {
            string subCommand = "help";

            if (args.Length >= 1)
            {
                subCommand = args[0];
            }

            foreach (SubCommand command in commands)
            {
                if (subCommand.Equals(command._name))
                {
                    if (client.Server.Player.HasPermission(command._permission))
                    {
                        command.OnCommand(client, args);
                    }
                    else
                    {
                        client.SendChatMessage(MollyTalk.MTConfig.ConfigFile.Sender, "Sorry! You don't have permission for that!");
                    }
                    return;
                }
            }

            client.SendChatMessage(MollyTalk.MTConfig.ConfigFile.Sender, "I don't know that command.. try /mt");
        }
    }
}
