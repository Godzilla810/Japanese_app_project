using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject option;
    public Transform[] optionSubAreas;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        //獲取五十音圖片
        sprites = new Sprite[50];
        for (int i = 1; i <= 50; i++)
        {
            string spriteName = i.ToString();
            // 使用 Resources.Load 来加载图像
            Sprite sprite = Resources.Load<Sprite>("50/" + spriteName);
            Debug.Log(spriteName);
            if (sprite != null)
            {
                // 将加载的图像存储到数组中
                sprites[i-1] = sprite;
            }
        }
        //產生選項及圖片
        for (int i = 0; i < optionSubAreas.Length; i++)
        {
            int randomInt = Random.Range(1, 40);
            GameObject gameObject = Instantiate(option, optionSubAreas[i]);
            gameObject.GetComponent<Image>().sprite = sprites[randomInt];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
