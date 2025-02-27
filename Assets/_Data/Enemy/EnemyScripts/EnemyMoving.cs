using System;
using _Data.Paths;
using _Data.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Data.Enemy.EnemyScripts
{
    public class EnemyMoving : LocMonoBehaviour
    {
        public GameObject target;
        
        [SerializeField] protected EnemyController enemyController;

        
        [SerializeField] protected string pathName = "path (1)";
        [FormerlySerializedAs("enemyPath")]
        [SerializeField] protected PathMoving enemyPathMoving;
        [SerializeField] protected Point currentPoint;
        
        [SerializeField] protected float pointDistance = Mathf.Infinity;
        [SerializeField] protected float stopDistance = 1f;
        
        [SerializeField] protected bool isFinish = false;
        [SerializeField] protected bool isMoving = false;
        [SerializeField] protected bool canMove = false;


        protected void OnEnable()
        {
            this.OnReborn();
        }


        protected override void Start()
        {
            this.LoadEnemyPath();
        }

        void FixedUpdate()
        {
            this.Moving();
            this.CheckMoving();
        }
   
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyController();
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
            if (!this.canMove)
            {
                this.enemyController.Agent.isStopped = true;
                return;
            }
            
            if (this.enemyController.EnemyDamageReceiver.IsDead())
            {
                this.enemyController.Agent.isStopped = true;
                return;
            }
            
            this.FindNextPoint();
            
            if (this.currentPoint == null || this.isFinish == true)
            {
                this.enemyController.Agent.isStopped = true;
                return;
            }
            
            this.enemyController.Agent.isStopped = false;
            this.enemyController.Agent.SetDestination(this.currentPoint.transform.position);
        }
        
        protected virtual void FindNextPoint()
        {
            if (this.currentPoint == null) this.currentPoint = this.enemyPathMoving.GetPoint(0);
            
            this.pointDistance = Vector3.Distance(transform.position, this.currentPoint.transform.position);
            if (this.pointDistance < this.stopDistance)
            {
                this.currentPoint = this.currentPoint.NextPoint;
                if (this.currentPoint == null) this.isFinish = true;
            }
        }

        protected virtual void LoadEnemyPath()
        {
            if (this.enemyPathMoving != null) return;
            this.enemyPathMoving = PathsManager.Instance.GetPath(this.pathName);
            
            //Debug.Log(transform.name + " is loading EnemyPath",gameObject);
        }
        
        protected virtual void CheckMoving()
        {
            if (this.enemyController.Agent.velocity.magnitude > 0.1f) this.isMoving = true;
            else this.isMoving = false;
            
            this.enemyController.Animator.SetBool("isMoving", this.isMoving);
        }
        
        protected virtual void OnReborn()
        {
            this.isFinish = false;
            this.currentPoint = null;
        }
    }
}
