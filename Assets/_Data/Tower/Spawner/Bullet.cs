using _Data.Scripts;
using _Data.Tower.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public class Bullet : LocMonoBehaviour
    {
        [SerializeField] protected float speed = 10f;
        [SerializeField] protected BulletDespawn despawn;
        
        public BulletDespawn Despawn => despawn;
        
        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadDespawn();
        }
        
        protected virtual void LoadDespawn()
        {
            if (this.despawn != null) return;
            this.despawn = transform.GetComponentInChildren<BulletDespawn>();
            Debug.Log(transform.name + ": LoadDespawn",gameObject);
        }
    }
}
