using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

        public float maxHealth;
    //public Animator animator;
    public float currentHealth;
    public static float critChance ;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        critChance = 0.2f;
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
            if(Random.Range(0f,1f) < critChance){
                 currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack *1.5f ;
            }
            else{
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
           
            Destroy(col.gameObject);
            }
        }

    
    }
}
