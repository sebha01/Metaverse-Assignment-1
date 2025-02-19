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
                    limb.GetHit();
                }
            }
        }

        transform.localScale = Vector3.zero;

        zombie.health -= 30;

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
