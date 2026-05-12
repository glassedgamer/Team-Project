using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    public int maxLives, currLives;

    private void Start()
    {
        currLives = maxLives;
        print(currLives);
    }

    private void Update()
    {
        if (currLives <= 0)
            print("Ded");
    }

    public void TakeDamage()
    {
        currLives--;
        print(currLives);
    }
}
