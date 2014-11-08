using SharpStar.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk
{
    class MTChat
    {
        public static void send(string msg)
        {
            foreach (var cl in SharpStarMain.Instance.Server.Clients.ToList())
            {
                if (cl != null)
                {
                    msg = msg.Replace("%player%", cl.Player.Name);
                    cl.PlayerClient.SendChatMessage(MollyTalk.MTConfig.ConfigFile.Sender, msg);
                }
            }
        }
    }
}
