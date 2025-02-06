using System;
using System.Collections.Generic;
using _Data.Scripts;
using _Data.Tower.Spawner;
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
        [SerializeField] protected List<FirePoint> firePoints = new();

        
        public Transform Rotator => rotator;
        public TowerTargeting TowerTargeting => towerTargeting;
        public BulletSpawner BulletSpawner => bulletSpawner;
        public Bullet Bullet => bullet;
        public List<FirePoint> FirePoints => firePoints;


        protected override void Awake()
        {
            base.Awake();
            this.HidePrefab();
        }


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
            this.LoadTowerTargeting();
            this.LoadBulletSpawner();
            this.LoadBullet();
            this.LoadFirePoints();
        }

          
        protected virtual void LoadFirePoints()
        {
            if (this.firePoints.Count > 0) return;
            FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
            this.firePoints = new List<FirePoint>(points);
            
            Debug.Log(transform.name + "LoadFirePoints", gameObject);
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
        
        protected virtual void HidePrefab()
        {
            this.bullet.gameObject.SetActive(false);
        }
    }
}

