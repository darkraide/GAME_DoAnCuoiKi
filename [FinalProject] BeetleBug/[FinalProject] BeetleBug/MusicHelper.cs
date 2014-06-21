using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class MusicHelper : InvisibleGameEntity
    {
        static List<Song> songs = new List<Song>();
        static MusicHelper()
        {
            Song song = Global.Content.Load<Song>(@"Music/MainMenu");
            songs.Add(song);

            song = Global.Content.Load<Song>(@"Music/MainPlay");
            songs.Add(song);

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
        }

        public void Mute()
        {
            MediaPlayer.Volume = 0f;
        }

        public void unMute()
        {
            MediaPlayer.Volume = 0.5f;
        }

        public void playSong(int songID)
        {
            MediaPlayer.Play(songs[songID]);
        }

        private static MusicHelper Instance = new MusicHelper();
        public static MusicHelper GetInstance()
        {
            return Instance;
        }
    }
}
