using _Data.Effect;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackHeavy : AttackAbstract
    {
        protected string effectName = "Fire2"; // Enable to change the effect name in the inspector
        
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackHeavy()) return;
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
