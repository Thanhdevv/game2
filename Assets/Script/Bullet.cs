using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    
    Rigidbody2D rb;
     GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-3, rb.velocity.y);
       /* rb.AddForce(new Vector2(-2, rb.velocity.y));*/
    }
   
}
