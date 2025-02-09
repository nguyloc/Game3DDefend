using Unity.VisualScripting;
using UnityEngine;

namespace _Data.DamageSystem.Bullet
{
    [RequireComponent(typeof(SphereCollider))]
    
    public class BulletDamageSender : DamageSender
    {
        [SerializeField] protected BulletController bulletController;
        [SerializeField] protected SphereCollider sphereCollider;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
            this.LoadBulletController();
        }
        
        protected virtual void LoadSphereCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.radius = 0.025f;
            this.sphereCollider.isTrigger = true;
            Debug.Log(transform.name + " SphereCollider loaded", gameObject);
        }
        
        protected virtual void LoadBulletController()
        {
            if (this.bulletController != null) return;
            this.bulletController = transform.parent.GetComponent<BulletController>();
            Debug.Log(transform.name + " BulletController loaded", gameObject);
        }
        
        protected override void Send (DamageReceiver damageReceiver)
        {
           base.Send(damageReceiver);
           this.bulletController.Bullet.Despawn.DoDespawn();
        }
    }
}
