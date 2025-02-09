using UnityEngine;

namespace _Data.DamageSystem.Bullet
{
    [RequireComponent(typeof(SphereCollider))]
    
    public class BulletDamageSender : DamageSender
    {
        [SerializeField] protected SphereCollider sphereCollider;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
        }
        
        protected virtual void LoadSphereCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.radius = 0.025f;
            this.sphereCollider.isTrigger = true;
            Debug.Log(transform.name + " SphereCollider loaded", gameObject);
        }
    }
}
