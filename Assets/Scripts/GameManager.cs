using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    //Zones
    [Header("Zone stuff")]
    GameObject currentZone;
    public GameObject[] zones;
    public int zoneNum = 0;

    [Header("UI")]
    public Text zoneText;

    [Header("Camera")]
    //Cam Stuff
    public Animator camTransitions;

    bool isTransitioning = false;

    //Enemy Stuff
    int enemiesPerZone;
    int enemiesLeft;

    void Start()
    {
        //Instantiates prefab in the current index of zone array into Game Object
        currentZone = Instantiate(zones[zoneNum]);
        print(enemiesLeft);

        //Grabs info about the current zone (look below for function)
        GetCurrentZoneInfo();
    }

    private void Update()
    {
        // Constantly checks if camera and zone text can change based on current zone
        CameraTransitions();
        zoneText.text = "Zone " + (zoneNum + 1).ToString();
    }

    void GetCurrentZoneInfo()
    {
        //Grabs the amount of enemies from the current zone prefab in the zone array, and sets it to a new variable in this script
        enemiesPerZone = zones[zoneNum].gameObject.GetComponent<EnemySpawn>().enemiesPerZone;

        enemiesLeft = enemiesPerZone;

    }

    // Changes the current zone to the next one in the array
    void NextZone()
    {
        print("Zone Complete!!!");

        // Destroys the current zone spawner in the scene
        Destroy(currentZone);

        // Current zone number for the array
        zoneNum++;

        // Doesn't allow the zoneNum var to get larger than the array's length
        if(zoneNum < zones.Length)
        {
            // Grabs the zone info for the new zone
            GetCurrentZoneInfo();

            // Sets the next prefab in the array to a Game Object
            currentZone = Instantiate(zones[zoneNum]);
            isTransitioning = false;
        }
    }

    // Deals with camera transitions
    void CameraTransitions()
    {
        // Gets current zone num, and will trigger the next set of cameras (references the State Driven Camera in scene)

        if(zoneNum == 1)
        {
            camTransitions.SetTrigger("SwitchCameras");
        }
    }

    // Checks how many enemies are left in the current zone. Referenced in the Gun script
    public void SubtractEnemies()
    {
        // Subtract from enemy var
        enemiesLeft--;

        print(enemiesLeft);

        // Transitions into the next zone when the amount of enemies reaches 0.
        if (enemiesLeft <= 0 && !isTransitioning)
        {
            isTransitioning = true;
            NextZone();
        }
    }

}
