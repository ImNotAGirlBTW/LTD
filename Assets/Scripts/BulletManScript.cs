using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManScript : MonoBehaviour
{
    public float speed = 5f; // rychlost pohybu bota
    public float shootInterval = 2f; // interval st�elby
    public GameObject bulletBotPrefab; // prefab st�ely


    private Transform player; // reference na hr��e
    private float lastShootTime; // �as posledn� st�elby


    private Rigidbody2D rb;

    public int damage;
    public PlayerHealth playerHealth;

    public bool canDmg;
    public float bulletSpeed;
    private float lineOfSite = 8f;
    void Start()
    {
        canDmg = true;
        player = GameObject.FindGameObjectWithTag("player").transform; // z�sk�n� reference na hr��e
        rb = GetComponent<Rigidbody2D>();
        lastShootTime = Time.time; // inicializace �asu posledn� st�elby





     
    }

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        // n�sledov�n� hr��e
          if (distanceFromPlayer < lineOfSite)
        {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        }
        // st�elba na hr��e s intervaly
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot(distanceFromPlayer);
            lastShootTime = Time.time;
        }

    }

    void Shoot(float distanceFromPlayer)
    {
        if(distanceFromPlayer < lineOfSite)
        {
        // vytvo�en� st�ely
        GameObject bullet = Instantiate(bulletBotPrefab, transform.position, Quaternion.identity);

        // ur�en� sm�ru st�ely
        Vector2 direction = (player.transform.position - transform.position).normalized;
        
        // vyst�elen� st�ely
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        }
            }

    void OnTriggerEnter2D(Collider2D other)
    {
        // reakce na kolizi s hr��em
        if (other.CompareTag("player"))
        {
        
            speed =0f;
            // sn�en� zdrav� hr��e
            if(canDmg){
                canDmg = false;
            StartCoroutine(TakeDamage(1,other));
            }

           
        }

        
    }

        void OnTriggerExit2D(Collider2D other){
              if (other.CompareTag("player")){
                speed =5f;
              }
        }

        public IEnumerator TakeDamage(int damage, Collider2D other)
        {
                PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            yield return new WaitForSeconds(2f);
            canDmg = true;
        }

}
