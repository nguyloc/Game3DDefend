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
        [SerializeField] protected BulletSpawner bulletSpawner;
        [SerializeField] protected Bullet bullet;


        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.TargetLoading), 1f);
        }

        protected void FixedUpdate()
        {
            this.Looking();
            this.Shooting();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
        }
    
        protected virtual void TargetLoading()
        {
            Invoke(nameof(this.TargetLoading), 1f);

            this.target = this.towerController.TowerTargeting.NearestEnemy;
        }
        
         
        protected virtual void Looking()
        {
            if (this.target == null) return; 
            Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerController.Rotator.position;
            Vector3 newDirection = Vector3.RotateTowards(
                this.towerController.Rotator.forward, 
                directionToTarget, 
                rotationSpeed * Time.fixedDeltaTime, 0.0f);
            
            this.towerController.Rotator.rotation = Quaternion.LookRotation(newDirection);
        }
        
        protected virtual void Shooting()
        {
            if (this.target == null) return;
            
            //Spawner
            this.towerController.BulletSpawner.Spawn(this.towerController.Bullet);
        }
    }
}
