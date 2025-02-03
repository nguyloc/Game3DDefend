using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public abstract class TowerAbstract : LocMonoBehaviour
    {
        [SerializeField] protected TowerController towerController;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTowerController();
        }
        
        protected virtual void LoadTowerController()
        {
            if (this.towerController != null) return;
            this.towerController = transform.parent.GetComponent<TowerController>();
            Debug.Log(transform.name + " is loading TowerController", gameObject);
        }
        protected virtual void Start()
        {
            Debug.Log("TowerAbstract Start logic");
        }
    }
}
