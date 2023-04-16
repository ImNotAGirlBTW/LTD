using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManScript : MonoBehaviour
{
    public float speed = 5f; // rychlost pohybu bota
    public float shootInterval = 2f; // interval støelby
    public GameObject bulletBotPrefab; // prefab støely

    private GameObject player; // reference na hráèe
    private float lastShootTime; // èas poslední støelby

    private Rigidbody2D rb;

    public int damage;
    public PlayerHealth playerHealth;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player"); // získání reference na hráèe
        rb = GetComponent<Rigidbody2D>();
        lastShootTime = Time.time; // inicializace èasu poslední støelby

        currentHealth = 100;



     
    }

    void Update()
    {
        // následování hráèe
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // støelba na hráèe s intervaly
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        // vytvoøení støely
        GameObject bullet = Instantiate(bulletBotPrefab, transform.position, Quaternion.identity);

        // urèení smìru støely
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // vystøelení støely
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(direction * 10f, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // reakce na kolizi s hráèem
        if (other.CompareTag("player"))
        {
            // snížení zdraví hráèe
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            // znièení bota
            Destroy(gameObject);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       /* if (col.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
            Instantiate(key, transform.position, Quaternion.identity);
        }
        else
        {

            Destroy(col.gameObject);

        } */

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
