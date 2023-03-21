using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyScript : MonoBehaviour
{
    public float speed;
    private float lineOfSite = 8f;
    private Transform player;
    public int Attack = 20;

    public int maxHealth = 100;
    public int currentHealth;



    public int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
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
        }
        else
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag.Equals("Bullet"))
        {
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
            Debug.Log(currentHealth);
            Destroy(col.gameObject);
            //Destroy(gameObject);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



}

