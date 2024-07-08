using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarLeft : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    bool active;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void OnBecameVisible()
    {
        active = true;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            ani.Play("runBoar");
        }

    }
}
