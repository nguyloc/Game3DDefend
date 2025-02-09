using _Data.Tower.Scripts;
using _Data.Tower.Spawner;
using UnityEngine;
using UnityEngine.AI;

namespace  _Data.Enemy.EnemyScripts
{
    public abstract class EnemyController : PoolObj
    {
        [SerializeField] protected Transform model;
        [SerializeField] protected NavMeshAgent agent;
        [SerializeField] protected Animator animator;
        [SerializeField] protected TowerTargetable towerTargetable;

        public NavMeshAgent Agent => agent;
        public Animator Animator => animator;
        public TowerTargetable TowerTargetable => towerTargetable;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadNavMeshAgent();
            this.LoadModel();
            this.LoadTowerTargetable();
            this.LoadAnimator();
        }

        protected virtual void LoadNavMeshAgent()
        {
            if (this.agent != null) return;
            this.agent = GetComponent<NavMeshAgent>();
            this.agent.speed = 2f;
            this.agent.angularSpeed = 200f;
            this.agent.acceleration = 150f;
            Debug.Log(transform.name + " is loading NavMeshAgent", gameObject);
        }

        protected virtual void LoadModel()
        {
            if (this.model != null) return;
            this.model = transform.Find("Model");
            this.model.localPosition = new Vector3(0, 0, 0);
            Debug.Log(transform.name + " is loading Model", gameObject);
        }
        
        protected virtual void LoadTowerTargetable()
        {
            if (this.towerTargetable != null) return;
            this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();
            this.towerTargetable.transform.localPosition = new Vector3(0, 0.4f, 0);
            Debug.Log(transform.name + " is loading Model", gameObject);
        }

        protected virtual void LoadAnimator()
        {
            if (this.animator != null) return;
            this.animator = this.model.GetComponent<Animator>();
            Debug.Log(transform.name + " is loading Animator", gameObject);
        }
    }
}
