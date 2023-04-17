using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBotScript : MonoBehaviour
{
    public int damage; // po�kozen�, kter� st�ela zp�sob�
    public int Attack = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        // reakce na kolizi se zdi nebo jin�m objektem
        if (!other.CompareTag("Bot") && !other.CompareTag("BulletBot"))
        {
            Destroy(gameObject); // zni�en� st�ely
        }

        // reakce na kolizi s hr��em
        if (other.CompareTag("player"))
        {
            // sn�en� zdrav� hr��e
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player.isAlive)
            {
                player.TakeDamage(damage);
            }

            // zni�en� bota
            Destroy(gameObject);
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
