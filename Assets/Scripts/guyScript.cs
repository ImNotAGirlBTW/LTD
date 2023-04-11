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
    public float inputVertical;

    public Text KeyScoreText;
    private int ScoreNum;
    
   

    // Start is called before the first frame update
    void Start()
    {
      ScoreNum= 0;
        KeyScoreText.text = "" + ScoreNum;  
    }

    // Update is called once per frame
    void Update()
    {
      inputHorizontal = Input.GetAxisRaw("Horizontal");
      inputVertical = Input.GetAxisRaw("Vertical");
        Move();

    }

    void Move()
    {
    Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    animator.SetFloat("speed",Mathf.Abs(inputHorizontal));
    animator.SetFloat("VerticalM",inputVertical);
     this.transform.position += Movement * speed * Time.deltaTime;
      if(inputHorizontal < 0){
        gameObject.transform.localScale = new Vector3(-1,1,1);
      }
     
      if(inputHorizontal > 0){
        gameObject.transform.localScale = new Vector3(1,1,1);
      }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            ScoreNum += 1;
            Destroy(collision.gameObject);
            KeyScoreText.text = "" + ScoreNum;
            // zmìna stavu klíèe na vypnuto
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

