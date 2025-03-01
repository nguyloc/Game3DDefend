using _Data.Player.Skills;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Weapon
{
    public abstract class WeaponAbtract : LocMonoBehaviour
    {
        [SerializeField] protected AttackPoint attackPoint;
        public AttackPoint AttackPoint => attackPoint;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadAttackPoint();
        }
        
        protected virtual void LoadAttackPoint()
        {
            if (this.attackPoint != null) return;
            this.attackPoint = GetComponentInChildren<AttackPoint>();
            Debug.Log(transform.name + ": Loaded AttackPoint", gameObject);
        }
    }
}
