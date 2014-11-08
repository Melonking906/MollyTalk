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
    class ChatListener
    {
        private MollyReply mr;

        public ChatListener()
        {
            this.mr = new MollyReply();
        }

        [AfterPacketEvent(KnownPacket.ChatReceived)]
        public void onChat(IPacket packet, SharpStarClient client)
        {
            ChatReceivedPacket chatPacket = (ChatReceivedPacket)packet;
            string msg = chatPacket.Message;
            string reply = mr.getReply(msg);

            if (reply != null)
            {
                reply = reply.Replace("%player%", client.Server.Player.Name); // Replace place holder.

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1)); // Wait a second so the client chat sends.
                MTChat.send(reply);
            }
        }
    }
}
