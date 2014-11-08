using MollyTalk.Config;
using SharpStar.Lib;
using SharpStar.Lib.Packets;
using SharpStar.Lib.Plugins;
using SharpStar.Lib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk.Listeners
{
    class ConnectionListener
    {
        [AfterPacketEvent(KnownPacket.ConnectionResponse)]
        public void onConnect(IPacket packet, SharpStarClient client)
        {
            if (client != null && client.Connected)
            {
                string msg = MollyTalk.MTConfig.ConfigFile.Join.Replace("%player%", client.Server.Player.Name);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1)); // Wait a second so the client chat sends.
                MTChat.send(msg);
            }
        }

        [AfterPacketEvent(KnownPacket.DisconnectResponse)]
        public void onDisconnect(IPacket packet, SharpStarClient client)
        {
            if (client != null && !client.Connected)
            {
                string msg = MollyTalk.MTConfig.ConfigFile.Leave.Replace("%player%", client.Server.Player.Name);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1)); // Wait a second so the client chat sends.
                MTChat.send(msg);
            }
        }
    }
}
