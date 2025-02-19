using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health = 100;
    public GameObject target;
    public EnemyHealthBarController enemyHealthBarController;

    private enum ZombieState
    {
        Walking,
        Attacking,
        Ragdoll
    }

    private Rigidbody[] _ragdollRigidBodies;
    private ZombieState _currentState = ZombieState.Walking;

    // Start is called before the first frame update
    void Awake()
    {
        _ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case ZombieState.Walking:
                WalkingBehaviour();
                break;
            case ZombieState.Attacking:
                AttackingBehaviour();
                break;
            case ZombieState.Ragdoll:
                RagDollBehaviour();
                break;
        }
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void WalkingBehaviour()
    {
        
    }

    private void AttackingBehaviour()
    {
        
    }

    private void RagDollBehaviour()
    {
        EnableRagdoll();
    }
}
