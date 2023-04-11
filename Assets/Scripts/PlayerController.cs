using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 direction;

    private Rigidbody2D rb;
    private Collider2D wallCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallCollider = GameObject.FindWithTag("Wall").GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        // Pohyb hráèe
        rb.velocity = direction * moveSpeed;

        // Detekce kolize s Colliderem na zdi
        if (Physics2D.OverlapBox(rb.position, rb.GetComponent<Collider2D>().bounds.size, 0, LayerMask.GetMask("Walls")))
        {
            rb.velocity = Vector2.zero; // Zastavení pohybu hráèe, aby nemohl projít zdí
        }
    }
}