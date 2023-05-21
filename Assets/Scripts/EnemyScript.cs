using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    //[SerializeField]
    public float maxHealth = 1000;
    public Animator animator;
    public Slider slider;
    private Rigidbody2D rb;
    //public GameObject targer;
    public float currentHealth;
    public float bulletSpeed;
     public float shootInterval = 2f; 
    public GameObject bulletBotPrefab;
    private Transform player;
    private float lastShootTime;
    private float lineOfSite = 10f;

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("player").transform;
        rb = this.GetComponent<Rigidbody2D>();

       currentHealth = maxHealth;
        animator.SetBool("hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot(distanceFromPlayer);
            lastShootTime = Time.time;
        }

        slider.value = currentHealth;//this.gameObject.GetComponent<EnemyHealthScript>().currentHealth;
       
           if(slider.value == 0){
           SceneManager.LoadScene(5);
           
        }
        rb.velocity = Vector2.zero;

Debug.Log(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
         
        if (col.gameObject.tag.Equals("Bullet"))
        {
            animator.SetBool("hit", true);
            StartCoroutine(Blink());

            if(Random.Range(0f,1f) < EnemyHealthScript.critChance){
                 currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack *1.5f ;
            }
            else{
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
           
            Destroy(col.gameObject);
            }
           
        }

    }

        void Shoot(float distanceFromPlayer)
    {
        if(distanceFromPlayer < lineOfSite)
        {

        GameObject bullet = Instantiate(bulletBotPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        }
    }
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.2f);
       animator.SetBool("hit", false);
    }

    
}
