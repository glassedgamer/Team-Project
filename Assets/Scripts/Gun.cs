using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera mainCam;


    //Calls the shoot function when the input action is called
    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            GameObject objHit = hit.transform.gameObject;

            Debug.Log(hit.transform.name);

            /*
            if(objHit.tag == "Enemy")
            {
                Debug.Log(hit.transform.name);
                Destroy(objHit);
            }
            */
        }
    }
}
