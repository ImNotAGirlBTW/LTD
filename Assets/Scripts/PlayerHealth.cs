using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
   //  public Sprite halfHeart;
    public Sprite emptyHeart;
    //Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
            // img.sprite = halfHeart;
        }

        for (int i = 0; i < health; i++)
        {

            hearts[i].sprite = fullHeart;
        }
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