using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    [SerializeField] Limb[] childLimbs;
    [SerializeField] GameObject limbPrefab;
    public Zombie zombie;

    private void Start()
    {
    }

    private void Update()
    {
        
    }

    public void GetHit()
    {
        if (childLimbs.Length > 0)
        {
            foreach (Limb limb in childLimbs)
            {
                if (limb != null)
                {
                    transform.localScale = Vector3.zero;
                    Destroy(this);
                }
            }
        }

        if (limbPrefab != null)
        {
            Instantiate(limbPrefab, transform.position, transform.rotation);
        }

        transform.localScale = Vector3.zero;

        zombie._currentHealth -= 30;

        Destroy(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GetHit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GetHit();
        }
    }
}
