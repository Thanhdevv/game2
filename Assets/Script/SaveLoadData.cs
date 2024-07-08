using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    public float diemCaoNhat;
    public string tenNguoiChoi;
    // Start is called before the first frame update
    void Start()
    {
        loadData();
        if (diemCaoNhat != 0)
        {
            Debug.Log("Điểm cao nhất: " + diemCaoNhat);
        } 
        if(tenNguoiChoi != "")
        {
            Debug.Log("Tên người chơi" + tenNguoiChoi);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetFloat("diemCaoNhat", diemCaoNhat);
            PlayerPrefs.SetString("tenNguoiChoi", tenNguoiChoi);
        }
    }
    public void loadData()
    {
        diemCaoNhat = PlayerPrefs.GetFloat("diemCaoNhat");
        tenNguoiChoi = PlayerPrefs.GetString("tenNguoiChoi");
    }
}
