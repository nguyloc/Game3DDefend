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
            this.FindNearest();
        }

             
        protected virtual void OnTriggerEnter(Collider collider)
        {
            this.AddEnemy(collider);
        }
        
        protected virtual void OnTriggerExit(Collider collider)
        {
            this.RemoveEnemy(collider);
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
            this.sphereCollider.radius = 15f;
            Debug.Log(transform.name + " is loading SphereCollider", gameObject);
        }
        
        protected virtual void LoadRigidbody()
        {
            if (this.rig != null) return;
            this.rig = GetComponent<Rigidbody>();
            this.rig.isKinematic = true;
            Debug.Log(transform.name + " is loading Rigidbody", gameObject);
        }
   
        protected virtual void AddEnemy(Collider collider)
        {
          if (collider.name != Const.TOWER_TARGETABLE) return;
          var enemyController = collider.transform.parent.GetComponent<EnemyController>();
          this.enemies.Add(enemyController);
          Debug.Log("Enemy added" + collider.name, gameObject);
        }
        
        protected virtual void RemoveEnemy(Collider collider)
        {
            Debug.Log("Enemy removed" + collider.name, gameObject);
            foreach (EnemyController enemyController in this.enemies)
            {
                if (collider.transform.parent == enemyController.transform)
                {
                    this.enemies.Remove(enemyController);
                    return;
                }
            }
        }
        
        protected virtual void FindNearest()
        {
            float nearestDistance = Mathf.Infinity;
            float enemyDistance;
            foreach (var enemyController in this.enemies)
            {
                enemyDistance = Vector3.Distance(transform.position, enemyController.transform.position);
                if (enemyDistance < nearestDistance)
                {
                    nearestDistance = enemyDistance;
                    this.nearestEnemy = enemyController;
                }
            }
        }
    }
}
