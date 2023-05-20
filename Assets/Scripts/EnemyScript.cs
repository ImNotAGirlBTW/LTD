using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    //[SerializeField]
    //public int maxHealth = 100;
    public Animator animator;
    public Slider slider;
    //public GameObject targer;
    //public int currentHealth;*/

    // Start is called before the first frame update
    void Start()
    {
       // currentHealth = 100;
        animator.SetBool("hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = this.gameObject.GetComponent<EnemyHealthScript>().currentHealth;



    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
           // currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
        
            animator.SetBool("hit", true);
            //Destroy(col.gameObject);
            StartCoroutine(Blink());
           
            //Destroy(gameObject);
        }

        /*if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.2f);
       animator.SetBool("hit", false);
    }

    
}
