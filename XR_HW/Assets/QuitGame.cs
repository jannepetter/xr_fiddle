using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Exit()
    {

        // UnityEditor.EditorApplication.isPlaying = false;
        // Debug.Log("quitting editor!");
        Application.Quit();
        Debug.Log("quitting!");
    }

    void Update(){
        if(Input.GetButtonDown("Fire3")){
            Exit();
        }
    }

}
