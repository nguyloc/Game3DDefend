using System;
using _Data.Enemy.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerShooting : TowerAbstract
    {
        [SerializeField] protected EnemyController target;

        protected void FixedUpdate()
        {
            this.LookAtTarget();
        }
        
        protected virtual void LookAtTarget()
        {
            if (this.target == null) return; 
            this.towerController.Rotator.LookAt(this.target.TowerTargetable.transform.position);
        }
    }
}
