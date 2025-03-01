using _Data.Enemy.Manager;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemyManagerController : LocMonoBehaviour
    {
      [SerializeField] protected EnemySpawner enemySpawner;
      [SerializeField] protected EnemyPrefab enemyPrefabs;
      
      public EnemySpawner EnemySpawner => enemySpawner;
      public EnemyPrefab EnemyPrefabs => enemyPrefabs;
      
      protected override void LoadComponents()
      {
          base.LoadComponents();
          this.LoadEnemySpawner();
          this.LoadEnemyPrefabs();
      }
      
        protected virtual void LoadEnemySpawner()
        {
            if (this.enemySpawner != null) return;
            this.enemySpawner = GetComponentInChildren<EnemySpawner>();
            Debug.Log(transform.name + " EnemySpawner loaded", gameObject);
        }
        
        protected virtual void LoadEnemyPrefabs()
        {
            if (this.enemyPrefabs != null) return;
            this.enemyPrefabs = GetComponentInChildren<EnemyPrefab>();
            Debug.Log(transform.name + " EnemyPrefabs loaded", gameObject);
        }
    }
}
