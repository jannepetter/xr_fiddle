using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    public GameObject lens;
    void Update()
    {
        // transform.LookAt(target);
        // Vector3 upLocation = transform.up;
        // transform.up = Vector3.up;
        Vector3 upDirection = lens.transform.up;
        transform.rotation = Quaternion.LookRotation(transform.position - target.position, upDirection);

    }
}
