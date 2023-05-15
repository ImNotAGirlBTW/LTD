using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

        public float maxHealth;
    //public Animator animator;
    public float currentHealth;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
            if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            if(Random.Range(0f,1f) < 0.2f){
                 currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack *1.5f ;
            }
            else{
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
            Debug.Log(currentHealth);
           //animator.SetBool("hit", true);
            Destroy(col.gameObject);
            //StartCoroutine(Blink());
            //Destroy(gameObject);
            }
            rb.velocity = Vector2.zero;
        }

    
    }
}
