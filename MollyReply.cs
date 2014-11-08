using MollyTalk.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk
{
    class MollyReply
    {
        private Dictionary<string, List<string>> replies;

        public MollyReply()
        {
            this.replies = MollyTalk.MTConfig.ConfigFile.Replies;
        }

        // Searches through the replies and returns the first match.
        public string getReply(string msg)
        {
            msg = formatMsg(msg);

            foreach (KeyValuePair<string, List<string>> reply in replies)
            {
                List<string> keys = reply.Value;
                List<string> words = msg.Split(' ').ToList(); // Split msg into a list.

                bool isSubset = !keys.Except(words).Any(); // Check if the msg contains all keys.

                if (isSubset)
                {
                    return reply.Key;
                }
            }

            return null;
        }

        // Cleans up message a little.
        private string formatMsg(string msg)
        {
            msg = msg.Replace('?', ' ');
            msg = msg.Replace('!', ' ');
            msg = msg.Replace('.', ' ');
            msg = msg.Replace(',', ' ');
            msg = msg.ToLower();

            return msg;
        }
    }
}
