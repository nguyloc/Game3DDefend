using _Data.Tower.Spawner.Despawn;

namespace _Data.Enemy.EnemyScripts
{
    public class EnemyDespawn : Despawn<EnemyController>
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.isDespawnByTime = false;
        }
    }
}
