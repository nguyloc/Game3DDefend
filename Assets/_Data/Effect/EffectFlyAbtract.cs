using _Data.Scripts;
using UnityEngine;

namespace _Data.Effect
{
    public abstract class EffectFlyAbtract : EffectController
    {
        [SerializeField] protected FlyToTarget flyToTarget;
        public FlyToTarget FlyToTarget => flyToTarget;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadFlyToTarget();
        }
        
        protected virtual void LoadFlyToTarget()
        {
            if (this.flyToTarget != null) return;
            this.flyToTarget = GetComponentInChildren<FlyToTarget>();
            Debug.Log(transform.name +": LoadFlyToTarget", gameObject);
        }
    }
}
