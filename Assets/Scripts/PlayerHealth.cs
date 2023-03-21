using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

   
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            health -= col.gameObject.GetComponent<FollowEnemyScript>().Attack;
            Debug.Log(health);

            Destroy(col.gameObject);

            //Destroy(gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
