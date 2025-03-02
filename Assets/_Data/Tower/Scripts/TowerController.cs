using System.Collections.Generic;
using _Data.Level;
using _Data.Scripts;
using _Data.Spawner;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Data.Tower.Scripts
{
    public abstract class TowerController : PoolObj
    {
        [SerializeField] protected Transform model;
        [SerializeField] protected Transform rotator;
        [SerializeField] protected TowerTargeting towerTargeting;
        [SerializeField] protected TowerShooting towerShooting;
        [SerializeField] protected LevelAbstract level;
        [SerializeField] protected List<FirePoint> firePoints = new();
        
      

        
        public Transform Rotator => rotator;
        public TowerTargeting TowerTargeting => towerTargeting;
        public List<FirePoint> FirePoints => firePoints;
        public TowerShooting TowerShooting => towerShooting;
        public LevelAbstract Level => level;

        

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
            this.LoadTowerTargeting();
            this.LoadFirePoints();
            this.LoadTowerShooting();
            this.LoadLevel();
        }
        
        protected virtual void LoadLevel()
        {
            if (this.level != null) return;
            this.level = GetComponentInChildren<LevelAbstract>();
            Debug.Log(transform.name + " is loading Level", gameObject);
        }

          
        protected virtual void LoadTowerShooting()
        {
            if (this.towerShooting != null) return;
            this.towerShooting = GetComponentInChildren<TowerShooting>();
            Debug.Log(transform.name + " is loading TowerShooting", gameObject);
        }
        
        protected virtual void LoadFirePoints()
        {
            if (this.firePoints.Count > 0) return;
            FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
            this.firePoints = new List<FirePoint>(points);
            
            Debug.Log(transform.name + "LoadFirePoints", gameObject);
        }
        
        protected virtual void LoadModel()
        {
            if (this.model != null) return;
            this.model = transform.Find("Model");
            this.rotator = this.model.Find("Rotator");
            Debug.Log(transform.name + " is loading Model", gameObject);
        }
        
        protected virtual void LoadTowerTargeting()
        {
            if (this.towerTargeting != null) return;
            this.towerTargeting = GetComponentInChildren<TowerTargeting>();
            this.towerTargeting.transform.localPosition = new Vector3(0, 1f, 0);
            Debug.Log(transform.name + " is loading TowerTargeting", gameObject);
        }
    }
}

