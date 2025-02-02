using UnityEngine;
using UnityEngine.AI;

public class EnemyController : LocMonoBehaviour
{
    [SerializeField]protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    
    public NavMeshAgent Agent => agent;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
    }
    
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 2f;
        this.agent.angularSpeed = 200f;
        this.agent.acceleration = 150f;
        Debug.Log(transform.name + " is loading NavMeshAgent",gameObject);
    }
    
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0,0,0);
        Debug.Log(transform.name + " is loading Model",gameObject);
    }
}
