using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject BulletBot;
     public GameObject FollowEn;
     public GameObject target;
   // private float Rate = 0.00002f;
    private float RateB = 0.002f;
    private float RateF = 0.005f;
    private float RateAb = 0.09f;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    public void Update()
    {   
     if(!MainMenuScript.IsPaused){
        StartCoroutine(abilitySP());
     }
    }

 

    void SpawnBot()
    {
              for(int i =0; i < 2;i++)
        {
        Instantiate(BulletBot, target.transform.position +  new Vector3(Random.Range(-2f,2f)+2, Random.Range(-2f,2f)+2,0.0f), Quaternion.identity);
        }
    }

    void SpawnFoll()
    {
        for(int i =0; i < 2;i++)
        {
         Instantiate(FollowEn, target.transform.position +  new Vector3(Random.Range(-2f,2f) + 2, Random.Range(-2f,2f) +2,0.0f), Quaternion.identity);
    }
    }


    IEnumerator abilitySP()
    {
   if(Random.Range(0f,1f) < RateAb){
            
        if(Random.Range(0f,1f) < RateB){
            SpawnBot();
        }
        if(Random.Range(0f,1f) < RateF)
        {
            SpawnFoll();
        }
        }
        yield return new WaitForSeconds(4f);
}
    }
    
