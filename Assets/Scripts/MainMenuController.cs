using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnShootP01(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("TeamProjectLevel");
        }
    }

    //Calls the shoot function when the input action is called
    public void OnShootP02(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("TeamProjectLevel");
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Application.Quit();
        }
    }
}
