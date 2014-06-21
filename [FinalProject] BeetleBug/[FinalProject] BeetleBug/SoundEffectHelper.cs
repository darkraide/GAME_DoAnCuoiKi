using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class SoundEffectHelper : InvisibleGameEntity
    {
        static List<SoundEffect> sounds = new List<SoundEffect>();
        static SoundEffectHelper()
        {
            SoundEffect song = Global.Content.Load<SoundEffect>("");
            sounds.Add(song);

            song = Global.Content.Load<SoundEffect>("");
            sounds.Add(song);
        }

        public void Mute()
        {
            SoundEffect.MasterVolume = 0;
        }

        public void unMute()
        {
            SoundEffect.MasterVolume = 0.5f;
        }

        public void PlaySound(int soundID)
        {
            sounds[soundID].Play();
        }

        private static SoundEffectHelper Instance = new SoundEffectHelper();

        public static SoundEffectHelper GetInstance()
        {
            return Instance;
        }
    }
}
