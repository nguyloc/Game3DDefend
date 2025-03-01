using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public Transform[] waypoints;  // Các điểm tuần tra
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude); // Điều khiển animation

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            NextWaypoint();
        }
    }

    void NextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}