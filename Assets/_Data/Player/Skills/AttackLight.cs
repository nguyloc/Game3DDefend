using System;
using _Data.Effect;
using _Data.Effect.Fly;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackLight : AttackAbstract
    {
        protected string effectName = "Fire1"; // Enable to change the effect name in the inspector
        
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackLight()) return;
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
