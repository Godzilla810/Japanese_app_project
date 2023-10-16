using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject image;
    public TextMeshProUGUI pinyin;
    public AudioSource soundBtn;
    public GameObject[] options;
    public void SetUp(LevelData levelData, List<Sprite> optionImg)
    {
        //LevelData
        image.GetComponent<Image>().sprite = levelData.image;
        pinyin.text = levelData.pinyin;
        soundBtn.clip = levelData.audio;
        //OptionData
        for (int i = 0; i < optionImg.Count; i++)
        {
            options[i].GetComponent<Option>().ChangeParentToOptionArea();
            options[i].GetComponent<Image>().sprite = optionImg[i];
        }
    }
}
