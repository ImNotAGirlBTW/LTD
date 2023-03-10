using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=7-8nE9_FwWs
    public float speed = 60f;
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

     
    // Start is called before the first frame update
    void Start()
    {
          Cursor.visible = false;
          hasAmmo = true;
        clickAmount = 0;
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
        StartCoroutine(Reload());
        if(hasAmmo){
        if(Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fire(direction, rotationZ);
           }
        }

          Debug.Log(rotationZ);
    
        FlipG(rotationZ);
        checkAmmo();
       
    void fire(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = GunL.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * speed;
        clickAmount += 1;
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


    void checkAmmo()
    {
        if(clickAmount == 10){
            hasAmmo = false;
            clickAmount =0;

    }
    }

    IEnumerator Reload()
    {
        if(Input.GetKeyDown("r"))
        {
            Debug.Log("reloding");
      yield return new WaitForSeconds(1.5f );
        hasAmmo =true;
                }
    }

  
}
}

