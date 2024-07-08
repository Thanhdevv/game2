using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    // liên tục bắn đạn sau mỗi 3s, mỗi lần bắn đạn phát ra âm thanh
    // viên đạn sinh ra từ mồm nó
    //viên đạn ra ngoài màn hình thì xóa
    // Nhân vật chạy qua nó rồi thì xóa 
    // Random ra vị trí ngẫu nhiên

    public GameObject bullet;
    public Transform bulletPos;
    float shootTimer = 0f;
    float shootInterval = 0.2f;
    Animator animator;
    AudioSource audioSource;
    public LayerMask layer;
    public bool atk;
    public
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         if (atk)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                PlaneShoot();
                animator.SetTrigger("atk");
                shootTimer = 0f; 
            }
        }

    }
    private void FixedUpdate()
    {
        RaycastDetectPlayer();
    }

    public void PlaneShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        audioSource.Play();
    }   
    public void RaycastDetectPlayer()
    {

        //Chiếu Raycast dài 10f về trái (bắt đầu từ plant)
        //nếu phát hiện player thì nhả đạn
        //nếu không chạm player thì tia màu xanh ngược lại tia màu đỏ
        RaycastHit2D hit = Physics2D.Raycast(bulletPos.position, Vector2.left, 6f, layer);

        if (hit)
        {
            //vẽ 1 tia từ vị trí bulletpos về trái 12f màu đỏ
            Debug.DrawRay(bulletPos.position, Vector2.left * hit.distance, Color.red);
            atk = true;
        }
        else
        {
            //vẽ 1 tia từ vị trí bulletpos về trái 12f màu xanh lá 
            Debug.DrawRay(bulletPos.position, Vector2.left * 12f, Color.green);
            atk = false;
           
        }
    }
    
}
