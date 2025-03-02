using _Data.Scripts;
using UnityEngine;

namespace _Data.Effect
{
    public class EffectSpawnerController : LocSingleton<EffectSpawnerController>
    {
        [SerializeField] protected EffectSpawner spawner;
        public EffectSpawner Spawner => spawner;

        [SerializeField] protected EffectPrefabs effectPrefabs;
        public EffectPrefabs EffectPrefabs => effectPrefabs;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEffectSpawner();
            this.LoadEffectPrefabs();
        }
        
        protected virtual void LoadEffectSpawner()
        {
            if (this.spawner != null) return;
            this.spawner = GetComponent<EffectSpawner>();
            Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
        }
        
        protected virtual void LoadEffectPrefabs()
        {
            if (this.effectPrefabs != null) return;
            this.effectPrefabs = GetComponentInChildren<EffectPrefabs>();
            Debug.Log(transform.name + ": LoadEffectPrefabs", gameObject);
        }
    }
}
