using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public Light light; 

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetKeyDown("tab")){
        light.enabled = !light.enabled;
        }
    }
    public void ButtonClicked(){
        light.enabled = !light.enabled;
    }
}
