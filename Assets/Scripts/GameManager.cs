using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //Zones
    [Header("Zone stuff")]
    GameObject currentZone;
    public GameObject[] zones;
    public int zoneNum = 0;

    //Enemy Stuff
    [Header("Enemy Stuff")]
    public GameObject enemyPrefab;
    public int enemiesPerZone = 5;

    void Start()
    {
        currentZone = Instantiate(zones[zoneNum]);
    }

    void Update()
    {

    }

    

}
