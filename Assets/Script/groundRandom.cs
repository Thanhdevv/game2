using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UnityEngine;

public class goundrandom : MonoBehaviour
{
    public List<GameObject> ground;
    public List<GameObject> groundOld;
    public Transform Player;
    Vector2 endPos;
    Vector2 nextPos;
    float rd;
    private int id;
    int groundLength;
    public GameObject plant;
    public GameObject boar;
    public GameObject boarleft;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector2(30f, 0f);  // Vị trí cuối của ô 
        for (int i = 0; i < 5; i++)
        {
            rd = Random.Range(2f, 5f); // random khoảng cách giữa các miếng đất miếng đầu và miếng tiếp theo
            nextPos = new Vector2(endPos.x + rd, 0f); // vị trí đặt miếng đất tiếp theo = vị trí cuối + random
            id = Random.Range(0, ground.Count); // random miếng đất sẽ sinh ra
            GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);// sinh ra với miếng đất random được, tại ví trí nextpos, không quay, là con của đối tượng hiện tại grid
            groundOld.Add(newGround);
            // kiểm tra miếng đất tiếp theo có độ dài bao nhiêu
            switch (id)
            {
                case 0: groundLength = 19; break;
                case 1: groundLength = 25; break;
                case 2: groundLength = 30; break;
                case 3: groundLength = 18; break;
                case 4: groundLength = 20; break;
            }
            endPos = new Vector2(nextPos.x + groundLength, 0f);
            if (id == 19 || id == 18)
            {
                SpawnBoarLeft();
            }
            else
            {
                int getEnety = Random.Range(0, 2);
                if (getEnety != 0)
                {
                    SpawnPlant();
                }
                else
                {
                    SpawnBoarAuto();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, endPos) < 60f)
        {
            for (int i = 0; i < 5; i++)
            {
                rd = Random.Range(2f, 5f); // random khoảng cách giữa các miếng đất miếng đầu và miếng tiếp theo
                nextPos = new Vector2(endPos.x + rd, 0f); // vị trí đặt miếng đất tiếp theo = vị trí cuối + random
                id = Random.Range(0, ground.Count); // random miếng đất sẽ sinh ra
                GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);// sinh ra với miếng đất random được, tại ví trí nextpos, không quay, là con của đối tượng hiện tại grid
                groundOld.Add(newGround);
                // kiểm tra miếng đất tiếp theo có độ dài bao nhiêu
                switch (id)
                {
                    case 0: groundLength = 19; break;
                    case 1: groundLength = 25; break;
                    case 2: groundLength = 30; break;
                    case 3: groundLength = 18; break;
                    case 4: groundLength = 20; break;
                }
                endPos = new Vector2(nextPos.x + groundLength, 0f);
                //
                if(id == 19 || id == 18)
                {
                    SpawnPlant();
                }
                else
                {
                    int getEnety = Random.Range(0, 2);
                    if(getEnety != 0)
                    {
                        SpawnBoarLeft();
                    }
                    else
                    {
                        SpawnBoarAuto();
                    }
                }
            }
        }
        GameObject getOneGround = groundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(Player.position, getOneGround.transform.position) > 40)
        {
            groundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SpawnPlant()
    {
        float posX = Random.Range(nextPos.x + 4f, endPos.x - 3f);
        Vector3 pos = new Vector3(posX, (float)-0.33, 0);
        Instantiate(plant, pos, Quaternion.identity);
    }

    public void SpawnBoarAuto()
    {
        float posX = Random.Range(nextPos.x + 8f, endPos.x - 8f);
        Vector3 pos = new Vector3(posX, (float)-0.33, 0);
        Instantiate(boar, pos, Quaternion.identity);
    }
    public void SpawnBoarLeft()
    {
        float posX = Random.Range(endPos.x - 7f, endPos.x - 2f);
        Vector3 pos = new Vector3(posX, (float)-0.33, 0);
        Instantiate(boarleft, pos, Quaternion.identity);
    }

  
}