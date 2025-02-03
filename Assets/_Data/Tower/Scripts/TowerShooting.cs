using System;
using _Data.Enemy.Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerShooting : TowerAbstract
    {
        [SerializeField] protected float rotationSpeed = 2f;
        [SerializeField] protected EnemyController target;

        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.TargetLoading), 1f);
        }

        protected void FixedUpdate()
        {
            this.LookingAtTarget();
        }
       
        protected virtual void TargetLoading()
        {
            Invoke(nameof(this.TargetLoading), 1f);

            this.target = this.towerController.TowerTargeting.NearestEnemy;
        }
        
         
        protected virtual void LookingAtTarget()
        {
            if (this.target == null) return; 
            Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerController.Rotator.position;
            Vector3 newDirection = Vector3.RotateTowards(
                this.towerController.Rotator.forward, 
                directionToTarget, 
                rotationSpeed * Time.fixedDeltaTime, 0.0f);
            
            this.towerController.Rotator.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
