using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarControl : MonoBehaviour
{
    // di chuyển đến A
    // nghỉ 2s
    // Quay đầu đi đến B
    // thấy người chơi: tăng tốc, di chuyển về phía người chơi
    // húc trượt người chơi quay lại
    public Transform boar;
    float speedMove = 5f;
    public Transform posA;
    public Transform posB;
    bool isFaceRight = true;
    public Animator ani;
    public SpriteRenderer SR;
    bool isWaiting = false;
    float waitTime = 2f;
    float timer = 0f;

    private void Start()
    {

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (isWaiting)
        {
            // Nếu đang đợi, tăng thời gian đếm
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                // Nếu đã đủ thời gian đợi, reset các giá trị
                timer = 0f;
                isWaiting = false;
                // Sau khi đã đợi xong, đổi hướng di chuyển
                isFaceRight = !isFaceRight;
                // Chuyển trạng thái animation thành "ideBoar"
                if (ani != null)
                {
                    ani.Play("ideBoar");
                }
            }
        }
        else
        {
            // Kiểm tra xem posA và posB có null hay không trước khi truy cập vào position của chúng
            if (posA != null && posB != null && boar != null)
            {
                if (isFaceRight)
                {
                    // di chuyển qua b (right)
                    if (Vector2.Distance(boar.position, posB.position) > 0.1f)
                    {
                        boar.position = Vector3.MoveTowards(boar.position, posB.position, speedMove * Time.deltaTime);
                        ani.Play("runBoar");
                        SR.flipX = false;
                    }
                    else
                    {
                        // Khi đến vị trí B, bắt đầu đợi
                        isWaiting = true;
                    }
                }
                else
                {
                    // di chuyển qua A (left)
                    if (Vector2.Distance(boar.position, posA.position) > 0.3f)
                    {
                        boar.position = Vector3.MoveTowards(boar.position, posA.position, speedMove * Time.deltaTime);
                        ani.Play("runBoar");
                        SR.flipX = true;
                    }
                    else
                    {
                        // Khi đến vị trí A, bắt đầu đợi
                        isWaiting = true;
                    }
                }
            }
        }
    }
}
//boarleft



