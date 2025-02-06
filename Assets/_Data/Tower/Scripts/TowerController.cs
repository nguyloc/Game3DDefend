using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerController : LocMonoBehaviour
    {
        [SerializeField] protected Transform model;
        [SerializeField] protected Transform rotator;
        [SerializeField] protected TowerTargeting towerTargeting;
        [SerializeField] protected BulletSpawner bulletSpawner;
        [SerializeField] protected Bullet bullet;

        
        public Transform Rotator => rotator;
        public TowerTargeting TowerTargeting => towerTargeting;
        public BulletSpawner BulletSpawner => bulletSpawner;
        public Bullet Bullet => bullet;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
            this.LoadTowerTargeting();
            this.LoadBulletSpawner();
            this.LoadBullet();
        }

            
        protected virtual void LoadBulletSpawner()
        {
            if (this.bulletSpawner != null) return;
            this.bulletSpawner = FindObjectOfType<BulletSpawner>();
            Debug.Log(transform.name + "LoadBulletSpawner", gameObject);
        }

        protected virtual void LoadBullet()
        {
            if (this.bullet != null) return;
            this.bullet = transform.GetComponentInChildren<Bullet>();
            Debug.Log(transform.name + "LoadBullet", gameObject);
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

