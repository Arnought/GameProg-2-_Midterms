using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bulletobj;
    public Transform spawn;
    
    void Start()
    {
        // Start a coroutine to repeatedly fire bullets as long as the game is not ended.
        StartCoroutine(Fire()); 
    }

    // Coroutine responsible for firing bullets at regular intervals.
    IEnumerator Fire()
    {
        // Continue firing bullets as long as the game is not ended (based on GameManager's state).
        while (!GameManager.Instance.isEnd) 
        {
            // Instantiate a new bullet at the specified spawn position and rotation.
            var bullet = Instantiate(bulletobj, spawn.position, spawn.rotation);
            Destroy(bullet, 5);

            // Wait for a specific duration before firing the next bullet.
            yield return new WaitForSeconds(1);
        }
    }
}
