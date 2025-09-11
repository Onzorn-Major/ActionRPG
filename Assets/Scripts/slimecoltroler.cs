using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class slimecoltroler : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 1f;
    public float detectionRange = 10f;

    Animator amin;
    bool isPlayerIngRage = false;
    bool hasReachePlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        amin = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerIngRage = distance <= detectionRange;
        if (isPlayerIngRage)
        {
            if (distance <= stopDistance)
            {
                StopMoving();
            }
            else
            {

            }
            MoveToPlayer();
        }
        else
        {
            StopMoving();

        }
    }
    void MoveToPlayer()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
           
        }
    }
    void StopMoving()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.ResetPath();
            hasReachePlayer = true;
        }
    }
    void UpdateAnimetions()
    {
        amin.SetBool("Attack", hasReachePlayer);
    }
}
