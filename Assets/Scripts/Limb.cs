using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    [SerializeField] Limb[] childLimbs;
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

        transform.localScale = Vector3.zero;

        zombie._currentHealth -= 30;

        Destroy(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        GetHit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetHit();
    }
}
