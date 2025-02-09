using _Data.Scripts;
using _Data.Tower.Spawner.Despawn;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public abstract class PoolObj : LocMonoBehaviour
    {
        [SerializeField] protected DespawnBase despawn;
        
        public DespawnBase Despawn => despawn;

        public abstract string GetName();
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadDespawn();
        }
    
        protected virtual void LoadDespawn()
        {
            if (this.despawn != null) return;
            this.despawn = transform.GetComponentInChildren<DespawnBase>();
            Debug.Log(transform.name + ": LoadDespawn",gameObject);
        }
    }
}
