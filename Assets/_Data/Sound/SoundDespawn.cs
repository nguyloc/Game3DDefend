using _Data.Spawner.Despawn;
using UnityEngine;

namespace _Data.Sound
{
    public class SoundDespawn : Despawn<SoundController>
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.timeLife = 2f;
            this.currentTime = 2f;
        }
    }
}
