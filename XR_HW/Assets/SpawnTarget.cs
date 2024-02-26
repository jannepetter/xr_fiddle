using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject startButton;
    public GameObject lever;


    public TextMeshProUGUI guide;
    private Queue<GameObject> targetQueue = new Queue<GameObject>();

    bool canCreateNewTarget = true;
    private int maxTargetCount = 5;
    private Vector3 minLimits = new Vector3(-7f, 1f, 10f);
    private Vector3 maxLimits = new Vector3(7f, 3f, 30f);

    bool gameOn = false;
    bool buttonReseted = true;
    float yThreshold = 0.6f;

    public int destroyedTargets = 0;
    public int spawnedTargets = 0;
    public int targetLimit = 10;

    private float spawnSpeed = 1.5f;



    void Start()
    {
    }

    void Update()
    {
        Transform buttonTransform = startButton.transform;
        float yPosition = buttonTransform.position.y;

        if(!gameOn){
            Vector3 eulerRotation = lever.transform.eulerAngles;
            float angle = eulerRotation.x;
            if(angle < 100){
                targetLimit= 20;
                spawnSpeed = 1.2f;
            }else{
                targetLimit= 10;
                spawnSpeed = 1.5f;
            }

        }


        if(yPosition >yThreshold){
            buttonReseted = true;
        }else if (buttonReseted && !gameOn && yPosition < yThreshold){
            buttonReseted=false;
            gameOn = true;
            destroyedTargets = 0;
            spawnedTargets = 0;
        }else if (buttonReseted && gameOn && yPosition < yThreshold){
                ClearTargetQueue();
                gameOn = false;
                buttonReseted = false;
        }

        if(gameOn && canCreateNewTarget && spawnedTargets < targetLimit){
            Spawn();
            spawnedTargets++;
        }else if(targetQueue.Count >0 && canCreateNewTarget){
            GameObject oldestTarget = targetQueue.Dequeue();
            Destroy(oldestTarget);
            canCreateNewTarget = false;
            StartCoroutine(TargetCooldown());
        }

        if(spawnedTargets >= targetLimit){
            gameOn = false;
        }
        SetText();
        
    }
    void Spawn(){
        float randomX = Random.Range(minLimits.x, maxLimits.x);
        float randomY = Random.Range(minLimits.y, maxLimits.y);
        float randomZ = Random.Range(minLimits.z, maxLimits.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
        var spawnedTarget = Instantiate(target, randomPosition, Quaternion.identity);
        targetQueue.Enqueue(spawnedTarget);

        if (targetQueue.Count >= maxTargetCount){
            GameObject oldestTarget = targetQueue.Dequeue();
            Destroy(oldestTarget);
        }

        canCreateNewTarget = false;
        StartCoroutine(TargetCooldown());
    }
    IEnumerator TargetCooldown(){
    float time = Random.Range(0.5f, spawnSpeed);
    yield return new WaitForSeconds(time);
    canCreateNewTarget = true;
    }

    private void ClearTargetQueue(){
        while (targetQueue.Count >0){
            GameObject targetObj = targetQueue.Dequeue();
            Destroy(targetObj);
        }
    }

    private void SetText(){
        if(spawnSpeed >= 1.5f){
            guide.text = $"Total targets {targetLimit} (normal speed)\nSpawned targets {spawnedTargets}\nDestroyed targets {destroyedTargets}";
        }else{
            guide.text = $"Total targets {targetLimit} (fast speed)\nSpawned targets {spawnedTargets}\nDestroyed targets {destroyedTargets}";
        }
    }

}
