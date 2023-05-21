using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    //[SerializeField]
    public float maxHealth = 1000;
    public Animator animator;
    public Slider slider;
    private Rigidbody2D rb;
    //public GameObject targer;
    public float currentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

       currentHealth = maxHealth;
        animator.SetBool("hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;//this.gameObject.GetComponent<EnemyHealthScript>().currentHealth;
       
           if(slider.value == 0){
           SceneManager.LoadScene(5);
           
        }
        rb.velocity = Vector2.zero;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            animator.SetBool("hit", true);
            StartCoroutine(Blink());

            if(Random.Range(0f,1f) < EnemyHealthScript.critChance){
                 currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack *1.5f ;
            }
            else{
            currentHealth -= col.gameObject.GetComponent<BulletScript>().Attack;
           
            Destroy(col.gameObject);
            }
           
        }

    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.2f);
       animator.SetBool("hit", false);
    }

    
}
