using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //Zones
    [Header("Zone stuff")]
    GameObject currentZone;
    public GameObject[] zones;
    public int zoneNum = 0;

    //Cam Stuff
    public Animator camTransitions;

    //Enemy Stuff
    int enemiesPerZone;
    int enemiesLeft;

    void Start()
    {
        currentZone = Instantiate(zones[zoneNum]);
        print(enemiesLeft);

        GetCurrentZoneInfo();
    }

    void Update()
    {
        if(enemiesLeft <= 0)
            NextZone();
    }

    void GetCurrentZoneInfo()
    {
        enemiesPerZone = zones[zoneNum].gameObject.GetComponent<EnemySpawn>().enemiesPerZone;

        enemiesLeft = enemiesPerZone;
    }

    void NextZone()
    {
        print("Zone Complete!!!");

        Destroy(zones[zoneNum].gameObject);

        CameraTransitions();

        zoneNum++;
        GetCurrentZoneInfo();

        currentZone = Instantiate(zones[zoneNum]);
    }

    void CameraTransitions()
    {
        if(zoneNum == 1)
        {
            camTransitions.SetTrigger("SwitchCameras");
        }
    }

    public void SubtractEnemies()
    {
        enemiesLeft--;

        print(enemiesLeft);
    }

}
