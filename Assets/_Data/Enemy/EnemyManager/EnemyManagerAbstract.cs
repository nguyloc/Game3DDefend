using _Data.Enemy.EnemyManager;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Enemy.Manager
{
    public class EnemyManagerAbstract : LocMonoBehaviour
    {
        [SerializeField] protected EnemyManagerController enemyManagerController;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyManagerController();
        }
        
        protected virtual void LoadEnemyManagerController()
        {
            if (this.enemyManagerController != null) return;
            this.enemyManagerController = transform.GetComponentInParent<EnemyManagerController>();
            Debug.Log(transform.name + " : LoadEnemyManagerController", gameObject);
        }
    }
}
