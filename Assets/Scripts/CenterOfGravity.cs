using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfGravity : MonoBehaviour
{
    public Vector3 centerOfMass;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the game is currently running in the Unity Editor(play mode)
        #if UNITY_EDITOR
        _rb.centerOfMass = centerOfMass;
        _rb.WakeUp();
        #endif
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerOfMass, 0.05f);
    }
}
