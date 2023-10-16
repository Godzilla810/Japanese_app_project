using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateGenerator : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] templates;
    
    // Start is called before the first frame update
    void Start()
    {
        StartChapter(GlobalData.chapter, GlobalData.mode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartChapter(int chapter, bool mode){
        //產生模板
        Instantiate(templates[chapter-1], panel.transform);
        //決定是否計時
        if (!mode)
        {
            GameObject.Find("Slider").SetActive(false);
        }
    }
}
