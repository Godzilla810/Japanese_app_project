using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] templates;
    public Transform panel;
    // Start is called before the first frame update
    void Start()
    {
        //產生模板
        Instantiate(templates[GlobalData.level-1], panel);
        //決定是否計時
        if (!GlobalData.mode)
        {
            GameObject.Find("Slider").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
