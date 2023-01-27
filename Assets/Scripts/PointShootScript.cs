using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootScript : MonoBehaviour
{
    public float speed = 60f;
    public GameObject bullet;
     public GameObject crosshair;
    public GameObject playerG;
    private Vector3 target;
    public GameObject Player;
     public GameObject GunL;
     
    // Start is called before the first frame update
    void Start()
    {
          Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      
       target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));
         crosshair.transform.position = new Vector2(target.x, target.y); 

         Vector3 difference = target - playerG.transform.position;
         float rotationZ = Mathf.Atan2(difference.y,difference.x)* Mathf.Rad2Deg;
         playerG.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ );
        playerG.transform.position = Player.transform.position;
        if(Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fire(direction, rotationZ);
        }
  
    }
    void fire(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = GunL.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

}
