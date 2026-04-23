using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Values")]
    public float damage = 10f;
    public float range = 100f;
    public float crosshairSpeed = 200f;

    [Header("Crosshairs")]
    public RectTransform crosshairP1;
    public RectTransform crosshairP2;
    Vector2 moveInput01;
    Vector2 moveInput02;

    [Header("Camera")]
    public Camera mainCam;

    [Header("Layers")]
    public LayerMask enemyLayer;

    [Header("Object References")]
    GameManager gm;

    private void Start()
    {
        // Finds the game manager in the scene
        gm = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // See the function right below
        CrosshairMovement();
    }

    // Crosshairs can move!!!
    void CrosshairMovement()
    {
        // Grabs the player input from both players and applies the speed. Because they're UI images, you have to create Vector2's and assign them to the images' anchored positions

        Vector2 movementP01 = moveInput01 * crosshairSpeed * Time.deltaTime;
        crosshairP1.anchoredPosition += movementP01;

        Vector2 movementP02 = moveInput02 * crosshairSpeed * Time.deltaTime;
        crosshairP2.anchoredPosition += movementP02;
    }

    //Calls the shoot function when the input action is called
    public void OnShootP01(InputAction.CallbackContext context)
    {
        Shoot(crosshairP1);
    }

    //Calls the shoot function when the input action is called
    public void OnShootP02(InputAction.CallbackContext context)
    {
        Shoot(crosshairP2);
    }

    // Sends out raycasts and stuff. RectTransform is to reference the UI images
    void Shoot(RectTransform crosshair)
    {
        // Create raycast hit, and shoot it out from the crosshair's position on the screen
        RaycastHit hit;

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, crosshair.position);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // Detects if the raycast hits something
        if (Physics.Raycast(ray, out hit, range, enemyLayer))
        {
            // Assigns the object hit by the raycast to a new game object (for easier reference)
            GameObject objHit = hit.transform.gameObject;

            print(objHit.name);

            // Detects enemy
            if(objHit.tag == "Enemy")
            {
                // Grabs the collider from the enemy
                Collider enemyCol = objHit.GetComponent<Collider>();

                // Detects if enemeyCol actually exists and if its collider is turned on
                if(enemyCol != null && enemyCol.enabled)
                {
                    // Turns off collider, destroys the object, and subtracts from the enemy count over in the game manager
                    enemyCol.enabled = false;
                    Destroy(objHit);
                    gm.SubtractEnemies();
                }
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
}
