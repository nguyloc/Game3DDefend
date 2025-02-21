using UnityEngine;

namespace _Data.Sound.Music
{
    public abstract class MusicController : SoundController
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.audioSource.loop = true;
        }
    }
}
