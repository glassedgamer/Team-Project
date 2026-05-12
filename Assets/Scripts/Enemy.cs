using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    public Animator anim;
    public LayerMask playerLayer;

    public bool isWalkingEnemy;

    [SerializeField] float range;
    [SerializeField] float attackCooldown = 1f;

    float nextAttackTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (isWalkingEnemy)
        {
            anim.SetBool("isWalking", true);
            transform.LookAt(null);
        } 
        else
        {
            anim.SetBool("isWalking", false);

            transform.LookAt(player.transform);
        }
        
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }

    public void AttackPlayer()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, playerLayer))
        {
            GameObject objHit = hit.transform.gameObject;

            if (objHit.tag == "Player")
            {
                objHit.GetComponent<PlayerGeneral>().TakeDamage();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerGeneral>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
