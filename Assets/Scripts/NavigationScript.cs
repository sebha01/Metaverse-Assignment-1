using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    public float AttackDistance;

    private NavMeshAgent agent;
    private Animator animator;
    private float distanceToTarget;
    private Zombie zombie;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombie = GetComponent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombie._currentHealth > 0)
        { 
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
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnAnimatorMove()
    {
        if (animator.GetBool("CanAttack") == false)
        {
            agent.speed = ((animator.deltaPosition / Time.deltaTime) * 2).magnitude;
        }
    }
}
