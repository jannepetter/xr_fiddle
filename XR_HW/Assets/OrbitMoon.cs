using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMoon : MonoBehaviour
{

    public GameObject planet;
    void Start()
    {
        planet = GetComponent<GameObject>();
    }

    void Update()
    {
        transform.Rotate(0,10*Time.deltaTime,0);
    }
}
