using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDead : MonoBehaviour
{
    public Slider boarHealth;
    public Image health;
    public int maxHealth;
    // Start is called before the first frame update

    private void Start()
    {
        boarHealth.maxValue = maxHealth;
        boarHealth.value = maxHealth;
    }

    private void Update()
    {
        updataHearColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coinBullet"))
        {
            boarHealth.value -= 1;
            if (boarHealth.value < 1)
            {
                Destroy(gameObject);
            }

        }
    }

    public void updataHearColor()
    {
        if (boarHealth.value == 2)
        {
            health.color = Color.yellow;
        }
        else if (boarHealth.value == 1 && boarHealth.value == maxHealth)
        {
            health.color = Color.green;
        }
        else if (boarHealth.value == 3)
        {
            health.color = Color.green;
        }
        else
        {
            health.color = Color.red;
        }
    }
}
