using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManScript : MonoBehaviour
{
    public float speed = 5f; // rychlost pohybu bota
    public float shootInterval = 2f; // interval st�elby
    public GameObject bulletBotPrefab; // prefab st�ely

    private GameObject player; // reference na hr��e
    private float lastShootTime; // �as posledn� st�elby

    private Rigidbody2D rb;

    public int damage;
    public PlayerHealth playerHealth;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player"); // z�sk�n� reference na hr��e
        rb = GetComponent<Rigidbody2D>();
        lastShootTime = Time.time; // inicializace �asu posledn� st�elby

        currentHealth = 100;



     
    }

    void Update()
    {
        // n�sledov�n� hr��e
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // st�elba na hr��e s intervaly
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        // vytvo�en� st�ely
        GameObject bullet = Instantiate(bulletBotPrefab, transform.position, Quaternion.identity);

        // ur�en� sm�ru st�ely
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // vyst�elen� st�ely
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(direction * 10f, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // reakce na kolizi s hr��em
        if (other.CompareTag("player"))
        {
            // sn�en� zdrav� hr��e
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            // zni�en� bota
           // Destroy(gameObject);
           
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
