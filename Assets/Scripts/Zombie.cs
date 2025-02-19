using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float _currentHealth;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Animator animator;

    [SerializeField] private HealthBar _healthbar;

    private Rigidbody[] _ragdollRigidBodies;

    // Start is called before the first frame update
    void Awake()
    {
        _ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll(); 
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
        {
            EnableRagdoll();
            _currentHealth = 0;
            _healthbar.gameObject.SetActive(false);
        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        }
    }

    private void DisableRagdoll()
    {
        animator.enabled = true;

        foreach (var rigidbody in _ragdollRigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void EnableRagdoll()
    {
        animator.enabled = false;

        foreach (var rigidbody in _ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
