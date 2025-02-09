using _Data.DamageSystem;
using UnityEngine;

namespace _Data.Enemy.Scripts
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] CapsuleCollider capsuleCollider;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCapsuleCollider();
        }
        
        protected virtual void LoadCapsuleCollider()
        {
            if (this.capsuleCollider != null) return;
            this.capsuleCollider = GetComponent<CapsuleCollider>();
            this.capsuleCollider.isTrigger = true;
            this.capsuleCollider.radius = 0.5f;
            this.capsuleCollider.height = 1.5f;
            this.capsuleCollider.center = new Vector3(0, 1f, 0);
            Debug.Log(transform.name + " CapsuleCollider loaded", gameObject);
        }
    }
}
