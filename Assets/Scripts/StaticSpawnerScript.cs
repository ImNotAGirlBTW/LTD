using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpawnerScript : MonoBehaviour
{
      public GameObject bEn;
    public GameObject fEn;
    public int xRange;
    public int yRange;
    private float spChance = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
               for(int i =0; i < Random.Range(10,20);i++)
        {
            if(Random.Range(0f,1f) <=  spChance){
         Instantiate(fEn, transform.position +  new Vector3(Random.Range(xRange,yRange) + 2, Random.Range(-8f,2f) +2,0.0f), Quaternion.identity);
            }else{
    Instantiate(bEn, transform.position +  new Vector3(Random.Range(xRange,yRange) + 2, Random.Range(-8f,2f) +2,0.0f), Quaternion.identity);
            }
    }
    }
    

    // Update is called once per frame
    void Update()
    {


}
}