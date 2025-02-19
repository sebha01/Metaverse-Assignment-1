using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Camera cameratToLookAt;

    private void Update()
    {
        Vector3 v = cameratToLookAt.transform.position - transform.position;
        v.x = v.x = 0.0f;
        transform.LookAt(cameratToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
