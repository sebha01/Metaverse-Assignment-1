using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;
    public float ZombiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decrementHealth(int healthToDecrement)
    {
        currentHealth -= healthToDecrement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            decrementHealth(10);
        }
    }
}
