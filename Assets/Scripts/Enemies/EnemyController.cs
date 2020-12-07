using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    public NavMeshAgent agent;
    public Animator animator;
    public float lookRadius = 10f;
    public float speed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
    }



    void Update()
    { if (animator.GetBool("isDead") != true)
        {

            float distance = Vector3.Distance(target.position, transform.position);

            if (animator.GetBool("Running") != true)
            {
                animator.SetBool("Running", false);
                animator.SetInteger("Condition", 0);
            }

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                animator.SetBool("Running", true);
                animator.SetInteger("Condition", 2);

                if (distance <= agent.stoppingDistance)
                {
                    animator.SetBool("Running", false);
                    animator.SetInteger("Condition", 0);
                }

            }
        } return;
    }
}