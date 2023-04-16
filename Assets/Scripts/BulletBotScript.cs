using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBotScript : MonoBehaviour
{
    public int damage; // poškození, které støela zpùsobí
    public int Attack = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        // reakce na kolizi se zdi nebo jiným objektem
        if (!other.CompareTag("Bot") && !other.CompareTag("BulletBot"))
        {
            Destroy(gameObject); // znièení støely
        }

        // reakce na kolizi s hráèem
        if (other.CompareTag("player"))
        {
            // snížení zdraví hráèe
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player.isAlive)
            {
                player.TakeDamage(damage);
            }

            // znièení bota
            Destroy(gameObject);
        }
    }
}
