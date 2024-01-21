using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public Light roomLight; 

    void Start()
    {
        roomLight = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2")){
            if (roomLight.color == Color.red){
            roomLight.color = Color.white;
            }else{
                roomLight.color = Color.red;
            }
        }
    }
    public void ButtonClicked(){
        if (roomLight.color == Color.red){
            roomLight.color = Color.white;
        }else{
            roomLight.color = Color.red;
        }
    }
}
