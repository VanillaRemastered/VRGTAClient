using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaUpdater
{
    class Notifications
    {
        static readonly System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public static void PlayNotificationSound()
        {
            player.Stream = Properties.Resources.notification;
            player.Play();
        }

        public static void PlayErrorSound()
        {
            player.Stream = Properties.Resources.unsure;
            player.Play();
        }
    }
}
