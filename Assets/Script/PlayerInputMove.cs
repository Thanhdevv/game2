using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMove : MonoBehaviour
{
    public float directionMove;
    public float test;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        directionMove = Input.GetAxis("Horizontal");
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        if (directionMove > 0)
        {
            test = Mathf.Lerp(directionMove, 1, Time.deltaTime);
        }

        if (directionMove < 0)
        {
            test = Mathf.Lerp(directionMove, -1f, Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionMove * 5f, rb.velocity.y);
    }
}
