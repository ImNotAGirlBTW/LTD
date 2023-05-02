using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyCombat : MonoBehaviour
{
    private float TimeBtwAttack;
    public float StartTimeBtwAttack;
    public Animator animator;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsBullet;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
   if (TimeBtwAttack <= 0)
{
    //mužeš melee
    if (Input.GetKey(KeyCode.Space))
    {
          animator.SetBool("attack",true);
        //Debug.Log("ParryThisYouFCasual");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
    foreach (Collider2D Enemy in enemiesToDamage)
        {
           // Debug.Log("hit");
           Enemy.GetComponent<EnemyHealthScript>().currentHealth -= damage;

        }

             Collider2D[] bulletsToDestroy = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsBullet);
    foreach (Collider2D bullet in bulletsToDestroy)
        {
            //Debug.Log("hit");
            bullet.GetComponent<BulletBotScript>().destroy();

        }


}


TimeBtwAttack = StartTimeBtwAttack;
   }else{
    TimeBtwAttack -= Time.deltaTime;
   }

   

    }
        void OnDrawGizmosSelected(){
             Gizmos.color = Color.red;
             Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }


public void EndMelee()
{
        animator.SetBool("attack",false);
}

    

}
