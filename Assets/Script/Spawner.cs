using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawn;

    private int spawnPoint;
    
    void Start()
    {
        StartCoroutine(Enemies());
    }

    // Coroutine responsible for spawning enemies at specified spawn points.
    IEnumerator Enemies()
    {
        // Continue spawning enemies as long as the game is not ended.
        while (!GameManager.Instance.isEnd) 
        {
            // Get the position of the current spawn point from the 'spawn' array.
            var pos = spawn[spawnPoint];
            Instantiate(enemy, pos.position, Quaternion.identity);

            // Cycle to the next spawn point, looping back to the first one.
            spawnPoint = (spawnPoint + 1) % spawn.Length;

            // Wait for a specific duration before spawning the next enemy.
            yield return new WaitForSeconds(2.0f);
        }
    }
}
