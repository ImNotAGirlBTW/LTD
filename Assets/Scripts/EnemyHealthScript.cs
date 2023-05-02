using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

        public int maxHealth;
    //public Animator animator;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
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
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
            Debug.Log(currentHealth);
           //animator.SetBool("hit", true);
            Destroy(col.gameObject);
            //StartCoroutine(Blink());
            //Destroy(gameObject);
        }

    
    }
}
