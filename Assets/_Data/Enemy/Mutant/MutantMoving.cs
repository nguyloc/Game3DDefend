using _Data.Enemy.EnemyScripts;
using UnityEngine;

namespace _Data.Enemy.Mutant
{
    public class MutantMoving : EnemyMoving
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.pathName = "path";
        }
    }
}
