using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 2f;
    public float detectionRange = 10f;

    Animator anim;
    bool isPlayerInRange = false;
    bool hasReachedPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerInRange = distance <= detectionRange;
        if (isPlayerInRange)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
            hasReachedPlayer = false;
        }
    }
}