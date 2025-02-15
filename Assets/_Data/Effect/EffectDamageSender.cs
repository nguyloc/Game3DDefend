using _Data.DamageSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Data.Effect
{
    [RequireComponent(typeof(SphereCollider))]
    public class EffectDamageSender : DamageSender
    {
        [FormerlySerializedAs("effectCtrl")]
        [SerializeField] protected EffectController effectController;
        [SerializeField] protected SphereCollider sphereCollider;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
            this.LoadEffectCtrl();
        }

        protected virtual void LoadEffectCtrl()
        {
            if (this.effectController != null) return;
            this.effectController = transform.GetComponentInParent<EffectController>();
            Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
        }

        protected virtual void LoadSphereCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.radius = 0.05f;
            this.sphereCollider.isTrigger = true;
            Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
        }

        protected override void Send(DamageReceiver damageReceiver)
        {
            base.Send(damageReceiver);
            //this.ShowHitEffect(collider);
            this.effectController.Despawn.DoDespawn();
        }

        // protected virtual void ShowHitEffect(Collider collider)
        // {
        //     Vector3 hitPoint = collider.ClosestPoint(transform.position);
        //     EffectCtrl prefab = EffectSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.GetHitName());
        //     EffectCtrl newObj = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, hitPoint);
        //     newObj.gameObject.SetActive(true);
        // }
        //
        // protected abstract string GetHitName();
    }
}
