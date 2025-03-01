using _Data.Tower.Scripts;
using UnityEngine;

namespace _Data.Level
{
    public class TowerLevel : LevelAbstract
    {
        [SerializeField]
        protected TowerController towerController;
        
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTowerController();
        }
        
        protected virtual void LoadTowerController()
        {
            if (this.towerController != null) return;
            this.towerController = GetComponentInParent<TowerController>();
            Debug.Log(transform.name + " is loading TowerController", gameObject);
        }
        
        protected override int GetCurrentExp()
        {
            return this.towerController.TowerShooting.KillCount;
        }

        protected override bool DeductExp(int exp)
        {
            return this.towerController.TowerShooting.DeductKillCount(exp);
        }

        // Thông số tăng cấp
        protected override int GetNextLevelExp()
        {
            return this.nextLevelExp = this.currentLevel * 2;
        }
    }
}
