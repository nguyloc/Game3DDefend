using System;
using System.Collections.Generic;
using _Data.Enemy.EnemyScripts;
using _Data.Enemy.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemySpawning : EnemyManagerAbstract
    {
        [SerializeField] protected float spawnSpeed = 1f;
        [SerializeField] protected int maxSpawn = 10;
        protected List<EnemyController> spawnedEnemies = new();

        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.Spawning), spawnSpeed);
        }

        protected void FixedUpdate()
        {
            this.RemoveDeadOne();
        }

        protected virtual void Spawning()
        {
            Invoke(nameof(this.Spawning), spawnSpeed);
            
            if(this.spawnedEnemies.Count >= maxSpawn) return;
            
            
            EnemyController prefab = this.enemyManagerController.EnemyPrefabs.GetRandom();
            
            //spawn
            EnemyController newEnemy = this.enemyManagerController.EnemySpawner.Spawn(prefab, transform.position);
            newEnemy.gameObject.SetActive(true);
            
            this.spawnedEnemies.Add(newEnemy);
            Debug.Log("Spawning", gameObject);
        }

        protected virtual void RemoveDeadOne()
        {
            foreach (EnemyController enemyController in this.spawnedEnemies)
            {
                if (enemyController.EnemyDamageReceiver.IsDead())
                {
                    this.spawnedEnemies.Remove(enemyController);
                    return;
                }
            }
        }
    }
}
