using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI nameGame;
    void Start()
    {

    }

    // Update is called once per frame
    //    private void OnGUI() {
    //         GUI.Box(new Rect(10,50,300,100),"Main Menu");
    //         if (GUI.Button(nnew Rect(70,70,100,50),"Button 1"))
    //         {
    //             print("hehe");
    //         }
    //     }
    public void startbutton()
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            nameGame.text = "Fantasy forest";
                
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            nameGame.text = "Game vo tri";
        }
    }
        

}