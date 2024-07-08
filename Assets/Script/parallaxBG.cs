using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Material bg1;
    public Material bg2;
    public Material bg3;
    public Material bg4;
    public Material bg5;

    float offset1;
    float offset2;
    float offset3;
    float offset4;
    float offset5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset5 -= Time.deltaTime * .2f;
        offset4 -= Time.deltaTime * .1f;
        offset3 -= Time.deltaTime * .08f;
        offset2 -= Time.deltaTime * .06f;

        bg2.mainTextureOffset = new Vector2(offset2, 0);
        bg3.mainTextureOffset = new Vector2(offset3, 0);
        bg4.mainTextureOffset = new Vector2(offset4, 0);
        bg5.mainTextureOffset = new Vector2(offset5, 0);

    }
}
