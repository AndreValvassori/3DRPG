using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 5f;
    public float attackInterval = 1.0f;

    private float UpdateInterval = 0.25f;
    private float nextUpdateInterval = 0f;
    private float nextAttackInterval = 0f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextUpdateInterval)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if(distance <= attackRadius)
            {
                if(Time.time >= nextAttackInterval)
                {
                    agent.SetDestination(transform.position); // Stop the agent.
                    Debug.Log("Attack");
                    nextAttackInterval = Time.time + attackInterval;
                }
            }
            else
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                //Debug.Log("Start Moving");
            }
            else
            {
                if (agent.destination != transform.position)
                {
                    agent.SetDestination(transform.position);
                    //Debug.Log("Start Idle");


                }

            }
            nextUpdateInterval = Time.time + UpdateInterval;
        }       
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
