using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnRate = 5.0f;
    public float spawnRadius = 30.0f;
    public float minSpawnDist = 15.0f;
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
        // Vector2 spawnPosition = playerPosition + new Vector2(
        //     Random.Range(-spawnRadius, spawnRadius),
        //     Random.Range(-spawnRadius, spawnRadius)
        // );
        float angle = Random.Range(0f, Mathf.PI * 2);
        float distance = Random.Range(minSpawnDist, spawnRadius);
        Vector2 spawnPosition = playerPosition + new Vector2(
            Mathf.Cos(angle) * distance,
            Mathf.Sin(angle) * distance
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}