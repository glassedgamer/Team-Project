using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float spawnRadius = 10f;

    //Enemy Stuff
    [Header("Enemy Stuff")]
    public GameObject enemyPrefab;
    public int enemiesPerZone = 5;

    private void Start()
    {

        SpawnZone();
    }

    //Spawns an enemy in the current zone
    void SpawnEnemy()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRadius;

        randomPos.y = 0;
        Vector3 spawnPoint = transform.position + randomPos;

        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }

    //Calls the Enemy spawning function based on how many enemies you want in a zone
    void SpawnZone()
    {
        for (int i = 0; i < enemiesPerZone; i++)
        {
            SpawnEnemy();
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
    */
}
