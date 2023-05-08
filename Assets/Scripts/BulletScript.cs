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
        StartCoroutine(TTL());
    }

    // Update is called once per frame
    void Update()
    {

        Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());



    }

    void destroy()
    {
        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("wall"))
        {
            Destroy(gameObject);


        }



    }

    IEnumerator TTL(){
        yield return new WaitForSeconds(3);
        destroy();
    }
}
