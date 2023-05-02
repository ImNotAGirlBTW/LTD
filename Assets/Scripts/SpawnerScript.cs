using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject BulletBot;
     public GameObject FollowEn;
     public GameObject target;
   // private float Rate = 0.00002f;
    private float RateB = 0.0002f;
    private float RateF = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    public void Update()
    {

        this.transform.position = target.transform.position;

        if(Random.Range(0f,1f) < RateB){
            SpawnBot();
        }
        if(Random.Range(0f,1f) < RateF)
        {
            SpawnFoll();
        }
    }

 

    void SpawnBot()
    {
        Instantiate(BulletBot, target.transform.position, Quaternion.identity);
    }

    void SpawnFoll()
    {
         Instantiate(FollowEn, target.transform.position, Quaternion.identity);
    }
}
