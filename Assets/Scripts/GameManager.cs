using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Splines;
using UnityEngine.SceneManagement;

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
    public SplineContainer[] nextSpline;

    bool firstZoneSpawned = false;
    bool isTransitioning = false;
    bool waitingForNextZone = false;

    //Enemy Stuff
    int enemiesPerZone;
    int enemiesLeft;

    void Start()
    {
        //Grabs info about the current zone (look below for function)
        GetCurrentZoneInfo();
        SwitchToNewSpline();
    }

    private void Update()
    {
        // Constantly checks if camera and zone text can change based on current zone
        zoneText.text = "Zone " + (zoneNum + 1).ToString();

        // First zone spawn
        if (!firstZoneSpawned)
        {
            print(firstZoneSpawned);
            if (animator.NormalizedTime >= 1.0f)
            {
                print("spawn 1");
                SpawnNextZone();
                firstZoneSpawned = true;
            }

            return;
        }

        // Wait for transition spline to finish
        if (isTransitioning)
        {
            if (animator.ElapsedTime >= animator.Duration)
            {
                SpawnNextZone();

                isTransitioning = false;
            }
        }
    }

    void SpawnNextZone()
    {
        print("spawn 2");

        GetCurrentZoneInfo();

        currentZone = Instantiate(zones[zoneNum]);
    }

    public void SwitchToNewSpline()
    {
        // Update the target container
        animator.Container = nextSpline[zoneNum];

        // Optional: Reset animation to the beginning of the new spline
        animator.ElapsedTime = 0f;
        animator.Play();
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

        // Current zone number for the array
        zoneNum++;

        // Doesn't allow the zoneNum var to get larger than the array's length
        if(zoneNum < zones.Length)
        {
            SwitchToNewSpline();
        }
    }

    void StartTransition()
    {
        isTransitioning = true;

        // Check if current zone was the final one
        if (zoneNum >= zones.Length - 1)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }

        zoneNum++;

        Destroy(currentZone);

        SwitchToNewSpline();
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
            StartTransition();
        }
    }

}
