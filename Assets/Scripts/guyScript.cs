using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class guyScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    public float inputMove;
    [SerializeField]
    public GameObject bullet;

    public GameObject crosshair;
    public GameObject player;
    private Vector3 target;
     

    // Start is called before the first frame update
    void Start()
    {
          Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        Look();
        
    }

    void Move()
    {
    Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

     this.transform.position += Movement * speed * Time.deltaTime;

     

    }

    void Shoot(Vector2 direction, float rotationZ)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        if(Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = new Vector2(
            mousePos.x - transform.position.x,
             mousePos.y - transform.position.y
        );
            b.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    void Look()
    {
        //https://www.youtube.com/watch?v=7-8nE9_FwWs
        target = transform.position.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));
         crosshair.transform.position = new Vector2(target.x, target.y); 

         Vector3 difference = target - player.transform.position;
         float rotationZ = Mathf.Atan2(difference.y,difference.x)* Mathf.Rad2Deg;
         player.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);

}
}
