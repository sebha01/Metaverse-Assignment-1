using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public AttributeManager attribMgr;
    public GameObject target;

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
        attribMgr = GetComponent<AttributeManager>();
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
        CheckHealth();
    }

    private void AttackingBehaviour()
    {
        CheckHealth();
    }

    private void RagDollBehaviour()
    {
        EnableRagdoll();
    }

    private void CheckHealth()
    {
        if (attribMgr.health <= 0)
        {
            _currentState = ZombieState.Ragdoll;
        }
    }
}
