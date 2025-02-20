using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    public float AttackDistance;

    private NavMeshAgent agent;
    private Animator animator;
    private float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.transform.position;

        distanceToTarget = Vector3.Distance(agent.transform.position, player.position);

        if (distanceToTarget < AttackDistance)
        {
            agent.isStopped = true;
            animator.SetBool("CanAttack", true);
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("CanAttack", false);
            agent.destination = player.position;
        }

        agent.height = 0.5f;
        agent.baseOffset = 0;
    }

    private void OnAnimatorMove()
    {
        if (animator.GetBool("CanAttack") == false)
        {
            agent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}
