using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PointShootScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=7-8nE9_FwWs
    public float speed = 160f;
    public GameObject bullet;
     public GameObject crosshair;
    public GameObject playerG;
    private Vector3 target;
    public GameObject Player;
     public GameObject GunL;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public bool hasAmmo;
    public int clickAmount;
    public TMP_Text AmmoText;
    public float rotationZ;
    private bool isFiring = false;
    // Start is called before the first frame update
    void Start()
    {
   
          Cursor.visible = false;
          hasAmmo = true;
        clickAmount = 10;
        AmmoText.text = clickAmount +"/∞";
    }

    // Update is called once per frame
    void Update()
    {

        if(!MainMenuScript.IsPaused){
       target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));
         crosshair.transform.position = new Vector2(target.x, target.y); 

         Vector3 difference = target - playerG.transform.position;
          rotationZ = Mathf.Atan2(difference.y,difference.x)* Mathf.Rad2Deg;
         playerG.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ );
        playerG.transform.position = Player.transform.position;
            if(Input.GetKeyDown("r"))
        {
        StartCoroutine(Reload());
        }
        if(clickAmount > 0){
        if(Input.GetMouseButton(0) && !isFiring){
             isFiring = true;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
           // StartCoroutine(fire(direction, rotationZ));
           StartFiring(direction,rotationZ);
           }
        }else{
            clickAmount = -1;
            AmmoText.text =clickAmount+1 +"/∞";
        }

    
    
        FlipG(rotationZ);
        }
        void StartFiring(Vector2 direction, float rotationZ){
            StartCoroutine(fire(direction,  rotationZ));
        }
       
    IEnumerator fire(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = GunL.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * speed;
        clickAmount -= 1;
        AmmoText.text = clickAmount +"/∞";
        yield return new WaitForSeconds(0.2f);
        isFiring = false;
    }

    void FlipG(float rotationZ)
    {
        if(Mathf.Abs(rotationZ) >= 90.01f){
           playerG.transform.localScale = new Vector3(1,-1,1);
            Player.transform.localScale = new Vector3(-1,1,1);
        }

         if(Mathf.Abs(rotationZ) <= 89.99f){
           playerG.transform.localScale = new Vector3(1,1,1);
            Player.transform.localScale = new Vector3(1,1,1);
        }
       
    }

    if(clickAmount == -1 && Input.GetMouseButtonDown(0)){
        StartCoroutine(Reload());
    }

    }

    IEnumerator Reload()
    {
   
           
      yield return new WaitForSeconds(1.5f );
      clickAmount =10;
      AmmoText.text = clickAmount +"/∞";
        hasAmmo =true;
        
                
    }

  
}


