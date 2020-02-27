namespace VanillaUpdater
{
    internal class Notifications
    {
        private static readonly System.Media.SoundPlayer Player = new System.Media.SoundPlayer();

        /// <summary>
        /// Plays the default 'deduction' sound..
        /// </summary>
        public static void PlayNotificationSound()
        {
            Player.Stream = Properties.Resources.deduction;
            Player.Play();
        }

        /// <summary>
        /// Plays point-blank notification as an alternative sound.
        /// </summary>
        public static void PlayNotificationSound2()
        {
            Player.Stream = Properties.Resources.point_blank;
            Player.Play();
        }


        /// <summary>
        /// Plays the error sound.
        /// </summary>
        public static void PlayErrorSound()
        {
            Player.Stream = Properties.Resources.unsure;
            Player.Play();
        }

    }
}