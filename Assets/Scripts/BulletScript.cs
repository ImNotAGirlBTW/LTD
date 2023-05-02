    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    public int Attack = 20;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
=======
       // Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(),this.GetComponent<Collider2D>());
    }

    void Destroy()
    {
        Destroy(gameObject);
>>>>>>> 447a967acbb5bf918b9ae43a7c93d69df27bc5c1
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("wall"))
        {
            Destroy(gameObject);


        }



    }
}
