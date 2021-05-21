using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRateMin;
    [SerializeField] float spawnRateDecrement;
    [SerializeField] float spawnRateDecrementInterval;
    [SerializeField] float spawnDistance;

    [SerializeField] GameObjectPool enemyPool;

    void Start()
    {
        InvokeRepeating("DecreaseSpawnRate", spawnRateDecrementInterval, spawnRateDecrementInterval);
        Invoke("Spawn", spawnRate);
        GameManager.instance.gameOver.AddListener(StopAndClear);
    }

    // Spawns enemies in a cirle around (0, 0, 0)
    void Spawn ()
    {
        GameObject enemy = enemyPool.GetNext();
        enemy.transform.position = RandomSpawnPosition();
        enemy.SetActive(true);
        Invoke("Spawn", spawnRate);
    }

    // Returns a point in a circle with radius spawnDistance and center (0, 0, 0)
    Vector3 RandomSpawnPosition ()
    {
        float z = Random.Range(-spawnDistance, spawnDistance);
        float x = Mathf.Sqrt(Mathf.Pow(spawnDistance, 2) - Mathf.Pow(z, 2));
        int sign = (Random.Range(0, 2) * 2) - 1;
        x *= sign;
        return new Vector3(x, 0, z);
    }

    // Makes the enemies spawn faster
    void DecreaseSpawnRate ()
    {
        if (spawnRate > spawnRateMin)
            spawnRate -= spawnRateDecrement;
    }

    void StopAndClear()
    {
        CancelInvoke();
        enemyPool.DisableAll();
    }

}
