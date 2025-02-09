using _Data.Scripts;
using UnityEngine;

namespace _Data.DamageSystem
{
    public class DamageReceiver : LocMonoBehaviour
    {
        protected int maxHP = 10;
        protected int currentHP = 10;
        protected bool isDead = false;

        public virtual int Deduct(int hp)
        {
            this.currentHP -= hp;
            this.IsDead();
            
            if (this.currentHP < 0) this.currentHP = 0;
            return currentHP;
        }

        protected virtual bool IsDead()
        {
            return this.isDead = this.currentHP <= 0;
        }
    }
}
