using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnRate = 5.0f;
    public float spawnRadius = 20.0f;
    private float nextSpawnTs;

    void Start() {}

    void Update() { 
        if (Time.time >= nextSpawnTs) {
            Spawn();
            nextSpawnTs = Time.time + 1f / spawnRate;
        }
    }

     void Spawn()
    {
        Vector2 playerPosition = transform.position; // Get the player's current position
        Vector2 spawnPosition = playerPosition + new Vector2(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius)
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}