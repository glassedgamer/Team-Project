using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour
{
    
    //Zones
    [Header("Zone stuff")]
    GameObject currentZone;
    public GameObject[] zones;
    public int zoneNum = 0;

    [Header("UI")]
    public Text zoneText;

    [Header("Splines")]
    public SplineAnimate animator;
    //public SplineContainer nextSpline;

    bool isTransitioning = false;

    //Enemy Stuff
    int enemiesPerZone;
    int enemiesLeft;

    void Start()
    {
        //Instantiates prefab in the current index of zone array into Game Object
        currentZone = Instantiate(zones[zoneNum]);

        //Grabs info about the current zone (look below for function)
        GetCurrentZoneInfo();
    }

    private void Update()
    {
        // Constantly checks if camera and zone text can change based on current zone
        zoneText.text = "Zone " + (zoneNum + 1).ToString();

        if (isTransitioning)
        {
            if (animator.ElapsedTime >= animator.Duration)
            {
                NextZone();
            }
        }
    }

    void Thing()
    {
        currentZone = Instantiate(zones[zoneNum]);
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

    // Checks how many enemies are left in the current zone. Referenced in the Gun script
    public void SubtractEnemies()
    {
        // Subtract from enemy var
        enemiesLeft--;

        print(enemiesLeft);

        // Transitions into the next zone when the amount of enemies reaches 0.
        if (enemiesLeft <= 0)
        {
            isTransitioning = true;
        }
    }

}
