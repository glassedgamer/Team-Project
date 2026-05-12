using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{

    [Header("Crosshairs")]
    public RectTransform crosshairP1;
    public RectTransform crosshairP2;
    Vector2 moveInput01;
    Vector2 moveInput02;

    public float crosshairSpeed = 200f;

    public Camera mainCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairMovement();
    }

    void CrosshairMovement()
    {
        // Grabs the player input from both players and applies the speed. Because they're UI images, you have to create Vector2's and assign them to the images' anchored positions

        Vector2 movementP01 = moveInput01 * crosshairSpeed * Time.deltaTime;
        crosshairP1.anchoredPosition += movementP01;

        Vector2 movementP02 = moveInput02 * crosshairSpeed * Time.deltaTime;
        crosshairP2.anchoredPosition += movementP02;
    }

    void Shoot(RectTransform crosshair)
    {
        // Create raycast hit, and shoot it out from the crosshair's position on the screen
        RaycastHit hit;

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, crosshair.position);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // Detects if the raycast hits something
        if (Physics.Raycast(ray, out hit, 1))
        {
            // Assigns the object hit by the raycast to a new game object (for easier reference)
            GameObject objHit = hit.transform.gameObject;

            print(objHit.name);

            // Detects enemy
            if (objHit.name == "Play")
            {
                print("play");
            }
        }
    }

    public void OnMoveP01(InputAction.CallbackContext context)
    {
        moveInput01 = context.ReadValue<Vector2>();
    }

    public void OnMoveP02(InputAction.CallbackContext context)
    {
        moveInput02 = context.ReadValue<Vector2>();
    }

    public void OnShootP01(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(crosshairP1);
        }
    }

    //Calls the shoot function when the input action is called
    public void OnShootP02(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(crosshairP2);
        }
    }
}
