using _Data.Scripts;
using UnityEngine;

namespace _Data.DamageSystem
{
    public class DamageReceiver : LocMonoBehaviour
    {
        [SerializeField] protected bool isImmotal = false;
        
        protected int maxHP = 10;
        protected int currentHP = 10;
        protected bool isDead = false;

        public virtual int Deduct(int hp)
        {
            if(!this.isImmotal) this.currentHP -= hp;
            if (this.IsDead())  this.OnDead();
            else this.OnHurt();
            
            if (this.currentHP < 0) this.currentHP = 0;
            return currentHP;
        }

        protected virtual bool IsDead()
        {
            return this.isDead = this.currentHP <= 0;
        }
        
        protected virtual void OnDead()
        {
           // overide
        }
        
        protected virtual void OnHurt()
        {
            // overide
        }
    }
}
