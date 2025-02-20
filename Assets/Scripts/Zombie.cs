using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float _currentHealth;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Animator animator;
    public PlayerManager playerManager;

    [SerializeField] private HealthBar _healthbar;

    private float timer = 0;

    private Rigidbody[] _ragdollRigidBodies;

    public AudioSource source;
    public AudioClip zombieNoise;
    public AudioClip zombieDeath;

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
            source.PlayOneShot(zombieDeath);
            _currentHealth = 0;
            _healthbar.gameObject.SetActive(false);
            playerManager.ZombiesKilled += 1;
            Destroy(this);

        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);

            if (timer <= 0)
            {
                source.PlayOneShot(zombieNoise);
                timer = Random.Range(40, 100) / 10;
            }
            else
            {
                timer -= Time.deltaTime;
            }
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
