using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject player;
    Animator animator;
    PlayerDeath pd;
    //Zombie stats
    public int health = 100;

    public const float attackDelay = 1.0f;
    public float delayRemaining;

    public float multiplier;
    void Start()
    {
        delayRemaining = attackDelay;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.transform.position);
        player = GameObject.FindGameObjectWithTag("Player");
        pd = player.GetComponent<PlayerDeath>();

        //Random stats
        agent.speed = Random.Range(3.0f, 6.0f);
        multiplier = Random.Range(0.6f, 1.5f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) > 2.0f)
        {
            agent.isStopped = false;
            animator.SetBool("isMoving", true);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (delayRemaining <= 0)
            {
                pd.TakeDamage(Random.Range(8, 11) * multiplier);
                delayRemaining = attackDelay;
            }
            
            animator.SetBool("isMoving", false);
            agent.isStopped = true;
        }

        if (delayRemaining >= 0)
        {
            delayRemaining -= Time.deltaTime;
        }
        //When out of health
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
