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

        protected virtual void Spawning()
        {
            Invoke(nameof(this.Spawning), spawnSpeed);
            EnemyController prefab = this.enemyManagerController.EnemyPrefabs.GetRandom();
            
            //spawn
            EnemyController newEnemy = this.enemyManagerController.EnemySpawner.Spawn(prefab, transform.position);
            newEnemy.gameObject.SetActive(true);
            
            Debug.Log("Spawning", gameObject);
        }
    }
}
