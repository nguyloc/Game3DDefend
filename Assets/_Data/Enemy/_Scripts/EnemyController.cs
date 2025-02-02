using UnityEngine;
using UnityEngine.AI;

public class EnemyController : LocMonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
    }
    
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + " is loading NavMeshAgent",gameObject);
    }
}
