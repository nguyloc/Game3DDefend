using System.Collections.Generic;
using _Data.Enemy.EnemyScripts;
using _Data.Enemy.Manager;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemyPrefab : EnemyManagerAbstract
    {
        [SerializeField] protected List<EnemyController> prefabs = new();


        protected override void Awake()
        {
            base.Awake();
            this.HidePrefabs();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyPrefabs();
        }
        
        protected virtual void LoadEnemyPrefabs()
        {
            if (this.prefabs.Count > 0) return;
            foreach (Transform child in transform)
            {
                EnemyController enemyController = child.GetComponent<EnemyController>();
                if (enemyController) this.prefabs.Add(enemyController);
            }
            Debug.Log(transform.name + " : LoadEnemyPrefabs", gameObject);
        }
        
        protected virtual void HidePrefabs()
        {
            foreach (var prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }

        public virtual EnemyController GetRandom()
        {
            int rand = Random.Range(0, this.prefabs.Count);
            return this.prefabs[rand];
        }
    }
}
