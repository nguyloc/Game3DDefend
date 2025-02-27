using System;
using _Data.Inventory.Item;
using _Data.Player.Scripts;
using _Data.Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerManager : LocSingleton<TowerManager>
    {
        [SerializeField] protected TowerCode newTowerId = TowerCode.NoTower;
        [SerializeField] protected TowerController towerPrefab;

        [SerializeField] protected bool towerPlace = false;

        protected virtual void FixedUpdate()
        {
            this.ShowTowerToPlace();
        }
   
        protected virtual void ShowTowerToPlace()
        {
            if (this.towerPlace) return;
            
            // Get tower code from input hot key
            this.newTowerId = this.GetTowerCode(InputHotKey.Instance.KeyCode);
            
            if (this.newTowerId == TowerCode.NoTower)
            {   
                if (this.towerPrefab != null) this.towerPrefab.SetActive(false);
                this.towerPrefab = null;
                return;
            }

            // If tower prefab is null, get tower prefab by tower code
            if (this.towerPrefab == null)
            {
                this.towerPrefab = this.GetTowerPrefab(this.newTowerId);
                if (this.towerPrefab == null) return;
                this.towerPrefab.TowerShooting.Disable();
                this.towerPrefab.SetActive(true);
            }
            
            // Set tower position to crosshair position of player
            this.towerPrefab.transform.position = PlayerController.Instance.CrosshairPointer.transform.position;
            
            if (InputHotKey.Instance.IsPlaceTower) this.PlaceTower();
        }
        
        protected virtual void PlaceTower()
        {
            // Set tower place to true
            this.towerPlace = true;
                
            // Spawn tower controller
            TowerController newTowerController = this.Spawn(this.towerPrefab);
            newTowerController.TowerShooting.Active();
            newTowerController.SetActive(true);
                
            
            Invoke(nameof(this.PlaceFinish), 0.5f);
        }
        
        
        protected virtual TowerController Spawn(TowerController towerPrefab)
        {
            return TowerSpawnerController.Instance.Spawner.Spawn(towerPrefab,this.towerPrefab.transform.position);
        }
        
        protected virtual TowerController GetTowerPrefab(TowerCode towerCode)
        {
            return TowerSpawnerController.Instance.TowerPrefabs.GetByName(towerCode.ToString());
        }

        protected virtual void PlaceFinish()
        {
            this.towerPlace = false;
        }
        
        protected virtual TowerCode GetTowerCode(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.Alpha1:
                    return TowerCode.MachineGun;
                case KeyCode.Alpha2:
                    return TowerCode.LaserGun;
                default:
                    return TowerCode.NoTower;
            }
        }
    }
}
