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
    public Animator animator;
    public float inputHorizontal;

   

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      inputHorizontal = Input.GetAxisRaw("Horizontal");
        Move();
     //Shoot();
       
        
    }

    void Move()
    {
    Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    animator.SetFloat("speed",Mathf.Abs(inputHorizontal));
     this.transform.position += Movement * speed * Time.deltaTime;
      if(inputHorizontal < 0){
        gameObject.transform.localScale = new Vector3(-1,1,1);
      }
     
      if(inputHorizontal > 0){
        gameObject.transform.localScale = new Vector3(1,1,1);
      }

    }

  /**  void Shoot(Vector2 direction, float rotationZ)
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
        }*/
    
    

}

