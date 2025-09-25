using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.UI;

public class slimecoltroler : MonoBehaviour
{

    public Image hpBar;
    public float hp = 100f;

    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 1f;
    public float detectionRange = 10f;

    Animator amin;
    bool isPlayerIngRage = false;
    bool hasReachePlayer = false;
    //bhjgvbjbgjvjjg

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
        UpdateAnimetions();
        UpdateUI();
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
        if (amin != null)
        {

        }
    
        amin.SetBool("Attack", hasReachePlayer);
    }
    void UpdateUI()
    {
        hpBar.fillAmount = hp / 100f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
           hp -= 20f;
            if (hp <= 0f)
            {
                Destroy(gameObject);
            }
        }

    }
}

    
