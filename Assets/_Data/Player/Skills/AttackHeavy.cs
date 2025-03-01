using _Data.Effect;
using _Data.Effect.Fly;
using _Data.Scripts;
using _Data.Sound.SFX;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackHeavy : AttackAbstract
    {
        protected string effectName = "Fire2";
        protected float timer = 0.0f;
        protected float delay = 0.5f;
        
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackHeavy()) return;
            
            // delay
            this.timer += Time.deltaTime;
            if(this.timer < this.delay) return;
            this.timer = 0.0f;
            
            
            AttackPoint attackPoint = this.GetAttackPoint();
            EffectController effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
            
            EffectFlyAbtract effectFly = (EffectFlyAbtract) effect;
            effectFly.FlyToTarget.SetTarget(this.playerController.CrosshairPointer.transform);
            
            effect.gameObject.SetActive(true);
        }
        
        protected virtual EffectController GetEffect()
        {
            return this.prefabs.GetByName(this.effectName);
        }
        
        
    }
}
