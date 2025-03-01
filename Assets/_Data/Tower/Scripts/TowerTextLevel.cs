using _Data.Level.UILevelText;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public  class TowerTextLevel : TextLevel
    {
        [SerializeField] protected  TowerController towerController;
   

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTowerController();
        }
        
        protected virtual void LoadTowerController()
        {
            if (this.towerController != null) return;
            this.towerController = GetComponentInParent<TowerController>();
            Debug.Log(transform.name + ": LoadTowerController: " , gameObject);
        }

        protected override string GetLevel()
        {
            return this.towerController.Level.CurrentLevel.ToString();
        }
    }
}
