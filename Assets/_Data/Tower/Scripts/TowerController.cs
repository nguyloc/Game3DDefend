using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerController : LocMonoBehaviour
    {
        [SerializeField] protected Transform model;
        [SerializeField] protected Transform rotator;
        [SerializeField] protected TowerTargeting towerTargeting;
        
        public Transform Rotator => rotator;
        public TowerTargeting TowerTargeting => towerTargeting;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
            this.LoadTowerTargeting();
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
            Debug.Log(transform.name + " is loading TowerTargeting", gameObject);
        }
    }
}

