using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public static int health = 4;

    public Image[] hearts;
    public Sprite fullHeart;
   //  public Sprite halfHeart;
    public Sprite emptyHeart;

    public bool isAlive = true;
    //Start is called before the first frame update
    void Start()
    {
        //health = maxHealth;
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
    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isAlive = false;
           // Time.timeScale = 0f;
            //Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            health -= col.gameObject.GetComponent<FollowEnemyScript>().Attack;
        

            Destroy(col.gameObject);

            //Destroy(gameObject);
        }

        if (col.gameObject.tag.Equals("BulletBot"))
        {
            health -= col.gameObject.GetComponent<BulletBotScript>().Attack;
        
            Destroy(col.gameObject);

            //Destroy(gameObject);
        }

        if (health <= 0)
        {
             SceneManager.LoadScene(4);
             Cursor.visible = true;
             health = maxHealth;
        }
    }

}