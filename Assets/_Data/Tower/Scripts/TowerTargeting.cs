using System.Collections.Generic;
using _Data.Enemy.Scripts;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    
    public class TowerTargeting : LocMonoBehaviour
    {
        [SerializeField] protected SphereCollider sphereCollider;
        [SerializeField] protected Rigidbody rig;
        [SerializeField] protected EnemyController nearestEnemy;

        [SerializeField] protected List<EnemyController> enemies = new();

        protected void FixedUpdate()
        {
            this.FindNearestEnemy();
        }


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
            this.LoadRigidbody();
        }
        
        protected virtual void LoadSphereCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.isTrigger = true;
            this.sphereCollider.radius = 5f;
            Debug.Log(transform.name + " is loading SphereCollider", gameObject);
        }
        
        protected virtual void LoadRigidbody()
        {
            if (this.rig != null) return;
            this.rig = GetComponent<Rigidbody>();
            this.rig.isKinematic = true;
            Debug.Log(transform.name + " is loading Rigidbody", gameObject);
        }
        
        protected virtual void FindNearestEnemy()
        {
            if (this.enemies.Count == 0) return;
            this.nearestEnemy = this.enemies[0];
            foreach (var enemy in this.enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) <
                    Vector3.Distance(transform.position, this.nearestEnemy.transform.position))
                {
                    this.nearestEnemy = enemy;
                }
            }
        }
    }
}
