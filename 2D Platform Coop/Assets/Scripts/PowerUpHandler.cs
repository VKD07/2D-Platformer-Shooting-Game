using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] float minTimeToSpawn = 5f;
    [SerializeField] float maxTimeToSpawn = 10f;
    [SerializeField]float randomTimeToSpawn;

    [Header("Power Ups Prefabs")]
    [SerializeField] GameObject[] powerUps;

    [Header("Spawning Points")]
    [SerializeField] Transform[] spawnPoints;
    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            randomTimeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            yield return new WaitForSeconds(randomTimeToSpawn);
            InstatiatePowerUps();
        }
    }

    void InstatiatePowerUps()
    {
        int randomPowerUP = Random.Range(0, powerUps.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(powerUps[randomPowerUP], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
