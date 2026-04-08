using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //Zones
    [Header("Zone stuff")]
    public GameObject[] zones;
    public GameObject currentZone;
    public int zoneNum = 0;

    //Enemy Stuff
    [Header("Enemy Stuff")]
    public GameObject enemyPrefab;
    public int enemiesPerZone = 5;

    void Start()
    {
        SpawnZone();
    }

    void Update()
    {
    }

    //Spawns an enemy in the current zone
    void SpawnEnemy()
    {
        currentZone = zones[zoneNum].gameObject;
        BoxCollider currColl = currentZone.GetComponent<BoxCollider>();
        Bounds bnds = currColl.bounds;

        float x = Random.Range(bnds.min.x, bnds.max.x);
        float y = currentZone.transform.position.y;
        float z = Random.Range(bnds.min.z, bnds.max.z);

        Vector3 randSpawn = new Vector3(x, y, z);

        Instantiate(enemyPrefab, randSpawn, Quaternion.identity);
    }

    void SpawnZone()
    {
        for(int i = 0; i < enemiesPerZone; i++)
        {
            SpawnEnemy();
        }
    }

}
