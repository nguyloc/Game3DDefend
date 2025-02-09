using System.Collections.Generic;
using _Data.Enemy.EnemyScripts;
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
        [SerializeField] protected LayerMask obstacleLayerMask;
        
        [SerializeField] protected List<EnemyController> enemies = new();

        
        public EnemyController NearestEnemy => nearestEnemy;
        
        protected void FixedUpdate()
        {
            this.FindNearest();
            this.RemoveDeadEnemies();
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
          
          if(enemyController.EnemyDamageReceiver.IsDead()) return;
          
          this.enemies.Add(enemyController);
        }
        
        protected virtual void RemoveEnemy(Collider collider)
        {
            foreach (EnemyController enemyController in this.enemies)
            {
                if (collider.transform.parent == enemyController.transform)
                {
                    if(enemyController == this.nearestEnemy) this.nearestEnemy = null;

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
                if(!this.CanSeeTarget(enemyController)) continue;
                
                enemyDistance = Vector3.Distance(transform.position, enemyController.transform.position);
                if (enemyDistance < nearestDistance)
                {
                    nearestDistance = enemyDistance;
                    this.nearestEnemy = enemyController;
                }
            }
        }

        protected virtual bool CanSeeTarget(EnemyController target)
        {
            Vector3 directionToTarget = target.transform.position - transform.position;
            float distanceToTarget = directionToTarget.magnitude;
            
            if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
            {
                Vector3 directionToCollider = hitInfo.point - transform.position;
                float distanceToCollier = directionToCollider.magnitude;
                
                Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollier, Color.red);
                return false;
            }
            Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
            return true;
        }

        protected virtual void RemoveDeadEnemies()
        {
            foreach (EnemyController enemyController in this.enemies)
            {
                if (enemyController.EnemyDamageReceiver.IsDead())
                {
                    if(enemyController == this.nearestEnemy) this.nearestEnemy = null;
                    this.enemies.Remove(enemyController);
                    return;
                }
            }
        }
    }
}
