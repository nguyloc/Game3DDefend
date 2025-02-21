using _Data.Scripts;
using UnityEngine;


namespace _Data.DamageSystem
{
    public abstract class DamageReceiver : LocMonoBehaviour
    {
        [SerializeField] protected int maxHP = 10;
        public int MaxHP => maxHP;
        
        [SerializeField] protected int currentHP = 10;
        public int CurrentHP => currentHP;
        
        protected bool isDead = false;
    
        [SerializeField] protected bool isImmortal = false;
        
        protected void OnEnable()
        {
            this.OnReborn();
        }

        public virtual int Deduct(int hp)
        {
            if (!this.isImmortal) this.currentHP -= hp;
            if (this.IsDead())  this.OnDead();
            else this.OnHurt();
            
            if (this.currentHP < 0) this.currentHP = 0;
            return currentHP;
        }

        public virtual bool IsDead()
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
        
        protected virtual void OnReborn()
        {
            this.currentHP = this.maxHP;
        }
    }
}
