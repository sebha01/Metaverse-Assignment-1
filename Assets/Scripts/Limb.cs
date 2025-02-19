using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    [SerializeField] Limb[] childLimbs;

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
                    limb.GetHit();
                }
            }
        }

        transform.localScale = Vector3.zero;
        Destroy(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            GetHit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Weapon"))
        {
            GetHit();
        }
    }
}
