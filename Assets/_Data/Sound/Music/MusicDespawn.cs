using _Data.Spawner.Despawn;
using UnityEngine;

namespace _Data.Sound.Music
{
    public class MusicDespawn : Despawn<SoundController>
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.isDespawnByTime = false;
        }
    }
}
