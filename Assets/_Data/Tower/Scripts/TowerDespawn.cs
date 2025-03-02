using _Data.Spawner.Despawn;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerDespawn : Despawn<TowerController>
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.isDespawnByTime = false;
        }
    }
}
