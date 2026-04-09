using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera mainCam;

    public LayerMask enemyLayer;


    //Calls the shoot function when the input action is called
    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;
        //Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        //Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject objHit = hit.transform.gameObject;

            if(objHit.tag == "Enemy")
            {
                Destroy(objHit);
            }
        }
    }
}
