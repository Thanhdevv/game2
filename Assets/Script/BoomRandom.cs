using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomRandom : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public GameObject boom;
   


    void Start()
    {
        //bom rơi ngẫu nhiên sau 10s
       InvokeRepeating("DropBoom", 10f, 10f);
    }


    /* void Update()
     {
         if (Input.GetKeyDown(KeyCode.B))
         {
             for (int i = 0; i < 3; i++)
             {
                 int rd = Random.Range(1, 4);

                 switch (rd)
                 {
                     case 1: Instantiate(boom, pos1.position, Quaternion.identity); break;
                     case 2: Instantiate(boom, pos2.position, Quaternion.identity); break;
                     case 3: Instantiate(boom, pos3.position, Quaternion.identity); break;
                 }

             }

         }
     }
 */

    void DropBoom()
    {
            int rd = Random.Range(1, 4);

            switch (rd)
            {
                case 1: Instantiate(boom, pos1.position, Quaternion.identity); break;
                case 2: Instantiate(boom, pos2.position, Quaternion.identity); break;
                case 3: Instantiate(boom, pos3.position, Quaternion.identity); break;
            }
    }

    /*void DropBoom()
    {
            Instantiate(boom, pos1.position, Quaternion.identity);                            
        }*/
    
}
