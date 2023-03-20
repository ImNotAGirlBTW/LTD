using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyScript : MonoBehaviour
{
    public float speed;
    private float lineOfSite = 8f;
    private Transform player;



    public int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}

