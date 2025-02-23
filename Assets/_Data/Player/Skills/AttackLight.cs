using System;
using _Data.Effect;
using _Data.Effect.Fly;
using _Data.Scripts;
using _Data.Sound;
using _Data.Sound.SFX;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackLight : AttackAbstract
    {
        protected string effectName = "Projectile1"; // Enable to change the effect name in the inspector
        protected SoundName shootSfxName = SoundName.Laser01;
        
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackLight()) return;
            AttackPoint attackPoint = this.GetAttackPoint();
            EffectController effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
            
            EffectFlyAbtract effectFly = (EffectFlyAbtract) effect;
            effectFly.FlyToTarget.SetTarget(this.playerController.CrosshairPointer.transform);
            
            effect.gameObject.SetActive(true);
            
            this.SpawnSound(effectFly.transform.position);
        }
        
        protected virtual EffectController GetEffect()
        {
            return this.prefabs.GetByName(this.effectName);
        }

        protected virtual void SpawnSound(Vector3 position)
        {
            SfxController newSfx = SoundManager.Instance.CreateSfx(this.shootSfxName);
            newSfx.transform.position = position;
            newSfx.gameObject.SetActive(true);
        }
    }
}
