using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamCoin : MonoBehaviour
{
    bool enableSpawn;

    public Transform player;

    public GameObject coin;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        enableSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSpawn)
        {
            enableSpawn = false;
            int soLuong = Random.Range(5, 16);
            float coinPosX = player.position.x + Random.Range(15f, 30f);
            float coinPosY = 5 * Mathf.Abs(Mathf.Sin(coinPosX / 3));

            for (int i = 0; i < soLuong; i++)
            {
                GameObject newCoin = Instantiate(coin, new Vector3(coinPosX, coinPosY + 2, 0), Quaternion.identity);
                coinPosX++;
                coinPosY = 5 * Mathf.Abs(Mathf.Sin(coinPosX / 3));

                // Attach a CoinController script to each coin to manage lifespan
                newCoin.AddComponent<CoinController>();
            }
            SpawnHeart();
            StartCoroutine(DelayForSpawn());
        }
    }

    IEnumerator DelayForSpawn()
    {
        float timer = Random.Range(5f, 8f);
        yield return new WaitForSeconds(timer);
        enableSpawn = true;
    }

    void SpawnHeart()
    {
        // Random x position within a range
        float heartPosX = player.position.x + Random.Range(15f, 30f);
        // Fixed y position
        float heartPosY = (float)(player.position.y + 1.3); // Or any fixed value you prefer
        // Spawn the heart prefab at the calculated position
        Instantiate(heart, new Vector3(heartPosX, heartPosY, 0), Quaternion.identity);
    }
}

public class CoinController : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // so sánh vị trí của coin và player
        if (transform.position.x < player.position.x - 7f)
        {
            Destroy(gameObject);
        }
    }
}
