using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Relocate : MonoBehaviour
{
    public GameObject xrorigin; 
    int locationStatus = 0;

    public void ToOutside(){
        Vector3 outside = new Vector3(0,0,34);
        xrorigin.transform.position = outside;
        locationStatus = 1;
    }

    public void ToRoom(){
        Vector3 room = new Vector3(0,0,0);
        xrorigin.transform.position = room;
        locationStatus = 0;
    }

    void Update(){
        if(Input.GetButtonDown("Fire1")){
            if(locationStatus == 0){
                ToOutside();
            }else{
                ToRoom();
            }
        }
    }

}
