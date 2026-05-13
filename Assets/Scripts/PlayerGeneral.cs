using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    public int maxLives, currLives;

    public GameObject loseScreen;

    private void Start()
    {
        currLives = maxLives;
        print(currLives);

        loseScreen.SetActive(false);
    }

    private void Update()
    {
        if (currLives <= 0)
            loseScreen.SetActive(true);
    }

    public void TakeDamage()
    {
        currLives--;
        print(currLives);
    }
}
