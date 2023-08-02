using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (knockback.gettingKnockBack) { return; }

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime));

        if (moveDir.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX= false;
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }
}
