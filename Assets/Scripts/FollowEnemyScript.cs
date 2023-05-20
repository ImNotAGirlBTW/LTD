using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyScript : MonoBehaviour
{
    public float speed;
    private float lineOfSite = 8f;
    private Transform player;
    public int Attack = 20;

    public float maxHealth = 100;
    public float currentHealth;
    public GameObject extraHealth;
    public Animator animator;
    public bool FirstInRange;


    public int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        FirstInRange = false;
        currentHealth = 100;
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            FirstInRange = true;
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            if (FirstInRange)
            {
                StartCoroutine(Timer());
                FirstInRange = false;
            }
        }
        else
        {
            FirstInRange = false;
            animator.SetBool("inRange", false);
            animator.SetBool("ShouldChange", false);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
                if(Random.Range(0f,1f) <=0.33f)
            {
            Instantiate(extraHealth, transform.position, Quaternion.identity);
            }
        }

        else
        {

         //   Destroy(col.gameObject);

        }


        if (col.gameObject.tag.Equals("Bullet"))
        {
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
            Destroy(col.gameObject);
            //Destroy(gameObject);
        }

        if (currentHealth <= 0)
        {
            if(Random.Range(0f,1f) <= 0.33f)
            {
            Instantiate(extraHealth, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

        }

   
    }

    IEnumerator Timer()
    {
        animator.SetBool("inRange", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("ShouldChange", true);

    }



}

