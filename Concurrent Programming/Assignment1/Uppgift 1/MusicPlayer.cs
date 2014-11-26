using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift_1
{
    public class MusicPlayer
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private string path;

        public void PlayMusic()
        {
                player.SoundLocation = FilePath;
                player.Play();
        }
        public void StopMusic()
        {
                player.Stop();
        }
        public string FilePath
        {
            get { return path; }
            set { path = value; }
        }
    }
}
