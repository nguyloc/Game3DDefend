using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackHeavy : AttackAbstract
    {
        protected override void Attacking()
        {
            if(!InputManager.Instance.IsAttackHeavy()) return;
        }
    }
}
