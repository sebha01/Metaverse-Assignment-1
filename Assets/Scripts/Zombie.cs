using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float _currentHealth;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] public Animator animator;
    public PlayerManager playerManager;

    [SerializeField] private HealthBar _healthbar;

    private float deathTimer = 5;
    private bool timerStarted = false;
    private bool deathSoundPlayed = false;
 
    public Spawner spawner;
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
        spawner = FindAnyObjectByType<Spawner>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
        {
            EnableRagdoll();

            if (!deathSoundPlayed)
            {
                source.PlayOneShot(zombieDeath);
                deathSoundPlayed = true;
            }

            _currentHealth = 0;
            _healthbar.gameObject.SetActive(false);
            playerManager.ZombiesKilled += 1;
            timerStarted = true;
        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        }

        if (timerStarted)
        {
            if (deathTimer <= 0)
            {
                Destroy(gameObject);
                timerStarted = false;
            }

            deathTimer -= Time.deltaTime;
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

    private void OnDestroy()
    {
        spawner.numberOfZombies--;
    }
}
