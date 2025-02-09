using _Data.DamageSystem;
using UnityEngine;

namespace _Data.Environment
{
    [RequireComponent(typeof(BoxCollider))]
    public class WallDamageReceiver : DamageReceiver
    {
        [SerializeField] protected BoxCollider boxCollider;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBoxCollider();
        }
        
        protected virtual void LoadBoxCollider()
        {
            if (this.boxCollider != null) return;
            this.boxCollider = GetComponent<BoxCollider>();
            this.boxCollider.isTrigger = true;
            Debug.Log(transform.name + " is loading BoxCollider", gameObject);
        }
        
        protected override void ResetValue()
        {
            base.ResetValue();
            this.isImmotal = true;
        }
    }
}
