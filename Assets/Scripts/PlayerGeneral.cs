using UnityEngine;
using UnityEngine.UI;

public class PlayerGeneral : MonoBehaviour
{
    public int maxLives, currLives;

    public GameObject loseScreen;

    [Header("Lives UI")]
    public RawImage heartUI;
    public GameObject heartContainer;

    private void Start()
    {
        currLives = maxLives;
        print(currLives);

        gameObject.GetComponent<Gun>().isGameOver = false;

        loseScreen.SetActive(false);

        HearttUISpawn();
    }

    private void Update()
    {
        if (currLives <= 0)
        {
            loseScreen.SetActive(true);
            gameObject.GetComponent<Gun>().isGameOver = true;
        }
    }

    public void TakeDamage()
    {
        currLives--;
        HearttUISpawn();
        print(currLives);
    }

    void HearttUISpawn()
    {
        for (int i = heartContainer.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(heartContainer.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < currLives; i++)
        {
            Instantiate(heartUI, heartContainer.transform);
        }
    }
}
