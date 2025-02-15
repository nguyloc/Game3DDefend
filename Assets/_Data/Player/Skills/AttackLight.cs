using System;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackLight : AttackAbstract
    {
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackLight()) return;
        }
    }
}
