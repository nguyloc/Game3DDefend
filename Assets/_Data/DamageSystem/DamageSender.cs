using System;
using _Data.Scripts;
using UnityEngine;

namespace _Data.DamageSystem
{
    [RequireComponent(typeof(Rigidbody))]
    
    public abstract class DamageSender : LocMonoBehaviour
    {
        [SerializeField] protected Rigidbody rigid;
        [SerializeField] protected int damage = 1;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRigidbody();
        }
        
        public void OnTriggerEnter(Collider collider)
        {
            Debug.Log("OnTriggerEnter" + collider.name);
            DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
            if (damageReceiver == null) return;
            this.Send(damageReceiver);
            Debug.Log("OnTriggerEnter" + collider.name);
        }
        
        protected virtual void Send (DamageReceiver receiver)
        {
            receiver.Deduct(this.damage);
        }
        
        protected virtual void LoadRigidbody()
        {
            if (this.rigid != null) return;
            this.rigid = GetComponent<Rigidbody>();
            this.rigid.useGravity = false;
            Debug.Log(transform.name + " Rigidbody loaded", gameObject);
        }
    }
}
