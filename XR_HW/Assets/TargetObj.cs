using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
    private SpawnTarget spawnTarget;
    private void Start()
    {
        spawnTarget = FindObjectOfType<SpawnTarget>();
        if (spawnTarget == null)
        {
            Debug.LogError("SpawnTarget script not found.");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")){
        Destroy(collision.gameObject);
        Destroy(gameObject);
        if (spawnTarget != null)
            {
                spawnTarget.destroyedTargets++;
            }
        }
    }
}
