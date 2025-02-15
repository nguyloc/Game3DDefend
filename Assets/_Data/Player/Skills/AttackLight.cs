using System;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackLight : AttackAbstract
    {
        protected void Update()
        {
            this.Attacking();
        }
        
        protected override void Attacking()
        {
            if(InputManager.Instance.IsAttackLight()) Debug.Log("Attacking Light");
        }
    }
}
