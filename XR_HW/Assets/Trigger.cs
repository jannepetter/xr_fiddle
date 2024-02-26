using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.XR.Interaction.Toolkit;

public class Trigger : MonoBehaviour
{   
    public InputActionReference laction;
    public InputActionReference raction;

    public InputActionReference lGrab;
    public InputActionReference rGrab;


    public Transform bulletSpawnPoint;
    public GameObject bulletModel;

    public float bulletSpeed = 30;

    private int maxBulletCount = 10;
    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    bool canFire = true;
    bool leftHand = false;
    bool rightHand = false;
    bool pressing = false;

    bool leftGrabbing = false;
    bool rightGrabbing = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftTriggerFinger"))
        {
            leftHand = true;
            rightHand = false;
        }
        if (other.gameObject.CompareTag("RightTriggerFinger"))
        {
            leftHand = false;
            rightHand = true;
        }
    }

    void Update(){

            leftGrabbing = lGrab.action.IsPressed();
            rightGrabbing = rGrab.action.IsPressed();


            pressing = false;
            if(leftGrabbing && leftHand){
                pressing = laction.action.IsPressed();
            }else if(rightGrabbing && rightHand){
                pressing = raction.action.IsPressed();

            }else if(!leftGrabbing && !rightGrabbing){
                leftHand = false;
                rightHand = false;
            }
            if(pressing && canFire){
                FireBullet();
            }
    }
    void FireBullet(){
        var bullet = Instantiate(bulletModel,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
        bulletQueue.Enqueue(bullet);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        if (bulletQueue.Count >= maxBulletCount){
            GameObject oldestBullet = bulletQueue.Dequeue();
            Destroy(oldestBullet);
        }
        canFire = false; 
        StartCoroutine(ResetFireCooldown());

    }
    IEnumerator ResetFireCooldown(){
    yield return new WaitForSeconds(0.3f);
    canFire = true;
    }

}