using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class playerControler : MonoBehaviour
{
    public GameManager gameManager;
    public Slider playerHealth;
    public Image health;
   /* public GameObject boar;*/
    Rigidbody2D rb;
    public float speed;
    public float jump;
    public float jump2;
    public float timer;
    public GameObject coinBullet;
    public Transform gunPos;
    public List<AudioClip> audioClips;
    AudioSource audioSource;
    Animator ani;
    public bool isGround;
    private int jumpCount = 0;
    private bool isRaycastRed = false;
    // raycast
    Color rayColor = Color.green;

    
    void Start()
    {
        Time.timeScale = 1;
        playerHealth.maxValue = 5;
        playerHealth.value = 5;
        speed = 5f;
        jump = 9f;
        jump2 = 5f;
        rb = GetComponent<Rigidbody2D>();
        timer = 5f;
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        
    }
    // vat li
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
           
        }
            
        
    }

 
    void Update()
    {

        killBoar();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if(gameManager.getScore() > 0)
            {
                Instantiate(coinBullet, gunPos.position, Quaternion.identity);
                gameManager.Truscore();
            }
            
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            speed++;
            timer = 5;
        }

        ani.SetBool("isJumping", isGround);
        ani.SetFloat("yVelocity", rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround || jumpCount < 2)
            {
                if(jumpCount == 1)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump2);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump);
                }
              
                audioSource.PlayOneShot(audioClips[0]);
                isGround = false;
                jumpCount++;
            }

        }

        RayCastPlayer();


        if (playerHealth.value <= 3)
        {
            health.color = Color.yellow;
        }
        if (playerHealth.value <= 2)
        {
            health.color = Color.red;
        }
        if (playerHealth.value >= 4)
        {
            health.color = Color.green;
        }
        if(playerHealth.value == 0)
        {
            Time.timeScale = 0;
            gameManager.PlayerDeath();
            gameManager.ScoreBoar.SetActive(false);
            gameManager.ScoreDead.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hoimau"))
        {
            playerHealth.value += 1;
            Destroy(collision.gameObject);
        }

       /* if (collision.CompareTag("boom"))
        {
            audioSource.PlayOneShot(audioClips[1]);
            Time.timeScale = 0;
            gameManager.PlayerDeath();
            gameManager.ScoreBoar.SetActive(false);
            gameManager.ScoreDead.SetActive(true);
        }*/

        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore();
            gameManager.SetScoreText();
            gameManager.SaveGame();
            audioSource.PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("deadzone"))
        {
            audioSource.PlayOneShot(audioClips[1]);
            Time.timeScale = 0;
            gameManager.PlayerDeath();
            gameManager.ScoreBoar.SetActive(false);
            gameManager.ScoreDead.SetActive(true);
        }
        if (collision.CompareTag("boar"))
        {
            if (playerHealth.value > 1 || playerHealth.value == 5)
            {
                playerHealth.value -= 1;
            }
            else
            {
                playerHealth.value = 0; 
                Time.timeScale = 0;
                gameManager.PlayerDeath();
                gameManager.ScoreBoar.SetActive(false);
                gameManager.ScoreDead.SetActive(true);
            }
        }

        if (collision.CompareTag("bullet"))
        {
            if (playerHealth.value > 1 || playerHealth.value == 5)
            {
                playerHealth.value -= 1;
            }
            else
            {
                playerHealth.value = 0;
                Time.timeScale = 0;
                gameManager.PlayerDeath();
                gameManager.ScoreBoar.SetActive(false);
                gameManager.ScoreDead.SetActive(true);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("isJumping", isGround);
            jumpCount = 0;
        }

    }
   

    

    public void killBoar()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject[] getBoar = GameObject.FindGameObjectsWithTag("boar");
            if(getBoar.Length > 0)
            {
                foreach (GameObject item in getBoar)
                {
                    Destroy(item);
                }
            }
        }
    }

    public void RayCastPlayer()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // Lấy vị trí xuất phát của raycast ở trung tâm của Collider của người chơi
            Vector2 raycastOrigin = GetComponent<Collider2D>().bounds.center;
            // Cập nhật raycast
            RaycastHit2D[] hits = Physics2D.RaycastAll(raycastOrigin, Vector2.right, 5f);

            // Thiết lập màu cho đường raycast
            Debug.DrawRay(raycastOrigin, Vector2.right * 5f, rayColor);

            bool hitBoar = false;

            // Kiểm tra tất cả các raycast hit
            foreach (RaycastHit2D hit in hits)
            {
                // Kiểm tra nếu raycast chạm vào một đối tượng
                if (hit.collider != null)
                {
                    // Kiểm tra nếu đối tượng mà raycast chạm vào là quái
                    if (hit.collider.CompareTag("boar"))
                    {
                        hitBoar = true;
                        // Đổi màu của đường raycast sang màu đỏ
                        rayColor = Color.red;

                        // Xử lý việc giết quái
                        Destroy(hit.collider.gameObject);
                        Debug.Log("Raycast hit boar!");

                        // Gọi coroutine để đổi màu raycast trở lại màu xanh sau 1 giây
                        StartCoroutine(ResetRaycastColor());
                    }
                }
            }
        }
        
    }


    IEnumerator ResetRaycastColor()
    {
        yield return new WaitForSeconds(1f); // Chờ 1 giây

        // Sau khi chờ xong, đặt màu raycast về màu xanh lá cây nếu không còn phát hiện quái nữa
        if (!isRaycastRed)
        {
            rayColor = Color.green;
        }

        // Đặt lại cờ isRaycastRed
        isRaycastRed = false;
    }


}