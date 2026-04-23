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
        gm = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        CrosshairMovement();
    }
    void CrosshairMovement()
    {
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


    void Shoot(RectTransform crosshair)
    {

        RaycastHit hit;

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, crosshair.position);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out hit, range, enemyLayer))
        {
            GameObject objHit = hit.transform.gameObject;

            print(objHit.name);

            // Detects enemy
            if(objHit.tag == "Enemy")
            {
                Collider enemyCol = objHit.GetComponent<Collider>();

                if(enemyCol != null && enemyCol.enabled)
                {
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
