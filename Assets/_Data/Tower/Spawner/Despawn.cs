using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public abstract class Despawn<T> : LocMonoBehaviour
    {
        [SerializeField] protected Spawner<T> spawner;
        [SerializeField] protected T parent;
        [SerializeField] protected float timeLife = 7f;
        [SerializeField] protected float currentTime = 7f;
        
        protected void FixedUpdate()
        {
            this.DespawnChecking();
        }
        
        protected override void LoadComponents()
        {
            this.LoadComponents();
            this.LoadParent();
        }
        
        public virtual void SetSpawner(Spawner<T> spawner)
        {
            this.spawner = spawner;
        }
        
        protected virtual void DespawnChecking()
        {
            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime > 0) return;

            this.spawner.Despawn(this.parent);
            this.currentTime = this.timeLife;
        }
        
        protected virtual void LoadParent()
        {
            if (this.parent != null) return;
            this.parent = transform.parent.GetComponent<T>();
            Debug.Log(transform.name + ": LoadParent",gameObject);
        }
    }
}
