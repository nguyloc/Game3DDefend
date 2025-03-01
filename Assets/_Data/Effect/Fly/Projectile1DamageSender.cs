using _Data.DamageSystem;
using UnityEngine;

namespace _Data.Effect.Fly
{
    public class Projectile1DamageSender : EffectDamageSender
    {
        protected override string GetHitName()
        {
            return "Hit1";
        }
    }
}
