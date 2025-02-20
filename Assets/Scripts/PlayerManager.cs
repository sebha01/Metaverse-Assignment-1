using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;
    public float ZombiesKilled = 0;

    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateHealthBar(maxHealth, currentHealth);

        if (currentHealth <= 0)
        {
            SceneTransitionManager.singleton.GoToSceneAsync(2);
        }
    }

    public void decrementHealth(int healthToDecrement)
    {
        currentHealth -= healthToDecrement;
    }

    private void OnTriggerEnter(Collider other)
    {
        Limb limb = other.GetComponent<Limb>();
        Zombie zombie = other.GetComponentInParent<Zombie>();

        if (limb != null)
        {
            if (zombie.animator.GetBool("CanAttack") == true)
            {
                decrementHealth(1);
            }
        }
    }
}
