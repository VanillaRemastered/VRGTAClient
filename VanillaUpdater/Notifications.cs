using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaUpdater
{
    class Notifications
    {
        public static void PlayNotificationSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("notification.wav");
            player.Play();
        }

        public static void PlayErrorSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("error.wav");
            player.Play();
        }
    }
}
