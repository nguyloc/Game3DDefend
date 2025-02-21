using UnityEngine;

namespace _Data.Sound.SFX
{
    public abstract class SfxController : SoundController
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.audioSource.loop = false;
            
        }
    }
}
