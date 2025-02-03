using System;
using _Data.Paths;
using UnityEngine;
using _Data.Scripts;


namespace _Data.Enemy.Scripts
{
    public class EnemyMoving : LocMonoBehaviour
    {
        public GameObject target;
        [SerializeField] protected EnemyController enemyController;
        [SerializeField] protected int pathIndex = 0;
        [SerializeField] protected Path enemyPath;


        protected void Start()
        {
            this.LoadEnemyPath();
        }

        void FixedUpdate()
        {
            this.Moving();
        }
   
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyController();
            this.LoadTargetMoving();
        }
   
        protected virtual void LoadEnemyController()
        {
            if (this.enemyController != null) return;
            this.enemyController = transform.parent.GetComponent<EnemyController>();
            Debug.Log(transform.name + " is loading EnemyController",gameObject);
        }
   
        protected virtual void LoadTargetMoving()
        {
            if (this.target != null) return;
            this.target = GameObject.Find("TargetMoving");
            Debug.Log(transform.name + " is loading Target",gameObject);
        }
   
        protected virtual void Moving()
        {
            this.enemyController.Agent.SetDestination(target.transform.position);
        }

        protected virtual void LoadEnemyPath()
        {
            if (this.enemyPath != null) return;
            this.enemyPath = PathsManager.Instance.GetPath(this.pathIndex);
            
            Debug.Log(transform.name + " is loading EnemyPath",gameObject);
        }
    }
}
