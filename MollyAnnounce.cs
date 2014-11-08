using SharpStar.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MollyTalk
{
    class MollyAnnounce
    {
        private int MinutesPerAnnounce = MollyTalk.MTConfig.ConfigFile.MinsPerAnnounce;
        private List<string> announcments = MollyTalk.MTConfig.ConfigFile.Announcements;

        private int lastIndex;

        public MollyAnnounce()
        {
            lastIndex = 0;
        }

        public void start()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = TimeSpan.FromMinutes(MinutesPerAnnounce).TotalMilliseconds;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Random random = new Random();
            int index = 0;

            do
            {
                index = random.Next(announcments.Count);
            }
            while ( index == lastIndex );

            lastIndex = index;
            MTChat.send( announcments[index] );
        }
    }
}
