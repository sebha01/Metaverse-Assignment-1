using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug;
    public GameObject target;
    public Material crossSectionMaterial;
    public float cutForce = 2000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(planeDebug.position, planeDebug.up);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetUpSlicedComponents(upperHull);
            
            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetUpSlicedComponents(lowerHull);

            Destroy(target);
        }
    }

    public void SetUpSlicedComponents(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
    }
}
