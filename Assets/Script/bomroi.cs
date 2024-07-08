
using UnityEngine;

public class bomroi : MonoBehaviour
{
    public Transform pos1, pos2, pos3;
    public GameObject bom;
    float timer = 0f;
    float bombInterval = 10f;

    // Update is called once per frame
    void Update()
    {
        // Accumulate time
        timer += Time.deltaTime;

        // Check if it's time to drop a bomb
        if (timer >= bombInterval)
        {
            // Reset the timer
            timer = 0f;

            // Generate a random number between 1 and 3
            int getOne = Random.Range(1, 4);

            // Instantiate bomb at a random position
            switch (getOne)
            {
                case 1:
                    Instantiate(bom, pos1.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bom, pos2.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bom, pos3.position, Quaternion.identity);
                    break;
                default:
                    Debug.LogError("Invalid number generated for bomb position.");
                    break;
            }
        }
    }
}


