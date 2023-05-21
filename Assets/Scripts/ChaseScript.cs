using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{ 
    public Animator animator;
    public float speed;
    private float lineOfSite = 10f;
    private Transform player;
        private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
          player = GameObject.FindGameObjectWithTag("player").transform;
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            animator.SetBool("InRange",true);
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
}else {
    animator.SetBool("InRange",false);
}
    }
 private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

}